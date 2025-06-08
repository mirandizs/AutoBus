import { Component, inject } from '@angular/core';
import { Footer } from "../../Componentes/Footer/footer";
import { Topbar } from '../../Componentes/Topbar/topbar';
import { ActivatedRoute, Router } from '@angular/router';
import { FormPesquisaViagens } from "../../Componentes/FormPesquisaViagens/pesquisa-viagens";
import { ButaoVoltar } from "../../Componentes/ButaoVoltar/butao-voltar";
import { HttpService } from '../../Services/Http.service';
import { Definicoes } from '../../Definicoes';
import { CurrencyPipe } from '@angular/common';

@Component({
  selector: 'pagina-viagens',
  imports: [Topbar, FormPesquisaViagens, ButaoVoltar, CurrencyPipe],
  templateUrl: './viagens.html',
  styleUrl: './viagens.css'
})
export class PaginaViagens {
  route = inject(ActivatedRoute) //informacoes da pagina atual
  ServicoHttp = inject(HttpService)
  
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



  adicionarCarrinho(viagem: any) {
    const URL_Pedido = new URL(Definicoes.API_URL+"carrinho")

    const Resposta = this.ServicoHttp.Request(URL_Pedido,"POST", "", {
      "id_ponto_partida": viagem.id_ponto_partida,
      "id_ponto_chegada": viagem.id_ponto_chegada,
    }) 
  }
}
