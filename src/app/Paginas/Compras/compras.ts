import { Component, inject } from '@angular/core';
import { Topbar } from '../../Componentes/Topbar/topbar';
import { Footer } from '../../Componentes/Footer/footer';
import { ServicoAutenticacao } from '../../Services/Autenticacao.service';
import { HttpService } from '../../Services/Http.service';
import { Definicoes } from '../../Definicoes';
import { saveAs } from 'file-saver'; // caso ainda não tenhas

@Component({
    selector: 'compras',
    imports: [Topbar],
    templateUrl: './compras.html',
    styleUrl: './compras.css'
  })

export class PaginaCompras {
    ServicoAutenticacao = inject(ServicoAutenticacao)
    Utilizador = this.ServicoAutenticacao.Utilizador
    Compras : any[] = []

    ServicoHTTP = inject(HttpService)

    async ngOnInit() {
        const Pedido_URL = new URL(Definicoes.API_URL+"compras")
        this.Compras = await this.ServicoHTTP.Request(Pedido_URL, "GET")
    }


    async transferirRecibo(idCompra: number) { //LocalPartida: string
        const Pedido_URL = new URL(Definicoes.API_URL + `recibo/${idCompra}`);
        const blob = await this.ServicoHTTP.Request(Pedido_URL, "GET", undefined, true)
        const ficheiro = new Blob([blob], { type: 'application/pdf' });
        saveAs(ficheiro, `recibo_${idCompra}.pdf`); //LocalPartida
    }
}

