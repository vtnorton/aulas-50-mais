using System;

namespace BancoRoxinho.Dominio.Model
{


    internal class Mensagem
    {
        public static string pontilhados = new String('-', 50);
        public static Mensagem MostrarMensagem(String mensagem)
        {
            Console.WriteLine(pontilhados);
            Console.WriteLine(mensagem);
            Console.ReadLine();
            Console.Clear();

            return null;
        }

    }
}
