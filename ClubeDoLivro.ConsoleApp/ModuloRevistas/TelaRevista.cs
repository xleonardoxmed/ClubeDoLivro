using ClubeDoLivro.ConsoleApp.ModuloAmigo;
using ClubeDoLivro.ConsoleApp.ModuloCaixas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.ConsoleApp.ModuloRevistas
{
    public class TelaRevista
    {
        RepositorioRevista repositorioRevista = new RepositorioRevista();
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
                Console.WriteLine("                              6 - Voltar ao Menu");
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
            string titulo = Convert.ToString(Console.ReadLine()!);

            Console.WriteLine($"\nInsira a EDIÇÃO da revista {titulo}: ");
            string edicao = Convert.ToString(Console.ReadLine()!);

            Console.WriteLine($"\nInsira o ANO DE PUBLICAÇÃO (nome) da revista {titulo}: ");
            int anoPublicacao = Convert.ToInt32(Console.ReadLine()!);

            Revista novaRevista = new Revista(titulo, edicao, anoPublicacao);
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

            Console.WriteLine("\nDigite o ID da Revista que deseja EDITAR");
            int idSelecionado = Convert.ToInt32(Console.ReadLine()!);

            Console.WriteLine("\nInsira o TITULO (nome) da revista: ");
            string titulo = Convert.ToString(Console.ReadLine()!);

            Console.WriteLine($"\nInsira a EDIÇÃO da revista {titulo}: ");
            string edicao = Convert.ToString(Console.ReadLine()!);

            Console.WriteLine($"\nInsira o ANO DE PUBLICAÇÃO (nome) da revista {titulo}: ");
            int anoPublicacao = Convert.ToInt32(Console.ReadLine()!);

            Revista novaRevista = new Revista(titulo, edicao, anoPublicacao);
            repositorioRevista.Editar(idSelecionado, novaRevista);

            bool conseguiuEditar = repositorioRevista.Editar(idSelecionado, novaRevista);

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

            Console.WriteLine("\nDigite o ID da Revista que deseja EXCLUIR");
            int idSelecionado = Convert.ToInt32(Console.ReadLine()!);

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

            Console.WriteLine("{0,-3} | {1,-40} | {2,-6} | {3,-6} | {4,-12} | {5}",
             "Id", "Título", "Edição", "Ano", "Status", "Caixa"
            );

            for (int i = 0; i < revistasCadastradas.Length; i++)
            {
                Revista dadosRevista = revistasCadastradas[i];

                if (dadosRevista == null) continue;
                temCadastros = true;

                string tituloFormatado = dadosRevista.Titulo.Length > 40 ? dadosRevista.Titulo.Substring(0, 37) + "..." : dadosRevista.Titulo;

                Console.WriteLine("{0,-3} | {1,-40} | {2,-6} | {3,-6} | {4,-12} | {5}",
                    dadosRevista.Id,
                    tituloFormatado,
                    dadosRevista.Edicao,
                    dadosRevista.AnoPublicacao,
                    dadosRevista.StatusEmprestimo,
                    string.IsNullOrEmpty(dadosRevista.Caixa) ? "Nenhuma" : dadosRevista.Caixa
                );
                Console.WriteLine("--------------------------------------------------------------------------------");
            }

            if (!temCadastros) { Console.WriteLine("\n                         Nenhuma revista cadastrada"); }

            Console.WriteLine("\n                   Aperte qualquer tecla para continuar");
            Console.ReadKey();
            Thread.Sleep(500);
        }
    }
}
