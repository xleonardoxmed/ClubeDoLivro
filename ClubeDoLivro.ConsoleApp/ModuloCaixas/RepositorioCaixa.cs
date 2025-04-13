using ClubeDoLivro.ConsoleApp.ModuloAmigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.ConsoleApp.ModuloCaixas
{
    public class RepositorioCaixa
    {
        public Caixa[] CaixasCadastradas = new Caixa[100];
        public int contadorCaixas;

        public void Inserir(Caixa novaCaixa)
        {
            if (contadorCaixas == 100) { Console.WriteLine("Limite de caixas cadastradas atingido!"); return; }

            novaCaixa.Id = contadorCaixas + 1;
            CaixasCadastradas[contadorCaixas] = novaCaixa;
            contadorCaixas++;
        }

        public bool Editar(int id, Caixa caixaEditada)
        {
            for (int i = 0; i < contadorCaixas; i++)
            {
                if (CaixasCadastradas[i] != null && CaixasCadastradas[i].Id == id)
                {
                    CaixasCadastradas[i].Etiqueta = caixaEditada.Etiqueta;
                    CaixasCadastradas[i].Cor = caixaEditada.Cor;
                    CaixasCadastradas[i].DiasEmprestimo = caixaEditada.DiasEmprestimo;

                    return true;
                }
            }
            return false;
        }

        public bool Excluir(int idSelecionado)
        {
            if (contadorCaixas == 0) return false;

            int indice = Array.FindIndex(CaixasCadastradas, 0, contadorCaixas, a => a?.Id == idSelecionado);
            //percorre o array até encontrar o id, do início até o fim, checando se é vazio ou é o ID.
            //Guarda a posição ou -1 caso não ecnontre-a.

            if (indice == -1)
            {
                Console.WriteLine("                    Caixa não encontrada...");
                Thread.Sleep(1000);
                return false;
            }

            for (int i = indice; i < contadorCaixas - 1; i++)
                CaixasCadastradas[i] = CaixasCadastradas[i + 1];
            //puxa todos para trás, preenchendo os buracos

            CaixasCadastradas[--contadorCaixas] = null!;
            //remove o último item duplicado

            for (int i = 0; i < contadorCaixas; i++)
                CaixasCadastradas[i].Id = i + 1;
            //atualiza os IDs
            return true;
        }
        public Caixa[] SelecionarTodas()
        {
            return CaixasCadastradas;
        }

        public Caixa? SelecionarPorId(int id)
        {
            for (int i = 0; i < contadorCaixas; i++)
            {
                if (CaixasCadastradas[i] != null && CaixasCadastradas[i].Id == id)
                    return CaixasCadastradas[i];
            }

            return null;
        }
    }
}
