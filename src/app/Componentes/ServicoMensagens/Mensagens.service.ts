import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Mensagem } from './mensagem';

@Injectable({ providedIn: 'root' })
export class ServicoMensagens {
  private mensagensSubject = new BehaviorSubject<Mensagem[]>([]);
  mensagens$ = this.mensagensSubject.asObservable();

  private contador = 0;

  erro(texto: string) {
    this.adicionarMensagem('erro', texto);
  }

  sucesso(texto: string) {
    this.adicionarMensagem('sucesso', texto);
  }

  info(texto: string) {
    this.adicionarMensagem('info', texto);
  }

  aviso(texto: string) {
    this.adicionarMensagem('aviso', texto);
  }

  private adicionarMensagem(tipo: Mensagem['tipo'], texto: string) {
    const mensagem: Mensagem = {
      id: ++this.contador,
      tipo,
      texto
    };
    const atual = this.mensagensSubject.value
    this.mensagensSubject.next([...atual, mensagem])

    // Remover automaticamente após 3s
    setTimeout(() => this.removerMensagem(mensagem.id), 3000)
  }

  removerMensagem(id: number) {
    this.mensagensSubject.next(this.mensagensSubject.value.filter(msg => msg.id !== id))
  }
}
