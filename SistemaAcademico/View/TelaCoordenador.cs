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
    public partial class TelaCoordenador : Form
    {
        int identificador;
        public TelaCoordenador()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TelaLogin t = new TelaLogin();
            TelaSecretaria p = new TelaSecretaria();
            p.Botaovoltar = true;
            p.Show();
            this.Hide();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Turma p = new Turma();
            TurmaDAO u = new TurmaDAO();
            UsuarioDAO j = new UsuarioDAO();
            bool resultado = Int32.TryParse(txtide.Text, out int ide);
            bool teste = true;
            if(resultado == true)
            {
                
                p.Identificador = int.Parse(txtide.Text);
            }
            else
            {
                teste = false;
                MessageBox.Show("Identificador só pode ter números!");
            }
            resultado = Int32.TryParse(txtnum.Text, out int num);
            if(resultado == true)
            {
                p.Professor = (txtnum.Text);
            }
            else
            {
                teste = false;
                MessageBox.Show("Professor só pode ter números!");
            }
            resultado = Int32.TryParse(txtano.Text, out int ano);
            if(resultado == true)
            {
                p.Ano = int.Parse(txtano.Text);
            }
            else
            {
                teste = false;
                MessageBox.Show("Ano só pode ter números!");
            }
            resultado = Int32.TryParse(txtdis.Text, out int dis);
            if(resultado == true)
            {
                p.Disciplina = (txtdis.Text);
            }
            else
            {
                teste = false;
                MessageBox.Show("Disciplina só pode ter números!");
            }
            resultado = Int32.TryParse(txtsem.Text, out int sem);
            if(resultado == true)
            {
                p.Semestre = int.Parse(txtsem.Text);
            }
            else
            {
                teste = false;
                MessageBox.Show("Semestre só pode ter números!");
            }
            if(teste == true)
            {
                Usuario i = new Usuario();
                i = j.ConsultarproNum(int.Parse(txtnum.Text));
                if (i.Perfil.Equals("Professor"))
                {


                    if (u.CriarTurma(p))
                    {
                        MessageBox.Show("Turma criada.");
                        txtdis.Clear();
                        txtano.Clear();
                        txtide.Clear();
                        txtnum.Clear();
                        txtsem.Clear();
                        TurmaDAO l = new TurmaDAO();
                        dg3.DataSource = l.ConsultarTurmasCoordenador();
                    }
                    else
                    {
                        MessageBox.Show("Escolha outro identificador para a turma");
                    }

                }
                else
                {
                    MessageBox.Show("Professor inválido.");

                }
            }
            else
            {
                
            }
            

        }

        private void TelaCoordenador_Load(object sender, EventArgs e)
        {
            TelaLogin t = new TelaLogin();
            ProfessorDAO p = new ProfessorDAO();
            dg2.DataSource = p.ConsultarPro();
            DisciplinaDAO u = new DisciplinaDAO();
            dg1.DataSource = u.ConsultarDis();
            TurmaDAO i = new TurmaDAO();
            dg3.DataSource = i.ConsultarTurmasCoordenador();
            t.Hide();
        }

        private void dg2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id2 = txtidentificador.Text;
            bool test = Int32.TryParse(id2, out int id);
            if (test == true)
            {
                TurmaDAO d = new TurmaDAO();
                if (d.DesativarTurmas(id))
                {
                    List<Aluno> listinha = new List<Aluno>();
                    listinha = d.ListaDeAlunos(id);
                    for (int i = 0; i < listinha.Count; i++)
                    {
                        if (d.CalcularAlunos(listinha[i], int.Parse(txtidentificador.Text)))
                        {
                            if (i == listinha.Count - 1)
                            {
                                MessageBox.Show("Turma fechada.");
                                txtidentificador.Clear();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível fechar a turma.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possível fechar a turma.");
                }
            }
            else
            {
                MessageBox.Show("Apenas números!");
            }
            
        }

        private void TelaCoordenador_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is TelaLogin)
                {
                    Hide();
                    form.Show();
                    break;
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
