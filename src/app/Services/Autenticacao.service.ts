import { inject, Injectable, signal } from '@angular/core';
import { ActivatedRouteSnapshot, Route, Router, RouterStateSnapshot } from '@angular/router';
import { HttpService } from './Http.service';
import { Definicoes } from '../Definicoes';

interface Utilizador {
  nif: number;
  telefone:number;
  morada: string;
  nascimento: string;
  localidade:string;
  nome: string;
  email: string;
  tipo_utilizador: number;
  atividade: number;
}

@Injectable({
  providedIn: 'root'
})

export class ServicoAutenticacao {

  router = inject(Router)
  HttpService = inject(HttpService)
  Utilizador = signal<Utilizador | undefined>(undefined)
  Admin = signal<boolean>(false)

  async Autenticar(){
    const AuthURL = new URL('autenticar',Definicoes.API_URL)
    const RespostaLogin = await this.HttpService.Request(AuthURL, 'POST')
    
    if (RespostaLogin){
      this.Utilizador.set(RespostaLogin)
      if (RespostaLogin.tipo_utilizador == 1){
        this.Admin.set(true)
      }
    }
  }
}
