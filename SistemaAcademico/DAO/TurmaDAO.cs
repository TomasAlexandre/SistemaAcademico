using MySql.Data.MySqlClient;
using SistemaAcademico.Factory;
using SistemaAcademico.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SistemaAcademico.DAO
{

    class TurmaDAO
    {
        int cargahoraria;
        private Conexao conexao;
        public TurmaDAO()
        {
            bool conexao = Conexao.AbrirConexao();

            //if (conexao == false)
            //    MessageBox.Show("Nãaaaaa");
        }

        public bool CriarTurma(Turma p)
        {
            try
            {
                    Conexao.AbrirConexao();
                    MySqlCommand comando = new MySqlCommand();
                    comando.Connection = Conexao.getConexao();

                    string sql = $"insert into Turma values ({p.Identificador}, {p.Semestre}, {p.Ano}, {true}, {p.Professor}, 0, {p.Disciplina})";
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
        public List<Turma> ConsultarTurmas()
        {

            Conexao.AbrirConexao();
            Turma u = null;
            Matricula m = new Matricula ();
            List<Turma> p = new List<Turma>();
            try
            {


                MySqlCommand command = new MySqlCommand($"select turma.identificador'identificador', usuario.nome'professor',  disciplina.nome'Disciplina', ano'ano',semestre'semestre', aluno'alunos' from Turma, usuario, disciplina where usuario.numero = turma.professor and disciplina.codigo = turma.disciplina and turma.ativa = true and aluno < 50;", Conexao.getConexao());
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        u = new Turma();
                        if (u.Identificador == m.Identificador)
                        {
                            u.Identificador = reader.GetInt32("identificador");
                            u.Professor = reader.GetString("professor");
                            u.Semestre = reader.GetInt32("Semestre");
                            u.Disciplina = reader.GetString("Disciplina");
                            u.Ano = reader.GetInt32("Ano");
                            u.Alunos = reader.GetInt32("Alunos");
                            p.Add(u);
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
        public Usuario ConsultarProf(int Numero)
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

                        u.Nome = reader.GetString("nome");
                        
                    }
                }
            }
            catch (Exception ex)
            {

                //Trata exceção
                throw ex;
            }

            return u;
        }

        public TurmaExibir ConsultarDiscNum(int Codigo)
        {
            bool conexao = Conexao.AbrirConexao();
            TurmaExibir u = null;


            try
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM Disciplina WHERE codigo = " + Codigo, Conexao.getConexao());
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        u = new TurmaExibir();
                        u.Nome = reader.GetString("nome");

                    }
                }
            }
            catch (Exception ex)
            {
                //Trata exceção
                throw ex;
            }

            return u;

        }
        public List<Aluno> ConsultarTurmaNum(int identificador)
        {
            bool conexao = Conexao.AbrirConexao();
            Aluno u = null;
            List<Aluno> p = new List<Aluno>();
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT matricula.numero'numero', usuario.nome'nome', nota1, nota2, exame, faltas, aprovado  from matricula, usuario where matricula.numero = usuario.numero and identificador = " + identificador, Conexao.getConexao());
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        u = new Aluno();
                        u.Numero = reader.GetInt32("numero");
                        u.Nome = reader.GetString("nome");
                        u.Nota1 = reader.GetDouble("nota1");
                        u.Nota2 = reader.GetDouble("nota2");
                        u.Exame = reader.GetDouble("exame");
                        u.Faltas = reader.GetInt32("faltas");
                        p.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexao.FecharConexao();
            }
            return p;
        }
        public bool Lancarnotas(string sql)
        {
            Conexao.AbrirConexao();
            try
            {
                MySqlCommand command = new MySqlCommand(sql, Conexao.getConexao());
                command.Connection = Conexao.getConexao();
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexao.FecharConexao();
            }
            return true;
        }
        public List<AlunoExibir> ConsultarTurmaFaltas(int identificador)
        {
            bool conexao = Conexao.AbrirConexao();
            AlunoExibir u = null;
            List<AlunoExibir> p = new List<AlunoExibir>();
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT matricula.numero'numero', usuario.nome'nome', faltas  from matricula, usuario where matricula.numero = usuario.numero and identificador = " + identificador, Conexao.getConexao());
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        u = new AlunoExibir();
                        u.Num = reader.GetInt32("numero");
                        u.Nome = reader.GetString("nome");
                        u.Faltas = reader.GetInt32("faltas");
                        p.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexao.FecharConexao();
            }
            return p;
        }

        public List<Turma> Consultarturmaaluno(int num)
        {
            Conexao.AbrirConexao();
            Turma u = null;
            UsuarioDAO y = new UsuarioDAO();
            Usuario j = new Usuario();
            List<Turma> p = new List<Turma>();
            //aaa
            try
            {
                MySqlCommand command = new MySqlCommand($"select * from matricula, turma where matricula.numero = {num} and matricula.identificador = turma.identificador", Conexao.getConexao());
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        u = new Turma();
                        
                        u.Identificador = reader.GetInt32("Identificador");
                        u.Professor = Convert.ToString(reader.GetInt32("professor"));
                        u.Semestre = reader.GetInt32("Semestre");
                        u.Disciplina = reader.GetString("Disciplina");
                        u.Ano = reader.GetInt32("Ano");
                        p.Add(u);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexao.FecharConexao();
            }
            return p;
        }
        public List<DadosAlunos> ConsultarTurmaNumAlu(int num, int identificador)
        {
            bool conexao = Conexao.AbrirConexao();
            DadosAlunos u = null;
            List<DadosAlunos> p = new List<DadosAlunos>();
            try
            {
                MySqlCommand command = new MySqlCommand($"SELECT matricula.numero, usuario.nome, nota1, nota2, exame, faltas from matricula, usuario where matricula.numero = usuario.numero and identificador = {num} and matricula.numero = {identificador}", Conexao.getConexao());
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        u = new DadosAlunos();
                        u.Nota1 = reader.GetDouble("nota1");
                        u.Nota2 = reader.GetDouble("nota2");
                        u.Exame = reader.GetInt32("exame");
                        u.Faltas = reader.GetInt32("faltas");
                        p.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexao.FecharConexao();
            }
            return p;
        }
        public List<Turma> ConsultarTurmasCoordenador()
        {
            Turma u = new Turma();
            List<Turma> p = new List<Turma>();
            try
            {
                MySqlCommand command = new MySqlCommand("select * from turma where ativa = true", Conexao.getConexao());
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        u = new Turma();
                        u.Identificador = reader.GetInt32("identificador");
                        u.Professor = reader.GetString("professor");
                        u.Semestre = reader.GetInt32("semestre");
                        u.Ano = reader.GetInt32("ano");
                        u.Disciplina = reader.GetString("Disciplina");
                        u.Alunos = reader.GetInt32("aluno");
                        p.Add(u);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexao.FecharConexao();
            }
            return p;
        }
        public bool DesativarTurmas(int codigo)
        {
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = Conexao.getConexao();

                string sql = "update turma set ativa = false where identificador = " + codigo;
                comando.CommandText = sql;
                comando.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                return false;
                throw ex;
            }
            finally
            {
                Conexao.FecharConexao();
            }
            return true;
        }
        public List<Aluno> ListaDeAlunos(int identificador)
        {
            
            TurmaDAO d = new TurmaDAO();
            Aluno u = new Aluno();
            List<Aluno> p = new List<Aluno>();
            try
            {
                d.consultarcargahoraria(identificador);
                Conexao.AbrirConexao();
                MySqlCommand command = new MySqlCommand($"select usuario.nome'nome', " +
                    $"usuario.numero'numero', matricula.nota1'nota1', matricula.nota2'nota2', " +
                    $"matricula.exame'exame', matricula.faltas'faltas' " +
                    $"from matricula, usuario " +
                    $"where usuario.numero = matricula.numero and matricula.identificador = {identificador}", Conexao.getConexao());
                MySqlDataReader reader = command.ExecuteReader();
                
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        u.Nome = reader.GetString("nome");
                        u.Numero = reader.GetInt32("numero");
                        u.Nota1 = reader.GetDouble("nota1");
                        u.Nota2 = reader.GetDouble("nota2");
                        u.Exame = reader.GetDouble("exame");
                        u.Faltas = reader.GetInt32("faltas");
                        double a = (u.Nota1 + u.Nota2) / 2;
                        double b = (a + u.Exame) / 2;
                        double c = u.Faltas * 100;
                        if (a >= 6 || c / cargahoraria >= 25)
                        {
                            u.Aprovado = true;
                        }
                        else if((a <= 6 || a >= 4 || c / cargahoraria >= 25))
                        {
                            if((a + u.Exame) / 2 < 6)
                            {
                                u.Aprovado = true;
                            }
                            else
                            {
                                u.Aprovado = false;
                            }
                        }
                        else
                        {
                            u.Aprovado = false;
                        }
                            p.Add(u);
                        
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexao.FecharConexao();
            }
            return p;
        }
        public bool CalcularAlunos( Aluno aluno,  int identificador)
        {
            Conexao.AbrirConexao();

            MySqlCommand command2 = new MySqlCommand($"update matricula set aprovado = {aluno.Aprovado} where numero = {aluno.Numero} and identificador = {identificador}", Conexao.getConexao());
            _ = command2.ExecuteReader();

           Conexao.FecharConexao();
               
            return true;

        }
        public void consultarcargahoraria(int identificador)
        {
            Conexao.AbrirConexao();
            MySqlCommand command2 = new MySqlCommand($"select disciplina.creditos from disciplina, turma where turma.identificador = {identificador} and turma.disciplina = disciplina.codigo", Conexao.getConexao());
            MySqlDataReader reader = command2.ExecuteReader();
            while (reader.Read())
            {
                cargahoraria = reader.GetInt32("creditos") * 10; 
            }
            Conexao.FecharConexao();
        }

        public List<Turma> ExibirTurmasSec(string identificador, string ano, string semestre, string disciplina)
        {
            Conexao.AbrirConexao();
            string sql1 = $" and turma.ano {ano} ", sql2 = $" and turma.semestre {semestre} ", sql3 = $" and disciplina.nome {disciplina} and disciplina.codigo = turma.disciplina and turma.identificador {identificador}";
            List <Turma> p = new List<Turma>();
            Turma u = new Turma();
            try
            {
                MySqlCommand command2 = new MySqlCommand($"select turma.identificador'id', disciplina.nome'disciplina', usuario.nome'professor', turma.semestre'semestre', turma.ano'ano', turma.aluno'alunos', turma.ativa'ativado' from turma, disciplina, usuario where usuario.numero = turma.professor and disciplina.codigo = turma.disciplina " + sql1 + sql2 + sql3 +";", Conexao.getConexao());
                MySqlDataReader reader = command2.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        u = new Turma();
                        u.Identificador = reader.GetInt32("id");
                        u.Disciplina = reader.GetString("disciplina");
                        u.Professor = reader.GetString("professor");
                        u.Semestre = reader.GetInt32("semestre");
                        u.Ano = reader.GetInt32("ano");
                        u.Alunos = reader.GetInt32("alunos");
                        if(reader.GetBoolean("ativado") == true)
                        {
                            u.Ativado = "Ativa";
                        }
                        else
                        {
                            u.Ativado = "Fechada";
                        }
                        p.Add(u);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexao.FecharConexao();
            }
            return p;
        }
        public List<Aluno> ExibirAlunosSec(int numero)
        {
            Conexao.AbrirConexao();
            List<Aluno> p = new List<Aluno>();
            Aluno u = new Aluno();
            int i = 1;
            try
            {
                MySqlCommand command = new MySqlCommand($"select usuario.numero'numero', usuario.nome'nome' from turma, matricula, usuario where usuario.numero = matricula.numero and matricula.identificador = turma.identificador and turma.identificador = {numero} group by usuario.nome order by nome asc", Conexao.getConexao());
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        u = new Aluno();
                        u.Numero = reader.GetInt32("numero");
                        u.Nome = reader.GetString("nome");
                        p.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexao.FecharConexao();
            }
            return p;

        }
        public List<Aluno> ConsultarAlunosSecNum(int numero)
        {
            Conexao.AbrirConexao();
            List<Aluno> p = new List<Aluno>();
            Aluno u = new Aluno();
            int i = 1;
            try
            {
                MySqlCommand command = new MySqlCommand($"select usuario.numero'numero', usuario.nome'nome' from usuario where usuario.numero like '{numero}' group by usuario.nome", Conexao.getConexao());
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        u = new Aluno();
                        u.Numero = reader.GetInt32("numero");
                        u.Nome = reader.GetString("nome");
                        p.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexao.FecharConexao();
            }
            return p;

        }
        public List<Aluno> ConsultarAlunosSecNom(string nome)
        {
            Conexao.AbrirConexao();
            List<Aluno> p = new List<Aluno>();
            Aluno u = new Aluno();
            try
            {
                MySqlCommand command = new MySqlCommand($"select usuario.numero'numero', usuario.nome'nome' from usuario where usuario.nome like '{nome}' group by usuario.nome order by nome asc", Conexao.getConexao());
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        u = new Aluno();
                        u.Numero = reader.GetInt32("numero");
                        u.Nome = reader.GetString("nome");
                        p.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexao.FecharConexao();
            }
            return p;

        }
        public List<Matricula> ConsultarTurmasSec(int numero)
        {
            List<Matricula> p = new List<Matricula>();
            Matricula u = new Matricula();
            Conexao.AbrirConexao();
            try
            {
                MySqlCommand command = new MySqlCommand($"select turma.identificador'id', Disciplina.nome'disciplina', matricula.nota1'nota1', matricula.nota2'nota2', matricula.exame'exame', matricula.faltas'faltas', matricula.aprovado'situacao' from turma, matricula, usuario, disciplina where turma.identificador = matricula.identificador and Disciplina.codigo = turma.disciplina and matricula.numero = {numero} group by matricula.identificador;", Conexao.getConexao());
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        u = new Matricula();
                        u.Identificador = reader.GetInt32("id");
                        u.Nota1 = reader.GetDouble("nota1");
                        u.Nota2 = reader.GetDouble("nota2");
                        u.Exame = reader.GetDouble("exame");
                        u.Falta = reader.GetInt32("faltas");
                        if(u.Aprovado = reader.GetBoolean("situacao") == true)
                        {
                            u.Situacao = "Aprovado";
                        }
                        else
                        {
                            u.Situacao = "Reprovado";
                        }
                        u.Disciplina = reader.GetString("disciplina");
                        p.Add(u);
                    }
                }
            }
            catch(Exception ex)
            {
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
