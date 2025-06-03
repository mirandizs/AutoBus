import { Component, Input, Output, EventEmitter} from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'modal-verificacao',
  imports: [RouterModule],
  templateUrl: './modal-verificacao.html',
  styleUrl: './modal-verificacao.css'
})

export class ModalVerificacao {
  @Output() close = new EventEmitter<void>();

  onFechar() {
    this.close.emit();
  }


  async ReenviarCodigo() {
    // Aqui você pode implementar a lógica para reenviar o código de verificação
    console.log('Reenviar código de verificação');
  }


  //funcao para permitir apenas a insercao de numeros
  permitirApenasNumeros(event: KeyboardEvent): void {
    const tecla = event.key;
    if (!/^\d$/.test(tecla)) {
      event.preventDefault();
    }
  }
}
