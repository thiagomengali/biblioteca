using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaGestao.Observers;
using Biblioteca.Utils;

namespace Biblioteca.Services
{
    public class EmprestimoServico
    {
        private List<Livro> _livros;
        private List<Usuario> _usuarios;
        private List<Emprestimo> _emprestimos;
        private ServicoNotificacao _servicoNotificacao;

        public EmprestimoServico(List<Livro> livros, List<Usuario> usuarios, List<Emprestimo> emprestimos, ServicoNotificacao servicoNotificacao)
        {
            _livros = livros;
            _usuarios = usuarios;
            _emprestimos = emprestimos;
            _servicoNotificacao = servicoNotificacao;
        }

        /// <summary>
        /// Realiza o empréstimo de um livro para o usuário.
        /// Verifica se o livro está disponível e registra o empréstimo.
        /// </
        public void RealizarEmprestimo()
        {
            try
            {
                ListarLivrosDisponiveis();

                Console.Write("\nDigite o ISBN do livro que deseja emprestar (ou 999 para listar novamente): ");
                string isbn = Console.ReadLine();

                if (isbn == "999")
                {
                    ListarLivrosDisponiveis();
                    Console.Write("\nDigite o ISBN do livro que deseja emprestar: ");
                    isbn = Console.ReadLine();
                }

                Livro livro = _livros.Find(l => l.ISBN == isbn);
                if (livro == null)
                {
                    MensagemUtil.ExibirErro("Livro não encontrado.");
                    return;
                }

                if (livro.Status != StatusLivro.Disponivel)
                {
                    MensagemUtil.ExibirErro("Livro não disponível para empréstimo.");
                    return;
                }

                Console.Write("\nDigite o ID do usuário: ");
                int usuarioId = int.Parse(Console.ReadLine());

                Usuario usuario = _usuarios.Find(u => u.Id == usuarioId);
                if (usuario == null)
                {
                    MensagemUtil.ExibirErro("Usuário não encontrado.");
                    return;
                }

                Emprestimo novoEmprestimo = new Emprestimo(usuario, livro);
                _emprestimos.Add(novoEmprestimo);
                livro.Status = StatusLivro.Emprestado;

                MensagemUtil.ExibirSucesso($"Empréstimo realizado com sucesso! Usuário: {usuario.Nome}, Livro: {livro.Titulo}");

                _servicoNotificacao.NotificarTodos($"O livro '{livro.Titulo}' foi emprestado para {usuario.Nome}.");
            }
            catch (FormatException ex)
            {
                MensagemUtil.ExibirErro("Erro de formato: O ID do usuário deve ser um número válido.");
                MensagemUtil.ExibirErro($"Detalhes do erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                MensagemUtil.ExibirErro("Ocorreu um erro inesperado ao tentar realizar o empréstimo.");
                MensagemUtil.ExibirErro($"Detalhes do erro: {ex.Message}");
            }

        }

        private void ListarLivrosDisponiveis()
        {
            Console.WriteLine("\nLivros Disponíveis para Empréstimo:");
            var livrosDisponiveis = _livros.Where(l => l.Status == StatusLivro.Disponivel).ToList();

            if (livrosDisponiveis.Any())
            {
                foreach (var livro in livrosDisponiveis)
                {
                    Console.WriteLine($"Título: {livro.Titulo}, Autor: {livro.Autor}, ISBN: {livro.ISBN}");
                }
            }
            else
            {
                MensagemUtil.ExibirAviso("Não há livros disponíveis no momento.");
            }
        }

        public void DevolverLivro()
        {
            try
                {

                Console.Write("\nDigite o ISBN do livro que deseja devolver: ");
                string isbn = Console.ReadLine();

                Livro livro = _livros.Find(l => l.ISBN == isbn);
                if (livro == null)
                {
                    MensagemUtil.ExibirErro("Livro não encontrado.");
                    return;
                }

                if (livro.Status == StatusLivro.Disponivel)
                {
                    MensagemUtil.ExibirAviso("Este livro já está disponível na biblioteca.");
                    return;
                }

                Emprestimo emprestimo = _emprestimos.Find(e => e.Livro.ISBN == isbn && !e.Devolvido);
                if (emprestimo == null)
                {
                    MensagemUtil.ExibirErro("Erro: Não foi encontrado um empréstimo ativo para este livro.");
                    return;
                }

                livro.Status = StatusLivro.Disponivel;
                emprestimo.Devolvido = true;
                emprestimo.DataDevolucao = DateTime.Now;

                MensagemUtil.ExibirAviso($"Livro '{livro.Titulo}' devolvido com sucesso!");

                // Notificar usuários sobre a devolução
                _servicoNotificacao.NotificarTodos($"O livro '{livro.Titulo}' foi devolvido e está disponível para empréstimo.");
            }
            catch (NullReferenceException ex)
            {
                MensagemUtil.ExibirErro("Erro: Não foi possível localizar o livro ou o empréstimo.");
                MensagemUtil.ExibirErro($"Detalhes do erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                MensagemUtil.ExibirErro("Ocorreu um erro inesperado ao tentar devolver o livro.");
                MensagemUtil.ExibirErro($"Detalhes do erro: {ex.Message}");
            }
        }

        public void ListarHistoricoEmprestimos()
        {
            if (!_emprestimos.Any()) 
            {
                Console.WriteLine("\nNenhum empréstimo foi realizado ainda.");
                return;
            }

            Console.WriteLine("\n===== Histórico de Empréstimos =====");

            foreach (var emprestimo in _emprestimos)
            {
                DefinirCorEmprestimo(emprestimo.Devolvido);

                Console.WriteLine($"Usuário: {emprestimo.Usuario.Nome} | " +
                                  $"Livro: {emprestimo.Livro.Titulo} | " +
                                  $"Data: {emprestimo.DataEmprestimo:dd/MM/yyyy} | " +
                                  $"{(emprestimo.Devolvido ? $"Devolvido em {emprestimo.DataDevolucao.Value:dd/MM/yyyy} | Disponível" : $"Emprestado em {emprestimo.DataEmprestimo:dd/MM/yyyy}")}");
                
                Console.ResetColor(); 
            }
        }

        private void DefinirCorEmprestimo(bool devolvido)
        {
            Console.ForegroundColor = devolvido ? ConsoleColor.Blue : ConsoleColor.Red;
        }

    }
}
