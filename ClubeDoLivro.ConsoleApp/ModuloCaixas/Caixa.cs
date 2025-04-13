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
        public List<string> Revistas = new();

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

        public void AdicionarRevista(string titulo)
        {
            Revistas.Add(titulo);
        }

        public void RemoverRevista(string titulo)
        {
            Revistas.Remove(titulo);
        }
    }
}
