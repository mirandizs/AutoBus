import { Component, HostBinding, inject } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { ServicoAutenticacao } from '../../Services/Autenticacao.service';
import { Definicoes } from '../../Definicoes';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
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
  ActiveRoute = inject(ActivatedRoute)

  PaginaAtiva = this.router.url
  PaginaViagens = this.router.url.includes('viagens')
  @HostBinding("class.pagina-viagens") pag_vig = this.PaginaViagens

  Ida = true
  Volta = false

  FormPesquisa: FormGroup = new FormGroup({
    local_partida: new FormControl('', [Validators.required]),
    local_chegada: new FormControl('', [Validators.required]),
    hora_ida: new FormControl('', []),
    hora_volta: new FormControl('', []),
    data_ida: new FormControl('', []),
    data_volta: new FormControl('', []),
    tipo_viagem: new FormControl('Ida', []), // Valor default e ida
  });

  RedirecionarPesquisa() {

    this.router.navigate(['/viagens'], {
      queryParams: this.FormPesquisa.value
    }).then(() => {
      window.location.reload()
    })
  }

  // Os estilos para definir a largura dos campos de pesquisa são definidos de acordo com a página ativa, para podermos usar este componente em ambas páginas
  ngOnInit() {
    const Pagina = this.router.url
    if (Pagina == '/inicial') {
      document.documentElement.style.setProperty('--width-campos', '30%');
    } else {
      // Tamanho automático para o tamanho dos campos de pesquisa
      document.documentElement.style.setProperty('--width-campos', '');
    }

    this.ActiveRoute.queryParams.subscribe(params => {
      this.FormPesquisa.setValue({
        local_partida: params['local_partida'] || '',
        local_chegada: params['local_chegada'] || '',
        hora_ida: params['hora_ida'] || '',
        hora_volta: params['hora_volta'] || '',
        data_ida: params['data_ida'] || '',
        data_volta: params['data_volta'] || '',
        tipo_viagem: params['tipo_viagem'] || 'Ida',
      });
    });
  }
}
