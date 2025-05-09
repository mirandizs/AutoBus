import { Component, inject } from '@angular/core';
import { Topbar } from '../../Componentes/Topbar/topbar';
import { Footer } from '../../Componentes/Footer/footer';
import { ServicoAutenticacao } from '../../Services/Autenticacao.service';
import { HttpService } from '../../Services/Http.service';
import { Definicoes } from '../../Definicoes';

@Component({
    selector: 'recibos',
    imports: [Topbar, Footer],
    templateUrl: './recibos.html',
    styleUrl: './recibos.css'
  })

export class PaginaRecibos {
    ServicoAutenticacao = inject(ServicoAutenticacao)
    Utilizador = this.ServicoAutenticacao.Utilizador
    Recibos : any[] = []

    ServicoHTTP = inject(HttpService)

    async ngOnInit() {
        const Pedido_URL = new URL(Definicoes.API_URL+"recibos")
        this.Recibos = await this.ServicoHTTP.Request(Pedido_URL, "GET") 
    }

    
}

  