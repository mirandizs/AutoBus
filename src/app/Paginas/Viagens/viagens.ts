import { Component, inject } from '@angular/core';
import { Footer } from "../../Componentes/Footer/footer";
import { Topbar } from '../../Componentes/Topbar/topbar';
import { ActivatedRoute, Router } from '@angular/router';
import { FormPesquisaViagens } from "../../Componentes/FormPesquisaViagens/pesquisa-viagens";
import { ButaoVoltar } from "../../Componentes/ButaoVoltar/butao-voltar";

@Component({
  selector: 'pagina-viagens',
  imports: [Topbar, FormPesquisaViagens, ButaoVoltar],
  templateUrl: './viagens.html',
  styleUrl: './viagens.css'
})
export class PaginaViagens {
  route = inject(ActivatedRoute) 

  async ngOnInit() {
    const queryParams = this.route.snapshot.queryParams
  }
}
