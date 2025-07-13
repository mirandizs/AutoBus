using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
  public class DadosUtilizador
  {
    public int id_utilizador { get; set; }
    public int nif { get; set; }
    public string nome { get; set; }
    public string email { get; set; }
    public int telefone { get; set; }
    public string localidade { get; set; }
    public DateTime nascimento { get; set; }
    public string password { get; set; }
    public string tipo_utilizador { get; set; }
    public string atividade { get; set; }
  }
}
