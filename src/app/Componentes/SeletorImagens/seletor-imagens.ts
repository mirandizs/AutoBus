import { Component, EventEmitter, Output, Input } from '@angular/core';
import { RouterModule } from '@angular/router';


@Component({
  selector: 'seletor-imagens',
  imports: [RouterModule],
  standalone: true,
  templateUrl: './seletor-imagens.html',
  styleUrl: './seletor-imagens.css'
})

export class SeletorImagens {
  // @Input() Visivel: boolean = false;
  @Output() close = new EventEmitter<void>();
  @Output() imagemSelecionada = new EventEmitter<File>();


  SelecionarImagem(Event: MouseEvent) {
    const ElementoImagem = Event.target as HTMLImageElement;
    const url = ElementoImagem.src;


    this.URLParaFicheiro(url, 'imagemSelecionada.png').then(file => {
      this.imagemSelecionada.emit(file);
      this.close.emit()
    })
  }

  URLParaFicheiro(url: string, filename: string): Promise<File> {
  return fetch(url)
    .then(res => res.blob())
    .then(blob => new File([blob], filename, { type: blob.type }));
}

  imagensPerfil: string[] = [
    'img/perfil/utilizador2.png',
    'img/perfil/utilizador7.png',
    'img/perfil/utilizador3.png',
    'img/perfil/utilizador10.png',
    'img/perfil/utilizador15.png',
    'img/perfil/utilizador14.png',
    'img/perfil/utilizador4.png',
    'img/perfil/utilizador8.png',
    'img/perfil/utilizador9.png',
    'img/perfil/utilizador5.png',
    'img/perfil/utilizador12.png',
    'img/perfil/utilizador11.png',
    'img/perfil/utilizador13.png',
    'img/perfil/utilizador6.png',
    'img/perfil/utilizador.png'
  ];

  onFechar() {
    this.close.emit();
  }
}