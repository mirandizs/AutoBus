import { Component } from '@angular/core';
import { Footer } from '../../Componentes/Footer/footer';
import { Topbar } from '../../Componentes/Topbar/topbar';

@Component({
  selector: 'pagina-contacto',
  imports: [Footer, Topbar],
  templateUrl: './contacto.html',
  styleUrl: './contacto.css'
})
export class PaginaContacto {
  ModalSucessoVisivel: boolean = false;
}
