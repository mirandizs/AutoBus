import { Component, Input } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'carregamento',
  imports: [RouterModule],
  templateUrl: './carregamento.html',
  styleUrl: './carregamento.css'
})

export class Carregamento {
  @Input() Visivel: boolean = false;
}
