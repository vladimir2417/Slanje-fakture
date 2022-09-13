using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SlanjeFakture
{
    public class PodaciONama
    {
        public void praviPodatkeONama(Document dokument)
        {
            BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
            Font f_10_normal = new Font(font, 10, Font.NORMAL);

            PdfPTable ispodLogoa = new PdfPTable(1);
            PdfPCell cell1 = new PdfPCell(new Phrase("Inter Boss SM", f_10_normal));
            PdfPCell cell2 = new PdfPCell(new Phrase("ul. Obalskih radnika 21", f_10_normal));
            PdfPCell cell3 = new PdfPCell(new Phrase("PIB: 112703724", f_10_normal));
            PdfPCell cell4 = new PdfPCell(new Phrase("M.B.: 66296113", f_10_normal));
            PdfPCell cell5 = new PdfPCell(new Phrase("Kontakt telefon: 011 24 11 098", f_10_normal));

            cell1.Border = Rectangle.NO_BORDER;
            cell2.Border = Rectangle.NO_BORDER;
            cell3.Border = Rectangle.NO_BORDER;
            cell4.Border = Rectangle.NO_BORDER;
            cell5.Border = Rectangle.NO_BORDER;

            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell3.HorizontalAlignment = Element.ALIGN_LEFT;
            cell4.HorizontalAlignment = Element.ALIGN_LEFT;
            cell5.HorizontalAlignment = Element.ALIGN_LEFT;

            ispodLogoa.WidthPercentage = 50;
            ispodLogoa.HorizontalAlignment = Element.ALIGN_LEFT;

            ispodLogoa.AddCell(cell1);
            ispodLogoa.AddCell(cell2);
            ispodLogoa.AddCell(cell3);
            ispodLogoa.AddCell(cell4);
            ispodLogoa.AddCell(cell5);

            ispodLogoa.SpacingAfter = -80;
            ispodLogoa.SpacingBefore = 10;

            dokument.Add(ispodLogoa);
        }
    }
}
