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


  @HostListener('window:scroll')
  onWindowScroll() {
    const TamanhoJanela = window.innerHeight;
    const TamanhoTotalPagina = document.documentElement.scrollHeight
    const PixeisParaMostrar = TamanhoTotalPagina - 100 // Tamanho total menos 100 pixeis, 100 pixeis antes da pagina estar no fim

    const PosicaoScroll = TamanhoJanela + (window.scrollY || document.documentElement.scrollTop)
    this.Visible = PosicaoScroll > PixeisParaMostrar; 
    //console.log(PixeisParaMostrar, PosicaoScroll)
  }

  VoltarAoTopo() {
    window.scrollTo({ top: 0, behavior: 'smooth' });
  }
}
