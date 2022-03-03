using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsabilityPrinciple_SOLID_
{
    class OrderServiceRefactor
    {
        private readonly NotificationService _notificationService;

        public OrderServiceRefactor(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task Add(Order order)
        {
            // crear orden

            //notificar
            var message = new MailMessage("sales@admin.com", order.ClientEmail)
            {
                Subject = "Se le asigno una compra",
                Body = "estimado, hemos creado su nueva orden de compra"
            };

            await this._notificationService.SendEmail(message);
        }

    }

    //la tarea de enviar la notif se realiza en otra clase

    public class NotificationService
    {
        private readonly System.Net.Mail.SmtpClient _smtpClient;

        public NotificationService(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }


        public async Task SendEmail(MailMessage message)
        {
            await _smtpClient.SendMailAsync(message);
        }
    }

}