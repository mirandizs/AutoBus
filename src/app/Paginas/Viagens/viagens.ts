import { Component, inject } from '@angular/core';
import { Footer } from "../../Componentes/Footer/footer";
import { Topbar } from '../../Componentes/Topbar/topbar';
import { ActivatedRoute, Router } from '@angular/router';
import { FormPesquisaViagens } from "../../Componentes/FormPesquisaViagens/pesquisa-viagens";
import { ButaoVoltar } from "../../Componentes/ButaoVoltar/butao-voltar";
import { HttpService } from '../../Services/Http.service';
import { Definicoes } from '../../Definicoes';
import { CurrencyPipe } from '@angular/common';
import { Carregamento } from "../../Componentes/Carregamento/carregamento";

@Component({
  selector: 'pagina-viagens',
  imports: [Topbar, FormPesquisaViagens, ButaoVoltar, CurrencyPipe, Carregamento],
  templateUrl: './viagens.html',
  styleUrl: './viagens.less'
})
export class PaginaViagens {
  route = inject(ActivatedRoute) //informacoes da pagina atual
  ServicoHttp = inject(HttpService)
  
  ModalAdicionarBilhete : boolean = false;

  Viagens : any[] = []

  async ngOnInit() { //funcao q é executada quando a pagina inicia 
    const queryParams = this.route.snapshot.queryParams // informacoes no link da pagina

    const URL_Pedido = new URL(Definicoes.API_URL+"viagens")
    URL_Pedido.searchParams.append("local_partida", queryParams["local_partida"]) // Append adiciona informacoes ao URL do endpoint que vai ser chamado
    URL_Pedido.searchParams.append("local_chegada", queryParams["local_chegada"])
    URL_Pedido.searchParams.append("hora_ida", queryParams["hora_ida"])

    this.Viagens = await this.ServicoHttp.Request(URL_Pedido,"GET")
    console.log(this.Viagens)
  }



  async adicionarCarrinho(viagem: any) {
    const URL_Pedido = new URL(Definicoes.API_URL+"carrinho")

    const queryParams = this.route.snapshot.queryParams;

    try {
      const Resposta = await this.ServicoHttp.Request(URL_Pedido, "POST", "", {
        "id_ponto_partida": viagem.id_ponto_partida,
        "id_ponto_chegada": viagem.id_ponto_chegada,
        tipo_viagem: queryParams["idaVolta"] === "ida-e-volta" ? "ida-e-volta" : "ida",
        // data_ida: queryParams["data_ida"],
        // data_volta: queryParams["data_volta"] === "ida-e-volta" ? queryParams["data_volta"] : null
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
