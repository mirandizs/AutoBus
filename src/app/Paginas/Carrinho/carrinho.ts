import { Component, inject } from '@angular/core';
import { Topbar } from '../../Componentes/Topbar/topbar';
import { ServicoAutenticacao } from '../../Services/Autenticacao.service';
import { HttpService } from '../../Services/Http.service';
import { Definicoes } from '../../Definicoes';
import { FormsModule, FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CurrencyPipe } from '@angular/common';
import { ModalVerificacao } from '../../Componentes/ModalVerificacao/modal-verificacao';

@Component({
  selector: 'pagina-carrinho',
  imports: [Topbar, FormsModule, ReactiveFormsModule, CurrencyPipe, ModalVerificacao],
  templateUrl: './carrinho.html',
  styleUrl: './carrinho.css'
})


export class PaginaCarrinho {
  ServicoAutenticacao = inject(ServicoAutenticacao)
  Utilizador = this.ServicoAutenticacao.Utilizador


  ModalMetodo = false
  TipoPagamentoCartao = false
  TipoPagamentoMB = false
  ModalCodigo = false

  ServicoHTTP = inject(HttpService)
  Carrinho : any[] = []
  Total: number = 0;

  async ngOnInit() {
    this.Total = 0

    const Pedido_URL = new URL(Definicoes.API_URL+"carrinho") //api = http://localhost:3000/api/

    this.Carrinho = await this.ServicoHTTP.Request(Pedido_URL, "GET") 

    this.Carrinho.forEach((produto: any) => {
      this.Total += produto.preco
    })
  }


  //funcao para submeter o formulario do cartao
  async realizarCompra() {
    const Pedido_URL = new URL(Definicoes.API_URL+"comprar") 

    const resultadoCompra = await this.ServicoHTTP.Request(Pedido_URL, "POST", "", {
      metodo:  this.TipoPagamentoCartao ? "cartao" : "mb",
      nome_cartao: this.FormCartao.value.nome_cartao,
      numero_cartao: this.FormCartao.value.numero_cartao,
      validade: this.FormCartao.value.validade,
      cvv: this.FormCartao.value.cvv,
      guardarCartao: this.FormCartao.value.guardarCartao,
    })
  }




  //funcao para remover um produto do carrinho
  async removerBilhete(idProduto: number) {

    const Pedido_URL = new URL(Definicoes.API_URL+"carrinho") //api = http://localhost:3000/api/

    await this.ServicoHTTP.Request(Pedido_URL, "DELETE", "", {id_produto: idProduto}) 

    this.ngOnInit()

  }




  FormCartao:FormGroup = new FormGroup({
    nome_cartao: new FormControl('', []),
    numero_cartao: new FormControl('', []),
    validade: new FormControl('', []),
    cvv: new FormControl('', []),
    guardarCartao: new FormControl(false, []),
  });




  //funcao para permitir apenas a insercao de letras
  permitirApenasLetras(event: any) {
    const input = event.target as HTMLInputElement;
    input.value = input.value.replace(/[^a-zA-ZÀ-ÿ\s]/g, '');
  }

  //funcao para permitir apenas a insercao de numeros
  permitirApenasNumeros(event: KeyboardEvent): void {
    const tecla = event.key;
    if (!/^\d$/.test(tecla)) {
      event.preventDefault();
    }
  }


  //funcao para fazer a mascara do input do cartao, com limite de digitos e os espacos
  formatarCartao(event: Event): void {
    let input = (event.target as HTMLInputElement).value;
    input = input.replace(/\D/g, ''); // remove não números
    //input = input.substring(0, 16);   // limita a 16 dígitos
    input = input.replace(/(\d{4})(?=\d)/g, '$1 '); // insere espaços a cada 4 dígitos
    (event.target as HTMLInputElement).value = input;
  }


  //funcao para a validade do cartao
  formatarValidade(event: Event): void {
    let input = (event.target as HTMLInputElement).value;
    input = input.replace(/\D/g, '');
    input = input.substring(0, 4); // MMYY
  
    //verificacao do mes
    if (input.length >= 2) {
      const mes = parseInt(input.substring(0, 2), 10);
      if (mes < 1 || mes > 12) {
        (event.target as HTMLInputElement).value = '';
        return;
      }
    }
  
    if (input.length > 2) {
      input = input.replace(/(\d{2})(\d{1,2})/, '$1/$2'); //adicionar a barra entre o mes e o ano
    }
  
    (event.target as HTMLInputElement).value = input;
  
    // Validação completa da data

    //esta funcao vai separar o input em mes e ano e adicionar o "20" antes do parametro do utilizador
    //vai buscar o ano e mes atual e verificar se o cartao é valido ou nao, caso nao um alert aparece
    if (input.length === 5) {
      const [mesStr, anoStr] = input.split('/');
      const mes = parseInt(mesStr, 10);
      const ano = parseInt('20' + anoStr, 10);
  
      const hoje = new Date();
      const anoAtual = hoje.getFullYear();
      const mesAtual = hoje.getMonth() + 1;
  
      if (ano < anoAtual || (ano === anoAtual && mes < mesAtual)) {
        alert('Data de validade inválida');
        (event.target as HTMLInputElement).value = '';
      }
    }
  }  
}

