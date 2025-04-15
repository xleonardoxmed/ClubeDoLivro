using ClubeDoLivro.ConsoleApp.ModuloRevistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.ConsoleApp.ModuloCaixas
{
    public class Caixa
    {
        public string Etiqueta;
        public string Cor;
        public int DiasEmprestimo;
        public int Id;
        public List<Revista> Revistas = new();

        public Caixa(string etiqueta, string cor, int diasEmprestimo)
        {
            Etiqueta = etiqueta;
            Cor = cor;
            DiasEmprestimo = diasEmprestimo;
        }
        public void DefinirCor(ConsoleColor colorir)
        {
            Console.ForegroundColor = colorir;
            Console.WriteLine(Cor);
            Console.ResetColor();
        }

        public bool Validar()
        {
            if (string.IsNullOrWhiteSpace(Etiqueta)) return false;
            if (string.IsNullOrWhiteSpace(Cor)) return false;
            if (DiasEmprestimo <= 0) return false;
            return true;
        }



        public void AdicionarRevista(Revista revista)
        {

            if (revista.Caixa != null)
            {
                Console.WriteLine("A revista já está associada a uma caixa.");
                return;
            }

            this.Revistas.Add(revista);
            revista.Caixa = this;
        }

        public void RemoverRevista(Revista revista)
        {
            
            if (this.Revistas.Contains(revista))
            {
                this.Revistas.Remove(revista);
                revista.Caixa = null;
            }
            else
            {
                Console.WriteLine("Revista não encontrada nesta caixa.");
            }

        }
    }
}
