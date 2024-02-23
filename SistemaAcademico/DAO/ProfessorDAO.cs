using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using SistemaAcademico.Factory;
using SistemaAcademico.Model;

namespace SistemaAcademico.DAO
{
    class ProfessorDAO
    {
        private Conexao conexao;

        public ProfessorDAO()
        {
            bool conexao = Conexao.AbrirConexao();

            //if (conexao == false)
                //MessageBox.Show("Não conectouDDD");
        }

        

        

        public void excluir(int codigo)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.getConexao();

            string sql = "delete from professor where numero =  " + codigo;
            comando.CommandText = sql;
            comando.ExecuteNonQuery();



        }

        public List<Usuario> ConsultarPro()
        {
            bool conexao = Conexao.AbrirConexao();
            Usuario u = null;
            List<Usuario> p = new List<Usuario>();


            try
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM Usuario WHERE perfil = '" + "Professor" + "'", Conexao.getConexao());
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        u = new Usuario();
                        

                        u.Numero = reader.GetInt32("numero");
                        u.Nome = reader.GetString("nome");
                        u.Login = reader.GetString("login");
                        u.Senha = reader.GetString("Senha");
                        u.Perfil = reader.GetString("Perfil");
                        u.Titulacao = reader.GetString("Titulacao");
                        p.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {
                //Trata exceção
                throw ex;
            }
            finally
            {
                Conexao.FecharConexao();
            }

            return p;

        }
        public Usuario ConsultarNum(int Numero)
        {
            bool conexao = Conexao.AbrirConexao();
            Usuario u = null;


            try
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM Usuario WHERE Numero ="+ Numero, Conexao.getConexao());
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        u = new Usuario();
                        

                        u.Numero = reader.GetInt32("numero");
                        u.Nome = reader.GetString("nome");
                        u.Login = reader.GetString("login");
                        u.Senha = reader.GetString("Senha");
                        u.Perfil = reader.GetString("Perfil");
                        u.Curso = reader.GetString("Curso");
                        u.Titulacao = reader.GetString("Titulacao");
                        

                    }
                }
            }
            catch (Exception ex)
            {

                //Trata exceção
                MessageBox.Show("Professor não existe");
                //throw ex;
            }
            finally
            {
                Conexao.FecharConexao();
            }

            return u;

        }
        public List<Turma> ConsultarTurmasProf(int numero)
        {

            bool conexao = Conexao.AbrirConexao();
            Turma u = null;
            Matricula m = new Matricula();
            List<Turma> p = new List<Turma>();

            try
            {


                MySqlCommand command = new MySqlCommand($"select identificador, semestre, ano, aluno, disciplina.nome'Disciplina' from turma, disciplina where turma.ativa = true and turma.professor = {numero}", Conexao.getConexao());
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        u = new Turma();
                        if (u.Identificador == m.Identificador)
                        {
                            u.Identificador = reader.GetInt32("Identificador");
                            u.Semestre = reader.GetInt32("Semestre");
                            u.Disciplina = Convert.ToString(reader.GetString("Disciplina"));
                            u.Ano = reader.GetInt32("Ano");
                            u.Alunos = reader.GetInt32("Aluno");
                            p.Add(u);
                        }
                        else
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //return false;
            }
            finally
            {
                Conexao.FecharConexao();
            }
            return p;
        }
    }
}
