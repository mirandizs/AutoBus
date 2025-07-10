import { Component, effect, inject } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { ServicoAutenticacao } from '../../../Services/Autenticacao.service';
import { Definicoes } from '../../../Definicoes';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Validadores } from '../../../Services/Validadores';
import { HttpService } from '../../../Services/Http.service';
import { Reactive } from '@angular/core/primitives/signals';
import { CommonModule } from '@angular/common';
import { Carregamento } from '../../../Componentes/Carregamento/carregamento';

@Component({
  selector: 'janela-aplicacao',
  imports: [RouterModule, FormsModule, ReactiveFormsModule, CommonModule],
  templateUrl: './aplicacao.html',
  styleUrl: '../definicoes.less'
})

export class JanelaAplicacao {

}



