import { Component, inject, signal, effect } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { ServicoAutenticacao } from '../../../Services/Autenticacao.service';
import { HttpService } from '../../../Services/Http.service';
import { Definicoes } from '../../../Definicoes';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';

interface Utilizador {
  nif: number;
  telefone: number;
  morada: string;
  nascimento: string;
  localidade: string;
  nome: string;
  email: string;
  tipo_utilizador: number;
  atividade: number;
}

@Component({
  selector: 'janela-editar-utilizador',
  imports: [RouterModule, FormsModule, ReactiveFormsModule],
  templateUrl: './editar-utilizador.html',
  styleUrl: '../definicoes.less'
})


export class JanelaEditarUtilizador {
  ServicoAutenticacao = inject(ServicoAutenticacao)
  route = inject(ActivatedRoute)
  router = inject(Router)
  ServicoHttp = inject(HttpService)
  Utilizador = this.ServicoAutenticacao.Utilizador
  PasswordVisivel = false

  UtilizadorSelecionado = signal<null | Utilizador>(null)

  async SubmeterForm() {
    this.FormEditarUtilizador.disable()

    const Resultado = await this.ServicoHttp.Request(Definicoes.API_URL + 'editar-utilizador', 'PATCH', 'Não foi possivel editar os dados da conta',
      this.FormEditarUtilizador.value) // O body equivale ao valor do form criar. Este .value e um array, com o nome de todos os campos e os seus valores

    if (Resultado) {
      await this.router.navigate(['/definicoes/minha-conta'])
      window.location.reload()
    }
    this.FormEditarUtilizador.enable()
  }



  FormEditarUtilizador: FormGroup = new FormGroup({
    nome: new FormControl('', [Validators.required]),
    nif: new FormControl('', [Validators.required, Validators.pattern(/^\d{9}$/)]),  // ^\d{9}$ -> 9 digitos
    nascimento: new FormControl('', [Validators.required]),
    telefone: new FormControl('', [Validators.required, Validators.pattern(/^\d{9}$/)]),  // ^\d{9}$ -> 9 digitos
    localidade: new FormControl('', [Validators.required]),
    foto: new FormControl('', [Validators.required]),
  });

  get nome() {
    return this.FormEditarUtilizador.get('nome');
  }
  get nif() {
    return this.FormEditarUtilizador.get('nif');
  }
  get nascimento() {
    return this.FormEditarUtilizador.get('nascimento');
  }
  get telefone() {
    return this.FormEditarUtilizador.get('telefone');
  }
  get localidade() {
    return this.FormEditarUtilizador.get('localidade');
  }
  get foto() {
    return this.FormEditarUtilizador.get('foto');
  }


  async ngOnInit() {
    const NIFUtilizador = this.route.snapshot.paramMap.get('id');

    if (NIFUtilizador) {
      const LinkAPI = Definicoes.API_URL

      const resultado = await this.ServicoHttp.Request(LinkAPI + `utilizadores/` + NIFUtilizador, 'GET')

      if (resultado) {
        this.UtilizadorSelecionado.set(resultado)
        console.log(resultado)
      }
    }
  }


  constructor() {
    this.FormEditarUtilizador.get('nif')?.disable();

    
    const NIFUtilizador = this.route.snapshot.paramMap.get('id');

    effect(() => {
      const Utilizador = this.Utilizador()
      if (Utilizador && !NIFUtilizador) {
        this.FormEditarUtilizador.get('nome')?.setValue(this.Utilizador()?.nome)
        this.FormEditarUtilizador.get('nif')?.setValue(this.Utilizador()?.nif)
        this.FormEditarUtilizador.get('nascimento')?.setValue(this.Utilizador()?.nascimento)
        this.FormEditarUtilizador.get('telefone')?.setValue(this.Utilizador()?.telefone)
        this.FormEditarUtilizador.get('localidade')?.setValue(this.Utilizador()?.localidade)
      }
    });
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
