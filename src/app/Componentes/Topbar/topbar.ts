import { Component, inject } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { Carregamento } from '../Carregamento/carregamento';
import { HttpService } from '../../Services/Http.service';
import { Definicoes } from '../../Definicoes';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ServicoAutenticacao } from '../../Services/Autenticacao.service';

@Component({
  selector: 'topbar',
  imports: [RouterModule, Carregamento, FormsModule, ReactiveFormsModule],
  templateUrl: './topbar.html',
  styleUrl: './topbar.css'
})


export class Topbar {
  ModalLoginVisivel = false
  DropdownVisivel = false
  CarregamentoVisivel = false

  ServicoHttp = inject(HttpService)
  ServicoAutenticacao = inject(ServicoAutenticacao)
  Router = inject(Router)

  URL_Imagens = Definicoes.API_URL+'imagens/utilizador'
  
  async Login(){
    this.CarregamentoVisivel = true

    const ValoresForm = this.FormLogin.value

    const URLLogin = new URL('login',Definicoes.API_URL)
    const ResultadoLogin = await this.ServicoHttp.Request(URLLogin, 'POST', 'Erro no login',
       {
        email: ValoresForm.email, 
        password: ValoresForm.password
      })

    if(ResultadoLogin){
      window.location.reload();
    }
    
    else{
      this.CarregamentoVisivel = false
    }
  }

  async Logout(){
    this.CarregamentoVisivel = true

    const URLLogout = new URL('Logout',Definicoes.API_URL)
    const ResultadoLogout = await this.ServicoHttp.Request(URLLogout, 'POST', 'Erro no logout')

    if(ResultadoLogout){
      await this.Router.navigate(['/inicial']) 
      window.location.reload()
    }else{
      this.CarregamentoVisivel = false
    }
  }

  FormLogin = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required]),
  });

  // get email() {
  //   return this.FormLogin.get('email');
  // }
  // get password() {
  //   return this.FormLogin.get('password');
  // }
}
