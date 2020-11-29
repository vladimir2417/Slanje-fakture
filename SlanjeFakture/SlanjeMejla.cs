using System.Net.Mail;
using System.Windows;

namespace SlanjeFakture
{
    public class SlanjeMejla
    {
        public void saljiMejl(string mejlFirme, string racunBroj, string putanjaFakture)
        {
            MailMessage mejl = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("mailcluster.loopia.se");

            mejl.From = new MailAddress("prodaja@sudo-per.co.rs");
            mejl.To.Add(mejlFirme);
            mejl.Subject = "SUDO PER  - faktura";
            mejl.Body = "Poštovani,\n " + "U prilogu Vam šaljemo fakturu, račun broj: " + racunBroj + ".";

            Attachment faktura = new Attachment(putanjaFakture);
            mejl.Attachments.Add(faktura);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("prodaja@sudo-per.co.rs", "stefanmatija");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mejl);
            MessageBox.Show("Mejl poslat.", "Uspešno!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
