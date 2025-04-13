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
        public string Caixa;
        public int Id;

        public Revista(string titulo, string edicao, int anoPublicacao)
        {
            Titulo = titulo;
            Edicao = edicao;
            AnoPublicacao = anoPublicacao;
            StatusEmprestimo = "Disponível";
            Caixa = null!;
        }

        public void ColocarNaCaixa(Caixa caixa)
        {
            Caixa = caixa.Etiqueta;
            StatusEmprestimo = "Emprestada";
        }

        public void Validar()
        {

        }

        public void Emprestar()
        {

        }

        public void Devolver()
        {

        }
    }
}
