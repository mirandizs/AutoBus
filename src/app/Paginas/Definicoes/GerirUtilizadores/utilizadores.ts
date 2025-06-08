import { Component, inject } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { ServicoAutenticacao } from '../../../Services/Autenticacao.service';
import { HttpService } from '../../../Services/Http.service';
import { Definicoes } from '../../../Definicoes';

@Component({
  selector: 'janela-utilizadores',
  imports: [RouterModule],
  templateUrl: './utilizadores.html',
  styleUrl: '../definicoes.less'
})
export class JanelaUtilizadores {
  ServicoAutenticacao = inject(ServicoAutenticacao)
  ServicoHttp = inject(HttpService)
  router = inject(Router)
  Utilizador = this.ServicoAutenticacao.Utilizador

  Utilizadores:any = []

  async ngOnInit() {
    const ResultadoUtilizadores = await this.ServicoHttp.Request(Definicoes.API_URL + 'utilizadores', 'GET', 
      'Erro ao carregar utilizadores')

    if (ResultadoUtilizadores) {
      this.Utilizadores = ResultadoUtilizadores
    }
  }

  MostrarGestao(Nif:number){
    this.router.navigate(['/definicoes/editar-utilizador', Nif]);

  }
}
