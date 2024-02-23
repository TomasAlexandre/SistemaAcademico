using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaAcademico.Model
{
    class Disciplina
    {
        private int codigo;
        private string nome;
        private int creditos;

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nome { get => nome; set => nome = value; }
        public int Creditos { get => creditos; set => creditos = value; }
    }
}
