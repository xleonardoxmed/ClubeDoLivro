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

            Console.WriteLine($"\nInsira a COR da caixa {etiqueta}: ");
            string cor = Convert.ToString(Console.ReadLine()!);

            Console.WriteLine($"\nInsira o prazo de devolução da caixa {etiqueta} em dias (números); ");
            int diasEmprestimo = Convert.ToInt32(Console.ReadLine()!);

            Caixa novaCaixa = new Caixa(etiqueta, cor, diasEmprestimo);
            //repositorioCaixa.Inserir(novaCaixa);

            //VisualizarCaixas();
            Console.WriteLine("                       Amigo adicionado com sucesso!");
            Thread.Sleep(1000);
        }

        internal void EditarCaixa()
        {
            throw new NotImplementedException();
        }

        internal void ExcluirCaixa()
        {
            throw new NotImplementedException();
        }

        internal void VisualizarCaixas()
        {
            throw new NotImplementedException();
        }
    }
}
