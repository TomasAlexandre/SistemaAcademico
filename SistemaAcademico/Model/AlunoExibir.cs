using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaAcademico.Model
{
    class AlunoExibir
    {
        int num;
        string nome;
        int faltas;

        public int Num { get => num; set => num = value; }
        public string Nome { get => nome; set => nome = value; }
        public int Faltas { get => faltas; set => faltas = value; }
    }
}
