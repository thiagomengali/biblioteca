namespace Biblioteca.Models;

public class Emprestimo
{
    public Usuario Usuario { get; set; }
    public Livro Livro { get; set; }
    public DateTime DataEmprestimo { get; set; }
    public bool Devolvido { get; set; } = false;
    public DateTime? DataDevolucao { get; set; }


    public Emprestimo(Usuario usuario, Livro livro)
    {
        Usuario = usuario;
        Livro = livro;
        DataEmprestimo = DateTime.Now; 
        DataDevolucao = null;
        Devolvido = false;
    }
}
