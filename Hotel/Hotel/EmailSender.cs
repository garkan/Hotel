using Hotel.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class EmailSender
    {
        public static void Send(Record r, User u)
        {
            var emailUser = u.email;
            var email = Properties.Resources.Email;
            var password = Properties.Resources.Password;
            var emailManager = Properties.Resources.ManagerEmail;
            string smtpServer = "smtp.gmail.com";
            int port = 587;
            //Указываем SMTP сервер и авторизуемся.
            SmtpClient Smtp_Client = new SmtpClient(smtpServer, port);
            Smtp_Client.Credentials = new NetworkCredential(email, password);
            //Выключаем или включаем SSL - (например для гугла должен быть включен).
            Smtp_Client.EnableSsl = true;
            //Приступаем к формированию самого письма
            MailMessage Message = new MailMessage();
            Message.From = new MailAddress(email);
            Message.To.Add(new MailAddress(emailUser));
            Message.To.Add(new MailAddress(emailManager));

            Message.Subject = "Заявка на бронирование";
            Message.Body = "Заявка на бронирование на период: " + r.datestart.ToShortDateString() + ";" + r.dateend.ToShortDateString() + ".\nОжидает подтверждения.";
            Smtp_Client.Send(Message);//непосредственно само отправление..
        }
    }
}
