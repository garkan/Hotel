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
    class EmailSender: INotifier
    {
        public void Notify(Record r, Client u, Admin a)
        {
            var emailUser = u.email;
            var email = Properties.Resources.Email;
            var password = Properties.Resources.Password;
            var emailManager = a.email;
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
            Message.Body = $"Номер брони: {r.id} \nДата заезда: {r.datestart.ToShortDateString()}" +
                            $"\nДата выезда: {r.dateend.ToShortDateString()}\nНомер: {r.id_room}\nИтоговая стоимость: {r.amount}" +
                            $"\nОжидает подтверждения.";
            Smtp_Client.Send(Message);//непосредственно само отправление..
        }
    }
}
