namespace ClubeDoLivro.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaAmigo telaAmigo = new TelaAmigo();
            
            telaAmigo.InserirAmigo();
            //telaAmigo.EditarAmigo();
            //telaAmigo.ExcluirAmigo();
            telaAmigo.VisualizarAmigos();

            Console.ReadKey();
        }
    }
}
