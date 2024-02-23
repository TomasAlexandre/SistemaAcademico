using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaAcademico.Model
{
    class TurmaExibir
    {
        private string nome;
        private string disciplinanome;
        private string ativa;
        private int identificador;
        private string alunos;

        public string Nome { get => nome; set => nome = value; }
        public string Disciplinanome { get => disciplinanome; set => disciplinanome = value; }
        public string Ativa { get => ativa; set => ativa = value; }
        public int Identificador { get => identificador; set => identificador = value; }
        public string Alunos { get => alunos; set => alunos = value; }
    }
}
