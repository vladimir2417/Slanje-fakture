using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SlanjeFakture
{
    public class Rekapitulacija
    {
        public void praviRekapitulaciju(Document dokument, string ukupnoRabat, double iznosBezRabata, string ukupnoSve)
        {
            BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
            Font f_10_normal = new Font(font, 10, Font.NORMAL);
            Font f_10_bold = new Font(font, 10, Font.BOLD);

            PdfPTable rekapitulacija = new PdfPTable(2);
            PdfPCell cell1 = new PdfPCell(new Phrase("REKAPITULACIJA:\n", f_10_bold));
            PdfPCell cell2 = new PdfPCell(new Phrase("", f_10_bold));
            PdfPCell cell3 = new PdfPCell(new Phrase("   Iznos bez odbijenog rabata: ", f_10_normal));
            PdfPCell cell4 = new PdfPCell(new Phrase(iznosBezRabata.ToString(), f_10_normal));
            PdfPCell cell5 = new PdfPCell(new Phrase("   Iznos rabata: ", f_10_normal));
            PdfPCell cell6 = new PdfPCell(new Phrase(ukupnoRabat.ToString(), f_10_normal));
            PdfPCell cell7 = new PdfPCell(new Phrase("   IZNOS ZA UPLATU: ", f_10_normal));
            PdfPCell cell8 = new PdfPCell(new Phrase(ukupnoSve.ToString(), f_10_normal));
            Paragraph paragraph = new Paragraph(new Phrase("\nNapomena o poreskom oslobođenju: Nismo u sistemu PDV-a.\n", f_10_normal));
            paragraph.Add(new Phrase("Račun za uplatu: 265-6680310000351-02 Raiffeisen banka A.D.-Beograd", f_10_normal));
            paragraph.Alignment = Element.ALIGN_JUSTIFIED;

            cell1.Border = Rectangle.NO_BORDER;
            cell2.Border = Rectangle.NO_BORDER;
            cell3.Border = Rectangle.NO_BORDER;
            cell4.Border = Rectangle.NO_BORDER;
            cell5.Border = Rectangle.NO_BORDER;
            cell6.Border = Rectangle.NO_BORDER;
            cell7.Border = Rectangle.TOP_BORDER;
            cell8.Border = Rectangle.TOP_BORDER;

            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell3.HorizontalAlignment = Element.ALIGN_LEFT;
            cell5.HorizontalAlignment = Element.ALIGN_LEFT;
            cell7.HorizontalAlignment = Element.ALIGN_LEFT;

            cell4.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell6.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell8.HorizontalAlignment = Element.ALIGN_RIGHT;

            rekapitulacija.WidthPercentage = 40;
            float[] width = new float[] { 80, 20 };
            rekapitulacija.SetWidths(width);
            rekapitulacija.HorizontalAlignment = Element.ALIGN_LEFT;

            rekapitulacija.AddCell(cell1);
            rekapitulacija.AddCell(cell2);
            rekapitulacija.AddCell(cell3);
            rekapitulacija.AddCell(cell4);
            rekapitulacija.AddCell(cell5);
            rekapitulacija.AddCell(cell6);
            rekapitulacija.AddCell(cell7);
            rekapitulacija.AddCell(cell8);

            rekapitulacija.SpacingAfter = 0;
            rekapitulacija.SpacingBefore = 10;

            dokument.Add(rekapitulacija);
            dokument.Add(paragraph);
        }
    }
}
