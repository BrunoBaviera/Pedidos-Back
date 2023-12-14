using Pedidos.Core.Interfaces;
using Pedidos.Core.Notifications;

namespace Pedidos.Core.Services
{
    public abstract class BaseService
    {
        private readonly INotifier _notificador;

        protected BaseService(INotifier notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notification(mensagem));
        }

    }
}
