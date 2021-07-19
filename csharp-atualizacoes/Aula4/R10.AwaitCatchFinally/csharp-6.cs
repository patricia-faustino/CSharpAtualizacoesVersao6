using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.DateTime;
using static System.String;

namespace CSharp6.R10
{
    class Programa
    {
        public async void Main()
        {

            StreamWriter logAplicacao = new StreamWriter("LogAplicacao.txt");
            try
            {
                await logAplicacao.WriteLineAsync("Aplicação está iniciando...");

                Aluno aluno = new Aluno("Marty", "McFly", new DateTime(1968, 6, 12))
                {
                    Endereco = "9303 Lyon Drive Hill Valey CA",
                    Telefone = "555-4356"
                };

                await logAplicacao.WriteLineAsync("Aluno Marty McFly criado");
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
                await logAplicacao.WriteLineAsync("Aluno Bart Simpson criado");

                aluno.PropertyChanged += Aluno_PropertyChanged;
                aluno.Telefone = "5469-89358";
                aluno.Endereco = "Rua Vergueiro, 3185";

                Aluno aluno3 = new Aluno("Charlie", "");
                await logAplicacao .WriteLineAsync("Aluno Charlie criado");
            }
            catch (ArgumentException exc) when (exc.Message.Contains("não informado"))
            {
                string mensagem = $"Parâmetro {exc.ParamName} não foi informado!";
                await logAplicacao.WriteLineAsync(mensagem);
                Console.WriteLine(mensagem);
            }
            catch (ArgumentException exc)
            {
                string mensagem = "Parâmetro com problema";
                await logAplicacao.WriteLineAsync(mensagem);
                Console.WriteLine(mensagem);
            }

            catch (Exception exc)
            {
                await logAplicacao.WriteLineAsync(exc.ToString());
                Console.WriteLine(exc.ToString());
            }
            finally
            {
                await logAplicacao.WriteLineAsync("Aplicação terminou.");
                //Liberando arquivos não gerenciados
                logAplicacao.Dispose();
            }
        }

        private void Aluno_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine($"Propriedade {e.PropertyName} foi alterada");
        }

        private static void ImprimirMelhorNota(Aluno aluno)
        {
            WriteLine($"Melhor nota {aluno?.MelhorAvaliacao?.Nota}");
        }
    }

    class Aluno : INotifyPropertyChanged 
    {

        public string Nome { get; }

        public string Sobrenome { get; }

        //public string Endereco { get; set; }

        //public string Telefone { get; set; }

        private string endereco;

        public string Endereco
        {
            get { return endereco; }
            set
            {
                if (endereco != value)
                {
                    endereco = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(DadosPessoais));
                }
            }
        }

        private string telefone;

        public string Telefone
        {
            get { return telefone; }
            set { 
                if(telefone != value)
                {
                    telefone = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(DadosPessoais));
                }
            }
        }

        public string DadosPessoais => $"Nome Completo: {NomeCompleto}," +
            $" Endereço: {Endereco}, Telefone: {Telefone}," +
            $" Data de Nascimento: {DataNascimento:dd/MM/yyyy}, Idade: {GetIdade()}" ;

        //inicializador de propriedade automática(default)
        public DateTime DataNascimento { get; } = new DateTime(1990, 1, 1);

        public string NomeCompleto => Nome + " " + Sobrenome;

        private IList<Avaliacao> avalicacoes = new List<Avaliacao>();

        public event PropertyChangedEventHandler PropertyChanged; 

        public IReadOnlyCollection<Avaliacao> Avaliacoes => new ReadOnlyCollection<Avaliacao>(avalicacoes);

        public int GetIdade() => (int)(((Now - DataNascimento).TotalDays) / 365.242199);

        public Aluno(string nome, string sobrenome)
        {
      
            VerificarParametroPreenchido(nome, nameof(nome));
            VerificarParametroPreenchido(sobrenome, nameof(sobrenome));

            Nome = nome;
            Sobrenome = sobrenome;

        }

        private static void VerificarParametroPreenchido(string valorDoParametro, string nomeDoParametro)
        {
            if (IsNullOrEmpty(valorDoParametro))
            {
                throw new ArgumentException($"Parâmetro não informado!", nomeDoParametro);
            }
        }

        public Aluno(string nome, string sobrenome, DateTime dataNascimento) : this(nome, sobrenome)
        {

            DataNascimento = dataNascimento;
        }

        public void AdicionarAvaliacao(Avaliacao avaliacao)
        {
            avalicacoes.Add(avaliacao);
        }

        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
