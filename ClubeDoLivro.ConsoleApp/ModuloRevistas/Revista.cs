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

        public void Validar()
        {

        }

        public void Emprestar()
        {
          StatusEmprestimo = "Emprestada";
        }

        public void Devolver()
        {

        }
        public ConsoleColor ObterCorConsole(string cor)
        {
            return telaCaixa.ObterCorConsole(cor);
        }
    }
}
