using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlanjeFakture.Artikli_izvestaj_kreiranje_PDF_a
{
    class praviGornjiDeoPDF
    {
        public void praviGornjiDeoPDFArtikli(Document dokument, string datumOd, string datumDo, string ukupnoProdatoArtikala, string ukupanPDVIznos, string ukupnaCena)
        {
            BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
            Font f_13_normal = new Font(font, 13, Font.NORMAL);

            PdfPTable ispodLogoa = new PdfPTable(1);
            PdfPCell cell1 = new PdfPCell(new Phrase("Vremenski period: " + datumOd + " - " + datumDo, f_13_normal));
            PdfPCell cell2 = new PdfPCell(new Phrase("Ukupno prodato artikala: "+ukupnoProdatoArtikala, f_13_normal));
            PdfPCell cell3 = new PdfPCell(new Phrase("Ukupan PDV iznos: "+ukupanPDVIznos, f_13_normal));
            PdfPCell cell4 = new PdfPCell(new Phrase("Ukupna cena: "+ukupnaCena, f_13_normal));

            cell1.Border = Rectangle.NO_BORDER;
            cell2.Border = Rectangle.NO_BORDER;
            cell3.Border = Rectangle.NO_BORDER;
            cell4.Border = Rectangle.NO_BORDER;

            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell3.HorizontalAlignment = Element.ALIGN_LEFT;
            cell4.HorizontalAlignment = Element.ALIGN_LEFT;

            ispodLogoa.WidthPercentage = 50;
            ispodLogoa.HorizontalAlignment = Element.ALIGN_LEFT;

            ispodLogoa.AddCell(cell1);
            ispodLogoa.AddCell(cell2);
            ispodLogoa.AddCell(cell3);
            ispodLogoa.AddCell(cell4);

            ispodLogoa.SpacingAfter = 20;
            ispodLogoa.SpacingBefore = 20;

            dokument.Add(ispodLogoa);
        }

        public void praviGornjiDeoPDFFakture(Document dokument, string datumOd, string datumDo, string ukupnoIzdatoFaktura, string ukupnoProdatoArtikala, string ukupnaCena, string ukupanPDVIznos)
        {
            BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
            Font f_13_normal = new Font(font, 13, Font.NORMAL);

            PdfPTable ispodLogoa = new PdfPTable(1);
            PdfPCell cell1 = new PdfPCell(new Phrase("Vremenski period: " + datumOd + " - " + datumDo, f_13_normal));
            PdfPCell cell2 = new PdfPCell(new Phrase("Ukupno izdato faktura: " + ukupnoIzdatoFaktura, f_13_normal));
            PdfPCell cell3 = new PdfPCell(new Phrase("Ukupno prodato artikala: " + ukupnoProdatoArtikala, f_13_normal));
            PdfPCell cell4 = new PdfPCell(new Phrase("Ukupan PDV iznos: " + ukupanPDVIznos, f_13_normal));
            PdfPCell cell5 = new PdfPCell(new Phrase("Ukupna cena: " + ukupnaCena, f_13_normal));

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

            ispodLogoa.SpacingAfter = 20;
            ispodLogoa.SpacingBefore = 20;

            dokument.Add(ispodLogoa);
        }

        public void praviGornjiDeoPDFKalkulacije(Document dokument, string datumKalkulacije, string brojBalkulacije, string brojDokumenta)
        {
            BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
            Font f_13_normal = new Font(font, 13, Font.NORMAL);

            PdfPTable ispodLogoa = new PdfPTable(1);
            PdfPCell cell1 = new PdfPCell(new Phrase("Kalkulacija broj: " + brojBalkulacije, f_13_normal));
            PdfPCell cell2 = new PdfPCell(new Phrase("Po dokumentu broj: " + brojDokumenta, f_13_normal));
            PdfPCell cell3 = new PdfPCell(new Phrase("Datum kalkulacije: " + datumKalkulacije, f_13_normal));

            cell1.Border = Rectangle.NO_BORDER;
            cell2.Border = Rectangle.NO_BORDER;
            cell3.Border = Rectangle.NO_BORDER;

            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell3.HorizontalAlignment = Element.ALIGN_LEFT;

            ispodLogoa.WidthPercentage = 50;
            ispodLogoa.HorizontalAlignment = Element.ALIGN_LEFT;

            ispodLogoa.AddCell(cell1);
            ispodLogoa.AddCell(cell2);
            ispodLogoa.AddCell(cell3);

            ispodLogoa.SpacingAfter = 20;
            ispodLogoa.SpacingBefore = 20;

            dokument.Add(ispodLogoa);
        }

        public void praviGornjiDeoPDFNivelacije(Document dokument, string datumNivelacije, string brojNivelacije)
        {
            BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
            Font f_13_normal = new Font(font, 13, Font.NORMAL);

            PdfPTable ispodLogoa = new PdfPTable(1);
            PdfPCell cell1 = new PdfPCell(new Phrase("Nivelacija broj: " + brojNivelacije, f_13_normal));
            PdfPCell cell2 = new PdfPCell(new Phrase("Datum: " + datumNivelacije, f_13_normal));

            cell1.Border = Rectangle.NO_BORDER;
            cell2.Border = Rectangle.NO_BORDER;

            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;

            ispodLogoa.WidthPercentage = 50;
            ispodLogoa.HorizontalAlignment = Element.ALIGN_LEFT;

            ispodLogoa.AddCell(cell1);
            ispodLogoa.AddCell(cell2);

            ispodLogoa.SpacingAfter = 20;
            ispodLogoa.SpacingBefore = 20;

            dokument.Add(ispodLogoa);
        }
    }
}
