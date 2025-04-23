import { Component, inject } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ServicoAutenticacao } from '../../../Services/Autenticacao.service';
import { Definicoes } from '../../../Definicoes';

@Component({
  selector: 'janela-minha-conta',
  imports: [RouterModule],
  templateUrl: './minha-conta.html',
  styleUrl: '../definicoes.css'
})
export class JanelaMinhaConta {
  ServicoAutenticacao = inject(ServicoAutenticacao)
  Utilizador = this.ServicoAutenticacao.Utilizador


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
}
