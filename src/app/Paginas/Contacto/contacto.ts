import { Component } from '@angular/core';
import { Footer } from '../../Componentes/Footer/footer';
import { Topbar } from '../../Componentes/Topbar/topbar';
import { ButaoVoltar } from "../../Componentes/ButaoVoltar/butao-voltar";

@Component({
  selector: 'pagina-contacto',
  imports: [Footer, Topbar, ButaoVoltar],
  templateUrl: './contacto.html',
  styleUrl: './contacto.css'
})
export class PaginaContacto {
  ModalSucessoVisivel: boolean = false;
}
