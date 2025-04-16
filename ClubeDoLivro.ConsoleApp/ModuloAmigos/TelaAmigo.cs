using ClubeDoLivro.ConsoleApp.ModuloEmprestimos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
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
        public RepositorioAmigo repositorioAmigo;
        public TelaAmigo(RepositorioAmigo repositorioAmigo)
        {
            this.repositorioAmigo = repositorioAmigo;
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
                Console.WriteLine("                              1 - Cadastrar Amigos");
                Console.WriteLine("                              2 - Editar Amigos");
                Console.WriteLine("                              3 - Excluir Amigos");
                Console.WriteLine("                              4 - Visualizar Amigos");
                Console.WriteLine("                              5 - Visualizar Empréstimos de Amigos");
                Console.WriteLine("                              6 - Voltar ao Menu");
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

            string nomeCompleto, nomeResponsavel, telefoneFormatado;
            List<Emprestimo> listaEmprestimosDoAmigo = new List<Emprestimo>();

            bool dadosValidos = ObterDadosAmigo(out nomeCompleto, out nomeResponsavel, out telefoneFormatado);

            if (!dadosValidos)
                return;

            Amigo novoAmigo = new Amigo(nomeCompleto, nomeResponsavel, telefoneFormatado, repositorioAmigo, listaEmprestimosDoAmigo);

            bool amigoValido = novoAmigo.Validar(novoAmigo, false);

            if (!amigoValido)
            {
                Console.WriteLine("                        Operação cancelada");
                Thread.Sleep(2000);
                return;
            }

            repositorioAmigo.Inserir(novoAmigo);

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

            string nomeCompleto, nomeResponsavel, telefoneFormatado;
            List<Emprestimo> listaEmprestimosDoAmigo = new List<Emprestimo>();

            Console.WriteLine("\nDigite o ID do Amigo que deseja EDITAR");
            string inputId = Console.ReadLine()!;


            if (!int.TryParse(inputId, out int idSelecionado))
            {
                Console.WriteLine("\n Erro! ID inválido!");
                Console.WriteLine("\nOperação Cancelada.");
                Thread.Sleep(2000);
                return;
            }

            bool dadosValidos = ObterDadosAmigo(out nomeCompleto, out nomeResponsavel, out telefoneFormatado);

            if (!dadosValidos)
                return;

            Amigo amigoEditado = new Amigo(nomeCompleto, nomeResponsavel, telefoneFormatado, repositorioAmigo, listaEmprestimosDoAmigo);

            bool amigoValido = amigoEditado.Validar(amigoEditado, true, idSelecionado);

            if (!amigoValido)
            {
                Console.WriteLine("                        Operação cancelada");
                Thread.Sleep(2000);
                return;
            }

            bool conseguiuEditar = repositorioAmigo.Editar(idSelecionado, amigoEditado);

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

            Console.WriteLine("\nDigite o ID do Amigo que deseja EXCLUIR");
            int idSelecionado = Convert.ToInt32(Console.ReadLine()!);

            bool conseguiuExcluir = repositorioAmigo.Excluir(idSelecionado);

            if (!conseguiuExcluir) { Console.WriteLine("\n                 Amigo não encontrado ou não pôde ser excluído."); }
            else { Console.WriteLine("                       Cadastro excluído com sucesso!"); }

            Console.WriteLine();

            Thread.Sleep(1000);
            VisualizarAmigos();
        }

        public void VisualizarAmigos()
        {
            Console.Clear();
            ExibirTitulo(false);
            Console.WriteLine("                             AMIGOS CADASTRADOS");
            Console.WriteLine("--------------------------------------------------------------------------------");

            Amigo[] amigosCadastrados = repositorioAmigo.SelecionarTodos();

            bool temCadastros = false;

            Console.WriteLine("{0,-3} | {1,-30} | {2,-30} | {3,-15}",
               "Id", "Nome Completo", "Nome do Responsável", "Telefone"
           );

            for (int i = 0; i < amigosCadastrados.Length; i++)
            {
                Amigo dadosAmigo = amigosCadastrados[i];

                if (dadosAmigo == null) continue;
                temCadastros = true;

                Console.WriteLine("{0,-3} | {1,-30} | {2,-30} | {3,-15}",
                 dadosAmigo.Id, dadosAmigo.NomeCompleto, dadosAmigo.NomeResponsavel, dadosAmigo.Telefone
                );
                Console.WriteLine("--------------------------------------------------------------------------------");
            }

            if (!temCadastros) { Console.WriteLine("\n                         Nenhum amigo cadastrado"); }

            Console.WriteLine("\n                   Aperte qualquer tecla para continuar");
            Console.ReadKey();
            Thread.Sleep(500);
        }

        public void VisualizarEmprestimosAmigo()
        {
            Console.Clear();
            ExibirTitulo(false);
            Console.WriteLine("                             VISUALIZAR EMPRÉSTIMOS DE AMIGO");
            Console.WriteLine("--------------------------------------------------------------------------------");

            VisualizarAmigos();  

            Console.WriteLine("\nDigite o ID do amigo que deseja visualizar os empréstimos");
            int idSelecionado;

            if (!int.TryParse(Console.ReadLine(), out idSelecionado))
            {
                Console.WriteLine("ID inválido! Operação cancelada.");
                Thread.Sleep(2000);
                return;
            }

            Amigo? amigoSelecionado = repositorioAmigo.SelecionarPorId(idSelecionado);

            if (amigoSelecionado == null)
            {
                Console.WriteLine("Amigo não encontrado.");
                Thread.Sleep(2000);
                return;
            }

            string emprestimos = amigoSelecionado.ObterEmprestimos();
            if (string.IsNullOrEmpty(emprestimos))
            {
                Console.WriteLine("Este amigo não tem empréstimos registrados.");
            }
            else
            {
                Console.WriteLine(emprestimos);
            }

            Console.WriteLine("\nAperte qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public bool ObterDadosAmigo(out string nomeCompleto, out string nomeResponsavel, out string telefoneFormatado)
        {
            nomeCompleto = nomeResponsavel = telefoneFormatado = "";

            Console.WriteLine("\nInsira o NOME COMPLETO do amigo: ");
            nomeCompleto = Console.ReadLine()!.ToUpper();
            if (nomeCompleto.Length < 3 || nomeCompleto.Length > 100)
            {
                Console.WriteLine("                       Erro! Precisa ter no mínimo TRÊS LETRAS");
                Console.WriteLine("                       Operação cancelada");
                Thread.Sleep(2000);
                return false;
            }

            Console.WriteLine($"\nInsira o NOME DO RESPONSÁVEL de {nomeCompleto}: ");
            nomeResponsavel = Console.ReadLine()!.ToUpper();
            if (nomeResponsavel.Length < 3 || nomeResponsavel.Length > 100)
            {
                Console.WriteLine("                       Erro! Precisa ter no mínimo TRÊS LETRAS");
                Console.WriteLine("                       Operação cancelada");
                Thread.Sleep(2000);
                return false;
            }

            Console.WriteLine($"\nInsira o NÚMERO DE TELEFONE de {nomeCompleto}");
            string telefone = Console.ReadLine()!;
            telefoneFormatado = new string(telefone.Where(char.IsDigit).ToArray());
            if (telefoneFormatado.Length < 10 || telefoneFormatado.Length > 11)
            {
                Console.WriteLine("                        Erro! O telefone deve conter 10 ou 11 dígitos numéricos.");
                Console.WriteLine("                        Operação cancelada");
                Thread.Sleep(2000);
                return false;
            }

            return true;
        }

    }
}


