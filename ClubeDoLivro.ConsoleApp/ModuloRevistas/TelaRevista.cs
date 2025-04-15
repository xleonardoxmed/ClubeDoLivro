using ClubeDoLivro.ConsoleApp.ModuloAmigo;
using ClubeDoLivro.ConsoleApp.ModuloCaixas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.ConsoleApp.ModuloRevistas
{
    public class TelaRevista
    {
        public RepositorioRevista repositorioRevista;
        public RepositorioCaixa repositorioCaixa;
        public TelaCaixa telaCaixa;

        public TelaRevista(RepositorioRevista repositorioRevista, RepositorioCaixa repositorioCaixa, TelaCaixa telaCaixa)
        {
            this.repositorioRevista = repositorioRevista;
            this.repositorioCaixa = repositorioCaixa;
            this.telaCaixa = telaCaixa;
        }

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
                Console.WriteLine("                              1 - Cadastrar Revistas");
                Console.WriteLine("                              2 - Editar Revistas");
                Console.WriteLine("                              3 - Excluir Revistas");
                Console.WriteLine("                              4 - Visualizar Revistas");
                Console.WriteLine("                              5 - Visualizar Caixas");
                Console.WriteLine("                              6 - Colocar Revistas nas Caixas");
                Console.WriteLine("                              7 - Remover Revistas das Caixas");
                Console.WriteLine("                              8 - Voltar ao Menu");
                Console.WriteLine("--------------------------------------------------------------------------------");
                char opcaoEscolhida = Convert.ToChar(Console.ReadLine()![0]);
                return opcaoEscolhida;
            }
            else return 'S';

        }
        public void InserirRevista()
        {
            Console.Clear();
            ExibirTitulo(false);
            Console.WriteLine("                             CADASTRO DE REVISTA");
            Console.WriteLine("--------------------------------------------------------------------------------");

            Console.WriteLine("\nInsira o TITULO (nome) da revista: ");
            string titulo = Console.ReadLine()!;

            Console.WriteLine($"\nInsira a EDIÇÃO da revista {titulo}: ");
            string edicao = Console.ReadLine()!;

            if (edicao.Contains('-') || edicao == "0")
            {
                Console.WriteLine("\nErro! A edição não pode ser um número menor ou igual a zero!");
                Console.WriteLine("\nOperação Cancelada.");
                Thread.Sleep(2000);
                return;
            }

            Console.WriteLine($"\nInsira o ANO DE PUBLICAÇÃO da revista {titulo}: ");
            string inputAno = Console.ReadLine()!;

            if (!int.TryParse(inputAno, out int anoPublicacao))
            {
                Console.WriteLine("\n Erro! Ano inválido!");
                Console.WriteLine("\nOperação Cancelada.");
                Thread.Sleep(2000);
                return;
            }

            Revista novaRevista = new Revista(titulo, edicao, anoPublicacao, telaCaixa);

            if (!novaRevista.Validar())
            {
                Thread.Sleep(2000);
                return;
            }

            repositorioRevista.Inserir(novaRevista);

            VisualizarRevistas();
            Console.WriteLine("                       Revista adicionada com sucesso!");
            Thread.Sleep(1000);
        }

        public void EditarRevista()
        {
            Console.Clear();
            ExibirTitulo(false);
            Console.WriteLine("                             EDIÇÃO DE REVISTA");
            Console.WriteLine("--------------------------------------------------------------------------------");

            VisualizarRevistas();

            bool temCadastros = false;

            foreach (var revista in repositorioRevista.RevistasCadastradas)
            {
                if (revista != null)
                {
                    temCadastros = true;
                    break;
                }
            }

            if (!temCadastros)
            {
                Console.WriteLine("    \n                            Voltando ao menu");
                Thread.Sleep(1000);
                return;
            }

            Console.WriteLine("\nDigite o ID da Revista que deseja EDITAR");
            string inputId = Console.ReadLine()!;


            if (!int.TryParse(inputId, out int idSelecionado))
            {
                Console.WriteLine("\n Erro! ID inválido!");
                Console.WriteLine("\nOperação Cancelada.");
                Thread.Sleep(2000);
                return;
            }
            Revista revistaExistente = repositorioRevista.SelecionarPorId(idSelecionado)!;

            if (revistaExistente == null)
            {
                Console.WriteLine("\nErro! Nenhuma revista com esse ID foi encontrada!");
                Console.WriteLine("\nOperação Cancelada.");
                Thread.Sleep(2000);
                return;
            }

            Console.WriteLine("\nInsira o TITULO (nome) da revista: ");
            string titulo = Console.ReadLine()!;

            Console.WriteLine($"\nInsira a EDIÇÃO da revista {titulo}: ");
            string edicao = Console.ReadLine()!;

            if (edicao.Contains('-') || edicao == "0")
            {
                Console.WriteLine("\nErro! A edição não pode ser um número menor que zero!");
                Console.WriteLine("\nOperação Cancelada.");
                Thread.Sleep(2000);
                return;
            }

            Console.WriteLine($"\nInsira o ANO DE PUBLICAÇÃO da revista {titulo}: ");
            string inputAno = Console.ReadLine()!;

            if (!int.TryParse(inputAno, out int anoPublicacao))
            {
                Console.WriteLine("\n Erro! Ano inválido!");
                Console.WriteLine("\nOperação Cancelada.");
                Thread.Sleep(2000);
                return;
            }

            Revista revistaEditada = new Revista(titulo, edicao, anoPublicacao, telaCaixa);

            if (!revistaEditada.Validar())
            {
                Thread.Sleep(2000);
                return;
            }

            repositorioRevista.Editar(idSelecionado, revistaEditada);

            bool conseguiuEditar = repositorioRevista.Editar(idSelecionado, revistaEditada);

            if (!conseguiuEditar)
            {
                Console.WriteLine("                Ocorreu um erro durante a edição...");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("                       Revista editada com sucesso!");
            Thread.Sleep(1000);
            VisualizarRevistas();
        }
        public void ExcluirRevista()
        {
            Console.Clear();
            ExibirTitulo(false);
            Console.WriteLine("                             EXCLUSÃO DE REVISTA");
            Console.WriteLine("--------------------------------------------------------------------------------");

            VisualizarRevistas();
            bool temCadastros = false;

            foreach (var revista in repositorioRevista.RevistasCadastradas)
            {
                if (revista != null)
                {
                    temCadastros = true;
                    break;
                }
            }

            if (!temCadastros)
            {
                Console.WriteLine("    \n                            Voltando ao menu");
                Thread.Sleep(1000);
                return;
            }

            Console.WriteLine("\nDigite o ID da Revista que deseja EXCLUIR");
            string inputId = Console.ReadLine()!;

            if (!int.TryParse(inputId, out int idSelecionado))
            {
                Console.WriteLine("\n Erro! ID inválido!");
                Console.WriteLine("\nOperação Cancelada.");
                Thread.Sleep(2000);
                return;
            }

            bool conseguiuExcluir = repositorioRevista.Excluir(idSelecionado);

            if (!conseguiuExcluir) { Console.WriteLine("\n                 Revista não encontrada ou não pôde ser excluída."); }
            else { Console.WriteLine("                       Revista excluída com sucesso!"); }

            Console.WriteLine();

            Thread.Sleep(1000);
            VisualizarRevistas();
        }
        public void VisualizarRevistas()
        {
            Console.Clear();
            ExibirTitulo(false);
            Console.WriteLine("                             REVISTAS CADASTRADAS");
            Console.WriteLine("--------------------------------------------------------------------------------");

            Revista[] revistasCadastradas = repositorioRevista.SelecionarTodas();

            bool temCadastros = false;

            Console.WriteLine("{0,-3} | {1,-30} | {2,-6} | {3,-6} | {4,-13} | {5,-8}",
                "Id", "Título", "Edição", "Ano", "Status", "Caixa"
            );

            for (int i = 0; i < revistasCadastradas.Length; i++)
            {
                Revista dadosRevista = revistasCadastradas[i];

                if (dadosRevista == null) continue;
                temCadastros = true;

                string tituloFormatado = dadosRevista.Titulo.Length > 30
                    ? dadosRevista.Titulo.Substring(0, 27) + "..."
                    : dadosRevista.Titulo;

                string statusFormatado = dadosRevista.StatusEmprestimo.Length > 13
                    ? dadosRevista.StatusEmprestimo.Substring(0, 10) + "..."
                    : dadosRevista.StatusEmprestimo;

                if (dadosRevista.Caixa != null)
                {
                    Console.Write("{0,-3} | {1,-30} | {2,-6} | {3,-6} | {4,-13} | ",
                        dadosRevista.Id,
                        tituloFormatado,
                        dadosRevista.Edicao,
                        dadosRevista.AnoPublicacao,
                        statusFormatado
                    );

                    Console.ForegroundColor = dadosRevista.ObterCorConsole(dadosRevista.Caixa.Cor);
                    Console.WriteLine("{0,-8}", dadosRevista.Caixa.Etiqueta);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("{0,-3} | {1,-30} | {2,-6} | {3,-6} | {4,-13} | {5,-8}",
                        dadosRevista.Id,
                        tituloFormatado,
                        dadosRevista.Edicao,
                        dadosRevista.AnoPublicacao,
                        statusFormatado,
                        "Nenhuma"
                    );
                }
            }

            if (!temCadastros)
                Console.WriteLine("\n                         Nenhuma revista cadastrada");

            Console.WriteLine("\n                   Aperte qualquer tecla para continuar");
            Console.ReadKey();
            Thread.Sleep(500);
        }


        public void ColocarNaCaixa()
        {
            VisualizarRevistas();

            Console.WriteLine("\nDigite o ID da Revista que deseja ADICIONAR a uma Caixa");
            int idSelecionado = Convert.ToInt32(Console.ReadLine()!);

            Revista revista = repositorioRevista.SelecionarPorId(idSelecionado)!;

            telaCaixa.VisualizarCaixas();

            Console.WriteLine($"\nDigite o ID da Caixa que deseja ADICIONAR {revista.Titulo}");
            int idCaixa = Convert.ToInt32(Console.ReadLine()!);

            Caixa caixa = repositorioCaixa.SelecionarPorId(idCaixa)!;

            caixa.AdicionarRevista(revista);
            revista.Caixa = caixa;

            Console.WriteLine("                       Revista incluída com sucesso!");
            Console.WriteLine();

            Thread.Sleep(1000);
            VisualizarRevistas();
        }
        public void RemoverDaCaixa()
        {
            Console.Clear();
            ExibirTitulo(false);
            Console.WriteLine("                             REMOVER REVISTA DE CAIXA");
            Console.WriteLine("--------------------------------------------------------------------------------");

            VisualizarRevistas();

            Console.WriteLine("\nDigite o ID da Revista que deseja REMOVER de uma Caixa");
            int idSelecionado = Convert.ToInt32(Console.ReadLine()!);

            Revista revista = repositorioRevista.SelecionarPorId(idSelecionado)!;

            if (revista == null)
            {
                Console.WriteLine("\nRevista não encontrada.");
                return;
            }

            if (revista.Caixa == null)
            {
                Console.WriteLine("\nEssa revista não está associada a nenhuma caixa.");
                return;
            }

            Console.WriteLine($"\nA revista '{revista.Titulo}' está na caixa: {revista.Caixa.Etiqueta}");

            revista.Caixa.RemoverRevista(revista);
            revista.Caixa = null;

            Console.WriteLine($"\nRevista '{revista.Titulo}' removida com sucesso!");
            Console.WriteLine();

            Thread.Sleep(5000);
            VisualizarRevistas();
        }
    }
}
