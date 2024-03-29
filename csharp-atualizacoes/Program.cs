﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_atualizacoes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] menus = new string[] {
                "1. Propriedades Automáticas Somente-Leitura",
                "2. Inicializadores De Propriedade Automática",
                "3. Membros Com Corpo De Expressão",
                "4. Using Static",
                "5. Operadores Null Condicionais",
                "6. Interpolação de Strings",
                "7. Monitorando Alteração em Propriedades",
                "8. Validação de Parâmetros",
                "9. Filtros De Exceção",
                "10. Await em Catch e Finally",
                "11. Inicializadores de Indíce",
                "12. Criando Lista Customizada com IEnumerable",
            };

            Console.WriteLine("ÍNDICE DE PROGRAMAS");
            Console.WriteLine("===================");


            int programa = 0;
            string line;
            do
            {
                foreach (var menu in menus)
                {
                    Console.WriteLine(menu);
                }

                Console.WriteLine();
                Console.WriteLine("Escolha um programa:");

                line = Console.ReadLine();
                Int32.TryParse(line, out programa);
                switch (programa)
                {
                    case 1:
                        new CSharp6.R01.Programa().Main();
                        break;
                    case 2:
                        new CSharp6.R02.Programa().Main();
                        break;
                    case 3:
                        new CSharp6.R03.Programa().Main();
                        break;
                    case 4:
                        new CSharp6.R04.Programa().Main();
                        break;
                    case 5:
                        new CSharp6.R05.Programa().Main();
                        break;
                    case 6:
                        new CSharp6.R06.Programa().Main();
                        break;
                    case 7:
                        new CSharp6.R07.Programa().Main();
                        break;
                    case 8:
                        new CSharp6.R08.Programa().Main();
                        break;
                    case 9:
                        new CSharp6.R09.Programa().Main();
                        break;
                    case 10:
                        new CSharp6.R10.Programa().Main();
                        break;
                    case 11:
                        new CSharp6.R11.Programa().Main();
                        break;
                    case 12:
                        new CSharp6.R12.Programa().Main();
                        break;
                    default:
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("PRESSIONE UMA TECLA PARA CONTINUAR...");
                Console.ReadKey();
                Console.Clear();
            } while (line.Length > 0);
        }
    }
}
