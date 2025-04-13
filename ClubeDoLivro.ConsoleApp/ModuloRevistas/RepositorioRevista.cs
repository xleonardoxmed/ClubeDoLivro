using ClubeDoLivro.ConsoleApp.ModuloCaixas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.ConsoleApp.ModuloRevistas
{
    public class RepositorioRevista
    {
        public Revista[] RevistasCadastradas = new Revista[100];
        public int contadorRevistas;

        public void Inserir(Revista novaRevista)
        {
            if (contadorRevistas == 100) { Console.WriteLine("Limite de revistas cadastradas atingido!"); return; }

            novaRevista.Id = contadorRevistas + 1;
            RevistasCadastradas[contadorRevistas] = novaRevista;
            contadorRevistas++;
        }

        public bool Editar(int id, Revista revistaEditada)
        {
            for (int i = 0; i < contadorRevistas; i++)
            {
                if (RevistasCadastradas[i] != null && RevistasCadastradas[i].Id == id)
                {
                    RevistasCadastradas[i].Edicao = revistaEditada.Edicao;
                    RevistasCadastradas[i].AnoPublicacao = revistaEditada.AnoPublicacao;
                    RevistasCadastradas[i].Titulo = revistaEditada.Titulo;
                    RevistasCadastradas[i].StatusEmprestimo = revistaEditada.StatusEmprestimo;
                    RevistasCadastradas[i].Caixa = revistaEditada.Caixa;
                    return true;
                }
            }
            return false;
        }

        public bool Excluir(int idSelecionado)
        {
            if (contadorRevistas == 0) return false;

            int indice = Array.FindIndex(RevistasCadastradas, 0, contadorRevistas, a => a?.Id == idSelecionado);
            //percorre o array até encontrar o id, do início até o fim, checando se é vazio ou é o ID.
            //Guarda a posição ou -1 caso não ecnontre-a.

            if (indice == -1)
            {
                Console.WriteLine("                    Revista não encontrada...");
                Thread.Sleep(1000);
                return false;
            }

            for (int i = indice; i < contadorRevistas - 1; i++)
                RevistasCadastradas[i] = RevistasCadastradas[i + 1];
            //puxa todos para trás, preenchendo os buracos

            RevistasCadastradas[--contadorRevistas] = null!;
            //remove o último item duplicado

            for (int i = 0; i < contadorRevistas; i++)
                RevistasCadastradas[i].Id = i + 1;
            //atualiza os IDs
            return true;
        }
        public Revista[] SelecionarTodas()
        {
            return RevistasCadastradas;
        }

        public Revista? SelecionarPorId(int id)
        {
            for (int i = 0; i < contadorRevistas; i++)
            {
                if (RevistasCadastradas[i] != null && RevistasCadastradas[i].Id == id)
                    return RevistasCadastradas[i];
            }

            return null;
        }
    }
}
