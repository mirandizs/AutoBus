import { Component, Input } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'modal-verificacao',
  imports: [RouterModule],
  templateUrl: './modal-verificacao.html',
  styleUrl: './modal-verificacao.css'
})

export class ModalVerificacao {
  @Input() Visivel: boolean = false;
  
  ModalCodigo: boolean = false;

  //funcao para permitir apenas a insercao de numeros
  permitirApenasNumeros(event: KeyboardEvent): void {
    const tecla = event.key;
    if (!/^\d$/.test(tecla)) {
      event.preventDefault();
    }
  }
}
