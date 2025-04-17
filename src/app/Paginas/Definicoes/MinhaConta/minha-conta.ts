import { Component, inject } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ServicoAutenticacao } from '../../../Services/Autenticacao.service';

@Component({
  selector: 'janela-minha-conta',
  imports: [RouterModule],
  templateUrl: './minha-conta.html',
  styleUrl: '../definicoes.css'
})
export class JanelaMinhaConta {
  ServicoAutenticacao = inject(ServicoAutenticacao)
  Utilizador = this.ServicoAutenticacao.Utilizador
}
