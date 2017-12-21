using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace LeKiosk.FullStack.Business
{
    class MailingServices
    {

     public void sendForgettenEmail(string email, string password) { 
    var fromAddress = new MailAddress("assass.mohamed@gmail.com", "From Name");
    var toAddress = new MailAddress(email, "To Name");
    const string fromPassword = "Lufy@100";
    const string subject = "Important";
     string body = "You Forgot Your Password , Here it is : " + password+" ,";

    var smtp = new SmtpClient
    {
        Host = "smtp.gmail.com",
        Port = 587,
        EnableSsl = true,
        DeliveryMethod = SmtpDeliveryMethod.Network,
        Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
        Timeout = 20000
    };
    using (var message = new MailMessage(fromAddress, toAddress)
    {
        Subject = subject,
        Body = body
        })
        {
    smtp.Send(message);
     }
        }
    }
}
