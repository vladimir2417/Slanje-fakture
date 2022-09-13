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
    /// Interaction logic for Nivelacija_izveštaj.xaml
    /// </summary>
    public partial class Nivelacija_izveštaj : Window
    {
        AppBazaDataContext appBazaDataContext = new AppBazaDataContext();
        DataTable tabelaProizvodaNivelacija = new DataTable();
        int? brojNiv;

        double? kolicina = 0;
        double? staraVrednost = 0;
        double? novaVrednost = 0;
        double? vrednostNivelacije = 0;
        double? razlikaPDV = 0;

        public Nivelacija_izveštaj(int? brojNivelacije)
        {
            InitializeComponent();
            this.brojNiv = brojNivelacije;
            puniGrid();
        }

        private void puniGrid()
        {
            var nivelacija = from f in appBazaDataContext.Nivelacijes
                             where f.BrojNivelacije == brojNiv
                             select f;

            //pravljenje hedera u tabeli
            if (tabelaProizvodaNivelacija.Columns.Count == 0)
            {
                tabelaProizvodaNivelacija.Columns.Add("Šifra");
                tabelaProizvodaNivelacija.Columns.Add("Naziv");
                tabelaProizvodaNivelacija.Columns.Add("Količina");
                tabelaProizvodaNivelacija.Columns.Add("Stara cena");
                tabelaProizvodaNivelacija.Columns.Add("Nova prodajna cena");
                tabelaProizvodaNivelacija.Columns.Add("Stara vrednost");
                tabelaProizvodaNivelacija.Columns.Add("Nova vrednost");
                tabelaProizvodaNivelacija.Columns.Add("Vrednost nivelacije");
                tabelaProizvodaNivelacija.Columns.Add("Razlika PDV");
            }

            foreach (var n in nivelacija)
            {
                DataRow red = tabelaProizvodaNivelacija.NewRow();

                red["Šifra"] = n.SifraArtikla;
                red["Naziv"] = n.NazivArtikla;
                red["Količina"] = n.Kolicina;
                red["Stara cena"] = n.StaraCena;
                red["Nova prodajna cena"] = n.NovaProdajnaCena;
                red["Stara vrednost"] = n.StaraCena * n.Kolicina;
                red["Nova vrednost"] = n.NovaProdajnaCena * n.Kolicina;
                red["Vrednost nivelacije"] = (n.NovaProdajnaCena * n.Kolicina) - (n.StaraCena * n.Kolicina);
                red["Razlika PDV"] = Math.Round((double)((n.NoviPDV * n.Kolicina) - (n.StariPDV * n.Kolicina)), 2);

                kolicina += n.Kolicina;
                staraVrednost += n.StaraCena * n.Kolicina;
                novaVrednost += n.NovaProdajnaCena * n.Kolicina;
                vrednostNivelacije += (n.NovaProdajnaCena * n.Kolicina) - (n.StaraCena * n.Kolicina);
                razlikaPDV += (n.NoviPDV * n.Kolicina) - (n.StariPDV * n.Kolicina);

                tabelaProizvodaNivelacija.Rows.Add(red);
            }
            gridNivelacija.ItemsSource = tabelaProizvodaNivelacija.AsDataView();
        }

        private void btnStampaj_Click(object sender, RoutedEventArgs e)
        {
            //PRAVLJENJE PDF-A //
            try
            {
                Document dokument = new Document(PageSize.A4);

                //putanja foldera gde se cuvaju fakture
                string putanjaDoFoldera = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                putanjaDoFoldera += @"\Nivelacije\";
                if (!Directory.Exists(putanjaDoFoldera))
                {
                    Directory.CreateDirectory(putanjaDoFoldera);
                }
                string putanjaFakture = putanjaDoFoldera + "nivelacije_izvestaj_br_nivelacije_" + tbBrojNivelacije.Text + ".pdf";

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
                    PdfPCell cell1 = new PdfPCell(new Phrase("Izveštaj urađene nivelacije", f_14_normal));

                    cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    cell1.HorizontalAlignment = Element.ALIGN_LEFT;

                    ispodLogoa.WidthPercentage = 50;
                    ispodLogoa.HorizontalAlignment = Element.ALIGN_LEFT;

                    ispodLogoa.AddCell(cell1);

                    ispodLogoa.SpacingAfter = 20;
                    ispodLogoa.SpacingBefore = 0;

                    dokument.Add(ispodLogoa);

                    praviGornjiDeoPDF gornjiDeoPDF = new praviGornjiDeoPDF();
                    gornjiDeoPDF.praviGornjiDeoPDFNivelacije(dokument, tbDatumNivelacije.Text, tbBrojNivelacije.Text);

                    praviListuArtikalaPDF listaArtikala = new praviListuArtikalaPDF();
                    listaArtikala.praviListuPDFNivelacija(dokument, tabelaProizvodaNivelacija);

                    UkupnoIRabatSve ukupnoIRabatSve = new UkupnoIRabatSve();
                    ukupnoIRabatSve.praviUkupnoSveNivelacije(dokument, kolicina.ToString(), staraVrednost.ToString(), novaVrednost.ToString(), vrednostNivelacije.ToString(), razlikaPDV.ToString());

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
        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
