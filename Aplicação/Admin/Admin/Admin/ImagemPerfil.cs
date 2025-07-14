using System;
using System.Windows.Forms;

namespace Admin
{
  public partial class ImagemPerfil : Form
  {
    private PictureBox ImagemSelecionada;

    public string CaminhoImagemSelecionada { get; private set; }

    private readonly string pastaImagens = @"C:\Users\sofia\Desktop\pap\AutoBus\Admin\Admin\Admin\bin\Debug\img\utilizadores";

    public ImagemPerfil(PictureBox destino)
    {
      InitializeComponent();
      this.ImagemSelecionada = destino;
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
      ImagemSelecionada.Image = pictureBox1.Image;
      CaminhoImagemSelecionada = System.IO.Path.Combine(pastaImagens, "utilizador2.png");
      this.Close();
    }

    private void pictureBox2_Click(object sender, EventArgs e)
    {
      ImagemSelecionada.Image = pictureBox2.Image;
      CaminhoImagemSelecionada = System.IO.Path.Combine(pastaImagens, "utilizador7.png");
      this.Close();
    }

    private void pictureBox3_Click(object sender, EventArgs e)
    {
      ImagemSelecionada.Image = pictureBox3.Image;
      CaminhoImagemSelecionada = System.IO.Path.Combine(pastaImagens, "utilizador3.png");
      this.Close();
    }

    private void pictureBox4_Click(object sender, EventArgs e)
    {
      ImagemSelecionada.Image = pictureBox4.Image;
      CaminhoImagemSelecionada = System.IO.Path.Combine(pastaImagens, "utilizador10.png");
      this.Close();
    }

    private void pictureBox5_Click(object sender, EventArgs e)
    {
      ImagemSelecionada.Image = pictureBox5.Image;
      CaminhoImagemSelecionada = System.IO.Path.Combine(pastaImagens, "utilizador15.png");
      this.Close();
    }

    private void pictureBox6_Click(object sender, EventArgs e)
    {
      ImagemSelecionada.Image = pictureBox6.Image;
      CaminhoImagemSelecionada = System.IO.Path.Combine(pastaImagens, "utilizador14.png");
      this.Close();
    }

    private void pictureBox7_Click(object sender, EventArgs e)
    {
      ImagemSelecionada.Image = pictureBox7.Image;
      CaminhoImagemSelecionada = System.IO.Path.Combine(pastaImagens, "utilizador4.png");
      this.Close();
    }

    private void pictureBox8_Click(object sender, EventArgs e)
    {
      ImagemSelecionada.Image = pictureBox8.Image;
      CaminhoImagemSelecionada = System.IO.Path.Combine(pastaImagens, "utilizador8.png");
      this.Close();
    }

    private void pictureBox9_Click(object sender, EventArgs e)
    {
      ImagemSelecionada.Image = pictureBox9.Image;
      CaminhoImagemSelecionada = System.IO.Path.Combine(pastaImagens, "utilizador9.png");
      this.Close();
    }

    private void pictureBox10_Click(object sender, EventArgs e)
    {
      ImagemSelecionada.Image = pictureBox10.Image;
      CaminhoImagemSelecionada = System.IO.Path.Combine(pastaImagens, "utilizador5.png");
      this.Close();
    }

    private void pictureBox11_Click(object sender, EventArgs e)
    {
      ImagemSelecionada.Image = pictureBox11.Image;
      CaminhoImagemSelecionada = System.IO.Path.Combine(pastaImagens, "utilizador12.png");
      this.Close();
    }

    private void pictureBox12_Click(object sender, EventArgs e)
    {
      ImagemSelecionada.Image = pictureBox12.Image;
      CaminhoImagemSelecionada = System.IO.Path.Combine(pastaImagens, "utilizador11.png");
      this.Close();
    }

    private void pictureBox13_Click(object sender, EventArgs e)
    {
      ImagemSelecionada.Image = pictureBox13.Image;
      CaminhoImagemSelecionada = System.IO.Path.Combine(pastaImagens, "utilizador13.png");
      this.Close();
    }

    private void pictureBox14_Click(object sender, EventArgs e)
    {
      ImagemSelecionada.Image = pictureBox14.Image;
      CaminhoImagemSelecionada = System.IO.Path.Combine(pastaImagens, "utilizador6.png");
      this.Close();
    }

    private void pictureBox15_Click(object sender, EventArgs e)
    {
      ImagemSelecionada.Image = pictureBox15.Image;
      CaminhoImagemSelecionada = System.IO.Path.Combine(pastaImagens, "utilizador.png");
      this.Close();
    }

    private void btSair_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void btSair_MouseHover_1(object sender, EventArgs e)
    {
      btSair.BackgroundImage = Properties.Resources.xB;
    }

    private void btSair_MouseLeave(object sender, EventArgs e)
    {
      btSair.BackgroundImage = Properties.Resources.x;
    }
  }
}
