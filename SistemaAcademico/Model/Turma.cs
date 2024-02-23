using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaAcademico.Model
{
    class Turma
    {
        private int identificador;
        private string disciplina;
        private string professor;
        private int semestre;
        private int ano;
        private int alunos;
        string ativado;
        

        public int Identificador { get => identificador; set => identificador = value; }
        public string Disciplina { get => disciplina; set => disciplina = value; }
        public string Professor { get => professor; set => professor = value; }
        public int Semestre { get => semestre; set => semestre = value; }
        public int Ano { get => ano; set => ano = value; }
        public int Alunos { get => alunos; set => alunos = value; }
        public string Ativado { get => ativado; set => ativado = value; }
    }
}
