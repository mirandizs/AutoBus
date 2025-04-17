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
}
