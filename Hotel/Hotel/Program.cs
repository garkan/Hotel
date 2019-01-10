using Hotel.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BookingRoom(new data.Client(1, "abramov", "15625", "Абрамов А.К.", "dariast123test@gmail.com", "89088456362"),
                new EmailSender()));
        }
    }
}
