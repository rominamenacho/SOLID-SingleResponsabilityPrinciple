using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsabilityPrinciple_SOLID_
{
    //clase que permite una orden de compra y luego manda notificacion al cliente
    class OrderService
    {
        private readonly System.Net.Mail.SmtpClient _smtpClient;

            public OrderService(SmtpClient smtpClient)
            {
                _smtpClient = smtpClient;
            }

        //tarea 1
        public async Task Add(Order order) {
            //1 cod para crear la orden

            //2 notificar
            var message = new MailMessage("sales@admin.com", order.ClientEmail)
            {
                Subject = "Se le asigno una compra",
                Body = "estimado, hemos creado su nueva orden de compra"
            };
            await this.SendCustomerNotification(message);
        }



        //tarea 2
        public async Task SendCustomerNotification(MailMessage message) {
            await _smtpClient.SendMailAsync(message);
        }

    }

    public class Order
    {
        public string ClientEmail { get; internal set; }
    }
}
