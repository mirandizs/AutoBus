import { Component, inject, signal } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { ServicoAutenticacao } from '../../../Services/Autenticacao.service';
import { HttpService } from '../../../Services/Http.service';
import { Definicoes } from '../../../Definicoes';

interface Utilizador {
  nif: number;
  telefone:number;
  morada: string;
  nascimento: string;
  localidade:string;
  nome: string;
  email: string;
  tipo_utilizador: number;
  atividade: number;
}

@Component({
  selector: 'janela-editar-utilizador',
  imports: [RouterModule],
  templateUrl: './editar-utilizador.html',
  styleUrl: '../definicoes.css'
})


export class JanelaEditarUtilizador {
  ServicoAutenticacao = inject(ServicoAutenticacao)
  route = inject(ActivatedRoute)
  servicoHTTP = inject(HttpService)
  Utilizador = this.ServicoAutenticacao.Utilizador
  PasswordVisivel = false

  UtilizadorSelecionado = signal<null | Utilizador>(null)

  async ngOnInit() {
    const NIFUtilizador = this.route.snapshot.paramMap.get('id');

    const LinkAPI = Definicoes.API_URL

    const resultado = await this.servicoHTTP.Request(LinkAPI + `utilizadores/` + NIFUtilizador, 'GET')

    if (resultado) {
      this.UtilizadorSelecionado.set(resultado)
      console.log(resultado)
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
}
