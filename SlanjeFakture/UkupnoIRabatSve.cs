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
            float[] width = new float[] { 420f, 80f, 50f };
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

        public void praviUkupnoIRabatSveKalkulacije(Document dokument, string vrednostRobeukupno, string troskoviUkupno, string RUCukupno, string osnovicaUkupno, string PDViznosUkupno, string prodajnaCenaUkupno )
        {
            BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
            Font f_10_normal = new Font(font, 10, Font.NORMAL);

            PdfPTable ukupnoIRabat = new PdfPTable(10);
            PdfPCell cell1 = new PdfPCell(new Phrase("UKUPNO:", f_10_normal));
            PdfPCell cell2 = new PdfPCell(new Phrase(vrednostRobeukupno, f_10_normal));
            PdfPCell cell3 = new PdfPCell(new Phrase(troskoviUkupno, f_10_normal));
            PdfPCell cell4 = new PdfPCell(new Phrase("", f_10_normal));
            PdfPCell cell5 = new PdfPCell(new Phrase(RUCukupno, f_10_normal));
            PdfPCell cell6 = new PdfPCell(new Phrase(osnovicaUkupno, f_10_normal));
            PdfPCell cell7 = new PdfPCell(new Phrase("", f_10_normal));
            PdfPCell cell8 = new PdfPCell(new Phrase(PDViznosUkupno, f_10_normal));
            PdfPCell cell9 = new PdfPCell(new Phrase(prodajnaCenaUkupno, f_10_normal));
            PdfPCell cell10 = new PdfPCell(new Phrase("", f_10_normal));
            


            ukupnoIRabat.WidthPercentage = 100;
            float[] width = new float[] { 169.3f, 42.3f, 42.3f, 42.3f, 42.3f, 42.3f, 42.3f, 42.3f, 42.3f, 42.3f };
            ukupnoIRabat.SetWidths(width);

            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_CENTER;
            cell1.FixedHeight = 40;
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.FixedHeight = 40;
            cell3.HorizontalAlignment = Element.ALIGN_CENTER;
            cell3.FixedHeight = 40;
            cell4.HorizontalAlignment = Element.ALIGN_CENTER;
            cell4.FixedHeight = 40;
            cell5.HorizontalAlignment = Element.ALIGN_CENTER;
            cell5.FixedHeight = 40;
            cell6.HorizontalAlignment = Element.ALIGN_CENTER;
            cell6.FixedHeight = 40;
            cell7.HorizontalAlignment = Element.ALIGN_CENTER;
            cell7.FixedHeight = 40;
            cell8.HorizontalAlignment = Element.ALIGN_CENTER;
            cell8.FixedHeight = 40;
            cell9.HorizontalAlignment = Element.ALIGN_CENTER;
            cell9.FixedHeight = 40;
            cell10.HorizontalAlignment = Element.ALIGN_CENTER;
            cell10.FixedHeight = 40;

            cell1.BackgroundColor = new BaseColor(230, 230, 230);
            cell2.BackgroundColor = new BaseColor(230, 230, 230);
            cell3.BackgroundColor = new BaseColor(230, 230, 230);
            cell4.BackgroundColor = new BaseColor(230, 230, 230);
            cell5.BackgroundColor = new BaseColor(230, 230, 230);
            cell6.BackgroundColor = new BaseColor(230, 230, 230);
            cell7.BackgroundColor = new BaseColor(230, 230, 230);
            cell8.BackgroundColor = new BaseColor(230, 230, 230);
            cell9.BackgroundColor = new BaseColor(230, 230, 230);
            cell10.BackgroundColor = new BaseColor(230, 230, 230);

            ukupnoIRabat.AddCell(cell1);
            ukupnoIRabat.AddCell(cell2);
            ukupnoIRabat.AddCell(cell3);
            ukupnoIRabat.AddCell(cell4);
            ukupnoIRabat.AddCell(cell5);
            ukupnoIRabat.AddCell(cell6);
            ukupnoIRabat.AddCell(cell7);
            ukupnoIRabat.AddCell(cell8);
            ukupnoIRabat.AddCell(cell9);
            ukupnoIRabat.AddCell(cell10);

            dokument.Add(ukupnoIRabat);
        }

        public void praviUkupnoSveNivelacije(Document dokument, string kolicina, string staraVrednost, string novaVrednost, string vrednostNivelacije, string razlikaPDV)
        {
            BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
            Font f_10_normal = new Font(font, 10, Font.NORMAL);

            PdfPTable ukupnoIRabat = new PdfPTable(8);
            PdfPCell cell1 = new PdfPCell(new Phrase("UKUPNO:", f_10_normal));
            PdfPCell cell2 = new PdfPCell(new Phrase(kolicina, f_10_normal));
            PdfPCell cell3 = new PdfPCell(new Phrase("", f_10_normal));
            PdfPCell cell4 = new PdfPCell(new Phrase("", f_10_normal));
            PdfPCell cell5 = new PdfPCell(new Phrase(staraVrednost, f_10_normal));
            PdfPCell cell6 = new PdfPCell(new Phrase(novaVrednost, f_10_normal));
            PdfPCell cell7 = new PdfPCell(new Phrase(vrednostNivelacije, f_10_normal));
            PdfPCell cell8 = new PdfPCell(new Phrase(razlikaPDV, f_10_normal));

            ukupnoIRabat.WidthPercentage = 100;
            float[] width = new float[] { 100f, 50f, 50f, 50f, 50f, 50f, 50f, 50f };
            ukupnoIRabat.SetWidths(width);

            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_CENTER;
            cell1.FixedHeight = 40;
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.FixedHeight = 40;
            cell3.HorizontalAlignment = Element.ALIGN_CENTER;
            cell3.FixedHeight = 40;
            cell4.HorizontalAlignment = Element.ALIGN_CENTER;
            cell4.FixedHeight = 40;
            cell5.HorizontalAlignment = Element.ALIGN_CENTER;
            cell5.FixedHeight = 40;
            cell6.HorizontalAlignment = Element.ALIGN_CENTER;
            cell6.FixedHeight = 40;
            cell7.HorizontalAlignment = Element.ALIGN_CENTER;
            cell7.FixedHeight = 40;
            cell8.HorizontalAlignment = Element.ALIGN_CENTER;
            cell8.FixedHeight = 40;

            cell1.BackgroundColor = new BaseColor(230, 230, 230);
            cell2.BackgroundColor = new BaseColor(230, 230, 230);
            cell3.BackgroundColor = new BaseColor(230, 230, 230);
            cell4.BackgroundColor = new BaseColor(230, 230, 230);
            cell5.BackgroundColor = new BaseColor(230, 230, 230);
            cell6.BackgroundColor = new BaseColor(230, 230, 230);
            cell7.BackgroundColor = new BaseColor(230, 230, 230);
            cell8.BackgroundColor = new BaseColor(230, 230, 230);

            ukupnoIRabat.AddCell(cell1);
            ukupnoIRabat.AddCell(cell2);
            ukupnoIRabat.AddCell(cell3);
            ukupnoIRabat.AddCell(cell4);
            ukupnoIRabat.AddCell(cell5);
            ukupnoIRabat.AddCell(cell6);
            ukupnoIRabat.AddCell(cell7);
            ukupnoIRabat.AddCell(cell8);

            dokument.Add(ukupnoIRabat);
        }
    }
}
