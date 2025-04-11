using ClubeDoLivro.ConsoleApp.ModuloAmigo;
using System.ComponentModel.Design;

namespace ClubeDoLivro.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaAmigo telaAmigo = new TelaAmigo();
            while (true)
            {
                Char opcaoEscolhida = telaAmigo.ExibirTitulo(true);

                switch (opcaoEscolhida)
                {
                    case '1': telaAmigo.InserirAmigo(); break;

                    case '2': telaAmigo.EditarAmigo(); break;

                    case '3': telaAmigo.ExcluirAmigo(); break;

                    case '4': telaAmigo.VisualizarAmigos(); break;
                   
                    case '5': telaAmigo.EmprestimosAmigos(); break;

                    default: break;
                }         
            }
        }
    }
}
