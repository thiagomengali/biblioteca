using System;
using System.Collections.Generic;

namespace BibliotecaGestao.Observers
{
    public class ServicoNotificacao
    {
        private List<IObservador> _observadores = new List<IObservador>();

        public void AdicionarObservador(IObservador observador)
        {
            if (!_observadores.Contains(observador))
            {
                _observadores.Add(observador);
            }
        }

        public void RemoverObservador(IObservador observador)
        {
            if (_observadores.Contains(observador))
            {
                _observadores.Remove(observador);
            }
        }

        public void NotificarTodos(string mensagem)
        {
            foreach (var observador in _observadores)
            {
                observador.Notificar(mensagem);
            }
        }
    }
}
