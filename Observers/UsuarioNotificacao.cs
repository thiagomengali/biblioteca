namespace BibliotecaGestao.Observers
{
    using System;
    using Biblioteca.Utils;

    public class UsuarioNotificacao : INotificacaoObserver
    {
        private readonly string _nomeUsuario;

        public UsuarioNotificacao(string nomeUsuario)
        {
            _nomeUsuario = nomeUsuario;
        }

        public void Notificar(string mensagem)
        {
            MensagemUtil.ExibirErro($"Notificação para {_nomeUsuario}: {mensagem}");
        }
    }
}
