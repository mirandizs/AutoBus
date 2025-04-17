import { Component, inject } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { ServicoAutenticacao } from '../../Services/Autenticacao.service';

@Component({
  selector: 'footer-componente',
  imports: [RouterModule],
  templateUrl: './footer.html',
  styleUrl: './footer.css'
})

export class Footer {
  router = inject(Router)
  ServicoAutenticacao = inject(ServicoAutenticacao)

  
  Caminho = this.router.url
}
