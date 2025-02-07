using System;
using BibliotecaGestao.Observers;

namespace Biblioteca.Models
{
    public class Usuario : IObservador
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Usuario(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void Notificar(string mensagem)
        {
            Console.WriteLine($"[Notificação para {Nome}]: {mensagem}");
        }
    }
}
