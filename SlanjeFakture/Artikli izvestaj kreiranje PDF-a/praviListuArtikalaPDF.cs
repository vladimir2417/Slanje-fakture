using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlanjeFakture.Artikli_izvestaj_kreiranje_PDF_a
{
    class praviListuArtikalaPDF
    {
        public void praviListuArtikalaPDFArtikli(Document dokument, DataTable tabelaProizvoda)
        {
            BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
            Font f_10_normal = new Font(font, 10, Font.NORMAL);

            PdfPTable artikli = new PdfPTable(5);

            //hederi tabele
            for (int j = 0; j < 5; j++)
            {
                PdfPCell cell1 = new PdfPCell(new Phrase(tabelaProizvoda.Columns[j].ColumnName, f_10_normal));

                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                cell1.VerticalAlignment = Element.ALIGN_CENTER;
                cell1.FixedHeight = 50;
                cell1.BackgroundColor = new BaseColor(230, 230, 230);
                artikli.AddCell(cell1);
            }

            //redovi tabele
            for (int i = 0; i < tabelaProizvoda.Rows.Count; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    PdfPCell cell1 = new PdfPCell(new Phrase(tabelaProizvoda.Rows[i][j].ToString(), f_10_normal));
                    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell1.FixedHeight = 40;
                    artikli.AddCell(cell1);
                }
            }

            artikli.WidthPercentage = 100;
            float[] width = new float[] { 100f, 100f, 100f, 100f, 150f };
            artikli.SetWidths(width);
            artikli.SpacingBefore = 10;

            dokument.Add(artikli);
        }

        public void praviListuPDFFakture(Document dokument, DataTable tabelaProizvoda)
        {
            BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
            Font f_10_normal = new Font(font, 10, Font.NORMAL);

            PdfPTable artikli = new PdfPTable(4);

            //hederi tabele
            for (int j = 0; j < 4; j++)
            {
                PdfPCell cell1 = new PdfPCell(new Phrase(tabelaProizvoda.Columns[j].ColumnName, f_10_normal));

                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                cell1.VerticalAlignment = Element.ALIGN_CENTER;
                cell1.FixedHeight = 50;
                cell1.BackgroundColor = new BaseColor(230, 230, 230);
                artikli.AddCell(cell1);
            }

            //redovi tabele
            for (int i = 0; i < tabelaProizvoda.Rows.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    PdfPCell cell1 = new PdfPCell(new Phrase(tabelaProizvoda.Rows[i][j].ToString(), f_10_normal));
                    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell1.FixedHeight = 40;
                    artikli.AddCell(cell1);
                }
            }

            artikli.WidthPercentage = 100;
            float[] width = new float[] { 100f, 100f, 100f, 100f };
            artikli.SetWidths(width);
            artikli.SpacingBefore = 10;

            dokument.Add(artikli);
        }

        public void praviListuPDFKalkulacije(Document dokument, DataTable tabelaProizvoda)
        {
            BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
            Font f_10_normal = new Font(font, 10, Font.NORMAL);

            PdfPTable artikli = new PdfPTable(13);

            //hederi tabele
            for (int j = 0; j < 13; j++)
            {
                PdfPCell cell1 = new PdfPCell(new Phrase(tabelaProizvoda.Columns[j].ColumnName, f_10_normal));

                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                cell1.VerticalAlignment = Element.ALIGN_CENTER;
                cell1.FixedHeight = 50;
                cell1.BackgroundColor = new BaseColor(230, 230, 230);
                artikli.AddCell(cell1);
            }

            //redovi tabele
            for (int i = 0; i < tabelaProizvoda.Rows.Count; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    PdfPCell cell1 = new PdfPCell(new Phrase(tabelaProizvoda.Rows[i][j].ToString(), f_10_normal));
                    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell1.FixedHeight = 40;
                    artikli.AddCell(cell1);
                }
            }

            artikli.WidthPercentage = 100;
            artikli.SpacingBefore = 10;

            dokument.Add(artikli);
        }
        public void praviListuPDFNivelacija(Document dokument, DataTable tabelaProizvoda)
        {
            BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
            Font f_10_normal = new Font(font, 10, Font.NORMAL);

            PdfPTable artikli = new PdfPTable(9);

            //hederi tabele
            for (int j = 0; j < 9; j++)
            {
                PdfPCell cell1 = new PdfPCell(new Phrase(tabelaProizvoda.Columns[j].ColumnName, f_10_normal));

                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                cell1.VerticalAlignment = Element.ALIGN_CENTER;
                cell1.FixedHeight = 50;
                cell1.BackgroundColor = new BaseColor(230, 230, 230);
                artikli.AddCell(cell1);
            }

            //redovi tabele
            for (int i = 0; i < tabelaProizvoda.Rows.Count; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    PdfPCell cell1 = new PdfPCell(new Phrase(tabelaProizvoda.Rows[i][j].ToString(), f_10_normal));
                    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell1.FixedHeight = 40;
                    artikli.AddCell(cell1);
                }
            }

            artikli.WidthPercentage = 100;
            //float[] width = new float[] { 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f, 50f };
            //artikli.SetWidths(width);
            artikli.SpacingBefore = 10;

            dokument.Add(artikli);
        }
    }
}
