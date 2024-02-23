using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SistemaAcademico.Factory;
using SistemaAcademico.Model;

namespace SistemaAcademico.DAO
{
    class AlunoDAO
    {
        public AlunoDAO()
        {
            bool conexao = Conexao.AbrirConexao();

            if (conexao == false)
                MessageBox.Show("Não conectouaaavv");
        }
        public List<Usuario> ConsultarAlu()
        {
            bool conexao = Conexao.AbrirConexao();
            Usuario u = null;
            List<Usuario> p = new List<Usuario>();


            try
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM Usuario WHERE perfil = '" + "Aluno" + "'", Conexao.getConexao());
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
        public Usuario ConsultarAluNum(int Numero)
        {
            bool conexao = Conexao.AbrirConexao();
            Usuario u = null;


            try
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM Usuario WHERE Numero =" + Numero, Conexao.getConexao());
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


                    }
                }
            }
            catch (Exception ex)
            {
                //Trata exceção
                MessageBox.Show("Aluno não existe");
                //throw ex;
            }
            finally
            {
                Conexao.FecharConexao();
            }

            return u;

        }

    }
}
