import { inject, Injectable, signal } from '@angular/core';
import { ActivatedRouteSnapshot, Route, Router } from '@angular/router';
import { ServicoMensagens } from '../Componentes/ServicoMensagens/Mensagens.service';
//import { NzMessageService } from 'ng-zorro-antd/message';

@Injectable({
  providedIn: 'root'
})

export class HttpService {

  //private MessageService = inject(NzMessageService)

  private readonly DefaultHeaders = {
    'Content-Type': 'application/json'
  }

  ServicoMensagens = inject(ServicoMensagens)


  async Request(RequestURL: URL | string, Method: string = "GET", ErrorSuffix: string = "", Data?: any): Promise<any> {
    return new Promise(async (resolve, reject) => {


      let RequestHeaders: any = undefined




      if (typeof (RequestURL) == 'string') {
        RequestURL = new URL(RequestURL)
      }

      if (Method == 'GET' && Data) {

        // Convert object to search params
        for (const [key, value] of Object.entries(Data)) {
          RequestURL.searchParams.append(key, String(value))
        }
        Data = undefined
      } else {

        // Convert body type
        const FormDataBody = (Data instanceof FormData)
        const EncodedBody = (Data instanceof URLSearchParams)
        const JSONBody = !EncodedBody && !FormDataBody
        if (JSONBody) {
          Data = JSON.stringify(Data)
          RequestHeaders = { 'Content-Type': 'application/json' }
        } else if (EncodedBody) {
          RequestHeaders = { 'Content-Type': 'application/x-www-form-urlencoded' }
        }
      }


      const Request = fetch(RequestURL, {
        headers: RequestHeaders,
        method: Method,
        credentials: 'include',
        body: Data,

        //PARSING
      }).then(async (Response) => {
        const ContentType = Response.headers.get("Content-Type") || ''

        var Result: any = undefined

        if (ContentType.includes("application/json")) {
          Result = await Response.json()
        } else if (ContentType.includes("text/html")) {
          Result = await Response.text()
        } else {
          Result = await Response.blob()
        }


        if (Response.ok) {
          resolve(Result)
        } else {
          const MensagemErro = `${ErrorSuffix} - ${Response.statusText}`
          if (ErrorSuffix) {
            console.error(`Erro: ${MensagemErro}`)
            this.ServicoMensagens.erro(MensagemErro)
          }
          resolve(false)
        }

        // ERROR
      }).catch((Error: Error) => {
        console.error(Error)
        this.ServicoMensagens.erro('Falha ao conectar ao servidor')
        resolve(false)
      })
    })
  }


  // para testes
  Wait = (seconds: number) => new Promise(resolve => setTimeout(resolve, seconds * 1000));
}
