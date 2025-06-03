import { Component, effect, inject } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { ServicoAutenticacao } from '../../../Services/Autenticacao.service';
import { Definicoes } from '../../../Definicoes';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Validadores } from '../../../Services/Validadores';
import { HttpService } from '../../../Services/Http.service';
import { Reactive } from '@angular/core/primitives/signals';
import { SeletorImagens } from '../../../Componentes/SeletorImagens/seletor-imagens';

@Component({
  selector: 'janela-minha-conta',
  imports: [RouterModule, FormsModule, ReactiveFormsModule, SeletorImagens],
  templateUrl: './minha-conta.html',
  styleUrl: '../definicoes.css'
})


export class JanelaMinhaConta {
  ServicoAutenticacao = inject(ServicoAutenticacao)
  Utilizador = this.ServicoAutenticacao.Utilizador
  ServicoHttp = inject(HttpService)
  router = inject(Router)
  
  CarregamentoVisivel = false
  SelecionarImagem = false
  Desativado = true;


  constructor() {
    this.FormEditar.get('nif')?.disable(); 

    effect(() => {
      const Utilizador = this.Utilizador()
      if(Utilizador) {
        this.FormEditar.get('nome')?.setValue(this.Utilizador()?.nome)
        this.FormEditar.get('nif')?.setValue(this.Utilizador()?.nif)
        this.FormEditar.get('nascimento')?.setValue(this.Utilizador()?.nascimento)
        this.FormEditar.get('telefone')?.setValue(this.Utilizador()?.telefone)
        this.FormEditar.get('localidade')?.setValue(this.Utilizador()?.localidade)
      }
    });
  }



  URL_Imagens = Definicoes.API_URL + 'imagens/utilizador'

  ImageSelecionada: string | ArrayBuffer | null = null;

  //funcao para carregar a imagem do pc 
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


  async SubmeterForm(){
    this.FormEditar.disable()

    const Resultado = await this.ServicoHttp.Request(Definicoes.API_URL+'minha-conta', 'PATCH', 'Nao foi possivel editar os dados da conta', 
      this.FormEditar.value) // O body equivale ao valor do form criar. Este .value e um array, com o nome de todos os campos e os seus valores

    if (Resultado){
      await this.router.navigate(['/definicoes/minha-conta'])
      window.location.reload()
    }
    this.FormEditar.enable()
  }



  FormEditar:FormGroup = new FormGroup({
    nome: new FormControl('', [Validators.required]),
    nif: new FormControl('', [Validators.required, Validators.pattern(/^\d{9}$/)]),  // ^\d{9}$ -> 9 digitos
    nascimento: new FormControl('', [Validators.required]),
    telefone: new FormControl('', [Validators.required, Validators.pattern(/^\d{9}$/)]),  // ^\d{9}$ -> 9 digitos
    localidade: new FormControl('', [Validators.required]),
    foto: new FormControl('', [Validators.required]),
  });

  get nome() {
    return this.FormEditar.get('nome');
  }
  get nif() {
    return this.FormEditar.get('nif');
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
  get foto() {
    return this.FormEditar.get('foto');
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
