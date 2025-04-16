using ClubeDoLivro.ConsoleApp.ModuloEmprestimos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.ConsoleApp.ModuloAmigo
{
    //Validar( ), ObterEmprestimos( )
    public class Amigo
    {
        public string NomeCompleto;
        public string NomeResponsavel;
        public string Telefone;
        public int Id;
        RepositorioAmigo repositorioAmigo;
        public List<Emprestimo> amigoEmprestimos;

        public Amigo(string nomeCompleto, string nomeResponsavel, string telefone, RepositorioAmigo repositorioAmigo, List<Emprestimo> amigoEmprestimos)
        {
            NomeCompleto = nomeCompleto;
            NomeResponsavel = nomeResponsavel;
            Telefone = telefone;
            this.repositorioAmigo = repositorioAmigo;
            this.amigoEmprestimos = amigoEmprestimos;
        }
        public bool Validar(Amigo novoAmigo, bool editar, int idAmigoEditado = -1)
        {
            for (int i = 0; i < repositorioAmigo.contadorAmigos; i++)
            {
                Amigo outroAmigo = repositorioAmigo.AmigosCadastrados[i];

                if (outroAmigo == null) continue;

                if (editar && outroAmigo.Id == idAmigoEditado)
                    continue;

                if (novoAmigo.NomeCompleto == outroAmigo.NomeCompleto)
                {
                    Console.WriteLine("                           Erro! Outro amigo com o mesmo nome já cadastrado");
                    return false;
                }

                if (novoAmigo.Telefone == outroAmigo.Telefone)
                {
                    Console.WriteLine("                           Erro! Outro amigo com o mesmo telefone já cadastrado");
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(NomeCompleto))
            {
                Console.WriteLine("Erro! Campo 'Nome Completo' obrigatório");
                Thread.Sleep(2000);
                return false;
            }

            if (string.IsNullOrWhiteSpace(NomeResponsavel))
            {
                Console.WriteLine("Erro! Campo 'Nome Responsável' obrigatório");
                Thread.Sleep(2000);
                return false;
            }

            if (string.IsNullOrWhiteSpace(Telefone))
            {
                Console.WriteLine("Erro! Campo 'Telefone' obrigatório");
                Thread.Sleep(2000);
                return false;
            }

            return true;
        }
        public void AdicionarEmprestimos(Emprestimo novoEmprestimo)
        {
            amigoEmprestimos.Add(novoEmprestimo);
        }

        public void RemoverEmprestimos(Emprestimo emprestimoRemovido)
        {
            amigoEmprestimos.Remove(emprestimoRemovido);
        }


        public void ObterEmprestimos()
        {
            Console.WriteLine($"\n{NomeCompleto} ID: ({Id})");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("{0,-3} | {1,-30} | {2,-20} | {3,-20} | {4,-10}",
                "ID", "Revista", "Data Empréstimo", "Data Devolução Prevista", "Status");

            bool temEmprestimos = false;
            DateTime dataAtual = DateTime.Today;

            foreach (var emprestimo in amigoEmprestimos)
            {
                if (emprestimo == null) continue;

                temEmprestimos = true;

                DateTime dataDevolucaoPrevista = emprestimo.DataDevolucao.HasValue
                ? emprestimo.DataDevolucao.Value.ToDateTime(new TimeOnly(0, 0))
                                    : DateTime.MinValue;
                string status;
                double multa = 0;

                if (emprestimo.StatusEmprestimo == "Em Aberto" && dataDevolucaoPrevista < dataAtual)
                {
                    TimeSpan atraso = dataAtual - dataDevolucaoPrevista;
                    multa = atraso.Days * 2;
                    status = $"Atrasado! ({multa} R$)";
                }
                else if (emprestimo.StatusEmprestimo == "Em Aberto")
                {
                    status = "Em Aberto";
                }
                else
                {
                    status = "Fechado";
                }

                string titulo = emprestimo.Revista.Titulo;
                string tituloFormatado = titulo.Length > 30 ? titulo.Substring(0, 27) + "..." : titulo;

                Console.Write($"{emprestimo.Id,-3} | ");

                if (emprestimo.Revista.Caixa != null)
                    Console.ForegroundColor = emprestimo.Revista.ObterCorConsole(emprestimo.Revista.Caixa.Cor);

                Console.Write($"{tituloFormatado,-30}");

                Console.ResetColor();

                Console.WriteLine(" | {0,-20} | {1,-20} | {2,-10}",
                    emprestimo.DataEmprestimo.ToString("dd/MM/yyyy"),
                    dataDevolucaoPrevista.ToString("dd/MM/yyyy"),
                    status
                );
            }

            if (!temEmprestimos)
            {
                Console.WriteLine("\nNenhum empréstimo registrado para este amigo.\n");
            }
        }

    }
}
