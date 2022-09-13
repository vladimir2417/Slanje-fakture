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
    /// <summary>
    /// Interaction logic for Artikli_izvestaj.xaml
    /// </summary>
    public partial class Artikli_izvestaj : Window
    {
        AppBazaDataContext appBazaDataContext = new AppBazaDataContext();
        DataTable tabelaProizvoda = new DataTable();
        public Artikli_izvestaj()
        {
            InitializeComponent();
        }

        private void btnIzvrsi_Click(object sender, RoutedEventArgs e)
        {

            DateTime datumOd = Convert.ToDateTime(dpOd.SelectedDate);
            DateTime datumDo = Convert.ToDateTime(dpDo.SelectedDate);

            var Stavke = (from a in appBazaDataContext.Artikals
                         join st in appBazaDataContext.FakturaStavkas
                         on a.SifraArtikla equals st.SifraArtikla
                         join f in appBazaDataContext.Fakturas on st.FakturaID equals f.FakturaID
                         where f.DatumPrometaDobara >= datumOd && f.DatumPrometaDobara <= datumDo
                          group st by new { a.SifraArtikla, a.NazivArtikla } into grp
                         select new { SifraArtikla = grp.Key.SifraArtikla, NazivArtikla = grp.Key.NazivArtikla, ProdatoArtikala = grp.Sum(a=>a.KolicinaStavke), PDVIznos = grp.Sum(a => a.PDVIznos), Ukupno = grp.Sum(a=>a.Ukupno) }
                         ).ToList();


            int ukupnoProdatoArtikala = 0;
            double ukuonaCenaSvihProdatih = 0;
            double? ukupanPDV = 0;

            foreach (var st in Stavke)
            {
                ukupnoProdatoArtikala += st.ProdatoArtikala;
                ukuonaCenaSvihProdatih += st.Ukupno;
                ukupanPDV += st.PDVIznos;
            }

            tbProdatoProizvoda.Text = ukupnoProdatoArtikala.ToString();
            tbUkunaCena.Text = ukuonaCenaSvihProdatih.ToString();
            tbIznosPDVa.Text = ukupanPDV.ToString();

            gridProizvoda.ItemsSource = Stavke;

            //pravljenje hedera u tabeli
            if (tabelaProizvoda.Columns.Count == 0)
            {
                tabelaProizvoda.Columns.Add("Šifra");
                tabelaProizvoda.Columns.Add("Naziv dobra");
                tabelaProizvoda.Columns.Add("Ukupna količina");
                tabelaProizvoda.Columns.Add("Ukupan PDV iznos");
                tabelaProizvoda.Columns.Add("Ukupna cena");
            }

            foreach (var st in Stavke)
            {
                DataRow red = tabelaProizvoda.NewRow();

                red["Šifra"] = st.SifraArtikla;
                red["Naziv dobra"] = st.NazivArtikla;
                red["Ukupna količina"] = st.ProdatoArtikala;
                red["Ukupan PDV iznos"] = st.PDVIznos;
                red["Ukupna cena"] = st.Ukupno;
                tabelaProizvoda.Rows.Add(red);
              
            }
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Odabir frmOdabir = new Odabir();
            frmOdabir.Show();
        }

        private void btnStampaj_Click(object sender, RoutedEventArgs e)
        {
            //PRAVLJENJE PDF-A //
            try
            {
                string datumOd = dpOd.SelectedDate.Value.ToString("dd.MM.yyy.", System.Globalization.CultureInfo.InvariantCulture);
                string datumDo = dpDo.SelectedDate.Value.ToString("dd.MM.yyy.", System.Globalization.CultureInfo.InvariantCulture);

                Document dokument = new Document(PageSize.A4);

                //putanja foldera gde se cuvaju fakture
                string putanjaDoFoldera = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                putanjaDoFoldera += @"\ArtikliIzvestaj\";
                if (!Directory.Exists(putanjaDoFoldera))
                {
                    Directory.CreateDirectory(putanjaDoFoldera);
                } 
                string putanjaFakture = putanjaDoFoldera + "artikli_izvestaj_" +datumOd + "-" + datumDo + ".pdf";

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
                    PdfPCell cell1 = new PdfPCell(new Phrase("Izveštaj prodatih artikala", f_14_normal));

                    cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    cell1.HorizontalAlignment = Element.ALIGN_LEFT;

                    ispodLogoa.WidthPercentage = 50;
                    ispodLogoa.HorizontalAlignment = Element.ALIGN_LEFT;

                    ispodLogoa.AddCell(cell1);

                    ispodLogoa.SpacingAfter = 20;
                    ispodLogoa.SpacingBefore = 0;

                    dokument.Add(ispodLogoa);

                    praviGornjiDeoPDF gornjiDeoPDF = new praviGornjiDeoPDF();
                    gornjiDeoPDF.praviGornjiDeoPDFArtikli(dokument, datumOd, datumDo, tbProdatoProizvoda.Text, tbIznosPDVa.Text, tbUkunaCena.Text);

                    praviListuArtikalaPDF listaArtikala = new praviListuArtikalaPDF();
                    listaArtikala.praviListuArtikalaPDFArtikli(dokument, tabelaProizvoda);

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
