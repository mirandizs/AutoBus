import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ServicoAutenticacao } from './Services/Autenticacao.service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
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
