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
            if (editar)
            {
                for (int i = 0; i < repositorioAmigo.contadorAmigos; i++)
                {
                    Amigo outroAmigo = repositorioAmigo.AmigosCadastrados[i];

                    if (outroAmigo == null) continue;

                    if (outroAmigo.Id == idAmigoEditado)
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


        public string ObterEmprestimos()
        {
            string resultado = $"{NomeCompleto} ({Telefone})\n";
            resultado += "--------------------------------------------------------------------------------\n";
            resultado += string.Format("{0,-3} | {1,-30} | {2,-20} | {3,-20} | {4,-10}\n",
                 "ID", "Revista", "Data Empréstimo", "Data Devolução Prevista", "Status");

            bool temEmprestimos = false;
            DateTime dataAtual = DateTime.Today;

            foreach (var emprestimo in amigoEmprestimos)
            {
                if (emprestimo == null) continue;

                temEmprestimos = true;


                DateTime dataDevolucaoPrevista = emprestimo.DataDevolucao.ToDateTime(new TimeOnly(0, 0));

                string dataDevolucaoReal = emprestimo.StatusEmprestimo == "Emprestada" ? "Não Devolvida" : emprestimo.DataDevolucao.ToString("dd/MM/yyyy");

                string status;
                double multa = 0;

                if (emprestimo.StatusEmprestimo == "Emprestada" && dataDevolucaoPrevista < dataAtual)
                {

                    TimeSpan atraso = dataAtual - dataDevolucaoPrevista;
                    multa = atraso.Days * 2;
                    status = $"Atrasado! ({multa} R$)";
                }
                else if (emprestimo.StatusEmprestimo == "Emprestada")
                {

                    status = "Em Aberto";
                }
                else
                {

                    status = "Fechado";
                }

                resultado += string.Format("{0,-3} | {1,-30} | {2,-20} | {3,-20} | {4,-10}\n",
                emprestimo.Id,
                emprestimo.Revista.Titulo,
                emprestimo.DataEmprestimo.ToString("dd/MM/yyyy"),
                emprestimo.DataDevolucao.ToString("dd/MM/yyyy"),
                status);
            }

            if (!temEmprestimos)
            {
                resultado += "\nNenhum empréstimo registrado para este amigo.\n";
            }

            return resultado;
        }
        
    }
}
