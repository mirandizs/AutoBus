import { Component, effect, inject } from '@angular/core';
import { RouterModule, Router } from '@angular/router';
import { ServicoAutenticacao } from '../../../Services/Autenticacao.service';
import { Carregamento } from '../../../Componentes/Carregamento/carregamento';
import { HttpService } from '../../../Services/Http.service';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Definicoes } from '../../../Definicoes';
import { ModalVerificacao } from "../../../Componentes/ModalVerificacao/modal-verificacao";
import { Validadores } from '../../../Services/Validadores';
import { CommonModule } from '@angular/common';
import { ServicoMensagens } from '../../../Componentes/ServicoMensagens/Mensagens.service';

@Component({
  selector: 'janela-privacidade',
  imports: [RouterModule, Carregamento, FormsModule, ReactiveFormsModule, ModalVerificacao, CommonModule],
  templateUrl: './privacidade.html',
  styleUrl: '../definicoes.less'
})
export class JanelaPrivacidade {
  ServicoAutenticacao = inject(ServicoAutenticacao)
  ServicoHttp = inject(HttpService)
  router = inject(Router)
  ServicoMensagens = inject(ServicoMensagens)

  Utilizador = this.ServicoAutenticacao.Utilizador
  PasswordVisivel = false
  
  AMandarEmail: boolean = false;
  ModalDesativar: boolean = false
  ModalSucessoVisivel: boolean = false
  ModalCodigo = false

  IsUtilizadorProtegidoEmail= false;

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
      const Utilizador = this.Utilizador()
      if (Utilizador) {
        this.IsUtilizadorProtegidoEmail = Utilizador.email === 'autobus.pap@gmail.com';

      // como o utilizador é undefined inicialmente, depois de fazer a autenticação no servidor ele é definido. 
      // é preciso esperar para pôr o valor do email do form como o email do utilizador
      this.FormPrivacidade.get('email')?.setValue(this.Utilizador()?.email)
      }
      if (this.IsUtilizadorProtegidoEmail) {
          this.FormPrivacidade.disable();
        }
    })
  }



  async Desativar() {
    const URLDesativar = new URL('desativarConta', Definicoes.API_URL)
    const ResultadoDesativar = await this.ServicoHttp.Request(URLDesativar, 'PATCH', 'Erro ao desativar conta.')

    if (ResultadoDesativar) {
    this.ModalSucessoVisivel = true
    this.ModalDesativar = false

    // Esperar 2 segundos antes de continuar
    await new Promise(resolve => setTimeout(resolve, 1000));

    const URLLogout = new URL('logout', Definicoes.API_URL);
    const ResultadoLogout = await this.ServicoHttp.Request(URLLogout, 'POST', 'Erro no logout')

      if (ResultadoLogout) {
        await this.router.navigate(['/inicial']);
        window.location.reload();
      } else {
        // Se o logout falhar, fecha o modal
        this.ModalDesativar = false;
      }

    } else {
      // Se a desativação falhar, fecha o modal também
      this.ServicoMensagens.erro("Erro ao desativar conta.")
      this.ModalDesativar = false;
    }
  }


  FecharModalSucesso() {
    this.ModalDesativar = false;
  } 
}
