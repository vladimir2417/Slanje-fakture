using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SlanjeFakture
{
    public class PodaciOFakturi
    {
        public void praviPodatkeOFakturi(Document dokument, string racunBroj, string mestoIzdavanja, string datum, string rokPlacanja)
        {
            BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
            Font f_10_normal = new Font(font, 10, Font.NORMAL);
            Font f_14_bold = new Font(font, 14, Font.BOLD);
            PdfPTable podaciOFakturi = new PdfPTable(1);
            PdfPCell cell1 = new PdfPCell(new Phrase("RAČUN BROJ: " + racunBroj, f_14_bold));
            cell1.Border = Rectangle.NO_BORDER;
            cell1.HorizontalAlignment = Element.ALIGN_CENTER;

            podaciOFakturi.WidthPercentage = 100;
            podaciOFakturi.HorizontalAlignment = Element.ALIGN_CENTER;

            podaciOFakturi.AddCell(cell1);

            podaciOFakturi.SpacingAfter = 20;
            podaciOFakturi.SpacingBefore = 0;

            dokument.Add(podaciOFakturi);

            Paragraph paragraf = new Paragraph(new Phrase("Mesto i datum izdavanja računa: " + mestoIzdavanja + ", " + datum + "\n", f_10_normal));
            paragraf.Add(new Phrase("Datum prometa dobara i usluga: " + datum + "\n\n", f_10_normal));
            paragraf.Add(new Phrase("Rok plaćanja: " + rokPlacanja + " Posle isteka roka plaćanja na iznos duga zaračunavamo zateznu kamatu.", f_10_normal));

            paragraf.Alignment = Element.ALIGN_JUSTIFIED;

            dokument.Add(paragraf);
        }
    }
}
