import { Component } from '@angular/core';
import { Footer } from '../../Componentes/Footer/footer';
import { Topbar } from '../../Componentes/Topbar/topbar';
import { Mapa } from '../../Componentes/Mapa/mapa';

@Component({
  selector: 'pagina-localidades',
  imports: [Footer, Topbar, Mapa],
  templateUrl: './localidades.html',
  styleUrl: './localidades.css'
})
export class PaginaLocalidades {

}
