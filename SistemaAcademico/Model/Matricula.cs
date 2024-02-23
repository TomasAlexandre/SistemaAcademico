using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaAcademico.Model
{
    class Matricula
    {
        int numero;
        int identificador;
        string disciplina;
        double nota1;
        double nota2;
        double exame;
        int falta;
        string situacao;
        bool aprovado;
        public int Numero { get => numero; set => numero = value; }
        public int Identificador { get => identificador; set => identificador = value; }
        public int Falta { get => falta; set => falta = value; }
        public bool Aprovado { get => aprovado; set => aprovado = value; }
        public double Nota1 { get => nota1; set => nota1 = value; }
        public double Nota2 { get => nota2; set => nota2 = value; }
        public double Exame { get => exame; set => exame = value; }
        public string Disciplina { get => disciplina; set => disciplina = value; }
        public string Situacao { get => situacao; set => situacao = value; }
    }
}
