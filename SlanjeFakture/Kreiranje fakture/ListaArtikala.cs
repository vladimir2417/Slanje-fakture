using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;

namespace SlanjeFakture
{
    public class ListaArtikala
    {
        public void praviListuArtikala(Document dokument, DataTable tabelaProizvoda)
        {
            BaseFont font = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
            Font f_10_normal = new Font(font, 10, Font.NORMAL);

            PdfPTable artikli = new PdfPTable(11);

            //hederi tabele
            for (int j = 0; j < 11; j++)
            {
                PdfPCell cell1 = new PdfPCell(new Phrase(tabelaProizvoda.Columns[j].ColumnName, f_10_normal));

                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                cell1.VerticalAlignment = Element.ALIGN_CENTER;
                cell1.FixedHeight = 30;
                cell1.BackgroundColor = new BaseColor(230, 230, 230);
                artikli.AddCell(cell1);
            }

            //redovi tabele
            for (int i = 0; i < tabelaProizvoda.Rows.Count; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    PdfPCell cell1 = new PdfPCell(new Phrase(tabelaProizvoda.Rows[i][j].ToString(), f_10_normal));
                    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell1.FixedHeight = 30;
                    artikli.AddCell(cell1);
                }
            }

            artikli.WidthPercentage = 100;
            float[] width = new float[] { 30f, 50f, 130f, 30f, 30f, 50f, 50f, 50f, 30f, 50f, 50f };
            artikli.SetWidths(width);
            artikli.SpacingBefore = 10;

            dokument.Add(artikli);
        }
    }
}
