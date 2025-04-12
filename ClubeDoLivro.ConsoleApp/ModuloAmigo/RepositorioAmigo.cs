using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.ConsoleApp.ModuloAmigo
{
    public class RepositorioAmigo
    {
        public Amigo[] AmigosCadastrados = new Amigo[100];
        public int contadorAmigos;

        public void Inserir(Amigo novoAmigo)
        {
            if (contadorAmigos == 100) { Console.WriteLine("Limite de amigos cadastrado atingido!"); return; }

            novoAmigo.Id = contadorAmigos + 1;
            AmigosCadastrados[contadorAmigos] = novoAmigo;
            contadorAmigos++;
        }

        public bool Editar(int id, Amigo amigoEditado)
        {
            for (int i = 0; i < contadorAmigos; i++)
            {
                if (AmigosCadastrados[i] != null && AmigosCadastrados[i].Id == id)
                {
                    AmigosCadastrados[i].NomeCompleto = amigoEditado.NomeCompleto;
                    AmigosCadastrados[i].NomeResponsavel = amigoEditado.NomeResponsavel;
                    AmigosCadastrados[i].Telefone = amigoEditado.Telefone;

                    return true;
                }
            }
            return false;
        }

        public bool Excluir(int idSelecionado)
        {
            if (contadorAmigos == 0) return false;
            
            int indice = Array.FindIndex(AmigosCadastrados, 0, contadorAmigos, a => a?.Id == idSelecionado);
            //percorre o array até encontrar o id, do início até o fim, checando se é vazio ou é o ID.
            //Guarda a posição ou -1 caso não ecnontre-a.

            if (indice == -1)
            {
                Console.WriteLine("                    Amigo não encontrado...");
                Thread.Sleep(1000);
                return false;
            }

            for (int i = indice; i < contadorAmigos - 1; i++)
                AmigosCadastrados[i] = AmigosCadastrados[i + 1];
            //puxa todos para trás, preenchendo os buracos

            AmigosCadastrados[--contadorAmigos] = null!;
            //remove o último item duplicado

            for (int i = 0; i < contadorAmigos; i++)
                AmigosCadastrados[i].Id = i + 1;
            //atualiza os IDs
            return true;
        }

        public Amigo[] SelecionarTodos()
        {
            return AmigosCadastrados;
        }

        public Amigo? SelecionarPorId(int id)
        {
            for (int i = 0; i < contadorAmigos; i++)
            {
                if (AmigosCadastrados[i] != null && AmigosCadastrados[i].Id == id)
                    return AmigosCadastrados[i];
            }

            return null;
        }


    }
}
