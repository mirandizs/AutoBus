using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin
{
    public partial class ImagemPerfil: Form
    {
        private PictureBox ImagemSelecionada;

        public ImagemPerfil(PictureBox destino)
        {
            InitializeComponent();
            this.ImagemSelecionada = destino;
        }


        //definicao das imagens
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ImagemSelecionada.Image = pictureBox1.Image;
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ImagemSelecionada.Image = pictureBox2.Image;
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ImagemSelecionada.Image = pictureBox3.Image;
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ImagemSelecionada.Image = pictureBox4.Image;
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ImagemSelecionada.Image = pictureBox5.Image;
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ImagemSelecionada.Image = pictureBox6.Image;
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            ImagemSelecionada.Image = pictureBox7.Image;
            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ImagemSelecionada.Image = pictureBox8.Image;
            this.Close();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {   
            ImagemSelecionada.Image = pictureBox9.Image;
            this.Close();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            ImagemSelecionada.Image = pictureBox10.Image;
            this.Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            ImagemSelecionada.Image = pictureBox11.Image;
            this.Close();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            ImagemSelecionada.Image = pictureBox12.Image;
            this.Close();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            ImagemSelecionada.Image = pictureBox13.Image;
            this.Close();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            ImagemSelecionada.Image = pictureBox4.Image;
            this.Close();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            ImagemSelecionada.Image = pictureBox15.Image;
            this.Close();
        }


        //botao de sair
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
