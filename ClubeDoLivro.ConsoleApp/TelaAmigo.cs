using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.ConsoleApp
{
    /* Módulo de Amigos
    Requisitos Funcionais
    ● O sistema deve permitir a inserção de novos amigos
    ● O sistema deve permitir a edição de amigos já cadastrados
    ● O sistema deve permitir excluir amigos já cadastrados
    ● O sistema deve permitir visualizar amigos cadastrados
    ● O sistema deve permitir visualizar os empréstimos do amigo.
    Regras de Negócio:
    ● Campos obrigatórios:
        ○ Nome(mínimo 3 caracteres, máximo 100)
        ○ Nome do responsável(mínimo 3 caracteres, máximo 100)
        ○ Telefone(formato validado: (XX) XXXX-XXXX ou (XX) XXXXX-XXXX)
    ● Não pode haver amigos com o mesmo nome e telefone.
    ● Não permitir excluir um amigo caso tenha empréstimos vinculados
    */
    public class TelaAmigo
    {
        public Amigo[] AmigosCadastrados = new Amigo[100];
        public int contadorAmigos;

        public void ExibirTitulo()
        {
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("                               CLUBE DO LIVRO");
            Console.WriteLine("--------------------------------------------------------------------------------");
        }
        public void InserirAmigo()
        {
            ExibirTitulo();
            Console.WriteLine("                             CADASTRO DE AMIGO");
            Console.WriteLine("--------------------------------------------------------------------------------");

            Console.WriteLine("\nInsira o NOME COMPLETO do amigo que deseja cadastrar: ");
            string nomeCompleto = Convert.ToString(Console.ReadLine()!);

            Console.WriteLine($"\nInsira o NOME DO RESPONSÁVEL de {nomeCompleto}: ");
            string nomeResponsavel = Convert.ToString(Console.ReadLine()!);

            Console.WriteLine($"\nInsira o NÚMERO DE TELEFONE de {nomeCompleto}");
            string telefone = Console.ReadLine()!;

            Amigo novoAmigo = new Amigo(nomeCompleto, nomeResponsavel, telefone);

            AmigosCadastrados[contadorAmigos++] = novoAmigo;
            VisualizarAmigos();
        }


        internal void EditarAmigo()
        {
            throw new NotImplementedException();
        }

        internal void ExcluirAmigo()
        {
            throw new NotImplementedException();
        }

        internal void VisualizarAmigos()
        {
            Console.Clear();
            ExibirTitulo();
            Console.WriteLine("                             AMIGOS CADASTRADOS");
            Console.WriteLine("--------------------------------------------------------------------------------");

            Console.WriteLine("{0, -30} | {1, -30} | {2, -15}",
               "Nome Completo","Nome do Responsável","Telefone"
           );

            for (int i = 0; i < AmigosCadastrados.Length; i++)
            {
                Amigo dadosAmigo = AmigosCadastrados[i];

                if (dadosAmigo == null) continue;

                Console.WriteLine("{0, -30} | {1, -30} | {2, -15}",
                 dadosAmigo.NomeCompleto, dadosAmigo.NomeResponsavel, dadosAmigo.Telefone
                );
                Console.WriteLine("--------------------------------------------------------------------------------");
            }
            Console.ReadLine();
        }
    }
}


