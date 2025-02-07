using System;

namespace Biblioteca.Utils
{
    public static class MensagemUtil
    {
        public static void ExibirErro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERRO]: {mensagem}");
            Console.ResetColor();
        }

        public static void ExibirSucesso(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[SUCESSO]: {mensagem}");
            Console.ResetColor();
        }

        public static void ExibirAviso(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[AVISO]: {mensagem}");
            Console.ResetColor();
        }
    }

}
