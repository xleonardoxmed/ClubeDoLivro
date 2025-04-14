using ClubeDoLivro.ConsoleApp.ModuloAmigo;
using ClubeDoLivro.ConsoleApp.ModuloCaixas;
using ClubeDoLivro.ConsoleApp.ModuloRevistas;
using System.ComponentModel.Design;

namespace ClubeDoLivro.ConsoleApp.Principal
{
    internal class Program
    {
        static void Main(string[] args)
        {          
            TelaPrincipal telaPrincipal = new TelaPrincipal();
            bool programa = true;

            while (programa)
            {
                char opcaoPrincipal = telaPrincipal.ExibirTitulo(true);

                switch (opcaoPrincipal)
                {
                    case '1': telaPrincipal.GerenciarAmigos(); break;

                    case '2': telaPrincipal.GerenciarCaixas(); break;

                    case '3': telaPrincipal.GerenciarRevistas(); break;

                    case '4': telaPrincipal.VisualizarListaNegra(); break;

                    case '5': telaPrincipal.VisualizarEmprestimos(); break;

                    case '6': programa = false ; break;

                    default: break;
                }

            }
        }
    }
}
