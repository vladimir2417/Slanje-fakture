using iTextSharp.text;
using iTextSharp.text.pdf;
using SlanjeFakture.Artikli_izvestaj_kreiranje_PDF_a;
using SlanjeFakture.LinqToSql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SlanjeFakture
{
    public partial class Kalkulacije_izvestaj : Window
    {
        AppBazaDataContext appBazaDataContext = new AppBazaDataContext();
        DataTable tabelaProizvoda = new DataTable();

        double? vrednostRobeUkupno = 0;
        double? troskoviUkupno = 0;
        double? RUCukupno = 0;
        double? osnovicaUkupno = 0;
        double? PDViznosUkupno = 0;
        double? prodajnaCenaUkupno = 0;

        int? brojKal;

        public Kalkulacije_izvestaj(int? brojKalkulacije)
        {
            InitializeComponent();
            this.brojKal = brojKalkulacije;
            puniGrid();
        }

        public void puniGrid()
        {
            var kalkuacija = from f in appBazaDataContext.Kalkulacijas
                             where f.BrojKalkulacije == brojKal
                             select f;

            if (tabelaProizvoda.Columns.Count == 0)
            {
                tabelaProizvoda.Columns.Add("Šifra");
                tabelaProizvoda.Columns.Add("Naziv artikla");
                tabelaProizvoda.Columns.Add("Količina");
                tabelaProizvoda.Columns.Add("Nabavna cena (RSD)");
                tabelaProizvoda.Columns.Add("Vrednost robe (RSD)");
                tabelaProizvoda.Columns.Add("Troškovi ukupno");
                tabelaProizvoda.Columns.Add("Marža");
                tabelaProizvoda.Columns.Add("RUC");
                tabelaProizvoda.Columns.Add("Osnovica");
                tabelaProizvoda.Columns.Add("PDV stopa");
                tabelaProizvoda.Columns.Add("PDV iznos");
                tabelaProizvoda.Columns.Add("Prodajna cena");
                tabelaProizvoda.Columns.Add("Prodajna cena po JM");
            }

            foreach (var k in kalkuacija)
            {
                DataRow red = tabelaProizvoda.NewRow();

                red["Šifra"] = k.SifraArtikla;
                red["Naziv artikla"] = k.NazivArtikla;
                red["Količina"] = k.Kolicina;
                red["Nabavna cena (RSD)"] = k.NabavnaCenaRSD;
                red["Vrednost robe (RSD)"] = k.Vrednost;
                red["Troškovi ukupno"] = k.UkupniTroskovi;
                red["Marža"] = k.Marza;
                red["RUC"] = k.RUCUkupno;
                red["Osnovica"] = k.OsnovicaUkupno;
                red["PDV stopa"] = 20;
                red["PDV iznos"] = k.IznosPDVUkupno;
                red["Prodajna cena"] = k.ProdajnaVrednostUkupno;
                red["Prodajna cena po JM"] = k.ProdajnaCena;

                vrednostRobeUkupno += k.Vrednost;
                troskoviUkupno += k.UkupniTroskovi;
                RUCukupno += k.RUCUkupno;
                osnovicaUkupno += k.OsnovicaUkupno;
                PDViznosUkupno += k.IznosPDVUkupno;
                prodajnaCenaUkupno += k.ProdajnaVrednostUkupno;

                tabelaProizvoda.Rows.Add(red);
            }

            gridKalkulacija.ItemsSource = tabelaProizvoda.AsDataView();
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void btnStampaj_Click(object sender, RoutedEventArgs e)
        {
            //PRAVLJENJE PDF-A //
            try
            {
                Document dokument = new Document(PageSize.A4.Rotate());

                //putanja foldera gde se cuvaju fakture
                string putanjaDoFoldera = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                putanjaDoFoldera += @"\Kalkulacije\";
                if (!Directory.Exists(putanjaDoFoldera))
                {
                    Directory.CreateDirectory(putanjaDoFoldera);
                }
                string putanjaFakture = putanjaDoFoldera + "kalkulacije_izvestaj_" + "-" + tbBrojKalkulacije.Text + ".pdf";

                FileStream os = new FileStream(putanjaFakture, FileMode.Create);

                using (os)
                {
                    PdfWriter writer = PdfWriter.GetInstance(dokument, os);

                    dokument.Open();

                    //logo
                    string putanjaSlike = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Logo za fakturu\logoInterBoss.png";
                    iTextSharp.text.Image slika = iTextSharp.text.Image.GetInstance(putanjaSlike);
                    slika.Alignment = Element.ALIGN_RIGHT;
                    slika.ScaleToFit(150, 100);
                    dokument.Add(slika);
                    //END logo

                    BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                    Font f_14_normal = new Font(font, 14, Font.BOLD);

                    PdfPTable ispodLogoa = new PdfPTable(1);
                    PdfPCell cell1 = new PdfPCell(new Phrase("Izveštaj urađene kalkulacije", f_14_normal));

                    cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    cell1.HorizontalAlignment = Element.ALIGN_LEFT;

                    ispodLogoa.WidthPercentage = 50;
                    ispodLogoa.HorizontalAlignment = Element.ALIGN_LEFT;

                    ispodLogoa.AddCell(cell1);

                    ispodLogoa.SpacingAfter = 20;
                    ispodLogoa.SpacingBefore = 0;

                    dokument.Add(ispodLogoa);

                    praviGornjiDeoPDF gornjiDeoPDF = new praviGornjiDeoPDF();
                    gornjiDeoPDF.praviGornjiDeoPDFKalkulacije(dokument, tbDatumKalkulacije.Text, tbBrojKalkulacije.Text, tbPoRacunuBroj.Text);

                    praviListuArtikalaPDF listaArtikala = new praviListuArtikalaPDF();
                    listaArtikala.praviListuPDFKalkulacije(dokument, tabelaProizvoda);

                    UkupnoIRabatSve ukupnoIRabatSve = new UkupnoIRabatSve();
                    ukupnoIRabatSve.praviUkupnoIRabatSveKalkulacije(dokument, vrednostRobeUkupno.ToString(), troskoviUkupno.ToString(), RUCukupno.ToString(), osnovicaUkupno.ToString(), PDViznosUkupno.ToString(), prodajnaCenaUkupno.ToString());

                    dokument.Close();
                }
                //END PRAVLJENJE PDF-A //

                //otvaranje nakon cuvanja
                Process.Start(putanjaFakture);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Neuspešno pravljenje izveštaja, molimo pokušajte ponovo. Greška: \n\n" + ex, "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
