using Biblioteca.Models;
using Biblioteca.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Services
{
    public class LivroCadastro
    {
        private List<Livro> _livros;

        public LivroCadastro(List<Livro> livros)
        {
            _livros = livros;
        }

                
        public void CadastrarLivro()
        {
            Console.Write("\nDigite o título do livro: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite o autor do livro: ");
            string autor = Console.ReadLine();

            Console.Write("Digite o ISBN do livro: ");
            string isbn = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(isbn))
            {
                MensagemUtil.ExibirErro("O ISBN não pode estar vazio.");
                return;
            }

            if (_livros.Any(l => l.ISBN == isbn))
            {
                MensagemUtil.ExibirErro("Este ISBN já está cadastrado.");
                return;
            }

            Livro novoLivro = new Livro(titulo, autor, isbn);
            _livros.Add(novoLivro);

            MensagemUtil.ExibirSucesso($"Livro '{titulo}' cadastrado com sucesso!");
        }

    }
}
