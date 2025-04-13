using ClubeDoLivro.ConsoleApp.ModuloAmigo;
using System.ComponentModel.Design;

namespace ClubeDoLivro.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaPrincipal telaPrincipal = new TelaPrincipal();
            TelaAmigo telaAmigo = new TelaAmigo();
            while (true)
            {
                Char opcaoPrincipal = telaPrincipal.ExibirTitulo(true);

                switch (opcaoPrincipal)
                {
                    case '1': telaPrincipal.GerenciarAmigos(); break;

                    case '2': telaPrincipal.GerenciarCaixas(); break;

                    case '3': telaPrincipal.GerenciarRevistas(); break;

                    case '4': telaPrincipal.VisualizarListaNegra(); break;

                    case '5': telaPrincipal.VisualizarEmprestimos(); break;

                    default: break;
                }

            }
        }
    }
}
