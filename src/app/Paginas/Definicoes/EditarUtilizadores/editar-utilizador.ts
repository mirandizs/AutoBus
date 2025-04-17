import { Component, inject } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { ServicoAutenticacao } from '../../../Services/Autenticacao.service';

@Component({
  selector: 'janela-editar-utilizador',
  imports: [RouterModule],
  templateUrl: './editar-utilizador.html',
  styleUrl: '../definicoes.css'
})
export class JanelaEditarUtilizador {
  ServicoAutenticacao = inject(ServicoAutenticacao)
  route = inject(ActivatedRoute)
  Utilizador = this.ServicoAutenticacao.Utilizador

  UtilizadorSelecionado = this.ServicoAutenticacao.Utilizador

  ngOnInit() {
    const IdUtilizador = this.route.snapshot.paramMap.get('id');
    console.log(IdUtilizador)
  }
}
