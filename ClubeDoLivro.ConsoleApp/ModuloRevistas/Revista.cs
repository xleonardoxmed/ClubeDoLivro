using ClubeDoLivro.ConsoleApp.ModuloCaixas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.ConsoleApp.ModuloRevistas
{
    public class Revista
    {
        public string Titulo;
        public string Edicao;
        public int AnoPublicacao;
        public string StatusEmprestimo;
        public Caixa? Caixa;
        public int Id;

        private TelaCaixa telaCaixa;
        public Revista(string titulo, string edicao, int anoPublicacao, TelaCaixa telaCaixa)
        {
            Titulo = titulo;
            Edicao = edicao;
            AnoPublicacao = anoPublicacao;
            StatusEmprestimo = "Disponível";
            Caixa = null!;
            this.telaCaixa = telaCaixa;
        }

        public void AtualizarCaixa(Caixa caixa, Revista revista)
        {
            Caixa = caixa;
        }

        public bool Validar()
        {
            bool temErro = false;

            if (string.IsNullOrWhiteSpace(Titulo)) { Console.WriteLine("→ Campo 'Título' é obrigatório."); temErro = true; }

            if (string.IsNullOrWhiteSpace(Edicao)) { Console.WriteLine("→ Campo 'Edição' é obrigatório."); temErro = true; }

            if (AnoPublicacao <= 0) { Console.WriteLine("→ Ano de Publicação inválido."); temErro = true; }

            if (temErro) { Console.WriteLine("\nOperação Cancelada."); }

            return !temErro;
        }

        public void Reservar()
        {
            StatusEmprestimo = "Reservada";
        }

        public void Emprestar()
        {
            StatusEmprestimo = "Emprestada";
        }

        public void Devolver()
        {
            StatusEmprestimo = "Disponível";
        }
        public ConsoleColor ObterCorConsole(string cor)
        {
            return telaCaixa.ObterCorConsole(cor);
        }
    }
}
