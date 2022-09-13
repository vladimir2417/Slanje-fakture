using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SlanjeFakture
{
    public class Rekapitulacija
    {
        public void praviRekapitulaciju(Document dokument, string ukupnoRabat, string ukupnoBezRabata, string ukupnoFaktura, string ukupanPDV, string poreskaOsnovica)
        {
            BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
            Font f_10_normal = new Font(font, 10, Font.NORMAL);
            Font f_10_bold = new Font(font, 10, Font.BOLD);

            PdfPTable rekapitulacija = new PdfPTable(2);
            PdfPCell cell1 = new PdfPCell(new Phrase("REKAPITULACIJA:\n", f_10_bold));
            PdfPCell cell2 = new PdfPCell(new Phrase("", f_10_bold));
            PdfPCell cell3 = new PdfPCell(new Phrase("   Iznos bez odbijenog rabata: ", f_10_normal));
            PdfPCell cell4 = new PdfPCell(new Phrase(ukupnoBezRabata.ToString(), f_10_normal));
            PdfPCell cell5 = new PdfPCell(new Phrase("   Iznos rabata: ", f_10_normal));
            PdfPCell cell6 = new PdfPCell(new Phrase(ukupnoRabat.ToString(), f_10_normal));
            PdfPCell cell7 = new PdfPCell(new Phrase("   Poreska osnovica: ", f_10_normal));
            PdfPCell cell8 = new PdfPCell(new Phrase(poreskaOsnovica.ToString(), f_10_normal));
            PdfPCell cell9 = new PdfPCell(new Phrase("   PDV ukupno: ", f_10_normal));
            PdfPCell cell10 = new PdfPCell(new Phrase(ukupanPDV.ToString(), f_10_normal));
            PdfPCell cell11 = new PdfPCell(new Phrase("   IZNOS ZA UPLATU: ", f_10_normal));
            PdfPCell cell12 = new PdfPCell(new Phrase(ukupnoFaktura.ToString(), f_10_normal));
            Paragraph paragraph = new Paragraph(new Phrase("\nNapomena o poreskom oslobođenju: U sistemu smo PDV-a.\n", f_10_normal));
            paragraph.Add(new Phrase("Račun za uplatu: 265-1680310002237-41 Raiffeisen banka A.D.-Beograd", f_10_normal));
            paragraph.Alignment = Element.ALIGN_JUSTIFIED;

            cell1.Border = Rectangle.NO_BORDER;
            cell2.Border = Rectangle.NO_BORDER;
            cell3.Border = Rectangle.NO_BORDER;
            cell4.Border = Rectangle.NO_BORDER;
            cell5.Border = Rectangle.NO_BORDER;
            cell6.Border = Rectangle.NO_BORDER;
            cell7.Border = Rectangle.TOP_BORDER;
            cell8.Border = Rectangle.TOP_BORDER;
            cell9.Border = Rectangle.NO_BORDER;
            cell10.Border = Rectangle.NO_BORDER; 
            cell11.Border = Rectangle.TOP_BORDER;
            cell12.Border = Rectangle.TOP_BORDER;

            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell3.HorizontalAlignment = Element.ALIGN_LEFT;
            cell5.HorizontalAlignment = Element.ALIGN_LEFT;
            cell7.HorizontalAlignment = Element.ALIGN_LEFT;
            cell9.HorizontalAlignment = Element.ALIGN_LEFT;
            cell11.HorizontalAlignment = Element.ALIGN_LEFT;

            cell4.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell6.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell8.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell10.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell12.HorizontalAlignment = Element.ALIGN_RIGHT;

            rekapitulacija.WidthPercentage = 50;
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
            rekapitulacija.AddCell(cell9);
            rekapitulacija.AddCell(cell10);
            rekapitulacija.AddCell(cell11);
            rekapitulacija.AddCell(cell12);

            rekapitulacija.SpacingAfter = 0;
            rekapitulacija.SpacingBefore = 10;

            dokument.Add(rekapitulacija);
            dokument.Add(paragraph);
        }
    }
}
