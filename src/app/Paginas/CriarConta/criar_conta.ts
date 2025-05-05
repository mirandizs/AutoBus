import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { HttpService } from '../../Services/Http.service';
import { Validadores } from '../../Services/Validadores';
import { Definicoes } from '../../Definicoes';

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
  router = inject(Router)

  async ngOnInit() {
   while (true){
    await this.ServicoHttp.Wait(3)
   }
  }


  async SubmeterForm(){
    this.FormCriar.disable()

    const Resultado = await this.ServicoHttp.Request(Definicoes.API_URL+'criar_conta', 'POST', 'Nao foi possivel criar a conta', 
      this.FormCriar.value) // O body equivale ao valor do form criar. Este .value e um array, com o nome de todos os campos e os seus valores

    if (Resultado){
      this.router.navigate(['/inicial'])
    }
    this.FormCriar.enable()
  }

  // Definimos o form com estrutura, campos e validacoes
  FormCriar:FormGroup = new FormGroup({
    nome: new FormControl('', [Validators.required]),
    nif: new FormControl('', [Validators.required, Validators.pattern(/^\d{9}$/)]),  // ^\d{9}$ -> 9 digitos
    password: new FormControl('', [Validators.required, Validadores.SenhaForte, Validadores.ConfirmacaoPassword]), 
    // Usamos o de confirmacao de password apenas para atualizar o campo de confirmacao sempre que o da password muda.
    // ^ Fiz um validador com varios erros no ficheiro Services/Validadores.ts

    nascimento: new FormControl('', [Validators.required]),
    telefone: new FormControl('', [Validators.required, Validators.pattern(/^\d{9}$/)]),  // ^\d{9}$ -> 9 digitos
    localidade: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    confirm_password: new FormControl('', [Validators.required, Validadores.ConfirmacaoPassword]),
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




  //funcao para permitir apenas a insercao de letras
  permitirApenasLetras(event: any) {
    const input = event.target as HTMLInputElement;
    input.value = input.value.replace(/[^a-zA-ZÀ-ÿ\s]/g, '');
  }

  //funcao para permitir apenas a insercao de numeros
  permitirApenasNumeros(event: KeyboardEvent): void {
    const tecla = event.key;
    if (!/^\d$/.test(tecla)) {
      event.preventDefault();
    }
  }
}
