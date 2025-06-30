import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ServicoAutenticacao } from './Services/Autenticacao.service';
import { MessageContainerComponent } from "./Componentes/ServicoMensagens/container-mensagens";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, MessageContainerComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'AutoBus';

  ServicoAutenticacao = inject(ServicoAutenticacao)

  constructor() {
    this.ServicoAutenticacao.Autenticar()
  }
}
