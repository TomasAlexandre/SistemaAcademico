using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SistemaAcademico.Factory;
using SistemaAcademico.Model;
using SistemaAcademico.View;

namespace SistemaAcademico.DAO
{
    class UsuarioDAO
    {
        public UsuarioDAO()
        {
            bool conexao = Conexao.AbrirConexao();

            //if (conexao == false)
            //MessageBox.Show("Não conectouAAAA");
        }

        public void VerificarLogin()
        {
            try
            {
                Usuario p = new Usuario();
                MySqlCommand command = new MySqlCommand($"SELECT * FROM Usuario WHERE login = '{p.Login}' and senha = '{p.Senha}'", Conexao.getConexao());
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        p.Perfil = reader.GetString("perfil");

                    }

                }
            }
            catch (Exception ex)
            {
                //Trata exceção
                throw ex;
            }
            return;
        }
        public bool Cadastrarusuario(Usuario p)
        {
            try
            {
                Conexao.AbrirConexao();
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = Conexao.getConexao();

                // Use string interpolation to concatenate strings.
                string sql = $"insert into Usuario values ({p.Numero}, '{p.Nome}','{p.Login}', '{p.Senha}', '{p.Perfil}', '{p.Curso}', '{p.Titulacao}')";
                comando.CommandText = $"insert into Usuario values ({p.Numero}, '{p.Nome}','{p.Login}', '{p.Senha}', '{p.Perfil}', '{p.Curso}', '{p.Titulacao}')";
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

        public Usuario VerificarUsuarios(string login)
        {
            Usuario usuario = null;


            try
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM usuario WHERE login = '" + login + "'", Conexao.getConexao());
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        usuario = new Usuario();
                        usuario.Numero = reader.GetInt32("numero");
                        usuario.Login = reader.GetString("login");
                        usuario.Senha = reader.GetString("senha");
                        usuario.Perfil = reader.GetString("perfil");
                    }
                }
            }
            catch (Exception ex)
            {
                //Trata exceção
                //throw ex;
                MessageBox.Show(" não foi possivel conectar com o banco de dados.");
            }
            finally
            {
                Conexao.FecharConexao();
            }

            return usuario;

        }
        public List<Usuario> ConsultarUsuarios()
        {
            bool conexao = Conexao.AbrirConexao();
            Usuario u = new Usuario();
            List<Usuario> p = new List<Usuario>();

            try
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM Usuario WHERE perfil = 'Aluno' or perfil = 'Professor';", Conexao.getConexao());
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        u = new Usuario();
                        u.Numero = reader.GetInt32("numero");
                        u.Nome = reader.GetString("nome");
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
        public Usuario ConsultarUsuNum(int Numero)
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
                throw ex;
            }
            finally
            {
                Conexao.FecharConexao();
            }
            return u;
        }

        public void IncluirUsu(Usuario p)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.Connection = Conexao.getConexao();

            // Use string interpolation to concatenate strings.
            string sql = $"insert into professor values ({p.Numero}, '{p.Nome}','{p.Login}', '{p.Senha}', '{p.Perfil}','{p.Curso}', '{p.Titulacao})";
            comando.CommandText = $"insert into professor values ({p.Numero}, '{p.Nome}','{p.Login}', '{p.Senha}', '{p.Perfil}', '{p.Curso}', '{p.Titulacao})";
            comando.ExecuteNonQuery();
            MessageBox.Show(sql);

        }
        public bool excluir(int codigo)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = Conexao.getConexao();

                string sql = "delete from usuario where numero =  " + codigo;
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
        //719214 was here
        public bool Alterar(Usuario u, int numero)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = Conexao.getConexao();
                string sql = "update usuario set nome = '" + u.Nome + "', login = '" + u.Login + "', senha = '" + u.Senha + "', perfil = '" + u.Perfil + "', Curso = '" + u.Curso + "', Titulacao = '" + u.Titulacao + "' where numero = " + numero;
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
        public Usuario ConsultarproNum(int Numero)
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

                        u.Perfil = reader.GetString("Perfil");



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
        public bool Matricular(int numero, int identificador)
        {
            Conexao.AbrirConexao();
            try
            {

                MySqlCommand command = new MySqlCommand($"insert into matricula values ({numero}, {identificador}, 0, 0, 0, 0, false)", Conexao.getConexao());
                command.Connection = Conexao.getConexao();
                command.ExecuteNonQuery();

            }

            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                MySqlCommand command2 = new MySqlCommand("update turma set aluno = aluno + 1 where identificador = " + identificador, Conexao.getConexao());
                command2.Connection = Conexao.getConexao();
                command2.ExecuteNonQuery();
                Conexao.FecharConexao();
            }

            return true;
        }
        public Matricula ConsultarMatricula(int numero, int identificador)
        {
            Matricula m = null;
            try
            {

                MySqlCommand command = new MySqlCommand($"select * from matricula where numero = {numero} and identificador = {identificador}");
                command.Connection = Conexao.getConexao();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        m = new Matricula();
                        m.Numero = reader.GetInt32("numero");
                        m.Identificador = reader.GetInt32("identificador");
                        m.Nota1 = reader.GetInt32("nota1");
                        m.Nota2 = reader.GetInt32("nota2");
                        m.Falta = reader.GetInt32("faltas");
                        m.Exame = reader.GetInt32("exame");

                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conexao.FecharConexao();
            }
            return m;
        }
        //public Aluno CalcularNota(int numalu, int numid)
        //{
        //    Conexao.AbrirConexao();
        //    Aluno u = new Aluno();
        //    try
        //    {
        //        MySqlCommand command = new MySqlCommand("SELECT nota1, nota2, exame, faltas, aprovado  from matricula, usuario where matricula.numero = " + numalu + " and identificador = " + numid);
        //        command.Connection = Conexao.getConexao();
        //        719214 was here
        //        MySqlDataReader reader = command.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                u.Nota1 = reader.GetDouble("nota1");
        //                u.Nota2 = reader.GetDouble("nota2");
        //                u.Exame = reader.GetDouble("exame");
        //                u.Faltas = reader.GetInt32("faltas");

        //            }

        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        Conexao.FecharConexao();
        //    }
        //    return u;
        //}
        //public Aluno CalcularNota2(int num, int id)
        //{
        //    Conexao.AbrirConexao();
        //    Aluno u = new Aluno();
        //    if (u.Nota1 + u.Nota2 + u.Exame >= 60)
        //    {
        //        MySqlCommand command2 = new MySqlCommand("update matricula set aprovado = true where matricula.numero = " + num+" and identificador = " + id, Conexao.getConexao());
        //        command2.Connection = Conexao.getConexao();
        //        command2.ExecuteNonQuery();
        //    }
        //    else
        //    {
        //        MySqlCommand command2 = new MySqlCommand("update matricula set aprovado = false  where matricula.numero = " + num+ " and identificador = " + id, Conexao.getConexao());
        //        command2.Connection = Conexao.getConexao();
        //        command2.ExecuteNonQuery();
        //    }
        //    Conexao.FecharConexao();
        //    return u;
        //}

        public List<Usuario> ConsultarUsuNumListaNum(int Numero)
        {
            bool conexao = Conexao.AbrirConexao();
            Usuario u = null;
            List<Usuario> p = new List<Usuario>();
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM Usuario WHERE Numero like '" + Numero+"' ", Conexao.getConexao());
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        u = new Usuario();
                        u.Numero = reader.GetInt32("numero");
                        u.Nome = reader.GetString("nome");
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
        public List<Usuario> ConsultarUsuNumListaNomm(string nome)
        {
            bool conexao = Conexao.AbrirConexao();
            Usuario u = null;
            List<Usuario> p = new List<Usuario>();
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM Usuario WHERE nome like '" + nome+"%' ", Conexao.getConexao());
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        u = new Usuario();
                        u.Numero = reader.GetInt32("numero");
                        u.Nome = reader.GetString("nome");
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
    }
}

