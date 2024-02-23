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
    public partial class ProfessorTela : Form
    {
        int numeror, id;
        public ProfessorTela(TelaLogin t)
        {
            numeror = t.numero;
            InitializeComponent();
        }

        private void dg1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
           
        }

        private void ProfessorTela_Load(object sender, EventArgs e)
        {
            List<Turma> u = new List<Turma>();
            ProfessorDAO p = new ProfessorDAO();
            dg1.DataSource = p.ConsultarTurmasProf(numeror);
            dg2.DataSource = p.ConsultarTurmasProf(numeror);
            label2.Visible = false;
            label3.Visible = false;
            comboBox1.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            label4.Visible = false;
            button1.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button2.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dg1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

        }

        private void dg1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int b;
            int linhas = e.RowIndex;
            int colunas = e.ColumnIndex;
            b = int.Parse(dg1.Rows[linhas].Cells[0].Value.ToString());
           
            TurmaDAO d = new TurmaDAO();
            id = b;
            dg1.DataSource = (d.ConsultarTurmaNum(b));
            label1.Text = "     selecione o aluno:";
            label2.Text = "selecione o tipo de nota:";
            label2.Visible = true;
            label3.Visible = true;
            comboBox1.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            label4.Visible = true;
            button1.Visible = true;
            dg1.Enabled = false;
            button3.Visible = true;
            button4.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = null;
            UsuarioDAO u = new UsuarioDAO();
            TurmaDAO d = new TurmaDAO();
            int a = int.Parse(textBox4.Text), num = int.Parse(textBox3.Text);
            sql = ("update matricula set Faltas = " + a + " where numero = " + num + " and identificador = " + id);
            d.Lancarnotas(sql);
            dg2.DataSource = (d.ConsultarTurmaFaltas(id));
            MessageBox.Show("Frequencia lançada.");
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            UsuarioDAO u = new UsuarioDAO();
            TurmaDAO d = new TurmaDAO();
            string valor = textBox1.Text, valor2 = textBox2.Text;
            int a, num;
            string nota = "";
            bool resultado = Int32.TryParse(valor, out a);
            bool resultado2 = Int32.TryParse(valor2, out num);
            if(resultado == false || resultado2 == false)
            {
                nota = "falsol";
            }
            else
            {
                nota = comboBox1.Text;
            }
            if(nota == "Nota 1")
            {
                nota = "nota1";
                string sql = ("update matricula set " + nota + " = " + a + " where numero = " + num + " and identificador = " + id);
                d.Lancarnotas(sql);
                dg1.DataSource = (d.ConsultarTurmaNum(id));
                MessageBox.Show("Nota lançada.");
                textBox1.Clear();
            }
            else if (valor == "")
            {
                MessageBox.Show("Digite a nota do aluno.");
            }
            else if (valor2 == "")
            {
                MessageBox.Show("Digite o número do aluno");
            }
            else if(nota == "Nota 2")
            {
                nota = "nota2";
                string sql = ("update matricula set " + nota + " = " + a + " where numero = " + num + " and identificador = " + id);
                d.Lancarnotas(sql);
                dg1.DataSource = (d.ConsultarTurmaNum(id));
                MessageBox.Show("Nota lançada.");
                textBox1.Clear();
            }
            else if(nota.Equals ("exame"))
            {
                nota = "exame";
                string sql = ("update matricula set " + nota + " = " + a + " where numero = " + num + " and identificador = " + id);
                d.Lancarnotas(sql);
                dg1.DataSource = (d.ConsultarTurmaNum(id));
                MessageBox.Show("Nota lançada.");
                textBox1.Clear();
            }
            
            else if (nota.Equals("falsol"))
            {
                MessageBox.Show("Apenas números!");
            }
            else
            {
                MessageBox.Show("Selecioe um tipo de nota!");
            }
            
            
            
        }

        private void dg2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int b;
            int linhas = e.RowIndex;
            int colunas = e.ColumnIndex;
            b = int.Parse(dg2.Rows[linhas].Cells[colunas].Value.ToString());
            TurmaDAO d = new TurmaDAO();
            id = b;
            dg2.DataSource = (d.ConsultarTurmaNum(b));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TurmaDAO d = new TurmaDAO();
            ProfessorDAO p = new ProfessorDAO();
            dg1.DataSource = p.ConsultarTurmasProf(numeror);
            dg1.Enabled = true;
            button3.Visible = false;
            button1.Visible = false;
            button4.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            comboBox1.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            label4.Visible = false;
            button2.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.ResetText();
        }

        private void ProfessorTela_FormClosed(object sender, FormClosedEventArgs e)
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

        private void dg2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int c;
            int linhas = e.RowIndex;
            int colunas = e.ColumnIndex;
            c = int.Parse(dg2.Rows[linhas].Cells[colunas].Value.ToString());
            TurmaDAO d = new TurmaDAO();
            id = c;
            dg2.DataSource = (d.ConsultarTurmaFaltas(id));
            label2.Visible = true;
            label3.Visible = true;
            comboBox1.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            label4.Visible = true;
            button1.Visible = true;
        }
    }
}
