using ClubeDoLivro.ConsoleApp.ModuloAmigo;
using ClubeDoLivro.ConsoleApp.ModuloCaixas;

namespace ClubeDoLivro.ConsoleApp
{
    public class TelaPrincipal
    {
        TelaAmigo telaAmigo = new TelaAmigo();
        TelaCaixa telaCaixa = new TelaCaixa();
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
                Console.WriteLine("--------------------------------------------------------------------------------");
                char opcaoEscolhida = Convert.ToChar(Console.ReadLine()![0]);
                return opcaoEscolhida;
            }
            else return 'S';

        }
        public void GerenciarAmigos()
        {
            Char opcaoEscolhida = telaAmigo.ExibirTitulo(true);

            switch (opcaoEscolhida)
            {
                case '1': telaAmigo.InserirAmigo(); break;

                case '2': telaAmigo.EditarAmigo(); break;

                case '3': telaAmigo.ExcluirAmigo(); break;

                case '4': telaAmigo.VisualizarAmigos(); break;

                case '5': telaAmigo.VisualizarEmprestimos(); break;

                default: break;
            }
        }

        internal void GerenciarCaixas()
        {
            Char opcaoEscolhida = telaCaixa.ExibirTitulo(true);

            switch (opcaoEscolhida)
            {
                case '1': telaCaixa.InserirCaixa(); break;

                case '2': telaCaixa.EditarCaixa(); break;

                case '3': telaCaixa.ExcluirCaixa(); break;

                case '4': telaCaixa.VisualizarCaixas(); break;

                default: break;
            }
        }

        internal void GerenciarRevistas()
        {
            throw new NotImplementedException();
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
