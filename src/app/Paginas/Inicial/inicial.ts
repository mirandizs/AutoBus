import { Component, AfterViewInit, ElementRef } from '@angular/core';
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
  styleUrl: './inicial.less'
})
export class PaginaInicial implements AfterViewInit{
  constructor(private el: ElementRef) {}

  ngAfterViewInit(): void {
    const elementos = this.el.nativeElement.querySelectorAll('.fade-in');

    const observer = new IntersectionObserver((entradas, obs) => {
      entradas.forEach(entrada => {
        if (entrada.isIntersecting) {
          entrada.target.classList.add('visible');
          obs.unobserve(entrada.target);
        }
      });
    });

    elementos.forEach((el: Element) => observer.observe(el));
  }
}
