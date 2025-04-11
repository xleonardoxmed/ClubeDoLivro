using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.ConsoleApp
{
    public class Amigo
    {
        public string NomeCompleto;
        public string NomeResponsavel;
        public string Telefone;

        public Amigo(string nomeCompleto, string nomeResponsavel, string telefone)
        {
            NomeCompleto = nomeCompleto;
            NomeResponsavel= nomeResponsavel;
            Telefone = telefone;
        }


    }
}
