import { Component, inject } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ServicoAutenticacao } from '../../../Services/Autenticacao.service';
import { Carregamento } from '../../../Componentes/Carregamento/carregamento';
import { HttpService } from '../../../Services/Http.service';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Definicoes } from '../../../Definicoes';
import { ModalVerificacao } from "../../../Componentes/ModalVerificacao/modal-verificacao";

@Component({
  selector: 'janela-privacidade',
  imports: [RouterModule, Carregamento, FormsModule, ReactiveFormsModule, ModalVerificacao],
  templateUrl: './privacidade.html',
  styleUrl: '../definicoes.css'
})
export class JanelaPrivacidade {
  ServicoAutenticacao = inject(ServicoAutenticacao)
  ServicoHttp = inject(HttpService)

  Utilizador = this.ServicoAutenticacao.Utilizador
  PasswordVisivel = false
  
  AMandarEmail: boolean = false;
  ModalCodigo = false

  async MandarEmail() {
      this.AMandarEmail = true
      this.FormPrivacidade.disable()
  
      const EmailMandado = await this.ServicoHttp.Request(Definicoes.API_URL + 'email-confirmacao', 'POST', 'Nao foi possivel contactar',
        this.FormPrivacidade.value) // Valores do form
  
      if (EmailMandado) {
        this.FormPrivacidade.reset()
        this.ModalCodigo = true
      }
      this.AMandarEmail = false
      this.FormPrivacidade.enable()
    }


    FormPrivacidade: FormGroup = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),
    })

}
