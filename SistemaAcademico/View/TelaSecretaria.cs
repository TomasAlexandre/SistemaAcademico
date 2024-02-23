using SistemaAcademico.DAO;
using SistemaAcademico.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaAcademico.View
{
    public partial class TelaSecretaria : Form
    {
        bool botaovoltar;

        public bool Botaovoltar { get => botaovoltar; set => botaovoltar = value; }

        public TelaSecretaria()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void professorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                Usuario u = new Usuario();
                UsuarioDAO p = new UsuarioDAO();
            u = new Usuario();
            bool resultado, verificacao = true;
            resultado = Int32.TryParse(txtnum.Text, out int i);
            if(resultado == true)
            {
                u.Numero = int.Parse(txtnum.Text);
            }
            else
            {
                verificacao = false;
                MessageBox.Show("Número só pode ter números");
            }
            u.Nome = txtnom.Text;
            u.Login = txtlog.Text;
            u.Senha = txtsen.Text;
            u.Perfil = comboBox1.Text;
            u.Curso = txtCur.Text;
            u.Titulacao = txtTit.Text;
            if(verificacao == true)
            {
                if (u.Perfil.Equals(""))
                    MessageBox.Show("Selecione um Perfil");
                else if (u.Perfil.Equals("Aluno"))
                {
                    u.Titulacao = null;
                    if (p.Cadastrarusuario(u))
                    {
                        MessageBox.Show("Usuário adicionado.");
                        txtnum.Clear();
                        txtsen.Clear();
                        txtlog.Clear();
                        txtnom.Clear();
                        txtCur.Clear();
                        txtTit.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Numero ou login de usuário já está em uso.");
                    }
                }
                else if (u.Perfil.Equals("Professor"))
                {
                    u.Curso = null;
                    if (p.Cadastrarusuario(u))
                    {
                        MessageBox.Show("Usuário adicionado.");
                        txtnum.Clear();
                        txtsen.Clear();
                        txtlog.Clear();
                        txtnom.Clear();
                        txtCur.Clear();
                        txtTit.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Numero ou login de usuário já está em uso.");
                    }
                }
            }
            else
            {
            }
            
        
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ProfessorDAO p = new ProfessorDAO();
            dg.DataSource = p.ConsultarPro();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AlunoDAO u = new AlunoDAO();
            dg.DataSource = u.ConsultarAlu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DisciplinaDAO p = new DisciplinaDAO();
            dg.DataSource = p.ConsultarDis();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string j = textBox1.Text;
            List<Usuario> p = new List<Usuario>();
            ProfessorDAO u = new ProfessorDAO();
            p.Add(u.ConsultarNum(int.Parse(textBox1.Text)));
            dg.DataSource = p;
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            List<Usuario> p = new List<Usuario>();
            AlunoDAO u = new AlunoDAO();
            p.Add(u.ConsultarAluNum(int.Parse(textBox1.Text)));
            dg.DataSource = p;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            DisciplinaDAO p = new DisciplinaDAO();
            List<Disciplina> u = new List<Disciplina>();
            u.Add(p.ConsultarDisNum(int.Parse(textBox2.Text)));
            dg.DataSource = u;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Disciplina d = new Disciplina();
            DisciplinaDAO p = new DisciplinaDAO();
            bool verificacao = true, resultado;
            resultado = Int32.TryParse(textBox3.Text, out int i);
            if (resultado == true)
            {
                d.Codigo = int.Parse(textBox3.Text);
            }
            else
            {
                verificacao = false;
                MessageBox.Show("Código só recebe números!");
            }
            d.Nome = textBox4.Text;
            //resultado = Int32.TryParse(textBox13.Text, out int i);
            //if(resultado == true)
            //{
            //    d.Creditos = int.Parse(textBox13.Text);
            //}
            //else
            //{
            //    verificacao = false;
            //    MessageBox.Show("Créditos só tem números!");
            //}
            d.Creditos = comboBox2.SelectedIndex;
            if (verificacao == true)
            {
                if (p.CadastrarDis(d))
                {
                    MessageBox.Show("Disciplina Cadastrada.");
                    txtCreditos.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                }
                else
                {
                    MessageBox.Show("Não foi possível Cadastrar a disciplina");
                }
            }
            else
            {

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            UsuarioDAO p = new UsuarioDAO();
            if (p.excluir(int.Parse(textBox15.Text)))
            {
                UsuarioDAO d = new UsuarioDAO();
                MessageBox.Show("Usuário excluido.");
                textBox5.ResetText();

                dg1.DataSource = d.ConsultarUsuarios();

                dg1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg1.Columns[2].Visible = false;
                dg1.Columns[3].Visible = false;
                dg1.Columns[4].Visible = false;
                dg1.Columns[5].Visible = false;
                dg1.Columns[6].Visible = false;

                
            }
            else
            {
                MessageBox.Show("Não foi possível excluir o usuário.");
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            DisciplinaDAO p = new DisciplinaDAO();
            if (p.excluir(int.Parse(textBox5.Text)))
            {
                DisciplinaDAO ds = new DisciplinaDAO();
                MessageBox.Show("Disciplina excluida.");
                textBox5.Text = "";

                dg2.DataSource = ds.ConsultarDis();

                dg2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                MessageBox.Show("Não foi possível excluir a disciplina.");
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario();
            UsuarioDAO p = new UsuarioDAO();
            u.Nome = txtnomalt.Text;
            u.Login = txtlogalt.Text;
            u.Senha = txtsenalt.Text;
            u.Perfil = comperalt.Text;
            u.Titulacao = txttitalt.Text;
            u.Curso = txtcuralt.Text;
            if (u.Perfil.Equals("Professor"))
            {
                u.Curso = null;
            }
            if (u.Perfil.Equals("Aluno"))
            {
                u.Titulacao = null;
            }
            if (p.Alterar(u, int.Parse(txtNumUsu.Text)))
            {
                txtnomalt.Clear();
                txtlogalt.Clear();
                txtsenalt.Clear();
                txttitalt.Clear();
                txtcuralt.Clear();
                MessageBox.Show("Usuário alterado.");
            }
            else
            {
                MessageBox.Show("Não foi possível alterar o usuário, confira o número e o login");
            }
            
        }

        private void comperalt_KeyPress(object sender, KeyPressEventArgs e)
        {
           e.Handled = true;
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            Disciplina u = new Disciplina();
            DisciplinaDAO p = new DisciplinaDAO();
            u.Nome = txtNomDis.Text;
            u.Creditos = int.Parse(txtCreditos.Text);
            u.Codigo = int.Parse(textBox6.Text);
            if (p.AlterarDis(u, int.Parse(textBox6.Text)))
            {
                MessageBox.Show("Disciplina alterada.");
                txtCreditos.ResetText();
                txtNomDis.ResetText();
                textBox6.ResetText();
            }
            else MessageBox.Show("Não foi possível alterar a disciplina, confira o código.");
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            
            TurmaDAO d = new TurmaDAO();
            string ano, disciplina, semestre;
            string identificador;
            if(txtano.Text == "")
            {
                 ano = " != -1 ";
            }
            else
            {
                 ano = " = "+txtano.Text;
            }

            if (txtdis.Text == "")
            {
                disciplina = " != -1";
            }
            else
            {
                disciplina = " = '"+txtdis.Text+"' ";
            }

            if(txtsem.Text == "")
            {
                semestre = " != -1";
            }
            else
            {
                semestre = " = " + txtsem.Text;
            }
            if (txtid.Text.Equals(""))
            {
                identificador = " != -1 ";
            }
            else
            {
                identificador = " = "+(txtid.Text);
            }
            
            dg3.DataSource = d.ExibirTurmasSec(identificador, ano, semestre, disciplina);

        }

        private void TelaSecretaria_Load(object sender, EventArgs e)
        {
            TelaLogin t = new TelaLogin();
            UsuarioDAO d = new UsuarioDAO();
            DisciplinaDAO ds = new DisciplinaDAO();
            if(Botaovoltar == true)
            {
                button13.Visible = true;
            }
            else
            {
                button13.Visible = false;
            }
            t.Hide();
            dg1.DataSource = d.ConsultarUsuarios();

            dg1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg1.Columns[2].Visible = false;
            dg1.Columns[3].Visible = false;
            dg1.Columns[4].Visible = false;
            dg1.Columns[5].Visible = false;
            dg1.Columns[6].Visible = false;


            dg2.DataSource = ds.ConsultarDis();

            dg2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dg3_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TurmaDAO d = new TurmaDAO();
            int b;
            int linhas = e.RowIndex;
            int colunas = e.ColumnIndex;
            b = int.Parse(dg3.Rows[linhas].Cells[0].Value.ToString());
            dg4.DataSource = d.ExibirAlunosSec(b);
            dg4.Columns[2].Visible = false;
            dg4.Columns[3].Visible = false;
            dg4.Columns[4].Visible = false;
            dg4.Columns[5].Visible = false;
            dg4.Columns[6].Visible = false;
            dg4.Columns[7].Visible = false;
            dg4.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg4.Columns[1].Width = 350;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            TurmaDAO d = new TurmaDAO();
            if(txtnumero.Text == "")
            {
                txtnumero.Text = "";
            }
            else
            {
                dg5.DataSource = d.ConsultarAlunosSecNum(int.Parse(txtnumero.Text));
                dg5.Columns[2].Visible = false;
                dg5.Columns[3].Visible = false;
                dg5.Columns[4].Visible = false;
                dg5.Columns[5].Visible = false;
                dg5.Columns[6].Visible = false;
                dg5.Columns[7].Visible = false;
                dg5.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg5.Columns[1].Width = 350;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            txtano.Clear();
            txtsem.Clear();
            txtid.Clear();
            txtdis.Clear();
        }

        private void txtano_TextChanged(object sender, EventArgs e)
        {
        }

        private void dg3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtnome_TextChanged(object sender, EventArgs e)
        {
            TurmaDAO d = new TurmaDAO();
            if (txtnome.Text == "")
            {
                txtnome.Text = "";
            }
            else
            {
                dg5.DataSource = d.ConsultarAlunosSecNom(txtnome.Text);
                dg5.Columns[2].Visible = false;
                dg5.Columns[3].Visible = false;
                dg5.Columns[4].Visible = false;
                dg5.Columns[5].Visible = false;
                dg5.Columns[6].Visible = false;
                dg5.Columns[7].Visible = false;
                dg5.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg5.Columns[1].Width = 350;
            }
        }

        private void dg5_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TurmaDAO d = new TurmaDAO();
            int b;
            int linhas = e.RowIndex;
            int colunas = e.ColumnIndex;
            b = int.Parse(dg5.Rows[linhas].Cells[0].Value.ToString());
            dg5.DataSource = d.ConsultarTurmasSec(b);
            dg5.Columns[0].Visible = false;
            dg5.Columns[1].Visible = true;
            dg5.Columns[2].Visible = true;
            dg5.Columns[3].Visible = true;
            dg5.Columns[4].Visible = true;
            dg5.Columns[5].Visible = true;
            dg5.Columns[6].Visible = true;
            dg5.Columns[7].Visible = true;
        }

        private void dg5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TelaSecretaria_FormClosed(object sender, FormClosedEventArgs e)
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

        private void button13_Click(object sender, EventArgs e)
        {
            TelaLogin t = new TelaLogin();
            TelaCoordenador tc = new TelaCoordenador();
            tc.Show();
            this.Hide();
            t.Hide();
            button13.Visible = false;
        }
    }
    
}
