using ClubeDoLivro.ConsoleApp.ModuloAmigo;
using ClubeDoLivro.ConsoleApp.ModuloCaixas;
using ClubeDoLivro.ConsoleApp.ModuloEmprestimos;
using ClubeDoLivro.ConsoleApp.ModuloRevistas;

namespace ClubeDoLivro.ConsoleApp.Principal
{
    public class TelaPrincipal
    {
        public TelaAmigo telaAmigo;
        public TelaCaixa telaCaixa;
        public TelaRevista telaRevista;
        public TelaEmprestimo telaEmprestimo;

        RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
        RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
        RepositorioRevista repositorioRevista = new RepositorioRevista();
        RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();

        public TelaPrincipal()
        {
            telaAmigo = new TelaAmigo(repositorioAmigo);
            telaCaixa = new TelaCaixa(repositorioCaixa);
            telaRevista = new TelaRevista(repositorioRevista, repositorioCaixa, telaCaixa);
            telaEmprestimo = new TelaEmprestimo(repositorioAmigo, repositorioRevista, repositorioEmprestimo, telaAmigo, telaRevista);
        }

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
                Console.WriteLine("                              4 - Gerenciar Empréstimos");
                Console.WriteLine("                              5 - Visualizar Lista Negra");
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

                    case '5': telaAmigo.VisualizarEmprestimosAmigo(); break;

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
                   
                    case '6': telaRevista.ColocarNaCaixa(); break;

                    case '7': telaRevista.RemoverDaCaixa(); break;

                    case '8': loop = false; break;

                    default: break;
                }
            }
        }

        internal void GerenciarEmprestimos()
        {
            bool loop = true;
            while (loop)
            {
                char opcaoEscolhida = telaEmprestimo.ExibirTitulo(true);

                switch (opcaoEscolhida)
                {
                    case '1': telaEmprestimo.InserirEmprestimo(); break;

                    case '2': telaEmprestimo.EditarEmprestimo(); break;

                    case '3': telaEmprestimo.ExcluirEmprestimo(); break;

                    case '4': telaEmprestimo.VisualizarEmprestimos(); break;

                    case '5': telaRevista.VisualizarRevistas(); break;

                    case '6': telaAmigo.VisualizarAmigos(); break;

                    case '7': telaEmprestimo.RegistrarDevolucao(); break;

                    case '8': loop = false; break;

                    default: break;
                }
            }
        }

        public void VisualizarListaNegra()
        {
            Console.Clear();
            Console.WriteLine("                          AMIGOS COM MULTA PENDENTE");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("{0,-20} | {1,-20} | {2,-10}", "Nome", "Telefone", "Multa (R$)");

            bool encontrouMultados = false;

            foreach (var amigo in repositorioAmigo.AmigosCadastrados)
            {
                if (amigo == null) continue;

                double multaTotal = 0;
                DateTime dataAtual = DateTime.Today;

                foreach (var emprestimo in amigo.amigoEmprestimos)
                {
                    if (emprestimo.StatusEmprestimo == "Em Aberto" && emprestimo.DataDevolucao.HasValue)
                    {
                        DateTime dataDevolucaoPrevista = emprestimo.DataDevolucao.Value.ToDateTime(new TimeOnly(0, 0));

                        if (dataDevolucaoPrevista < dataAtual)
                        {
                            TimeSpan atraso = dataAtual - dataDevolucaoPrevista;
                            multaTotal += atraso.Days * 2;
                        }
                    }
                }

                if (multaTotal > 0)
                {
                    encontrouMultados = true;
                    Console.WriteLine("{0,-20} | {1,-20} | {2,-10:F2}", amigo.NomeCompleto, amigo.Telefone, multaTotal);
                }
            }

            if (!encontrouMultados)
            {
                Console.WriteLine("Nenhum amigo com multa pendente.");
            }

            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
