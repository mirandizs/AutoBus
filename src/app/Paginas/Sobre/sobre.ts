import { Component,  AfterViewInit, ElementRef } from '@angular/core';
import { Footer } from '../../Componentes/Footer/footer';
import { Topbar } from '../../Componentes/Topbar/topbar';
import { ButaoVoltar } from "../../Componentes/ButaoVoltar/butao-voltar";

@Component({
  selector: 'sobre',
  imports: [Footer, Topbar, ButaoVoltar],
  templateUrl: './sobre.html',
  styleUrl: './sobre.less'
})


export class PaginaSobre implements AfterViewInit {
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

