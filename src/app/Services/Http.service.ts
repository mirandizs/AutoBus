import { inject, Injectable, signal } from '@angular/core';
import { ActivatedRouteSnapshot, Route, Router } from '@angular/router';
//import { NzMessageService } from 'ng-zorro-antd/message';

@Injectable({
  providedIn: 'root'
})

export class HttpService {

  //private MessageService = inject(NzMessageService)

  private readonly DefaultHeaders = {
    'Content-Type': 'application/json'
  }



  async Request(URL: URL | string, Method: string = "GET", ErrorSuffix: string = "", Body?: any, Headers: HeadersInit = this.DefaultHeaders, JSONBody: boolean = true): Promise<Boolean | any> {
    return new Promise(async (resolve, reject) => {
      if (JSONBody) {
        Body = JSON.stringify(Body)
      }

      const Request = fetch(URL, {
        method: Method,
        credentials: 'include',
        headers: Headers,
        body: Body,
      }).then(async (Response) => {
        if (Response.ok) {
          const contentType = Response.headers.get('content-type');

          let Result;
          if (contentType && contentType.includes('application/json')) {
            Result = await Response.json();
          } else {
            Result = await Response.text();
          }
          
          resolve(Result)
        } else {
          //this.MessageService.error(`${ErrorSuffix}\n${Response.statusText}`)
          resolve(false)
        }
      }).catch((Error: Error) => {
        //this.MessageService.error(`Erro de conexão`)
        resolve(false)
      })
    })
  }


  // para testes
  Wait = (seconds: number) => new Promise(resolve => setTimeout(resolve, seconds * 1000));
}
