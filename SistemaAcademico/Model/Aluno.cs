using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaAcademico.Model
{
    class Aluno
    {
        int numero;
        string nome, Situação;
        double nota1, nota2, exame;
        int faltas;
        bool aprovado;
        
       
        public int Numero { get => numero; set => numero = value; }
        public string Nome { get => nome; set => nome = value; }
        public double Nota1 { get => nota1; set => nota1 = value; }
        public double Nota2 { get => nota2; set => nota2 = value; }
        public double Exame { get => exame; set => exame = value; }
        public int Faltas { get => faltas; set => faltas = value; }
        public string Situação1 { get => Situação; set => Situação = value; }
        public bool Aprovado { get => aprovado; set => aprovado = value; }
    }
}
