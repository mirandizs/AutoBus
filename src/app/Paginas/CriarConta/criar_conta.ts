import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { HttpService } from '../../Services/Http.service';
import { Validadores } from '../../Services/Validadores';
import { Definicoes } from '../../Definicoes';
import { SeletorImagens } from '../../Componentes/SeletorImagens/seletor-imagens';
import { ModalVerificacao } from "../../Componentes/ModalVerificacao/modal-verificacao";
import { Carregamento } from "../../Componentes/Carregamento/carregamento";
import { ServicoMensagens } from '../../Componentes/ServicoMensagens/Mensagens.service';

@Component({
  selector: 'criar-conta',
  imports: [RouterModule, FormsModule, ReactiveFormsModule, SeletorImagens, ModalVerificacao, Carregamento],
  templateUrl: './criar_conta.html',
  styleUrl: './criar_conta.less'
})
export class PaginaCriarConta {
  ServicoHttp = inject(HttpService)
  ServicoMensagens = inject(ServicoMensagens)
  router = inject(Router)

  MostarPassword = false
  MostarConfirmacaoPassword = false
  MostrarFotoCriarConta = false
  SelecionarImagens = false
  ModalCodigo = false
  ACriarConta = false
  
  ngOnInit() {
    if (this.SelecionarImagens === true) {
      console.log('Está a aparecer!');
    }
  }

  URL_Imagens = Definicoes.API_URL + 'imagens/utilizador'

  
  AMandarEmail: boolean = false;
  async EnviarCodigo() {
    this.AMandarEmail = true

    const EmailMandado = await this.ServicoHttp.Request(Definicoes.API_URL + 'email-confirmacao', 'POST', 
      'Falha ao enviar o email de confirmação', {
      email: this.FormCriar.value.email,
    })

    if (EmailMandado) {
        this.ModalCodigo = true
    }
    this.AMandarEmail = false
  }


  
  async CriarConta(Codigo:number){
    /*this.FormCriar.disable()*/
    this.ACriarConta = true

    const SucessoConta = await this.ServicoHttp.Request(Definicoes.API_URL+'criar_conta', 'POST', 'Nao foi possivel criar a conta', 
      {
        ...this.FormCriar.value,
        codigo_confirmacao: Codigo
      }
    )

    if (SucessoConta){
      if (this.FicheiroSelecionado){
        const Data = new FormData()
        Data.append('foto', this.FicheiroSelecionado)

        const SucessoImagem = await this.ServicoHttp.Request(this.URL_Imagens, 'POST', 'Nao foi possivel criar a foto da conta', Data)

      }

      this.ServicoMensagens.sucesso("Conta criada com sucesso!")
      this.router.navigate(["/inicial"]).then(()=> {
        window.location.reload()
      })
    }

    
    this.ACriarConta = false
    this.FormCriar.enable()
  }

  Avancando = false
  async Avancar(){
    this.Avancando = true
    
    const ValoresForm = this.FormCriar.value
    const Resposta = await this.ServicoHttp.Request(Definicoes.API_URL+'verificar_existe', 'GET', 'Erro ao avancar', {
      nif:ValoresForm.nif,
      email:ValoresForm.email
    }) 
    
    const ContaExiste = Resposta?.existe
    if (!ContaExiste){
      this.MostrarFotoCriarConta = true
    }else{
      this.ServicoMensagens.erro('Uma conta com este nif ou email ja existe!')
    }
    this.Avancando = false
  }

  FicheiroSelecionado?:File
  ImagemSelecionada?:string|ArrayBuffer|null

  async PreverImagem(Ficheiro: File) {
    if (Ficheiro){
    const reader = new FileReader();

    this.FicheiroSelecionado = Ficheiro

    reader.onload = () => {
      this.ImagemSelecionada = reader.result
    };

    reader.readAsDataURL(Ficheiro);
    }
  }

  async ImagemMudada(Event:Event){
    const Input = Event.target as HTMLInputElement
    this.PreverImagem(Input.files![0])
  }


  FormFoto: FormGroup = new FormGroup({
    foto: new FormControl('', [Validators.required])
  })


  // definir o form com estrutura, campos e validacoes
  FormCriar:FormGroup = new FormGroup({
    nome: new FormControl('', [Validators.required]),
    nif: new FormControl('', [Validators.required, Validators.pattern(/^\d{9}$/)]),  // ^\d{9}$ -> 9 digitos
    password: new FormControl('', [Validators.required, Validadores.SenhaForte, Validadores.ConfirmacaoPassword]), 
    // o de confirmacao de password é utilizador apenas para atualizar o campo de confirmacao sempre que o da password muda.
    // ^ fiz um validador com varios erros no ficheiro Services/Validadores.ts

    nascimento: new FormControl('', [Validators.required]),
    telefone: new FormControl('', [Validators.required, Validators.pattern(/^\d{9}$/)]),  // ^\d{9}$ -> 9 digitos
    localidade: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    confirm_password: new FormControl('', [Validators.required, Validadores.ConfirmacaoPassword]),
  });

  // usei um wrapper para o form, para facilitar o acesso aos campos
  // defini estas variaveis para poderem ser acedidas no html
  get nome() {
    return this.FormCriar.get('nome');
  }
  get nif() {
    return this.FormCriar.get('nif');
  }
  get password() {
    return this.FormCriar.get('password');
  }
  get nascimento() {
    return this.FormCriar.get('nascimento');
  }
  get telefone() {
    return this.FormCriar.get('telefone');
  }
  get localidade() {
    return this.FormCriar.get('localidade');
  }
  get email() {
    return this.FormCriar.get('email');
  }
  get confirm_password() {
    return this.FormCriar.get('confirm_password');
  }




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












  preencherFormComValoresAleatorios() {
    const randomNif = () => {
      const prefixos = [1, 2, 5, 6, 7, 9];
      const prefix = prefixos[Math.floor(Math.random() * prefixos.length)];
      let nif = prefix.toString();
      for (let i = 0; i < 8; i++) {
        nif += Math.floor(Math.random() * 10);
      }
      return nif;
    };
    const randomTelemovel = () => {
      let tel = '9';
      for (let i = 0; i < 8; i++) {
        tel += Math.floor(Math.random() * 10);
      }
      return tel;
    };
    const randomEmail = () => {
      const dominios = ['gmail.com', 'yahoo.com', 'hotmail.com'];
      const dominio = dominios[Math.floor(Math.random() * dominios.length)];
      const user = Math.random().toString(36).substring(2, 10);
      return `teste_${user}@${dominio}`;
    };
    this.FormCriar.setValue({
      nome: 'Teste',
      nif: randomNif(),
      password: 'Teste1234',
      nascimento: '1990-01-01',
      telefone: randomTelemovel(),
      localidade: 'Lisboa',
      email: randomEmail(),
      confirm_password: 'Teste1234',
    });
  }
}


// DA PRINT AOS VALORES INVALIDOS DO FORM A CADA 2 SEGUDOS
 // setInterval(() => {

    //   const invalidFields = [];
    //   const controls = this.FormCriar.controls;
    //   for (const name in controls) {
    //     if (controls[name].invalid) {
    //       invalidFields.push({
    //         field: name,
    //         errors: controls[name].errors
    //       });
    //     }
    //   }
    //   console.log('Invalid fields:', invalidFields);
    //   return invalidFields;
    
    // }, 1
    //2000)