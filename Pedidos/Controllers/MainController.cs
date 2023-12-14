using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Pedidos.Core.Interfaces;
using Pedidos.Core.Notifications;

namespace Pedidos.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly INotifier _notificador;

        protected MainController(INotifier pNotifier)
        {
            _notificador = pNotifier;
        }

        protected bool ValidOperation()
        {
            return !_notificador.HasNotification();
        }

        protected ActionResult CustomResponse(object? result = null)
        {
            if (ValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificador.GetNotifications().Select(n => n.Message)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyInvalidModelError(modelState);
            return CustomResponse();
        }

        protected void NotifyInvalidModelError(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError(errorMsg);
            }
        }

        protected void NotifyError(string mensagem)
        {
            _notificador.Handle(new Notification(mensagem));
        }
    }
}