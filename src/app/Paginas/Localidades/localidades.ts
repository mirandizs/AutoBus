import { Component } from '@angular/core';
import { Footer } from '../../Componentes/Footer/footer';
import { Topbar } from '../../Componentes/Topbar/topbar';
import { Mapa } from '../../Componentes/Mapa/mapa';
import { ButaoVoltar } from "../../Componentes/ButaoVoltar/butao-voltar";

@Component({
  selector: 'pagina-localidades',
  imports: [Footer, Topbar, Mapa, ButaoVoltar],
  templateUrl: './localidades.html',
  styleUrl: './localidades.less'
})
export class PaginaLocalidades {

}
