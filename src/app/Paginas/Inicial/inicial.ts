import { Component } from '@angular/core';
import { Footer } from '../../Componentes/Footer/footer';
import { Topbar } from '../../Componentes/Topbar/topbar';

@Component({
  selector: 'pagina-inicial',
  imports: [Footer, Topbar],
  templateUrl: './inicial.html',
  styleUrl: './inicial.css'
})
export class PaginaInicial {

}
