using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin
{
  public class Funcoes
  {
    DadosUtilizador utilizador = new DadosUtilizador();

    public void UploadImagem(string caminhoOriginal, int nif)
    {
      string pastaDestino = @"C:\Users\sofia\Desktop\pap\ServidorAutoBus\Servidor\Uploads";

      try
      {
        string extensao = Path.GetExtension(caminhoOriginal);
        string nomeFicheiro = nif.ToString() + extensao;
        string destino = Path.Combine(pastaDestino, nomeFicheiro);


        File.Copy(caminhoOriginal, destino, true);

        MessageBox.Show("Imagem carregada e copiada com sucesso!", "AutoBus", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception ex)
      {
        MessageBox.Show("Erro ao copiar imagem: " + ex.Message);
      }
    }
  }
}
