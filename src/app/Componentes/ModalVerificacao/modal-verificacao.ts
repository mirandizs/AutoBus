import { Component, Input, Output, EventEmitter, inject, HostBinding } from '@angular/core';
import { RouterModule, } from '@angular/router';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ServicoAutenticacao } from '../../Services/Autenticacao.service';
import { Router } from '@angular/router';
import { HttpService } from '../../Services/Http.service';
import { Definicoes } from '../../Definicoes';

@Component({
  selector: 'modal-verificacao',
  imports: [RouterModule, FormsModule, ReactiveFormsModule],
  templateUrl: './modal-verificacao.html',
  styleUrl: './modal-verificacao.css'
})

export class ModalVerificacao {

  @Input() Aberto!:Boolean
  @Output() AbertoChange = new EventEmitter<boolean>();

  MudarAberto(Estado:boolean) {
    this.Aberto = Estado
    this.AbertoChange.emit(Estado)
  }

  @HostBinding('style.display')
  get display(): string {
    return this.Aberto ? '' : 'none';
  }

  @Output() submetido = new EventEmitter<number>();

  router = inject(Router);
  ServicoAutenticacao = inject(ServicoAutenticacao);
  ServicoHttp = inject(HttpService);

  Caminho = this.router.url


  async ReenviarCodigo() {
  }



  // Formulário de verificação
  FormVerificacao: FormGroup = new FormGroup({
    codigo: new FormControl('', [Validators.required, Validators.minLength(6), Validators.maxLength(6)]),
  });

  //funcao para permitir apenas a insercao de numeros
  permitirApenasNumeros(event: KeyboardEvent): void {
    const tecla = event.key;
    if (!/^\d$/.test(tecla)) {
      event.preventDefault();
    }
  }

  SubmeterModal() {
    if (this.FormVerificacao.invalid) return;
    this.submetido.emit(this.FormVerificacao.value.codigo);
  }
}
