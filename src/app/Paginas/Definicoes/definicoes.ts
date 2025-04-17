import { Component, inject } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { ServicoAutenticacao } from '../../Services/Autenticacao.service';
import { Footer } from '../../Componentes/Footer/footer';

@Component({
  selector: 'pagina-definicoes',
  imports: [RouterModule, RouterOutlet, Footer],
  templateUrl: './definicoes.html',
  styleUrl: './definicoes.css'
})
export class PaginaDefinicoes {
  JanelaAtiva = "MinhaConta";  

  
  ServicoAutenticacao = inject(ServicoAutenticacao)
  Utilizador = this.ServicoAutenticacao.Utilizador
}
