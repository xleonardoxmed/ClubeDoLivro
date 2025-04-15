using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDoLivro.ConsoleApp.ModuloAmigo;
using ClubeDoLivro.ConsoleApp.ModuloCaixas;
using ClubeDoLivro.ConsoleApp.ModuloRevistas;

namespace ClubeDoLivro.ConsoleApp.ModuloEmprestimos
{
    public class TelaEmprestimo
    {
        RepositorioAmigo repositorioAmigo;
        RepositorioRevista repositorioRevista;
        RepositorioEmprestimo repositorioEmprestimo;

        TelaAmigo telaAmigo;
        TelaRevista telaRevista;

        public TelaEmprestimo(RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista, RepositorioEmprestimo repositorioEmprestimo, TelaAmigo telaAmigo, TelaRevista telaRevista)
        {
            this.repositorioAmigo = repositorioAmigo;
            this.repositorioRevista = repositorioRevista;
            this.repositorioEmprestimo = repositorioEmprestimo;

            this.telaAmigo = telaAmigo;
            this.telaRevista = telaRevista;
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
                Console.WriteLine("                              1 - Registrar Empréstimos");
                Console.WriteLine("                              2 - Editar Empréstimos");
                Console.WriteLine("                              3 - Excluir Empréstimos");
                Console.WriteLine("                              4 - Visualizar Empréstimos");
                Console.WriteLine("                              5 - Visualizar Revistas");
                Console.WriteLine("                              6 - Visualizar Amigos");
                Console.WriteLine("                              7 - Registrar Devolução");
                Console.WriteLine("                              8 - Voltar ao Menu");
                Console.WriteLine("--------------------------------------------------------------------------------");
                char opcaoEscolhida = Convert.ToChar(Console.ReadLine()![0]);
                return opcaoEscolhida;
            }
            else return 'S';

        }

        public void InserirEmprestimo()
        {
            Console.Clear();
            ExibirTitulo(false);
            Console.WriteLine("                             REGISTRO DE EMPRÉSTIMO");
            Console.WriteLine("--------------------------------------------------------------------------------");

            telaAmigo.VisualizarAmigos();

            bool temCadastros = false;

            foreach (var amigo in repositorioAmigo.AmigosCadastrados)
            {
                if (amigo != null)
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

            Console.WriteLine("\nInsira o ID DO AMIGO que ira pegar uma revista EMPRESTADA: ");
            string inputAmigoId = Console.ReadLine()!;

            if (!int.TryParse(inputAmigoId, out int idAmigoSelecionado))
            {
                Console.WriteLine("\n Erro! ID inválido!");
                Console.WriteLine("\nOperação Cancelada.");
                Thread.Sleep(2000);
                return;
            }


            Amigo amigoEmprestado = repositorioAmigo.SelecionarPorId(idAmigoSelecionado)!;

            if (amigoEmprestado == null)
            {
                Console.WriteLine("\nErro! ID do amigo inválido ou não encontrado.");
                return;
            }

            telaRevista.VisualizarRevistas();

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

            Console.WriteLine($"\nInsira o ID DA REVISTA que {amigoEmprestado.NomeCompleto} quer pegar EMPRESTADA: ");
            string inputRevistaId = Console.ReadLine()!;

            if (!int.TryParse(inputRevistaId, out int idRevistaSelecionado))
            {
                Console.WriteLine("\n Erro! ID inválido!");
                Console.WriteLine("\nOperação Cancelada.");
                Thread.Sleep(2000);
                return;
            }

            Revista revistaEmprestada = repositorioRevista.SelecionarPorId(idRevistaSelecionado)!;

            if (revistaEmprestada.Caixa == null)
            {
                Console.WriteLine("Erro: A revista selecionada não tem uma caixa associada. Não é possível registrar o empréstimo.");
                Thread.Sleep(2000);
                return;
            }

            DateOnly dataEmprestimo = DateOnly.FromDateTime(DateTime.Today);

            Emprestimo novoEmprestimo = new Emprestimo(amigoEmprestado, revistaEmprestada, dataEmprestimo);


            if (!novoEmprestimo.Validar())
            {
                Thread.Sleep(2000);
                return;
            }

            repositorioEmprestimo.Inserir(novoEmprestimo);

            VisualizarEmprestimos();
            Console.WriteLine("                       Empréstimo registrado com sucesso!");
            Thread.Sleep(1000);
        }

        internal void EditarEmprestimo()
        {
            throw new NotImplementedException();
        }

        internal void ExcluirEmprestimo()
        {
            throw new NotImplementedException();
        }

        internal void RegistrarDevolucao()
        {
            throw new NotImplementedException();
        }

        public void VisualizarEmprestimos()
        {
            Console.Clear();
            ExibirTitulo(false);
            Console.WriteLine("                             EMPRÉSTIMOS REGISTRADOS");
            Console.WriteLine("--------------------------------------------------------------------------------");

            Emprestimo[] emprestimosCadastrados = repositorioEmprestimo.SelecionarTodas();
            Revista[] revistosCadastradas = repositorioRevista.SelecionarTodas();

            bool temCadastros = false;


            Console.WriteLine("{0,-3} | {1,-40} | {2,-6} | {3,-6} | {4,-12}",
             "Id", "Amigo", "Revista", "Data de Empréstimo", "Prazo de Entrega"
            );

            for (int i = 0; i < emprestimosCadastrados.Length; i++)
            {
                Emprestimo dadosEmprestimo = emprestimosCadastrados[i];
                Revista dadosRevista = revistosCadastradas[i];

                if (dadosEmprestimo == null) continue;
                temCadastros = true;

                string tituloFormatado = dadosEmprestimo.Titulo.Length > 40 ? dadosEmprestimo.Titulo.Substring(0, 37) + "..." : dadosEmprestimo.Titulo;

                if (dadosEmprestimo.Caixa != null)
                {
                    Console.Write("{0,-3} | {1,-40} | {2,-6} | {3,-6} | {4,-12} | ",
                        dadosEmprestimo.Id,
                        tituloFormatado,
                        dadosEmprestimo.Edicao,
                        dadosEmprestimo.AnoPublicacao,
                        dadosEmprestimo.StatusEmprestimo
                    );

                    Console.ForegroundColor = dadosRevista.ObterCorConsole(dadosRevista.Caixa.Cor);
                    Console.Write(dadosRevista.Caixa.Etiqueta); // Pinta a caixa 
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("{0,-3} | {1,-40} | {2,-6} | {3,-6} | {4,-12} | {5} ",
                        dadosRevista.Id,
                        tituloFormatado,
                        dadosRevista.Edicao,
                        dadosRevista.AnoPublicacao,
                        dadosRevista.StatusEmprestimo,
                        "Nenhuma"
                    );
                }
            }
        }
    }
