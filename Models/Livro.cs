namespace Biblioteca.Models
{

    public class Livro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public StatusLivro Status { get; set; } = StatusLivro.Disponivel; 

        public Livro(string titulo, string autor, string isbn)
        {
            Titulo = titulo;
            Autor = autor;
            ISBN = isbn;
        }
    }
}