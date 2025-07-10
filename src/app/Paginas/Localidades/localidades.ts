import { Component, AfterViewInit, ElementRef } from '@angular/core';
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
export class PaginaLocalidades implements AfterViewInit {
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
