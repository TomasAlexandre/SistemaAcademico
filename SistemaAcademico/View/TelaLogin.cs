using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SistemaAcademico.DAO;
using SistemaAcademico.Model;

namespace SistemaAcademico.View
{
    public partial class TelaLogin : Form
    {
        public string situacao;
        public int numero;
        bool guardarlogin;
        public TelaLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void TelaLogin_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            UsuarioDAO p = new UsuarioDAO();
            Usuario u = new Usuario();
            u = p.VerificarUsuarios(txtlogin.Text);
            if (u == null)
            {
                MessageBox.Show("Usuario não existe.");
            }
            else if (u.Login.Equals(txtlogin.Text) && u.Senha.Equals(txtsenha2.Text))
            {
                if(guardarlogin == false)
                {
                    txtsenha2.Clear();
                }
                numero = u.Numero;
                if (u.Perfil.Equals("Aluno"))
                {
                    AlunoTela i = new AlunoTela(this);
                    i.Show();
                    Hide();
                }
                if(u.Perfil.Equals("Professor"))
                {
                    ProfessorTela i = new ProfessorTela(this);
                    i.Show();
                    Hide();
                }
                if ((u.Perfil.Equals("Secretaria")))
                {
                    TelaSecretaria i = new TelaSecretaria();
                    i.Botaovoltar = false;
                    i.Show();
                    Hide();
                }
                if (u.Perfil.Equals("Coordenador"))
                {
                    TelaCoordenador i = new TelaCoordenador();
                    i.Show();
                    Hide();
                }


            }


            else
            {
                MessageBox.Show("Senha inválida");
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void TelaLogin_Load_1(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            guardarlogin = checkBox1.Checked;
        }
    }
}
