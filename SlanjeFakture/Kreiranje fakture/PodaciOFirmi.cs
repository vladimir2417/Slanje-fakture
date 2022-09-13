using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SlanjeFakture
{
    public class PodaciOFirmi
    {
        public void praviPodatkeOFirmi(Document dokument, string nazivFirme, string adresaFirme, string postanskiBroj, string pib, string mb)
        {
            BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
            Font f_10_normal = new Font(font, 10, Font.NORMAL);
            Font f_12_normal = new Font(font, 12, Font.NORMAL);

            PdfPTable podaciOFirmi = new PdfPTable(1);
            PdfPCell cell1 = new PdfPCell(new Phrase("Kupac:", f_10_normal));
            PdfPCell cell2 = new PdfPCell(new Phrase(nazivFirme, f_12_normal));
            PdfPCell cell3 = new PdfPCell(new Phrase(adresaFirme, f_10_normal));
            PdfPCell cell4 = new PdfPCell(new Phrase(postanskiBroj, f_10_normal));
            PdfPCell cell5 = new PdfPCell(new Phrase("PIB: " + pib.ToString() + "  M.B.: " + mb.ToString(), f_10_normal));

            cell1.Border = Rectangle.NO_BORDER;
            cell2.Border = Rectangle.NO_BORDER;
            cell3.Border = Rectangle.NO_BORDER;
            cell4.Border = Rectangle.NO_BORDER;
            cell5.Border = Rectangle.NO_BORDER;

            cell1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cell2.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cell3.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cell4.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cell5.HorizontalAlignment = Element.ALIGN_JUSTIFIED;

            podaciOFirmi.AddCell(cell1);
            podaciOFirmi.AddCell(cell2);
            podaciOFirmi.AddCell(cell3);
            podaciOFirmi.AddCell(cell4);
            podaciOFirmi.AddCell(cell5);

            PdfPTable okvirTabele = new PdfPTable(1);
            okvirTabele.AddCell(podaciOFirmi);

            okvirTabele.HorizontalAlignment = Element.ALIGN_RIGHT;

            okvirTabele.WidthPercentage = 40;
            okvirTabele.SpacingAfter = 30;

            dokument.Add(okvirTabele);
        }
    }
}
