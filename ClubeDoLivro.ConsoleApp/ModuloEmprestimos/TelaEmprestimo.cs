﻿using System;
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

            
            bool podeEmprestar = revistaEmprestada.PodeEmprestar();  

            if (!podeEmprestar)
            {
                Console.WriteLine("\n                       Erro: Esta revista já está emprestada.");
                Thread.Sleep(2000);
                return;  
            }

            DateOnly dataEmprestimo = DateOnly.FromDateTime(DateTime.Today);

            Emprestimo novoEmprestimo = new Emprestimo(amigoEmprestado, revistaEmprestada, dataEmprestimo);

            novoEmprestimo.StatusEmprestimo = "Em Aberto";

            if (!novoEmprestimo.Validar())
            {
                Thread.Sleep(2000);
                return;
            }

            repositorioEmprestimo.Inserir(novoEmprestimo);
            novoEmprestimo.Revista.StatusEmprestimo = "Emprestada";
           
            amigoEmprestado.AdicionarEmprestimos(novoEmprestimo);

            VisualizarEmprestimos();
            Console.WriteLine("                       Empréstimo registrado com sucesso!");
            Thread.Sleep(1000);
        }


        public void EditarEmprestimo()
        {
            Console.Clear();
            ExibirTitulo(false);
            Console.WriteLine("                             EDIÇÃO DE EMPRÉSTIMO");
            Console.WriteLine("--------------------------------------------------------------------------------");

            VisualizarEmprestimos();

            bool temCadastros = false;

            foreach (var emprestimo in repositorioEmprestimo.EmprestimosCadastrados)
            {
                if (emprestimo != null)
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

            Console.WriteLine("\nDigite o ID do Empréstimo que deseja EDITAR");
            string inputId = Console.ReadLine()!;

            if (!int.TryParse(inputId, out int idSelecionado))
            {
                Console.WriteLine("\n Erro! ID inválido!");
                Console.WriteLine("\nOperação Cancelada.");
                Thread.Sleep(2000);
                return;
            }

            Emprestimo emprestimoExistente = repositorioEmprestimo.SelecionarPorId(idSelecionado)!;

            if (emprestimoExistente == null)
            {
                Console.WriteLine("\nErro! Nenhum empréstimo com esse ID foi encontrado!");
                Console.WriteLine("\nOperação Cancelada.");
                Thread.Sleep(2000);
                return;
            }

            telaAmigo.VisualizarAmigos();

            Console.WriteLine($"\nInsira o ID DO AMIGO que irá pegar a revista EMPRESTADA: ");
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

            DateOnly dataEmprestimo = repositorioEmprestimo.SelecionarPorId(idSelecionado)!.DataEmprestimo;

            emprestimoExistente.Amigo?.RemoverEmprestimos(emprestimoExistente);

            emprestimoExistente.Revista.StatusEmprestimo = "Disponível";

            Emprestimo emprestimoEditado = new Emprestimo(amigoEmprestado, revistaEmprestada, dataEmprestimo);

            if (!emprestimoEditado.Validar())
            {
                Thread.Sleep(2000);
                return;
            }

            bool conseguiuEditar = repositorioEmprestimo.Editar(idSelecionado, emprestimoEditado);

            amigoEmprestado.AdicionarEmprestimos(emprestimoEditado);

            if (!conseguiuEditar)
            {
                Console.WriteLine("                Ocorreu um erro durante a edição...");
                return;
            }

            emprestimoEditado.Revista.StatusEmprestimo = "Emprestada";

            Console.WriteLine();
            Console.WriteLine("                       Empréstimo editado com sucesso!");
            Thread.Sleep(1000);
            VisualizarEmprestimos();
        }

        public Emprestimo? ExcluirEmprestimo(bool devolucao = false)
        {
            if (!devolucao)
            {
                Console.Clear();
                ExibirTitulo(false);
                Console.WriteLine("                             EXCLUSÃO DE EMPRÉSTIMO");
                Console.WriteLine("--------------------------------------------------------------------------------");
                VisualizarEmprestimos();
            }

            bool temCadastros = repositorioEmprestimo.EmprestimosCadastrados.Any(e => e != null);

            if (!temCadastros)
            {
                if (!devolucao)
                {
                    Console.WriteLine("\n                            Voltando ao menu");
                    Thread.Sleep(1000);
                }
                return null;
            }

            if (!devolucao)
                Console.WriteLine("\nDigite o ID do Empréstimo em questão: ");

            string inputId = Console.ReadLine()!;
            if (!int.TryParse(inputId, out int idSelecionado))
            {
                if (!devolucao)
                {
                    Console.WriteLine("\n Erro! ID inválido!");
                    Console.WriteLine("\nOperação Cancelada.");
                    Thread.Sleep(2000);
                }
                return null;
            }

            Emprestimo emprestimoExcluido = repositorioEmprestimo.SelecionarPorId(idSelecionado)!;

            if (emprestimoExcluido != null)
            {
                emprestimoExcluido.Revista.StatusEmprestimo = "Disponível";
                emprestimoExcluido.Amigo?.RemoverEmprestimos(emprestimoExcluido);
            }

            bool conseguiuExcluir = repositorioEmprestimo.Excluir(idSelecionado);

            if (!conseguiuExcluir)
            {
                if (!devolucao)
                    Console.WriteLine("\n                 Empréstimo não encontrado!");
                return null;
            }

            if (!devolucao)
            {
                Console.WriteLine("                       Empréstimo excluído com sucesso!");
                Console.WriteLine();
                Thread.Sleep(1000);
                VisualizarEmprestimos();
            }

            return emprestimoExcluido;
        }

        public void RegistrarDevolucao()
        {
            Console.Clear();
            ExibirTitulo(false);
            Console.WriteLine("                             REGISTRO DE DEVOLUÇÃO");
            Console.WriteLine("--------------------------------------------------------------------------------");
            VisualizarEmprestimos();

            Console.WriteLine("\nDigite o ID do Empréstimo em questão: ");

            string inputId = Console.ReadLine()!;
            if (!int.TryParse(inputId, out int idSelecionado))
            {
                Console.WriteLine("\n                       Erro! ID inválido!");
                Console.WriteLine("\n                      Operação Cancelada.");
                Thread.Sleep(2000);
                return;
            }

            Emprestimo emprestimoFechado = repositorioEmprestimo.SelecionarPorId(idSelecionado)!;

            if (emprestimoFechado == null)
            {
                Console.WriteLine("                        Empréstimo não encontrado.");
                Console.WriteLine("\n                         Operação Cancelada.");
                Thread.Sleep(2000);
                return;
            }

            emprestimoFechado.StatusEmprestimo = "Fechado";
            emprestimoFechado.Revista.StatusEmprestimo = "Disponível";


            DateOnly dataDevolucaoReal = DateOnly.FromDateTime(DateTime.Today);
            emprestimoFechado.FecharEmprestimo(dataDevolucaoReal);

            Console.WriteLine("                       Devolução registrada com sucesso!");
            Thread.Sleep(1500);
        }

        public void VisualizarEmprestimos()
        {
            Console.Clear();
            ExibirTitulo(false);
            Console.WriteLine("                             EMPRÉSTIMOS REGISTRADOS");
            Console.WriteLine("--------------------------------------------------------------------------------");

            Emprestimo[] emprestimosCadastrados = repositorioEmprestimo.SelecionarTodas();
            Revista[] revistasCadastradas = repositorioRevista.SelecionarTodas();

            bool temCadastros = false;

            int larguraId = 3;
            int larguraAmigo = 18;
            int larguraRevista = 20;
            int larguraDataEmprestimo = 12;
            int larguraPrazoDeEntrega = 15;

            Console.WriteLine("{0,-" + larguraId + "} | {1,-" + larguraAmigo + "} | {2,-" + larguraRevista + "} | {3,-" + larguraDataEmprestimo + "} | {4,-" + larguraPrazoDeEntrega + "}",
                "Id", "Amigo", "Revista", "Data Empréstimo", "Prazo de Entrega");

            foreach (Emprestimo dadosEmprestimo in emprestimosCadastrados)
            {
                if (dadosEmprestimo == null || dadosEmprestimo.StatusEmprestimo == "Fechado")
                    continue;

                temCadastros = true;

                Revista dadosRevista = revistasCadastradas.FirstOrDefault(r => r.Id == dadosEmprestimo.Revista.Id)!;
                if (dadosRevista == null)
                {
                    Console.WriteLine("\nRevista não encontrada para o empréstimo!");
                    continue;
                }

                string tituloFormatado = dadosEmprestimo.Revista.Titulo.Length > larguraRevista
                    ? dadosEmprestimo.Revista.Titulo.Substring(0, larguraRevista - 3) + "..."
                    : dadosEmprestimo.Revista.Titulo;

                string amigoFormatado = dadosEmprestimo.Amigo.NomeCompleto.Length > larguraAmigo
                    ? dadosEmprestimo.Amigo.NomeCompleto.Substring(0, larguraAmigo - 3) + "..."
                    : dadosEmprestimo.Amigo.NomeCompleto;

                Console.Write("{0,-" + larguraId + "} | {1,-" + larguraAmigo + "} | ", dadosEmprestimo.Id, amigoFormatado);

                if (dadosRevista.Caixa != null)
                    Console.ForegroundColor = dadosRevista.ObterCorConsole(dadosRevista.Caixa.Cor);

                Console.Write("{0,-" + larguraRevista + "}", tituloFormatado);
                Console.ResetColor();

                Console.WriteLine(" | {0,-" + larguraDataEmprestimo + "} | {1,-" + larguraPrazoDeEntrega + "}",
                    dadosEmprestimo.DataEmprestimo.ToString("dd/MM/yyyy"),
                    dadosEmprestimo.CalcularDataDevolucao(dadosEmprestimo.DataEmprestimo, dadosRevista).ToString("dd/MM/yyyy"));
            }

            if (!temCadastros)
                Console.WriteLine("\n                         Nenhum empréstimo registrado.");

            Console.WriteLine("\n                   Aperte qualquer tecla para continuar");
            Console.ReadKey();
            Thread.Sleep(500);
        }

    }
}
