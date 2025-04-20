import { Component, inject } from '@angular/core';
import { Footer } from '../../Componentes/Footer/footer';
import { Topbar } from '../../Componentes/Topbar/topbar';
import { Definicoes } from '../../Definicoes';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { FormPesquisaViagens } from "../../Componentes/FormPesquisaViagens/pesquisa-viagens";
import { ButaoVoltar } from "../../Componentes/ButaoVoltar/butao-voltar";

@Component({
  selector: 'pagina-inicial',
  imports: [Footer, Topbar, FormsModule, ReactiveFormsModule, FormPesquisaViagens, ButaoVoltar],
  templateUrl: './inicial.html',
  styleUrl: './inicial.css'
})
export class PaginaInicial {
  
}
