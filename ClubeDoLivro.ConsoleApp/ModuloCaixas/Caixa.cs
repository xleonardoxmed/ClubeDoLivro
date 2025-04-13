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

        public Caixa(string etiqueta, string cor, int diasEmprestimo)
        {
            Etiqueta = etiqueta;
            Cor = cor;
            DiasEmprestimo = diasEmprestimo;
        }

        public void Validar()
        {

        }

        public void AdicionarRevista()
        {

        }

        public void RemoverRevista()
        {

        }
    }
}
