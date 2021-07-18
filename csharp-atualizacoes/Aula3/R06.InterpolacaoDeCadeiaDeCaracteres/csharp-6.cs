using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.DateTime;

namespace CSharp6.R06
{
    class Programa
    {
        public void Main()
        {

            Aluno aluno = new Aluno("Marty", "McFly", new DateTime(1968, 6, 12))
            {
                Endereco = "9303 Lyon Drive Hill Valey CA",
                Telefone = "555-4356"
            };

            WriteLine(aluno.Nome);
            WriteLine(aluno.Sobrenome);
            WriteLine(aluno.NomeCompleto);
            WriteLine($"Idade:  {aluno.GetIdade()}");
            WriteLine(aluno.DadosPessoais);

            aluno.AdicionarAvaliacao(new Avaliacao(1, "Geografia", 8));
            aluno.AdicionarAvaliacao(new Avaliacao(1, "Matematica", 7));
            aluno.AdicionarAvaliacao(new Avaliacao(1, "História", 9));
            ImprimirMelhorNota(aluno);

            Aluno aluno2 = new Aluno("Bart", "Simpson");
            ImprimirMelhorNota(aluno2);
            WriteLine(aluno.DadosPessoais);
        }

        private static void ImprimirMelhorNota(Aluno aluno)
        {
            WriteLine($"Melhor nota {aluno?.MelhorAvaliacao?.Nota}");
        }
    }

    class Aluno
    {

        public string Nome { get; }

        public string Sobrenome { get; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        public string DadosPessoais => $"Nome Completo: {NomeCompleto}," +
            $" Endereço: {Endereco}, Telefone: {Telefone}," +
            $" Data de Nascimento: {DataNascimento:dd/MM/yyyy}, Idade: {GetIdade()}" ;

        //inicializador de propriedade automática(default)
        public DateTime DataNascimento { get; } = new DateTime(1990, 1, 1);

        public string NomeCompleto => Nome + " " + Sobrenome;

        private IList<Avaliacao> avalicacoes = new List<Avaliacao>();

        public IReadOnlyCollection<Avaliacao> Avaliacoes => new ReadOnlyCollection<Avaliacao>(avalicacoes);

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

        public void AdicionarAvaliacao(Avaliacao avaliacao)
        {
            avalicacoes.Add(avaliacao);
        }

        public Avaliacao MelhorAvaliacao => avalicacoes.OrderBy(a => a.Nota).LastOrDefault();

    }

    class Avaliacao
    {
        public Avaliacao(int bimestre, string materia, double nota)
        {
            Bimestre = bimestre;
            Materia = materia;
            Nota = nota;
        }

        public int Bimestre { get; }

        public string Materia { get; }

        public double Nota { get; }

    }

}
