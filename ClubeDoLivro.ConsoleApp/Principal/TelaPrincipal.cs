using ClubeDoLivro.ConsoleApp.ModuloAmigo;
using ClubeDoLivro.ConsoleApp.ModuloCaixas;
using ClubeDoLivro.ConsoleApp.ModuloRevistas;

namespace ClubeDoLivro.ConsoleApp.Principal
{
    public class TelaPrincipal
    {
        TelaAmigo telaAmigo = new TelaAmigo();
        TelaCaixa telaCaixa = new TelaCaixa();
        TelaRevista telaRevista = new TelaRevista();
        public char ExibirTitulo(bool opcaoPrincipal)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("                               CLUBE DO LIVRO");
            Console.WriteLine("--------------------------------------------------------------------------------");

            if (opcaoPrincipal)
            {
                Console.WriteLine("                             Selecione a Opção desejada");
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine("                              1 - Gerenciar Amigos");
                Console.WriteLine("                              2 - Gerenciar Caixas");
                Console.WriteLine("                              3 - Gerenciar Revistas");
                Console.WriteLine("                              4 - Visualizar Lista Negra");
                Console.WriteLine("                              5 - Visualizar Empréstimos");
                Console.WriteLine("                              6 - Sair do Programa");
                Console.WriteLine("--------------------------------------------------------------------------------");
                char opcaoEscolhida = Convert.ToChar(Console.ReadLine()![0]);
                return opcaoEscolhida;
            }
            else return 'S';

        }
        public void GerenciarAmigos()
        {
            bool loop = true;
            while (loop)
            {
                Char opcaoEscolhida = telaAmigo.ExibirTitulo(true);

                switch (opcaoEscolhida)
                {
                    case '1': telaAmigo.InserirAmigo(); break;

                    case '2': telaAmigo.EditarAmigo(); break;

                    case '3': telaAmigo.ExcluirAmigo(); break;

                    case '4': telaAmigo.VisualizarAmigos(); break;

                    case '5': telaAmigo.VisualizarEmprestimos(); break;

                    case '6': loop = false; break;

                    default: break;
                }
            }
        }

        public void GerenciarCaixas()
        {
            bool loop = true;
            while (loop)
            {
                char opcaoEscolhida = telaCaixa.ExibirTitulo(true);

                switch (opcaoEscolhida)
                {
                    case '1': telaCaixa.InserirCaixa(); break;

                    case '2': telaCaixa.EditarCaixa(); break;

                    case '3': telaCaixa.ExcluirCaixa(); break;

                    case '4': telaCaixa.VisualizarCaixas(); break;

                    case '5': loop = false; break;

                    default: break;
                }
            }
        }

        public void GerenciarRevistas()
        {
            bool loop = true;
            while (loop)
            {
                char opcaoEscolhida = telaRevista.ExibirTitulo(true);

                switch (opcaoEscolhida)
                {
                    case '1': telaRevista.InserirRevista(); break;

                    case '2': telaRevista.EditarRevista(); break;

                    case '3': telaRevista.ExcluirRevista(); break;

                    case '4': telaRevista.VisualizarRevistas(); break;

                    case '5': telaCaixa.VisualizarCaixas(); break;

                    case '6': loop = false; break;

                    default: break;
                }
            }
        }

        internal void VisualizarEmprestimos()
        {
            throw new NotImplementedException();
        }

        internal void VisualizarListaNegra()
        {
            throw new NotImplementedException();
        }
    }
}
