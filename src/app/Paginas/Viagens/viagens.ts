import { Component } from '@angular/core';
import { Footer } from "../../Componentes/Footer/footer";
import { Topbar } from '../../Componentes/Topbar/topbar';

@Component({
  selector: 'pagina-viagens',
  imports: [Footer, Topbar],
  templateUrl: './viagens.html',
  styleUrl: './viagens.css'
})
export class PaginaViagens {

}
