import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpService } from '../../Services/Http.service';
import { Validadores } from '../../Services/Validadores';

@Component({
  selector: 'criar-conta',
  imports: [RouterModule, FormsModule, ReactiveFormsModule],
  templateUrl: './criar_conta.html',
  styleUrl: './criar_conta.less'
})
export class PaginaCriarConta {
  MostarPassword = false
  MostarConfirmacaoPassword = false

  ServicoHttp = inject(HttpService)
  async ngOnInit() {
   while (true){
    await this.ServicoHttp.Wait(3)
   }
  }

  // Definimos o form, com estrutura, campos e validacoes
  FormCriar:FormGroup = new FormGroup({
    nome: new FormControl('', [Validators.required]),
    nif: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required, Validadores.SenhaForte]), 
    // ^ Fiz um validador com varios erros no ficheiro Services/Validadores.ts

    nascimento: new FormControl('', [Validators.required]),
    telefone: new FormControl('', [Validators.required]),
    localidade: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    confirm_password: new FormControl('', [Validators.required]),
  });

  // Usamos um wrapper para o form, para facilitar o acesso aos campos
  // Definimos estas variaveis para poderem ser acedidas no html
  get nome() {
    return this.FormCriar.get('nome');
  }
  get nif() {
    return this.FormCriar.get('nif');
  }
  get password() {
    return this.FormCriar.get('password');
  }
  get nascimento() {
    return this.FormCriar.get('nascimento');
  }
  get telefone() {
    return this.FormCriar.get('telefone');
  }
  get localidade() {
    return this.FormCriar.get('localidade');
  }
  get email() {
    return this.FormCriar.get('email');
  }
  get confirm_password() {
    return this.FormCriar.get('confirm_password');
  }
}
