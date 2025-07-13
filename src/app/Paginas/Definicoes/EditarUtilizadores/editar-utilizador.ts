import { Component, inject, signal, effect } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { ServicoAutenticacao } from '../../../Services/Autenticacao.service';
import { HttpService } from '../../../Services/Http.service';
import { Definicoes } from '../../../Definicoes';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Carregamento } from '../../../Componentes/Carregamento/carregamento';

interface Utilizador {
  id_utilizador: number,
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
  imports: [RouterModule, FormsModule, ReactiveFormsModule, Carregamento],
  templateUrl: './editar-utilizador.html',
  styleUrl: '../definicoes.less'
})


export class JanelaEditarUtilizador {
  ServicoAutenticacao = inject(ServicoAutenticacao)
  route = inject(ActivatedRoute)
  router = inject(Router)
  ServicoHttp = inject(HttpService)
  Utilizador = this.ServicoAutenticacao.Utilizador

  ModalSucessoVisivel: boolean = false

  UtilizadorSelecionado = signal<null | Utilizador>(null)

  async SubmeterForm() {
    this.FormEditarUtilizador.disable()

    const Id = this.UtilizadorSelecionado()?.id_utilizador

    const Resultado = await this.ServicoHttp.Request(Definicoes.API_URL + 'editar-utilizador', 'PATCH', 'Não foi possivel editar os dados da conta',
      {
        ...this.FormEditarUtilizador.value,
        id_utilizador: Id
      })

    if (Resultado) {
      this.ModalSucessoVisivel = true
    }
    this.FormEditarUtilizador.enable()
  }



  FormEditarUtilizador: FormGroup = new FormGroup({
    nome: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required]),
    nif: new FormControl('', [Validators.required, Validators.pattern(/^\d{9}$/)]),  // ^\d{9}$ -> 9 digitos
    nascimento: new FormControl('', [Validators.required]),
    telefone: new FormControl('', [Validators.required, Validators.pattern(/^\d{9}$/)]),  // ^\d{9}$ -> 9 digitos
    localidade: new FormControl('', [Validators.required]),
    foto: new FormControl('', [Validators.required]),
    tipo_utilizador: new FormControl('', [Validators.required]),
    atividade: new FormControl('', [Validators.required]),
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



  // Por dados do utilizador a ser editado
  async ngOnInit() {
    const NIFUtilizador = this.route.snapshot.paramMap.get('id');

    if (NIFUtilizador) {
      const LinkAPI = Definicoes.API_URL

      const resultado = await this.ServicoHttp.Request(LinkAPI + `utilizadores/` + NIFUtilizador, 'GET')

      if (resultado) {
        this.UtilizadorSelecionado.set(resultado)
        this.FormEditarUtilizador.get('nome')?.setValue(resultado.nome)
        this.FormEditarUtilizador.get('nif')?.setValue(resultado.nif)
        this.FormEditarUtilizador.get('email')?.setValue(resultado.email)
        this.FormEditarUtilizador.get('nascimento')?.setValue(resultado.nascimento)
        this.FormEditarUtilizador.get('telefone')?.setValue(resultado.telefone)
        this.FormEditarUtilizador.get('localidade')?.setValue(resultado.localidade)
        this.FormEditarUtilizador.get('tipo_utilizador')?.setValue(resultado.tipo_utilizador)
        this.FormEditarUtilizador.get('atividade')?.setValue(resultado.atividade)
      }
    }
  }

  // Por dados do utilizador que tem sessao inciada, caso nao haja nenhum a ser editado
  constructor() {
    this.FormEditarUtilizador.get('nif')?.disable();
    this.FormEditarUtilizador.get('email')?.disable();

    const NIFUtilizador = this.route.snapshot.paramMap.get('id');

    effect(() => {
      const Utilizador = this.Utilizador()
      if (Utilizador && !NIFUtilizador) {
        this.FormEditarUtilizador.get('nome')?.setValue(this.Utilizador()?.nome)
        this.FormEditarUtilizador.get('nif')?.setValue(this.Utilizador()?.nif)
        this.FormEditarUtilizador.get('nascimento')?.setValue(this.Utilizador()?.nascimento)
        this.FormEditarUtilizador.get('telefone')?.setValue(this.Utilizador()?.telefone)
        this.FormEditarUtilizador.get('localidade')?.setValue(this.Utilizador()?.localidade)
        this.FormEditarUtilizador.get('tipo_utilizador')?.setValue(this.Utilizador()?.tipo_utilizador)
        this.FormEditarUtilizador.get('atividade')?.setValue(this.Utilizador()?.atividade)
      }
    });
  }



  VerificarMudancas() {
    const ValoresForm = this.FormEditarUtilizador.getRawValue()
    return ValoresForm.nome !== this.Utilizador()?.nome ||
      ValoresForm.nascimento !== this.Utilizador()?.nascimento ||
      ValoresForm.telefone !== this.Utilizador()?.telefone ||
      ValoresForm.localidade !== this.Utilizador()?.localidade ||
      ValoresForm.tipo_utilizador !== this.Utilizador()?.tipo_utilizador ||
      ValoresForm.atividade !== this.Utilizador()?.atividade
  }


  FecharModalSucesso() {
    this.ModalSucessoVisivel = false;
    this.router.navigate(['/definicoes/minha-conta'])
    window.location.reload()
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
