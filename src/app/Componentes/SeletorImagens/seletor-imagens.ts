import { Component, EventEmitter, Output, Input} from '@angular/core';
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

  onFechar() {
    this.close.emit();
  }
}