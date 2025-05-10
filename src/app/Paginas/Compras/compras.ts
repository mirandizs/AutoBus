import { Component, inject } from '@angular/core';
import { Topbar } from '../../Componentes/Topbar/topbar';
import { Footer } from '../../Componentes/Footer/footer';
import { ServicoAutenticacao } from '../../Services/Autenticacao.service';
import { HttpService } from '../../Services/Http.service';
import { Definicoes } from '../../Definicoes';

@Component({
    selector: 'compras',
    imports: [Topbar, Footer],
    templateUrl: './compras.html',
    styleUrl: './compras.css'
  })

export class PaginaCompras {
    ServicoAutenticacao = inject(ServicoAutenticacao)
    Utilizador = this.ServicoAutenticacao.Utilizador
    Recibos : any[] = []

    ServicoHTTP = inject(HttpService)

    async ngOnInit() {
        const Pedido_URL = new URL(Definicoes.API_URL+"recibos")
        this.Recibos = await this.ServicoHTTP.Request(Pedido_URL, "GET") 
    }

    
}

  