using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SlanjeFakture
{
    public class Footer : PdfPageEventHelper
    {
        public override void OnEndPage(PdfWriter writer, Document dokument)
        {
            BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
            Font f_10_normal = new Font(font, 10, Font.NORMAL);

            base.OnEndPage(writer, dokument);

            PdfPTable footer = new PdfPTable(5);
            PdfPCell cell1 = new PdfPCell(new Phrase("FAKTURISAO", f_10_normal));
            PdfPCell cell2 = new PdfPCell(new Phrase("", f_10_normal));
            PdfPCell cell3 = new PdfPCell(new Phrase("PRIMIO", f_10_normal));
            PdfPCell cell4 = new PdfPCell(new Phrase("", f_10_normal));
            PdfPCell cell5 = new PdfPCell(new Phrase("OVLAŠĆENO LICE", f_10_normal));

            cell1.HorizontalAlignment = Element.ALIGN_CENTER;
            cell1.VerticalAlignment = Element.ALIGN_CENTER;
            cell1.FixedHeight = 40;
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.FixedHeight = 40;
            cell3.HorizontalAlignment = Element.ALIGN_CENTER;
            cell3.VerticalAlignment = Element.ALIGN_CENTER;
            cell3.FixedHeight = 40;
            cell4.HorizontalAlignment = Element.ALIGN_CENTER;
            cell4.FixedHeight = 40;
            cell5.HorizontalAlignment = Element.ALIGN_CENTER;
            cell5.VerticalAlignment = Element.ALIGN_CENTER;
            cell5.FixedHeight = 40;

            cell1.Border = Rectangle.TOP_BORDER;
            cell2.Border = Rectangle.NO_BORDER;
            cell3.Border = Rectangle.TOP_BORDER;
            cell4.Border = Rectangle.NO_BORDER;
            cell5.Border = Rectangle.TOP_BORDER;

            footer.TotalWidth = 500f;
            float[] width = new float[] { 125f, 62.5f, 125f, 62.5f, 125f };
            footer.SetWidths(width);
            footer.HorizontalAlignment = Element.ALIGN_CENTER;

            footer.AddCell(cell1);
            footer.AddCell(cell2);
            footer.AddCell(cell3);
            footer.AddCell(cell4);
            footer.AddCell(cell5);

            footer.WriteSelectedRows(0, 40, 45, dokument.Bottom, writer.DirectContent);
        }
    }
}
