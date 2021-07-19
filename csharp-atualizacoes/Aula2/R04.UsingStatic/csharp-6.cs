using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.DateTime;

namespace CSharp6.R04
{
    class Programa
    {
        public void Main()
        {

            Aluno aluno = new Aluno("Marty", "McFly", new DateTime(1968, 6, 12)) 
            { 
                Endereco =  "9303 Lyon Drive Hill Valey CA",
                Telefone = "555-4356"
            };

            WriteLine(aluno.Nome);
            WriteLine(aluno.Sobrenome);
            WriteLine(aluno.NomeCompleto);
            WriteLine($"Idade:  {aluno.GetIdade()}");
            WriteLine(aluno.DadosPessoais);
        }
    }

    class Aluno
    {

        public string Nome { get; }

        public string Sobrenome { get; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        public string DadosPessoais => $"{NomeCompleto}, {Endereco}, {Telefone}";

        //inicializador de propriedade automática(default)
        public DateTime DataNascimento { get; } = new DateTime(1990, 1, 1);

        public string NomeCompleto => Nome + " " + Sobrenome;

        public int GetIdade() => (int)(((Now - DataNascimento).TotalDays) / 365.242199);

        public Aluno(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;

        }

        public Aluno(string nome, string sobrenome, DateTime dataNascimento) : this(nome, sobrenome)
        {

            DataNascimento = dataNascimento;
        }

    }

}
