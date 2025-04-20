import { Component, HostListener, inject } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { ServicoAutenticacao } from '../../Services/Autenticacao.service';

@Component({
  selector: 'butao-voltar',
  imports: [RouterModule],
  templateUrl: './butao-voltar.html',
  styleUrl: './butao-voltar.less',
  
})

export class ButaoVoltar {

  Visible = false
  PixeisParaMostrar = 50

  @HostListener('window:scroll')
  onWindowScroll() {
    const PosicaoScroll = window.scrollY || document.documentElement.scrollTop;
    this.Visible = PosicaoScroll > this.PixeisParaMostrar;
  }

  VoltarAoTopo() {
    window.scrollTo({ top: 0, behavior: 'smooth' });
  }
}
