import { Component } from '@angular/core';
import { Topbar } from '../../Componentes/Topbar/topbar';
import { Footer } from '../../Componentes/Footer/footer';

@Component({
  selector: 'pagina-carrinho',
  imports: [Topbar, Footer],
  templateUrl: './carrinho.html',
  styleUrl: './carrinho.css'
})
export class PaginaCarrinho {

}
