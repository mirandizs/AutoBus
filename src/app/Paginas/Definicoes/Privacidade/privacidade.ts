import { Component, inject } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ServicoAutenticacao } from '../../../Services/Autenticacao.service';

@Component({
  selector: 'janela-privacidade',
  imports: [RouterModule],
  templateUrl: './privacidade.html',
  styleUrl: '../definicoes.css'
})
export class JanelaPrivacidade {
  ServicoAutenticacao = inject(ServicoAutenticacao)
  Utilizador = this.ServicoAutenticacao.Utilizador
  PasswordVisivel = false
}
