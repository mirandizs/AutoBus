import { Component, inject } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { ServicoAutenticacao } from '../../../Services/Autenticacao.service';
import { Definicoes } from '../../../Definicoes';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Validadores } from '../../../Services/Validadores';
import { HttpService } from '../../../Services/Http.service';

@Component({
  selector: 'janela-minha-conta',
  imports: [RouterModule, FormsModule, ReactiveFormsModule],
  templateUrl: './minha-conta.html',
  styleUrl: '../definicoes.css'
})


export class JanelaMinhaConta {
  ServicoAutenticacao = inject(ServicoAutenticacao)
  Utilizador = this.ServicoAutenticacao.Utilizador
  CarregamentoVisivel = false
  ServicoHttp = inject(HttpService)
  router = inject(Router)


  async ngOnInit() {
    while (true){
     await this.ServicoHttp.Wait(3)
    }
  }


  URL_Imagens = Definicoes.API_URL + 'imagens/utilizador'

  ImageSelecionada: string | ArrayBuffer | null = null;

  PreverImagem(event: Event): void {
    const input = event.target as HTMLInputElement;

    if (input.files && input.files[0]) {
      const file = input.files[0];
      const reader = new FileReader();

      reader.onload = () => {
        this.ImageSelecionada = reader.result;
      };

      reader.readAsDataURL(file);
    }
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


  async SubmeterForm(){
    this.FormEditar.disable()

    const Resultado = await this.ServicoHttp.Request(Definicoes.API_URL+'minha-conta', 'PATCH', 'Nao foi possivel editar os dados da conta', 
      this.FormEditar.value) // O body equivale ao valor do form criar. Este .value e um array, com o nome de todos os campos e os seus valores

    if (Resultado){
      this.router.navigate(['/definicoes/minha-conta'])
    }
    this.FormEditar.enable()
  }



  FormEditar:FormGroup = new FormGroup({
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




  get nome() {
    return this.FormEditar.get('nome');
  }
  get nif() {
    return this.FormEditar.get('nif');
  }
  get password() {
    return this.FormEditar.get('password');
  }
  get nascimento() {
    return this.FormEditar.get('nascimento');
  }
  get telefone() {
    return this.FormEditar.get('telefone');
  }
  get localidade() {
    return this.FormEditar.get('localidade');
  }
  get email() {
    return this.FormEditar.get('email');
  }
  get confirm_password() {
    return this.FormEditar.get('confirm_password');
  }
}
