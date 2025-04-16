using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDoLivro.ConsoleApp.ModuloRevistas;

namespace ClubeDoLivro.ConsoleApp.ModuloEmprestimos
{
    public class RepositorioEmprestimo
    {
        public Emprestimo[] EmprestimosCadastrados = new Emprestimo[100];
        public int contadorEmprestimos;

        public void Inserir(Emprestimo novoEmprestimo)
        {
            if (contadorEmprestimos == 100) { Console.WriteLine("Limite de empréstimos cadastrados atingido!"); return; }

            novoEmprestimo.Id = contadorEmprestimos + 1;
            EmprestimosCadastrados[contadorEmprestimos] = novoEmprestimo;
            contadorEmprestimos++;
        }

        public bool Editar(int idSelecionado, Emprestimo emprestimoEditado)
        {
            if (contadorEmprestimos == 0) return false;

            int indice = Array.FindIndex(EmprestimosCadastrados, 0, contadorEmprestimos, a => a?.Id == idSelecionado);
           
            if (indice == -1)
            {
                Console.WriteLine("                    Empréstimo não encontrado...");
                Thread.Sleep(1000);
                return false;
            }

            for (int i = 0; i < contadorEmprestimos; i++)
            {
                if (EmprestimosCadastrados[i] != null && EmprestimosCadastrados[i].Id == idSelecionado)
                {
                    EmprestimosCadastrados[i].Amigo = emprestimoEditado.Amigo;
                    EmprestimosCadastrados[i].Revista = emprestimoEditado.Revista;
                    EmprestimosCadastrados[i].DataEmprestimo = emprestimoEditado.DataEmprestimo;
                    EmprestimosCadastrados[i].Situação = emprestimoEditado.Situação;
                    return true;
                }
            }
            return false;
        }

        public bool Excluir(int idSelecionado)
        {
            if (contadorEmprestimos == 0) return false;

            int indice = Array.FindIndex(EmprestimosCadastrados, 0, contadorEmprestimos, a => a?.Id == idSelecionado);
          
            if (indice == -1)
            {
                Console.WriteLine("                    Empréstimo não encontrado...");
                Thread.Sleep(1000);
                return false;
            }

            for (int i = indice; i < contadorEmprestimos - 1; i++)
                EmprestimosCadastrados[i] = EmprestimosCadastrados[i + 1];
        
            EmprestimosCadastrados[--contadorEmprestimos] = null!;

            for (int i = 0; i < contadorEmprestimos; i++)
                EmprestimosCadastrados[i].Id = i + 1;
            return true;
        }
        public Emprestimo[] SelecionarTodas()
        {
            return EmprestimosCadastrados;
        }

        public Emprestimo? SelecionarPorId(int id)
        {
            for (int i = 0; i < contadorEmprestimos; i++)
            {
                if (EmprestimosCadastrados[i] != null && EmprestimosCadastrados[i].Id == id)
                    return EmprestimosCadastrados[i];
            }

            return null;
        }   
    }
}
