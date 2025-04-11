using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.ConsoleApp.ModuloAmigo
{
    /* Módulo de Amigos
    Requisitos Funcionais

    ● O sistema deve permitir visualizar os empréstimos do amigo. 
     ● Não permitir excluir um amigo caso tenha empréstimos vinculados
                                 => Fazer depois do Modulo de Emprestimos

    Regras de Negócio:

    ● Campos obrigatórios:
    VALIDAÇÕES 

        ○ Nome(mínimo 3 caracteres, máximo 100)
        ○ Nome do responsável(mínimo 3 caracteres, máximo 100)
        ○ Telefone(formato validado: (XX) XXXX-XXXX ou (XX) XXXXX-XXXX)

    ● Não pode haver amigos com o mesmo NOME e TELEFONE.

   
    */
    public class TelaAmigo
    {
        public Amigo[] AmigosCadastrados = new Amigo[100];
        public int contadorAmigos;

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
                Console.WriteLine("                              1 - Cadastrar Amigos");
                Console.WriteLine("                              2 - Editar Amigos");
                Console.WriteLine("                              3 - Excluir Amigos");
                Console.WriteLine("                              4 - Visualizar Amigos");
                Console.WriteLine("                              5 - Visualizar Empréstimos de Amigos");
                Console.WriteLine("--------------------------------------------------------------------------------");
                char opcaoEscolhida = Convert.ToChar(Console.ReadLine()![0]);
                return opcaoEscolhida;
            }
            else return 'S';

        }
        public void InserirAmigo()
        {
            Console.Clear();
            ExibirTitulo(false);
            Console.WriteLine("                             CADASTRO DE AMIGO");
            Console.WriteLine("--------------------------------------------------------------------------------");

            Console.WriteLine("\nInsira o NOME COMPLETO do amigo: ");
            string nomeCompleto = Convert.ToString(Console.ReadLine()!);

            Console.WriteLine($"\nInsira o NOME DO RESPONSÁVEL de {nomeCompleto}: ");
            string nomeResponsavel = Convert.ToString(Console.ReadLine()!);

            Console.WriteLine($"\nInsira o NÚMERO DE TELEFONE de {nomeCompleto}");
            string telefone = Console.ReadLine()!;

            Amigo novoAmigo = new Amigo(nomeCompleto, nomeResponsavel, telefone);
            AmigosCadastrados[contadorAmigos++] = novoAmigo;
            novoAmigo.Id = contadorAmigos;

            VisualizarAmigos();
            Console.WriteLine("                       Amigo adicionado com sucesso!");
            Thread.Sleep(1000);
        }


        public void EditarAmigo()
        {
            Console.Clear();
            ExibirTitulo(false);
            Console.WriteLine("                             EDIÇÃO DE AMIGO");
            Console.WriteLine("--------------------------------------------------------------------------------");

            VisualizarAmigos();

            Console.WriteLine("\nDigite o ID do Amigo que deseja EDITAR");
            int idSelecionado = Convert.ToInt32(Console.ReadLine()!);

            Console.WriteLine("\nInsira o NOME COMPLETO do amigo: ");
            string nomeCompleto = Convert.ToString(Console.ReadLine()!);

            Console.WriteLine($"\nInsira o NOME DO RESPONSÁVEL de {nomeCompleto}: ");
            string nomeResponsavel = Convert.ToString(Console.ReadLine()!);

            Console.WriteLine($"\nInsira o NÚMERO DE TELEFONE de {nomeCompleto}");
            string telefone = Console.ReadLine()!;

            Amigo amigoEditado = new Amigo(nomeCompleto, nomeResponsavel, telefone);

            bool conseguiuEditar = false;

            for (int i = 0; i < contadorAmigos; i++)
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
            Thread.Sleep(1000);
            VisualizarAmigos();

        }

        public void ExcluirAmigo()
        {
            Console.Clear();
            ExibirTitulo(false);
            Console.WriteLine("                             EXCLUSÃO DE AMIGO");
            Console.WriteLine("--------------------------------------------------------------------------------");

            VisualizarAmigos();

            if (contadorAmigos == 0) return;

            Console.WriteLine("\nDigite o ID do Amigo que deseja EXCLUIR");
            int idSelecionado = Convert.ToInt32(Console.ReadLine()!);

            int indice = Array.FindIndex(AmigosCadastrados, 0, contadorAmigos, a => a?.Id == idSelecionado);
            //percorre o array até encontrar o id, do início até o fim, checando se é vazio ou é o ID.
            //Guarda a posição ou -1 caso não ecnontre-a.

            if (indice == -1)
            {
                Console.WriteLine("                    Amigo não encontrado...");
                Thread.Sleep(1000);
                return;
            }

            for (int i = indice; i < contadorAmigos - 1; i++)
                AmigosCadastrados[i] = AmigosCadastrados[i + 1];
            //puxa todos para trás, preenchendo os buracos

            AmigosCadastrados[--contadorAmigos] = null!;
            //remove o último item duplicado

            for (int i = 0; i < contadorAmigos; i++)
                AmigosCadastrados[i].Id = i + 1;
            //atualiza os IDs

            Console.WriteLine();
            Console.WriteLine("                       Cadastro excluído com sucesso!");
            Thread.Sleep(1000);
            VisualizarAmigos();
        }

        public void VisualizarAmigos()
        {
            Console.Clear();
            ExibirTitulo(false);
            Console.WriteLine("                             AMIGOS CADASTRADOS");
            Console.WriteLine("--------------------------------------------------------------------------------");

            if (contadorAmigos == 0)
            {
                Console.WriteLine("\n                         Nenhum amigo cadastrado");
                Console.WriteLine("\n                   Aperte qualquer tecla para continuar");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("{0,-3} | {1,-30} | {2,-30} | {3,-15}",
               "Id", "Nome Completo", "Nome do Responsável", "Telefone"
           );

            for (int i = 0; i < contadorAmigos; i++)
            {
                Amigo dadosAmigo = AmigosCadastrados[i];

                if (dadosAmigo == null) continue;

                Console.WriteLine("{0,-3} | {1,-30} | {2,-30} | {3,-15}",
                 dadosAmigo.Id, dadosAmigo.NomeCompleto, dadosAmigo.NomeResponsavel, dadosAmigo.Telefone
                );
                Console.WriteLine("--------------------------------------------------------------------------------");
            }
            Console.WriteLine("\n                   Aperte qualquer tecla para continuar");
            Console.ReadKey();
            Thread.Sleep(500);
        }

        public void VisualizarEmprestimos()
        {
            throw new NotImplementedException();
        }
    }
}


