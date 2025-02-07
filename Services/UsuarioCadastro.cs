using Biblioteca.Models;
using Biblioteca.Utils;
using BibliotecaGestao.Observers;
using System;
using System.Collections.Generic;
using System.Linq; // Necessário para usar Max()

namespace Biblioteca.Services
{
    public class UsuarioCadastro
    {
        private List<Usuario> _usuarios;
        private ServicoNotificacao _servicoNotificacao; 

        public UsuarioCadastro(List<Usuario> usuarios, ServicoNotificacao servicoNotificacao)
        {
            _usuarios = usuarios;
            _servicoNotificacao = servicoNotificacao; 
        }

        public void CadastrarUsuario()
        {
            try
            {
                Console.Write("\nDigite o nome do usuário: ");
                string nome = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nome))
                {
                    MensagemUtil.ExibirErro("O nome do usuário não pode estar vazio.");
                    return;
                }

                if (_usuarios.Any(u => u.Nome == nome))
                {
                    MensagemUtil.ExibirErro("Já existe um usuário com este nome!");
                    return;
                }

                int novoId = _usuarios.Count > 0 ? _usuarios.Max(u => u.Id) + 1 : 1; 

                Usuario novoUsuario = new Usuario(novoId, nome);
                _usuarios.Add(novoUsuario);

                _servicoNotificacao.AdicionarObservador(novoUsuario); 

                MensagemUtil.ExibirSucesso($"Usuário '{nome}' cadastrado com sucesso. Id: {novoId}!");
            }
            catch (ArgumentNullException ex)
            {
                MensagemUtil.ExibirErro("Erro ao cadastrar o usuário: nome inválido.");
                MensagemUtil.ExibirErro($"Detalhes do erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                MensagemUtil.ExibirErro("Ocorreu um erro inesperado ao tentar cadastrar o usuário.");
                MensagemUtil.ExibirErro($"Detalhes do erro: {ex.Message}");
            }
        }
    }
}
