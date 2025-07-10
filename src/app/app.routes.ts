import { Routes } from '@angular/router';
import { PaginaDefinicoes } from './Paginas/Definicoes/definicoes';
import { PaginaInicial } from './Paginas/Inicial/inicial';
import { PaginaViagens } from './Paginas/Viagens/viagens';
import { PaginaCriarConta } from './Paginas/CriarConta/criar_conta';
import { PaginaCompras} from './Paginas/Compras/compras';
import { PaginaCarrinho } from './Paginas/Carrinho/carrinho';
import { PaginaLocalidades } from './Paginas/Localidades/localidades';
import { PaginaContacto } from './Paginas/Contacto/contacto';
import { PaginaSobre } from './Paginas/Sobre/sobre';
import { JanelaPrivacidade } from './Paginas/Definicoes/Privacidade/privacidade';
import { JanelaMinhaConta } from './Paginas/Definicoes/MinhaConta/minha-conta';
import { JanelaUtilizadores } from './Paginas/Definicoes/GerirUtilizadores/utilizadores';
import { JanelaEditarUtilizador } from './Paginas/Definicoes/EditarUtilizadores/editar-utilizador';
import { JanelaAplicacao } from './Paginas/Definicoes/Aplicacao/aplicacao';

export const routes: Routes = [
    {path:'', redirectTo:'inicial', pathMatch:'full'}, // Apenas redireciona para a página inicial quando o caminho é vazio

    {path:'inicial', component:PaginaInicial},
    {path:'viagens', component:PaginaViagens},
    
    {path:'localidades', component:PaginaLocalidades},
    {path:'contacto', component:PaginaContacto},

    {path:'definicoes', component:PaginaDefinicoes, children:[
        {path:'', redirectTo:'minha-conta', pathMatch:'full'}, //Redireciona para minha conta quando o caminho e apenas /definicoes
        {path:'minha-conta', component:JanelaMinhaConta},
        {path:'privacidade', component:JanelaPrivacidade},
        {path:'utilizadores', component:JanelaUtilizadores},
        {path:'editar-utilizador/:id', component:JanelaEditarUtilizador},
        {path:'editar-utilizador', component:JanelaEditarUtilizador}, // Como id e opcional, tambem e preciso definir rota sem id
        {path:'aplicacao', component:JanelaAplicacao},
    ]},
    {path:'carrinho', component:PaginaCarrinho},
    {path:'compras', component:PaginaCompras},
    
    {path:'criarConta', component:PaginaCriarConta},

    {path:'sobre', component:PaginaSobre}
];
