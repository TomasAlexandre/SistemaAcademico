using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaAcademico.Model
{
    class DadosAlunos
    {
        double nota1, nota2, exame;
        int faltas;

        public double Nota1 { get => nota1; set => nota1 = value; }
        public double Nota2 { get => nota2; set => nota2 = value; }
        public double Exame { get => exame; set => exame = value; }
        public int Faltas { get => faltas; set => faltas = value; }
    }
}
