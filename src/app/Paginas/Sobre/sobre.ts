import { Component, inject } from '@angular/core';
import { Footer } from '../../Componentes/Footer/footer';
import { Topbar } from '../../Componentes/Topbar/topbar';
import { ButaoVoltar } from "../../Componentes/ButaoVoltar/butao-voltar";

@Component({
  selector: 'sobre',
  imports: [Footer, Topbar, ButaoVoltar],
  templateUrl: './sobre.html',
  styleUrl: './sobre.css'
})


export class PaginaSobre {


}