import { Component, effect, inject } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { ServicoAutenticacao } from '../../../Services/Autenticacao.service';
import { Definicoes } from '../../../Definicoes';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Validadores } from '../../../Services/Validadores';
import { HttpService } from '../../../Services/Http.service';
import { Reactive } from '@angular/core/primitives/signals';
import { SeletorImagens } from '../../../Componentes/SeletorImagens/seletor-imagens';
import { CommonModule } from '@angular/common';
import { Carregamento } from '../../../Componentes/Carregamento/carregamento';

@Component({
  selector: 'janela-minha-conta',
  imports: [RouterModule, FormsModule, ReactiveFormsModule, SeletorImagens, CommonModule, Carregamento],
  templateUrl: './minha-conta.html',
  styleUrl: '../definicoes.less'
})


export class JanelaMinhaConta {
  ServicoAutenticacao = inject(ServicoAutenticacao)
  Utilizador = this.ServicoAutenticacao.Utilizador
  ServicoHttp = inject(HttpService)
  router = inject(Router)

  CarregamentoVisivel = false
  SelecionarImagem = false
  Desativado = true;
  ModalSucessoVisivel: boolean = false;
  ModalFotoSucesso: boolean = false

  IsUtilizadorProtegidoNome = false;
  IsUtilizadorProtegidoEmail= false;

  constructor() {
    this.FormEditar.get('nif')?.disable();

    effect(() => {
      const Utilizador = this.Utilizador()
      if (Utilizador) {
        this.IsUtilizadorProtegidoNome  = Utilizador.nome === 'admin'
        this.IsUtilizadorProtegidoEmail = Utilizador.email === 'autobus.pap@gmail.com';

        this.FormEditar.get('nome')?.setValue(Utilizador.nome)
        this.FormEditar.get('nif')?.setValue(Utilizador.nif)
        this.FormEditar.get('nascimento')?.setValue(Utilizador.nascimento)
        this.FormEditar.get('telefone')?.setValue(Utilizador.telefone)
        this.FormEditar.get('localidade')?.setValue(Utilizador.localidade)

        // Desativar todos os campos se for protegido
        if (this.IsUtilizadorProtegidoEmail && this.IsUtilizadorProtegidoNome) {
          this.FormEditar.disable();
        }
      }
    });
  }



  URL_Imagens = Definicoes.API_URL + 'imagens/utilizador'

  ImageSelecionada: string | ArrayBuffer | null = null;
  FicheiroSelecionado: File | null = null;

  //funcao para carregar a imagem do pc 
  async PreverImagem(Ficheiro: File) {
    if (Ficheiro){
      const reader = new FileReader();

      this.FicheiroSelecionado = Ficheiro

      reader.onload = () => {
        this.ImageSelecionada = reader.result
        this.MudarImagem(Ficheiro)
      };

      
      this.ModalFotoSucesso = true

      reader.readAsDataURL(Ficheiro);
    }
  }

  async ImagemMudada(Event:Event){
    const Input = Event.target as HTMLInputElement
    this.PreverImagem(Input.files![0])
  }



  async MudarImagem(Ficheiro: File) {

    const Data = new FormData()
    Data.append('foto', Ficheiro)

    const Sucesso = await this.ServicoHttp.Request(this.URL_Imagens, 'POST', 'Nao foi possivel editar a foto da conta', Data)
  }



  async SubmeterForm() {
    this.FormEditar.disable()

    const Resultado = await this.ServicoHttp.Request(Definicoes.API_URL + 'minha-conta', 'PATCH', 'Nao foi possivel editar os dados da conta',
      this.FormEditar.value) // O body equivale ao valor do form criar. Este .value e um array, com o nome de todos os campos e os seus valores

    if (Resultado) {
      this.ModalSucessoVisivel = true
      //await this.router.navigate(['/definicoes/minha-conta'])
    }
    this.FormEditar.enable()
  }



  // funcao para fechar o modal
  FecharModalSucesso() {
    this.ModalSucessoVisivel = false;
    this.router.navigate(['/definicoes/minha-conta'])
    window.location.reload()
  } 



  FormEditar: FormGroup = new FormGroup({
    nome: new FormControl('', [Validators.required]),
    nascimento: new FormControl('', [Validators.required]),
    telefone: new FormControl('', [Validators.required, Validators.pattern(/^\d{9}$/)]),  // ^\d{9}$ -> 9 digitos
    localidade: new FormControl('', [Validators.required]),
  })



  get nome() {
    return this.FormEditar.get('nome');
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


  VerificarMudancas() {
    const ValoresForm = this.FormEditar.value
    return ValoresForm.nome !== this.Utilizador()?.nome ||
      ValoresForm.nascimento !== this.Utilizador()?.nascimento ||
      ValoresForm.telefone !== this.Utilizador()?.telefone ||
      ValoresForm.localidade !== this.Utilizador()?.localidade
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
