import { Component, inject } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { ServicoAutenticacao } from '../../Services/Autenticacao.service';
import { Definicoes } from '../../Definicoes';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgTemplateOutlet } from '@angular/common';

@Component({
  selector: 'pesquisa-viagens',
  imports: [RouterModule, FormsModule, ReactiveFormsModule, NgTemplateOutlet],
  templateUrl: './pesquisa-viagens.html',
  styleUrl: './pesquisa-viagens.less'
})

export class FormPesquisaViagens {
  Definicoes = Definicoes
  router = inject(Router)

  PaginaAtiva = this.router.url
  PaginaViagens = this.router.url.includes('viagens')

  FormPesquisa: FormGroup = new FormGroup({
    local_partida: new FormControl('', []),
    local_chegada: new FormControl('', []),
    hora_ida: new FormControl('', []),
    data_ida: new FormControl('', []),
    passageiros: new FormControl('1', []),
    ida: new FormControl('ida', []), // Valor default e ida
  });

  RedirecionarPesquisa() {

    this.router.navigate(['/viagens'], {
      queryParams: this.FormPesquisa.value
    }).then(()=>{
      window.location.reload()
    })
  }

  // Os estilos para definir a largura dos campos de pesquisa são definidos de acordo com a página ativa, para podermos usar este componente em ambas páginas
  ngOnInit() {
    const Pagina = this.router.url
    if (Pagina == '/inicial'){
      document.documentElement.style.setProperty('--width-campos', '30%');
    }else{
      // Tamanho automático para o tamanho dos campos de pesquisa
      document.documentElement.style.setProperty('--width-campos', '');
    }
  }
}
