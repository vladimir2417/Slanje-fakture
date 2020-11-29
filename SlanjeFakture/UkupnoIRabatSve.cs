using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SlanjeFakture
{
    public class UkupnoIRabatSve
    {
        public void praviUkupnoIRabatSve(Document dokument, string ukupnoSve)
        {
            BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
            Font f_10_normal = new Font(font, 10, Font.NORMAL);

            PdfPTable ukupnoIRabat = new PdfPTable(3);
            PdfPCell cell1 = new PdfPCell(new Phrase("", f_10_normal));
            PdfPCell cell2 = new PdfPCell(new Phrase("UKUPNO: ", f_10_normal));
            PdfPCell cell3 = new PdfPCell(new Phrase(ukupnoSve, f_10_normal));

            ukupnoIRabat.WidthPercentage = 100;
            float[] width = new float[] { 440f, 60f, 50f };
            ukupnoIRabat.SetWidths(width);

            cell1.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell1.FixedHeight = 20;
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.FixedHeight = 20;
            cell3.HorizontalAlignment = Element.ALIGN_CENTER;
            cell3.FixedHeight = 20;

            ukupnoIRabat.AddCell(cell1);
            ukupnoIRabat.AddCell(cell2);
            ukupnoIRabat.AddCell(cell3);

            dokument.Add(ukupnoIRabat);
        }
    }
}
