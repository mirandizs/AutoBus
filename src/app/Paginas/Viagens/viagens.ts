import { Component, inject } from '@angular/core';
import { Footer } from "../../Componentes/Footer/footer";
import { Topbar } from '../../Componentes/Topbar/topbar';
import { ActivatedRoute, Router } from '@angular/router';
import { FormPesquisaViagens } from "../../Componentes/FormPesquisaViagens/pesquisa-viagens";
import { ButaoVoltar } from "../../Componentes/ButaoVoltar/butao-voltar";
import { HttpService } from '../../Services/Http.service';
import { Definicoes } from '../../Definicoes';
import { CurrencyPipe, DatePipe } from '@angular/common';
import { Carregamento } from "../../Componentes/Carregamento/carregamento";
import { ServicoAutenticacao } from '../../Services/Autenticacao.service';
import { ServicoMensagens } from '../../Componentes/ServicoMensagens/Mensagens.service';

@Component({
  selector: 'pagina-viagens',
  imports: [Topbar, FormPesquisaViagens, ButaoVoltar, CurrencyPipe, Carregamento, DatePipe],
  templateUrl: './viagens.html',
  styleUrl: './viagens.less'
})
export class PaginaViagens {
  route = inject(ActivatedRoute) //informacoes da pagina atual
  ServicoHttp = inject(HttpService)
  ServicoAutenticacao = inject(ServicoAutenticacao)
  ServicoMensagens = inject(ServicoMensagens)

  ModalAdicionarBilhete: boolean = false;
  ModalVerDetalhes: boolean = false;
  ViagemSelecionada: any = null;

  abrirDetalhes(viagem: any) {
    // Corrige a inversão para viagens de volta
    if (viagem.tipo === "Volta") {
      const viagemCorrigida = { ...viagem };
      [viagemCorrigida.local_partida, viagemCorrigida.local_chegada] = [viagem.local_chegada, viagem.local_partida];
      this.ViagemSelecionada = viagemCorrigida;
    } else {
      this.ViagemSelecionada = viagem;
    }

    this.ModalVerDetalhes = true;
  }

  IdaSelecionada = true // true significa que volta esta selecionado
  ViagensIda: any[] = []
  ViagensVolta?: any[]

  async ngOnInit() { //funcao q é executada quando a pagina inicia 
    const queryParams = this.route.snapshot.queryParams // informacoes no link da pagina

    const URL_Pedido = new URL(Definicoes.API_URL + "viagens")
    URL_Pedido.searchParams.append("local_partida", queryParams["local_partida"]) // Append adiciona informacoes ao URL do endpoint que vai ser chamado
    URL_Pedido.searchParams.append("local_chegada", queryParams["local_chegada"])
    URL_Pedido.searchParams.append("hora_ida", queryParams["hora_ida"])
    URL_Pedido.searchParams.append("hora_volta", queryParams["hora_volta"])
    URL_Pedido.searchParams.append("tipo_viagem", queryParams["tipo_viagem"])

    const Resultado = await this.ServicoHttp.Request(URL_Pedido, "GET")
    this.ViagensIda = Resultado.ViagensIda
    this.ViagensVolta = Resultado.ViagensVolta

    for (const viagem of [...this.ViagensIda, ...this.ViagensVolta || []]) {
      viagem.data = viagem.tipo == "Ida" && queryParams["data_ida"]
        || viagem.tipo == "Volta" && queryParams["data_volta"]
        || new Date().toISOString().split('T')[0]
    }
  }



  async adicionarCarrinho(viagem: any) {
    const utilizador = this.ServicoAutenticacao.Utilizador();

    if (!utilizador) {
      this.ServicoMensagens.erro("É necessário iniciar sessão para adicionar ao carrinho.");
      return;
    }

    const URL_Pedido = new URL(Definicoes.API_URL + "carrinho")

    try {
      const Resposta = await this.ServicoHttp.Request(URL_Pedido, "POST", "Erro ao adicionar ao carrinho", {
        "id_ponto_partida": viagem.id_ponto_partida,
        "id_ponto_chegada": viagem.id_ponto_chegada,
        data: viagem.data,
        "tipo": viagem.tipo,
        distancia_km: viagem.distancia_km,
        duracao_estimada: viagem.duracao_estimada,
        hora_chegada: viagem.hora_chegada,
      });

      if (Resposta?.success || Resposta?.status === 200) {
        this.ModalAdicionarBilhete = true;
      }

      else {
        console.error("Erro na resposta:", Resposta);
      }
    }

    catch (erro) {
      console.error("Erro no pedido:", erro);
    }
  }
}
