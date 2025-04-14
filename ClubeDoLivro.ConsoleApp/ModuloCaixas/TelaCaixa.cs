using ClubeDoLivro.ConsoleApp.ModuloAmigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.ConsoleApp.ModuloCaixas
{
    public class TelaCaixa
    {
        public RepositorioCaixa repositorioCaixa;
        public TelaCaixa(RepositorioCaixa repositorioCaixa)
        {
            this.repositorioCaixa = repositorioCaixa;
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
                Console.WriteLine("                              1 - Cadastrar Caixas");
                Console.WriteLine("                              2 - Editar Caixas");
                Console.WriteLine("                              3 - Excluir Caixas");
                Console.WriteLine("                              4 - Visualizar Caixas");
                Console.WriteLine("                              5 - Voltar ao Menu");
                Console.WriteLine("--------------------------------------------------------------------------------");
                char opcaoEscolhida = Convert.ToChar(Console.ReadLine()![0]);
                return opcaoEscolhida;
            }
            else return 'S';

        }
        public void InserirCaixa()
        {
            Console.Clear();
            ExibirTitulo(false);
            Console.WriteLine("                             CADASTRO DE CAIXA");
            Console.WriteLine("--------------------------------------------------------------------------------");

            Console.WriteLine("\nInsira a ETIQUETA (nome) da caixa: ");
            string etiqueta = Convert.ToString(Console.ReadLine()!);

            string cor = SolicitarCorValida(etiqueta);

            Console.WriteLine($"\nInsira o prazo de devolução da caixa {etiqueta} em dias (números): ");
            int diasEmprestimo = Convert.ToInt32(Console.ReadLine()!);

            Caixa novaCaixa = new Caixa(etiqueta, cor, diasEmprestimo);
            repositorioCaixa.Inserir(novaCaixa);

            VisualizarCaixas();
            Console.WriteLine("                       Caixa adicionada com sucesso!");
            Thread.Sleep(1000);
        }

        public void EditarCaixa()
        {
            Console.Clear();
            ExibirTitulo(false);
            Console.WriteLine("                             EDIÇÃO DE CAIXA");
            Console.WriteLine("--------------------------------------------------------------------------------");

            VisualizarCaixas();

            Console.WriteLine("\nDigite o ID da Caixa que deseja EDITAR");
            int idSelecionado = Convert.ToInt32(Console.ReadLine()!);

            Console.WriteLine("\nInsira a ETIQUETA (nome) da caixa: ");
            string etiqueta = Convert.ToString(Console.ReadLine()!);

            string cor = SolicitarCorValida(etiqueta);

            Console.WriteLine($"\nInsira o prazo de devolução da caixa {etiqueta} em dias (números): ");
            int diasEmprestimo = Convert.ToInt32(Console.ReadLine()!);

            Caixa caixaEditada = new Caixa(etiqueta, cor, diasEmprestimo);

            bool conseguiuEditar = repositorioCaixa.Editar(idSelecionado, caixaEditada);

            if (!conseguiuEditar)
            {
                Console.WriteLine("                Ocorreu um erro durante a edição...");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("                       Caixa editada com sucesso!");
            Thread.Sleep(1000);
            VisualizarCaixas();

        }

        public void ExcluirCaixa()
        {
            Console.Clear();
            ExibirTitulo(false);
            Console.WriteLine("                             EXCLUSÃO DE CAIXA");
            Console.WriteLine("--------------------------------------------------------------------------------");

            VisualizarCaixas();

            Console.WriteLine("\nDigite o ID da Caixa que deseja EXCLUIR");
            int idSelecionado = Convert.ToInt32(Console.ReadLine()!);

            bool conseguiuExcluir = repositorioCaixa.Excluir(idSelecionado);

            if (!conseguiuExcluir) { Console.WriteLine("\n                 Caixa não encontrada ou não pôde ser excluída."); }
            else { Console.WriteLine("                       Caixa excluída com sucesso!"); }

            Console.WriteLine();

            Thread.Sleep(1000);
            VisualizarCaixas();
        }

        public void VisualizarCaixas()
        {
            Console.Clear();
            ExibirTitulo(false);
            Console.WriteLine("                             CAIXAS CADASTRADAS");
            Console.WriteLine("--------------------------------------------------------------------------------");

            Caixa[] caixasCadastradas = repositorioCaixa.SelecionarTodas();

            bool temCadastros = false;

            Console.WriteLine("{0,-3} | {1,-30} | {2,-30} | {3,-15}",
               "Id", "Etiqueta:", "Cor", "Prazo de Devolução"
           );

            for (int i = 0; i < caixasCadastradas.Length; i++)
            {
                Caixa dadosCaixa = caixasCadastradas[i];

                if (dadosCaixa == null) continue;
                temCadastros = true;

                Console.Write("{0,-3} | {1,-30} | ", dadosCaixa.Id, dadosCaixa.Etiqueta);

                ConsoleColor corConsole = ObterCorConsole(dadosCaixa.Cor);
                Console.ForegroundColor = corConsole;
                Console.Write("{0,-30}", dadosCaixa.Cor);
                //Pinta a cor
                Console.ResetColor();
                Console.WriteLine(" | {0,-15}", dadosCaixa.DiasEmprestimo);
                Console.WriteLine("--------------------------------------------------------------------------------");
            }


            if (!temCadastros) { Console.WriteLine("\n                         Nenhuma caixa cadastrada"); }

            Console.WriteLine("\n                   Aperte qualquer tecla para continuar");
            Console.ReadKey();
            Thread.Sleep(500);
        }
        public ConsoleColor ObterCorConsole(string cor)
        {
            return cor.ToLower() switch
            {
                "vermelho" => ConsoleColor.Red,
                "verde" => ConsoleColor.Green,
                "azul" => ConsoleColor.Blue,
                "amarelo" => ConsoleColor.Yellow,
                "ciano" => ConsoleColor.Cyan,
                "branco" => ConsoleColor.White,
                "cinza" => ConsoleColor.Gray,
                "magenta" => ConsoleColor.Magenta,
                _ => ConsoleColor.White
            };
        }

        public string SolicitarCorValida(string etiqueta)
        {
            string[] coresValidas = { "vermelho", "verde", "azul", "amarelo", "ciano", "branco", "cinza","magenta" };

            string cor;

            Console.WriteLine("\nCores disponíveis: " + string.Join(", ", coresValidas));

            while (true)
            {
                Console.WriteLine($"\nInsira a COR da caixa {etiqueta}: ");
                cor = Console.ReadLine()!;

                if (coresValidas.Contains(cor.ToLower()))
                    break;

                Console.WriteLine("Cor inválida! Tente novamente.");
            }

            return cor;
        }
    }
}
