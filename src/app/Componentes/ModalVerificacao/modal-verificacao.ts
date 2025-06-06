import { Component, Input, Output, EventEmitter, inject} from '@angular/core';
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
  @Output() close = new EventEmitter<void>();

  router = inject(Router);
  ServicoAutenticacao = inject(ServicoAutenticacao);
  ServicoHttp = inject(HttpService);
  
  Caminho = this.router.url

  onFechar() {
    this.close.emit();
  }


  async ReenviarCodigo() {
    // Aqui você pode implementar a lógica para reenviar o código de verificação
    console.log('Reenviar código de verificação');
  }

  // Formulário de verificação
  FormVerificacao: FormGroup = new FormGroup({
    codigo: new FormControl('', [Validators.required, Validators.minLength(6), Validators.maxLength(6)]),
  });

  // Método para submeter o formulário de verificação
  async SubmeterVerificacao() {
    if (this.FormVerificacao.valid) {
      const codigo = this.FormVerificacao.value.codigo;
      console.log('Código de verificação:', codigo);
      this.onFechar();
    } else {
      console.log('Formulário inválido');
    }
  }

  //funcao para permitir apenas a insercao de numeros
  permitirApenasNumeros(event: KeyboardEvent): void {
    const tecla = event.key;
    if (!/^\d$/.test(tecla)) {
      event.preventDefault();
    }
  }

  async VerificarCodigo(){
      /*this.FormCriar.disable()*/
  
      const Resultado = await this.ServicoHttp.Request(Definicoes.API_URL+'verificar-codigo', 'POST', 'O codigo de verificacao é invalido', 
        this.FormVerificacao.value) // O body equivale ao valor do form criar. Este .value e um array, com o nome de todos os campos e os seus valores
  
      if (Resultado){
      await this.router.navigate(['/definicoes/privacidade'])
      window.location.reload()
      }
      this.FormVerificacao.enable()
    }

    
}
