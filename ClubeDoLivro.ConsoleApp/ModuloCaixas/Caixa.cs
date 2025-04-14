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
            Revistas.Add(revista);
        }

        public void RemoverRevista(Revista revista)
        {
            Revistas.Remove(revista);
        }
    }
}
