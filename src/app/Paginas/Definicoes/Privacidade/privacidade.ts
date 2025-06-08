import { Component, effect, inject } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ServicoAutenticacao } from '../../../Services/Autenticacao.service';
import { Carregamento } from '../../../Componentes/Carregamento/carregamento';
import { HttpService } from '../../../Services/Http.service';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Definicoes } from '../../../Definicoes';
import { ModalVerificacao } from "../../../Componentes/ModalVerificacao/modal-verificacao";
import { Validadores } from '../../../Services/Validadores';

@Component({
  selector: 'janela-privacidade',
  imports: [RouterModule, Carregamento, FormsModule, ReactiveFormsModule, ModalVerificacao],
  templateUrl: './privacidade.html',
  styleUrl: '../definicoes.less'
})
export class JanelaPrivacidade {
  ServicoAutenticacao = inject(ServicoAutenticacao)
  ServicoHttp = inject(HttpService)

  Utilizador = this.ServicoAutenticacao.Utilizador
  PasswordVisivel = false
  
  AMandarEmail: boolean = false;
  ModalCodigo = false

  TipoEdicao: 'email' | 'password' | null = null;

  async MandarCodigoVerificacao() {
    this.AMandarEmail = true
    this.FormPrivacidade.disable()

    const EmailMandado = await this.ServicoHttp.Request(Definicoes.API_URL + 'email-confirmacao', 'POST', 
      'Falha ao enviar o email de confirmação')

    if (EmailMandado) {
        this.ModalCodigo = true
    }
    this.AMandarEmail = false
  }

  async EditarCredenciais(Codigo:number) {

    const valores = this.FormPrivacidade.value;

    const carregado = {
      codigo: Codigo,
      email: this.TipoEdicao === 'email' ? valores.email : undefined,
      password: this.TipoEdicao === 'password' ? valores.password : undefined,
    };

    console.log(carregado)

    const DadosAlterados = await this.ServicoHttp.Request(Definicoes.API_URL + 'editar-privacidade', 'PATCH',
       'Não foi possivel editar os dados de privacidade', carregado) // Valores do form

    if (DadosAlterados) {
        this.ModalCodigo = false
    }
    this.FormPrivacidade.enable()
    this.TipoEdicao = null; // resetar depois da edição
  }


  FormPrivacidade: FormGroup = new FormGroup({
    email: new FormControl(this.Utilizador()?.email, [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required, Validadores.SenhaForte]),
  })


  
  constructor(){
    // effect é uma função chamada quando sinais mudam de valor
    effect(() => { 
      // como o utilizador é undefined inicialmente, depois de fazer a autenticação no servidor ele é definido. 
      // é preciso esperar para pôr o valor do email do form como o email do utilizador
      this.FormPrivacidade.get('email')?.setValue(this.Utilizador()?.email)
    })
  }

}
