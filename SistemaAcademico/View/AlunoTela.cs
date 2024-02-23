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
    public partial class AlunoTela : Form
    {
        int numeror, id;
        public AlunoTela(TelaLogin t)
        {
            numeror = t.numero;
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void AlunoTela_Load(object sender, EventArgs e)
        {
          
            
            TurmaDAO p = new TurmaDAO();
            List<Turma> u = new List<Turma>();
            dg1.DataSource = p.ConsultarTurmas();
            dg2.DataSource = p.Consultarturmaaluno(numeror);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TurmaDAO p = new TurmaDAO();
            dg2.DataSource = p.Consultarturmaaluno(numeror);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Matricula m = new Matricula();
            UsuarioDAO d = new UsuarioDAO();
            m = d.ConsultarMatricula(numeror, int.Parse(txtcodigo.Text));
            if (m == null) {
                if (d.Matricular(numeror, int.Parse(txtcodigo.Text)))
                {

                    MessageBox.Show("Matricula realizada com sucesso.");
                    txtcodigo.Clear();
                }
                else
                {
                    MessageBox.Show("Essa turma nao existe.");
                }
            }
            else
            {
                MessageBox.Show("você já está matriculado.");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            TurmaDAO p = new TurmaDAO();
            dg2.DataSource = p.Consultarturmaaluno(numeror);
            btVoltar.Visible = false;
            dg2.Enabled = true;
        }

        private void dg2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void AlunoTela_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach(Form form in Application.OpenForms)
            {
                if(form is TelaLogin)
                {
                    Hide();
                    form.Show();
                    break;
                }
            }
        }

        private void dg2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int b;
            int linhas = e.RowIndex;
            int colunas = e.ColumnIndex;
            b = int.Parse(dg2.Rows[linhas].Cells[0].Value.ToString());
            id = b;
            TurmaDAO dao = new TurmaDAO();
            dg2.DataSource = dao.ConsultarTurmaNumAlu(id, numeror);
            dg2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg2.Enabled = false;
            btVoltar.Visible = true;
        }
    }
}
