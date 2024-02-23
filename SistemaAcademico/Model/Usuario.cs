using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaAcademico.Model
{
    class Usuario
    {
        private string nome;
        private int numero;
        private string login;
        private string senha;
        private string perfil;
        private string curso;
        private string titulacao;

        public int Numero { get => numero; set => numero = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Login { get => login; set => login = value; }
        public string Senha { get => senha; set => senha = value; }
        public string Perfil { get => perfil; set => perfil = value; }
        public string Curso { get => curso; set => curso = value; }
        public string Titulacao { get => titulacao; set => titulacao = value; }
    }
}
