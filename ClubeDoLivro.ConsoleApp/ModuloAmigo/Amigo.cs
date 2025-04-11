using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.ConsoleApp.ModuloAmigo
{
    public class Amigo
    {       
        public string NomeCompleto;
        public string NomeResponsavel;
        public string Telefone;
        public int Id;

        public Amigo(string nomeCompleto, string nomeResponsavel, string telefone)
        {
            NomeCompleto = nomeCompleto;
            NomeResponsavel= nomeResponsavel;
            Telefone = telefone;
        }
        
        /*public string ObterIdAmigo()
        {
            string identificador = NomeCompleto.Substring(0, 3).ToUpper();
            return $"{identificador}: {}";
        }
        */



    }
}
