using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDoLivro.ConsoleApp.ModuloAmigo;
using ClubeDoLivro.ConsoleApp.ModuloCaixas;
using ClubeDoLivro.ConsoleApp.ModuloRevistas;

namespace ClubeDoLivro.ConsoleApp.ModuloEmprestimos
{
    public class Emprestimo
    {
        public Amigo Amigo;
        public Revista Revista;
        public DateOnly DataDevolucao;
        public DateOnly DataEmprestimo;
        public string Situação;
        public int Id;
        public string StatusEmprestimo;


        public Emprestimo(Amigo amigo, Revista revista, DateOnly dataEmprestimo)
        {
            Amigo = amigo;
            Revista = revista;
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = CalcularDataDevolucao(DataEmprestimo, Revista);
            Situação = "Emprestada";
            StatusEmprestimo = "Em Aberto";
        }

        public bool Validar()
        {
            bool temErro = false;

            if (Amigo == null) { Console.WriteLine("→ Campo 'Amigo' obrigatório"); temErro = true; }

            if (Revista == null) { Console.WriteLine("→ Campo 'Revista' obrigatório"); temErro = true; }

            if (temErro) { Console.WriteLine("\nOperação Cancelada."); }
                
            return !temErro;
        }
        public DateOnly CalcularDataDevolucao(DateOnly dataEmprestimo, Revista revista)
        {
            if (revista.Caixa == null)
            {
                Console.WriteLine("Erro: A revista não possui uma caixa associada.");
                return dataEmprestimo;
            }

            return dataEmprestimo.AddDays(revista.Caixa.DiasEmprestimo);
        }
        public void FecharEmprestimo(DateOnly dataDevolucaoReal)
        {
            DataDevolucao = dataDevolucaoReal;
            StatusEmprestimo = "Fechado";
        }
    }
}
