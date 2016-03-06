using Microsoft.AspNet.Identity;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AplicacionWebBase.Services
{
    /// <summary>
    /// Servicio que permite las notificaciones por correo electronico.
    /// </summary>
    public class EmailService : IIdentityMessageService
    {
        private SmtpClient smtpCliente = new SmtpClient();
        private NetworkCredential credential;
        private MailMessage message;
        private string accountEmail;

        /// <summary>
        /// Permite el envio de correos electronicos atravez de SMTP.
        /// </summary>
        /// <param name="accountEmail"></param>
        /// <param name="password"></param>
        public EmailService(string hostSmtp, int portStmp, string accountEmail, string accountPass)
        {   
            this.accountEmail = accountEmail;

            this.credential = new NetworkCredential(accountEmail, accountPass);
            this.smtpCliente.EnableSsl = true;
            this.smtpCliente.Credentials = this.credential;
            this.smtpCliente.Port = portStmp;
            this.smtpCliente.Host = hostSmtp;
        }

        public async Task SendAsync(IdentityMessage message)
        {
            this.message = new MailMessage(accountEmail, message.Destination);
            this.message.Body = message.Body;
            this.message.Subject = message.Subject;
            await Task.Run(() => this.smtpCliente.SendAsync(this.message, "Sending.."));
        }
    }
}