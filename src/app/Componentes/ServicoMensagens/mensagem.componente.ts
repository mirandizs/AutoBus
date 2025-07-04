import { Component, Input, Output, EventEmitter, OnInit, inject } from '@angular/core';
import { Mensagem } from './mensagem';
import { ServicoMensagens } from './Mensagens.service';

@Component({
    selector: 'mensagem',
    template: `
    <div [class]='"mensagem "+mensagem.tipo'
         (mouseenter)="pausar()" (mouseleave)="retomar()">
      {{ mensagem.texto }}
      <button (click)="Fechar.emit()">×</button>
    </div>
  `,
    styles: [`
    .mensagem {
      padding: 12px 16px;
      border-radius: 4px;
      color: white;
      box-shadow: 0 2px 6px rgba(0,0,0,0.2);
      display: flex;
      justify-content: space-between;
      align-items: center;
      min-width: 200px;
      font-weight: 500;
    }
    .mensagem.erro { background: #ff4d4f; }
    .mensagem.sucesso { background: #52c41a; }
    .mensagem.info { background: #1890ff; }
    .mensagem.aviso { background: #faad14; }
    button {
      background: none;
      border: none;
      color: white;
      font-size: 16px;
      cursor: pointer;
    }
  `]
})
export class MensagemComponente implements OnInit {
    @Input() mensagem!: Mensagem;
    @Output() Fechar = new EventEmitter<void>();

    ServicoMensagens = inject(ServicoMensagens)
    private temporizador: any;

    ngOnInit() {
        this.iniciarTemporizador();

        this.Fechar.subscribe(() => {
            this.ServicoMensagens.removerMensagem(this.mensagem.id)
        })
    }


    pausar() {
        clearTimeout(this.temporizador);
    }

    retomar() {
        this.iniciarTemporizador();
    }

    iniciarTemporizador() {
        this.temporizador = setTimeout(() => this.Fechar.emit(), 3000);
    }
}