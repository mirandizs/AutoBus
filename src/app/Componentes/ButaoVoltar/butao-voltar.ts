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
  offset = '25px' // se nao houver footer, o botao fica a 25px do fundo da pagina


  @HostListener('window:scroll')
  onWindowScroll() {
    const TamanhoJanela = window.innerHeight;
    const TamanhoTotalPagina = document.documentElement.scrollHeight

    
    const footer = document.querySelector('footer');
    const OffsetPixeisNecessarios = footer ? 100 : 25;

    if (footer){
      this.offset = '100px' // se houver footer
    }
    const PixeisParaMostrar = TamanhoTotalPagina - OffsetPixeisNecessarios

    const PosicaoScroll = TamanhoJanela + (window.scrollY || document.documentElement.scrollTop)
    this.Visible = PosicaoScroll > PixeisParaMostrar; 
    //console.log(PixeisParaMostrar, PosicaoScroll)
  }

  VoltarAoTopo() {
    window.scrollTo({ top: 0, behavior: 'smooth' });
  }
}
