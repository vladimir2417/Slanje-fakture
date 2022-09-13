using iTextSharp.text;
using iTextSharp.text.pdf;
using SlanjeFakture.Artikli_izvestaj_kreiranje_PDF_a;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace SlanjeFakture.LinqToSql
{
    public partial class Izvestaji : Window
    {
        AppBazaDataContext appBazaDataContext = new AppBazaDataContext();
        DataTable tabelaProizvoda = new DataTable();
        public Izvestaji()
        {
            InitializeComponent();
        }

        private void btnIzvrsi_Click(object sender, RoutedEventArgs e)
        {
            tbIzdatoFaktura.Text = "";
            tbIznosPDVa.Text = "";
            tbProdatoProizvoda.Text = "";
            tbUkunaCena.Text = "";

            DateTime datumOd = Convert.ToDateTime(dpOd.SelectedDate);
            DateTime datumDo = Convert.ToDateTime(dpDo.SelectedDate);

            var faktura = from f in appBazaDataContext.Fakturas
                          where f.DatumPrometaDobara >= datumOd && f.DatumPrometaDobara <= datumDo
                          select f;

            int ukuonoProdatoArtikala = 0;
            double ukuonaCenaSvihFaktura = 0;
            double ukupanPDV = 0;

            foreach (Faktura fak in faktura)
            {
                var stavke = from a in appBazaDataContext.FakturaStavkas
                             where a.FakturaID == fak.FakturaID
                             select a;
                foreach(FakturaStavka fakStav in stavke)
                {
                    ukuonoProdatoArtikala += fakStav.KolicinaStavke;
                    ukupanPDV += Math.Round((double)fakStav.PDVIznos, 2); 
                }
                ukuonaCenaSvihFaktura += Math.Round(fak.Ukupno, 2);
            }

            gridProizvoda.ItemsSource = faktura;

            tbIzdatoFaktura.Text = faktura.Count().ToString();
            tbProdatoProizvoda.Text = ukuonoProdatoArtikala.ToString();
            tbUkunaCena.Text = ukuonaCenaSvihFaktura.ToString();
            tbIznosPDVa.Text = ukupanPDV.ToString();

            //pravljenje hedera u tabeli
            if (tabelaProizvoda.Columns.Count == 0)
            {
                tabelaProizvoda.Columns.Add("Račun broj");
                tabelaProizvoda.Columns.Add("Kupac");
                tabelaProizvoda.Columns.Add("Datum prometa");
                tabelaProizvoda.Columns.Add("Ukupno");
            }

            foreach (var fk in faktura)
            {
                DataRow red = tabelaProizvoda.NewRow();

                red["Račun broj"] = fk.RacunBroj;
                red["Kupac"] = fk.NazivKupca;
                red["Datum prometa"] = fk.DatumPrometaDobara;
                red["Ukupno"] = fk.Ukupno;
                
                tabelaProizvoda.Rows.Add(red);

            }
        }

        private void btnDetalji_Click(object sender, RoutedEventArgs e)
        {
            DetaljiFakture detaljiFakture = new DetaljiFakture(((Faktura)gridProizvoda.SelectedValue).FakturaID);

            detaljiFakture.tbRacunBroj.Text = ((Faktura)gridProizvoda.SelectedValue).RacunBroj.ToString();

            detaljiFakture.ShowDialog();
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
                putanjaDoFoldera += @"\FaktureIzvestaj\";
                if (!Directory.Exists(putanjaDoFoldera))
                {
                    Directory.CreateDirectory(putanjaDoFoldera);
                }
                string putanjaFakture = putanjaDoFoldera + "fakture_izvestaj_" + datumOd + "-" + datumDo + ".pdf";

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
                    PdfPCell cell1 = new PdfPCell(new Phrase("Izveštaj izdatih faktura", f_14_normal));

                    cell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    cell1.HorizontalAlignment = Element.ALIGN_LEFT;

                    ispodLogoa.WidthPercentage = 50;
                    ispodLogoa.HorizontalAlignment = Element.ALIGN_LEFT;

                    ispodLogoa.AddCell(cell1);

                    ispodLogoa.SpacingAfter = 20;
                    ispodLogoa.SpacingBefore = 0;

                    dokument.Add(ispodLogoa);

                    praviGornjiDeoPDF gornjiDeoPDF = new praviGornjiDeoPDF();
                    gornjiDeoPDF.praviGornjiDeoPDFFakture(dokument, datumOd, datumDo, tbIzdatoFaktura.Text, tbProdatoProizvoda.Text, tbUkunaCena.Text, tbIznosPDVa.Text);

                    praviListuArtikalaPDF listaArtikala = new praviListuArtikalaPDF();
                    listaArtikala.praviListuPDFFakture(dokument, tabelaProizvoda);

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
            Odabir frmOdabir = new Odabir();
            frmOdabir.Show();
        }

        private void btnStorniraj_Click(object sender, RoutedEventArgs e)
        {

            Faktura faktura = appBazaDataContext.Fakturas.Single(u => u.FakturaID == ((Faktura)gridProizvoda.SelectedValue).FakturaID);

            var Stavke = from a in appBazaDataContext.FakturaStavkas
                         where a.FakturaID == ((Faktura)gridProizvoda.SelectedValue).FakturaID
                         select a;

            foreach(FakturaStavka s in Stavke)
            {
                Artikal artikal = appBazaDataContext.Artikals.Single(u => u.SifraArtikla == s.SifraArtikla);

                artikal.Kolicina += s.KolicinaStavke;
                try
                {
                    appBazaDataContext.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Neuspešno brisanje fakture, molimo pokušajte ponovo. Greška: \n\n" + ex, "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            

            foreach (FakturaStavka s in Stavke)
            {
                appBazaDataContext.FakturaStavkas.DeleteOnSubmit(s);
                try
                {
                    appBazaDataContext.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Neuspešno brisanje fakture, molimo pokušajte ponovo. Greška: \n\n" + ex, "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            appBazaDataContext.Fakturas.DeleteOnSubmit(faktura);
            try
            {
                appBazaDataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Neuspešno brisanje fakture, molimo pokušajte ponovo. Greška: \n\n" + ex, "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            this.Hide();

            var Odabir = new Odabir();
            Odabir.Show();

        }
    }
}
