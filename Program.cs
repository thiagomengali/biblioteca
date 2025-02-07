using Biblioteca.Models;
using Biblioteca.Services;
using Biblioteca.Utils;
using BibliotecaGestao.Observers;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Livro> biblioteca = new List<Livro>();
    static List<Usuario> usuarios = new List<Usuario>();
    static List<Emprestimo> emprestimos = new List<Emprestimo>();

    static void Main()
    {
        try
        {
            Console.Clear();

            // Criando as instâncias dos serviços
            ServicoNotificacao servicoNotificacao = new ServicoNotificacao();
            LivroCadastro livroCadastro = new LivroCadastro(biblioteca);
            UsuarioCadastro usuarioCadastro = new UsuarioCadastro(usuarios, servicoNotificacao);
            EmprestimoServico emprestimoServico = new EmprestimoServico(biblioteca, usuarios, emprestimos, servicoNotificacao);

            int numeroDaOpcaoSelecionada;
            do
            {
                ExibirMenu();

                if (int.TryParse(Console.ReadLine(), out numeroDaOpcaoSelecionada))
                {
                    switch (numeroDaOpcaoSelecionada)
                    {
                        case 0:
                            Console.WriteLine("Saindo do programa...");
                            break;

                        case 1:
                            livroCadastro.CadastrarLivro();
                            break;

                        case 2:
                            usuarioCadastro.CadastrarUsuario();
                            break;

                        case 3:
                            emprestimoServico.RealizarEmprestimo();
                            break;

                        case 4:
                            emprestimoServico.DevolverLivro();
                            break;

                        case 5:
                            emprestimoServico.ListarHistoricoEmprestimos();
                            break;

                        default:
                            MensagemUtil.ExibirAviso("Opção inválida! Tente novamente.");
                            break;
                    }
                }
                else
                {
                    MensagemUtil.ExibirAviso("Entrada inválida! Digite um número válido.");
                    numeroDaOpcaoSelecionada = -1;  // Atribuindo um valor que não vá quebrar o loop
                }

            } while (numeroDaOpcaoSelecionada != 0);
        }
        catch (Exception ex)
        {
            MensagemUtil.ExibirErro("Ocorreu um erro inesperado ao executar o programa.");
            MensagemUtil.ExibirErro($"Detalhes do erro: {ex.Message}");
        }
    }

    private static void ExibirMenu()
    {
        Console.WriteLine("\n===== Sistema de Gestão de Biblioteca =====");
        Console.WriteLine("0 - Sair");
        Console.WriteLine("1 - Cadastrar Livro");
        Console.WriteLine("2 - Cadastrar Usuário");
        Console.WriteLine("3 - Realizar Empréstimo");
        Console.WriteLine("4 - Devolver Livro");
        Console.WriteLine("5 - Histórico de Empréstimos");
        Console.Write("Escolha uma opção: ");
    }
}
