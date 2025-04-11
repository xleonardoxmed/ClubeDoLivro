using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.ConsoleApp.ModuloAmigo
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

            Console.WriteLine("\n                    Insira o NOME COMPLETO do amigo: ");
            string nomeCompleto = Convert.ToString(Console.ReadLine()!);

            Console.WriteLine($"\n                   Insira o NOME DO RESPONSÁVEL de {nomeCompleto}: ");
            string nomeResponsavel = Convert.ToString(Console.ReadLine()!);

            Console.WriteLine($"\n                   Insira o NÚMERO DE TELEFONE de {nomeCompleto}");
            string telefone = Console.ReadLine()!;

            Amigo novoAmigo = new Amigo(nomeCompleto, nomeResponsavel, telefone);
            AmigosCadastrados[contadorAmigos++] = novoAmigo;
            novoAmigo.Id = contadorAmigos;

            VisualizarAmigos();
            Console.WriteLine("                       Amigo adicionado com sucesso!");
            Thread.Sleep(3000);
        }


        public void EditarAmigo()
        {
            Console.Clear();
            ExibirTitulo();
            Console.WriteLine("                             EDIÇÃO DE AMIGO");
            Console.WriteLine("--------------------------------------------------------------------------------");

            VisualizarAmigos();

            Console.WriteLine("                   Digite o ID do Amigo que deseja EDITAR");
            int idSelecionado = Convert.ToInt32(Console.ReadLine()!);

            Console.WriteLine("\n                     Insira o NOME COMPLETO do amigo: ");
            string nomeCompleto = Convert.ToString(Console.ReadLine()!);

            Console.WriteLine($"\n                    Insira o NOME DO RESPONSÁVEL de {nomeCompleto}: ");
            string nomeResponsavel = Convert.ToString(Console.ReadLine()!);

            Console.WriteLine($"\n                    Insira o NÚMERO DE TELEFONE de {nomeCompleto}");
            string telefone = Console.ReadLine()!;

            Amigo amigoEditado = new Amigo(nomeCompleto, nomeResponsavel, telefone);

            bool conseguiuEditar = false;

            for (int i = 0; i < AmigosCadastrados.Length; i++)
            {
                if (AmigosCadastrados[i] == null) continue;
                else if (AmigosCadastrados[i].Id == idSelecionado)
                {
                    AmigosCadastrados[i].NomeCompleto = amigoEditado.NomeCompleto;
                    AmigosCadastrados[i].NomeResponsavel = amigoEditado.NomeResponsavel;
                    AmigosCadastrados[i].Telefone = amigoEditado.Telefone;
                    conseguiuEditar = true;
                }
            }

            if (!conseguiuEditar)
            {
                Console.WriteLine("                Ocorreu um erro durante a edição...");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("                       Amigo editado com sucesso!");
            Thread.Sleep(3000);

        }

        public void ExcluirAmigo()
        {
            throw new NotImplementedException();
        }

        public void VisualizarAmigos()
        {
            Console.Clear();
            ExibirTitulo();
            Console.WriteLine("                             AMIGOS CADASTRADOS");
            Console.WriteLine("--------------------------------------------------------------------------------");

            Console.WriteLine("{0,-3} | {1,-30} | {2,-30} | {3,-15}",
               "Id", "Nome Completo", "Nome do Responsável", "Telefone"
           );

            for (int i = 0; i < AmigosCadastrados.Length; i++)
            {
                Amigo dadosAmigo = AmigosCadastrados[i];

                if (dadosAmigo == null) continue;

                Console.WriteLine("{0,-3} | {1,-30} | {2,-30} | {3,-15}",
                 dadosAmigo.Id, dadosAmigo.NomeCompleto, dadosAmigo.NomeResponsavel, dadosAmigo.Telefone
                );
                Console.WriteLine("--------------------------------------------------------------------------------");
            }
        }
    }
}


