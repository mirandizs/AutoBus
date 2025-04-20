import { Component, inject } from '@angular/core';
import { Footer } from '../../Componentes/Footer/footer';
import { Topbar } from '../../Componentes/Topbar/topbar';
import { ButaoVoltar } from "../../Componentes/ButaoVoltar/butao-voltar";
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpService } from '../../Services/Http.service';
import { Definicoes } from '../../Definicoes';
import { Carregamento } from "../../Componentes/Carregamento/carregamento";

@Component({
  selector: 'pagina-contacto',
  imports: [Footer, Topbar, ButaoVoltar, FormsModule, ReactiveFormsModule, Carregamento],
  templateUrl: './contacto.html',
  styleUrl: './contacto.css'
})
export class PaginaContacto {
  ModalSucessoVisivel: boolean = false;
  AMandarEmail: boolean = false;

  ServicoHttp = inject(HttpService)

  FormContacto: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    assunto: new FormControl('', [Validators.required]),
    mensagem: new FormControl('', [Validators.required]),
  })

  async MandarEmail() {
    this.AMandarEmail = true
    this.FormContacto.disable()

    const EmailMandado = await this.ServicoHttp.Request(Definicoes.API_URL + 'email-contacto', 'POST', 'Nao foi possivel contactar',
      this.FormContacto.value) // Valores do form

    if (EmailMandado) {
      this.FormContacto.reset()
      this.ModalSucessoVisivel = true
    }
    this.AMandarEmail = false
    this.FormContacto.enable()
  }
}
