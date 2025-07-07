import { Component, inject } from '@angular/core';
import { Topbar } from '../../Componentes/Topbar/topbar';
import { Footer } from '../../Componentes/Footer/footer';
import { ServicoAutenticacao } from '../../Services/Autenticacao.service';
import { HttpService } from '../../Services/Http.service';
import { Definicoes } from '../../Definicoes';
import { saveAs } from 'file-saver'; // caso ainda não tenhas
import { CurrencyPipe } from '@angular/common';
import { ButaoVoltar } from "../../Componentes/ButaoVoltar/butao-voltar";

@Component({
    selector: 'compras',
    imports: [Topbar, CurrencyPipe, ButaoVoltar],
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
        const Compras = await this.ServicoHTTP.Request(Pedido_URL, "GET", 'Erro ao obter compras')
        if (Compras){
            this.Compras = Compras;
        }
    }


    async transferirRecibo(idCompra: number) { //LocalPartida: string
        const Pedido_URL = new URL(Definicoes.API_URL + `recibo/${idCompra}`);
        const blob = await this.ServicoHTTP.Request(Pedido_URL, "GET", undefined, true)
        const ficheiro = new Blob([blob], { type: 'application/pdf' });
        saveAs(ficheiro, `recibo_${idCompra}.pdf`); //LocalPartida
    }


    //ordenar tabela por ondem mais antiga ou mais recente
    ordenarCompras(criterio: 'maisAntiga' | 'maisRecente' | 'a-z' | 'z-a' | 'menorPreco' | 'maiorPreco') {
        if (criterio === 'maisAntiga' || criterio === 'maisRecente') {
            this.Compras.sort((a, b) => {
                const dataA = new Date(a.data_compra.split('/').reverse().join('-'));
                const dataB = new Date(b.data_compra.split('/').reverse().join('-'));

                return criterio === 'maisAntiga'
                    ? dataA.getTime() - dataB.getTime()
                    : dataB.getTime() - dataA.getTime();
            });
        } 
        
        else if (criterio === 'a-z' || criterio === 'z-a') {
            this.Compras.sort((a, b) => {                
                const descA = (a.local_partida + ' para ' + a.local_chegada).toLowerCase();
                const descB = (b.local_partida + ' para ' + b.local_chegada).toLowerCase();

                return criterio === 'a-z'
                    ? descA.localeCompare(descB)
                    : descB.localeCompare(descA);
            });
        }

        else if (criterio === 'menorPreco' || criterio === 'maiorPreco') {
            this.Compras.sort((a, b) => {
                return criterio === 'menorPreco'
                    ? a.preco - b.preco
                    : b.preco - a.preco;
            });
        }
    }

    onFiltroAlterado(event: Event) {
        
        const valor = (event.target as HTMLSelectElement).value;

        switch (valor) {
            case 'Mais antiga': this.ordenarCompras('maisAntiga'); break;
            case 'Mais recente': this.ordenarCompras('maisRecente'); break;
            case 'A-Z': this.ordenarCompras('a-z'); break;
            case 'Z-A': this.ordenarCompras('z-a'); break;
            case 'Menor preço': this.ordenarCompras('menorPreco'); break;
            case 'Maior preço': this.ordenarCompras('maiorPreco'); break;
        }
    }
}

