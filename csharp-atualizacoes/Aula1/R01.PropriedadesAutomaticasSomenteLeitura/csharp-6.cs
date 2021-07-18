using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6.R01
{
    class Programa
    {
        public void Main()
        {
            Console.WriteLine("1. Propriedades Automáticas Somente-Leitura");

            Aluno aluno = new Aluno("Marty", "McFly", new DateTime(1968, 6, 12));

            Console.WriteLine(aluno.Nome);
            Console.WriteLine(aluno.Sobrenome);
            Console.WriteLine(aluno);

        }
    }

    class Aluno
    {

        public string Nome { get; }
        public string Sobrenome { get; }
        public DateTime DataNascimento { get; }

        public Aluno(string nome, string sobrenome, DateTime dataNascimento)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
        }
        public override string ToString()
        {
            return $"{Nome} {Sobrenome}"; 
        }
    }

}

