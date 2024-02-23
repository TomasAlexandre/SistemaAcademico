using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SistemaAcademico.Factory;
using SistemaAcademico.Model;

namespace SistemaAcademico.DAO
{
    class DisciplinaDAO
    {
        public DisciplinaDAO()
        {
            bool conexao = Conexao.AbrirConexao();

        }
        public List<Disciplina> ConsultarDis()
        {
            bool conexao = Conexao.AbrirConexao();
            Disciplina u = null;
            List<Disciplina> p = new List<Disciplina>();


            try
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM Disciplina", Conexao.getConexao());
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        u = new Disciplina();
                        u.Nome = reader.GetString("nome");
                        u.Codigo = reader.GetInt32("Codigo");
                        u.Creditos = reader.GetInt32("Creditos");
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
        public Disciplina ConsultarDisNum(int Codigo)
        {
            bool conexao = Conexao.AbrirConexao();
            Disciplina u = null;


            try
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM Disciplina WHERE codigo = "+ Codigo, Conexao.getConexao());
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        u = new Disciplina();
                        u.Nome = reader.GetString("nome");
                        u.Codigo = reader.GetInt32("Codigo");
                        u.Creditos = reader.GetInt32("Creditos");
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

            return u;

        }
        public bool CadastrarDis(Disciplina p)
        {
            try
            {
                Conexao.AbrirConexao();
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = Conexao.getConexao();

                // Use string interpolation to concatenate strings.
                string sql = $"insert into Disciplina values ({p.Codigo}, '{p.Nome}',{p.Creditos})";
                comando.CommandText = $"insert into Disciplina values ({p.Codigo}, '{p.Nome}',{p.Creditos})";
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Trata exceção
                //throw ex;
                return false;
            }
            finally
            {
                Conexao.FecharConexao();
            }
            return true;
        }
        public bool excluir(int codigo)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = Conexao.getConexao();

                string sql = "delete from disciplina where codigo =  " + codigo;
                comando.CommandText = sql;
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                return false;
            }
            finally
            {
                Conexao.FecharConexao();
            }
            return true;

        }
        public bool AlterarDis(Disciplina d, int codigo)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = Conexao.getConexao();

                string sql = "update Disciplina set Nome = '"+ d.Nome +"', Creditos = " + d.Creditos + " where codigo = " + codigo;
                comando.CommandText = sql;
                comando.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                //throw ex;
                return false;
            }
            finally
            {
                Conexao.FecharConexao();
            }
            return true;
        }
    }
}
