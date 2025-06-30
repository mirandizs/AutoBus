export interface Mensagem {
  id: number;
  tipo: 'sucesso' | 'erro' | 'info' | 'aviso';
  texto: string;
}
