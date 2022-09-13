using System.Net.Mail;
using System.Windows;

namespace SlanjeFakture
{
    public class SlanjeMejla
    {
        public void saljiMejl(string mejlFirme, string racunBroj, string putanjaFakture)
        {
            MailMessage mejl = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mejl.From = new MailAddress("interboss.sm@gmail.com");
            mejl.To.Add(mejlFirme);
            mejl.Subject = "Inter Boss SM  - faktura";
            mejl.Body = "Poštovani,\n " + "U prilogu Vam šaljemo fakturu, račun broj: " + racunBroj + ".";

            Attachment faktura = new Attachment(putanjaFakture);
            mejl.Attachments.Add(faktura);

            SmtpServer.EnableSsl = true;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("interboss.sm@gmail.com", "stefanmatija");
            

            SmtpServer.Send(mejl);
            MessageBox.Show("Mejl poslat.", "Uspešno!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
