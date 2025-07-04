import { Component, OnInit } from '@angular/core';
import { Mensagem } from './mensagem';
import { ServicoMensagens } from './Mensagens.service';
import { MensagemComponente } from './mensagem.componente';

@Component({
    selector: 'container-mensagens',
    imports: [MensagemComponente],
    template: `
    <div class="message-wrapper">
        @for (Mensagem of Mensagens; track $index){
            <mensagem
                [mensagem]="Mensagem"
                (close)="close(Mensagem.id)">
            </mensagem>
        }
    </div>
  `,
    styles: [`
    .message-wrapper {
      position: fixed;
      top: 20px;
      right: 20px;
      display: flex;
      flex-direction: column;
      gap: 8px;
      z-index: 1000;
    }
  `]
})
export class MessageContainerComponent implements OnInit {
    Mensagens: Mensagem[] = [];

    constructor(private ServicoMensagens: ServicoMensagens) { }

    ngOnInit() {
        this.ServicoMensagens.mensagens$.subscribe(msgs => this.Mensagens = msgs);
    }

    close(id: number) {
        this.ServicoMensagens.removerMensagem(id);
    }
}
