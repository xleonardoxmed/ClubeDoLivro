using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.ConsoleApp
{
    public class TelaPrincipal
    {
        public char ExibirTitulo(bool opcoes)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("                               CLUBE DO LIVRO");
            Console.WriteLine("--------------------------------------------------------------------------------");

            if (opcoes)
            {
                Console.WriteLine("                             Selecione a Opção desejada");
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine("                              1 - Gerenciar Amigos");
                Console.WriteLine("                              2 - Gerenciar Empréstimos");
                Console.WriteLine("                              3 - Visualizar Lista Negra");
                Console.WriteLine("                              4 - Visualizar Amigos");
                Console.WriteLine("                              5 - Visualizar Empréstimos de Amigos");
                Console.WriteLine("--------------------------------------------------------------------------------");
                char opcaoEscolhida = Convert.ToChar(Console.ReadLine()![0]);
                return opcaoEscolhida;
            }
            else return 'S';

        }
    }
}
