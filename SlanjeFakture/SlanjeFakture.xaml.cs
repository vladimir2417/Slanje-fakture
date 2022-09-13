using iTextSharp.text;
using iTextSharp.text.pdf;
using SlanjeFakture.LinqToSql;
using System.Linq;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace SlanjeFakture
{
    public partial class MainClass : Window
    {
        AppBazaDataContext appBazaDataContext = new AppBazaDataContext();
        DataTable tabelaProizvoda = new DataTable();
        public MainClass()
        {
            InitializeComponent();
            praviDataTable(tabelaProizvoda);
            dpDatum.SelectedDate = DateTime.Today;
        }

        public void resetujPolja()
        {
            tbNazivFirme.Clear();
            tbAdresaFirme.Clear();
            tbpostanskiBroj.Clear();
            tbPIB.Clear();
            tbMB.Clear();
            tbRacunBr.Clear();
            tbMestoIzdavanja.Clear();
            dpDatum.SelectedDate = null;
            dpRokPlacanja.SelectedDate = null;
            cbCestiKlijenti.Items.Clear();
            puniCombo();
        }

        public void resetujPoljaZaArtikle()
        {

        }


        //combobox cesti klijenti
        public void puniCombo()
        {

        }

        double ukupnoFaktura = 0;
        double ukupnoBezRabata = 0;
        double ukupnoRabat = 0;
        double ukupanPDV = 0;
        double poreskaOsnovicaPom = 0;

        public void puniDataTable(Artikal artikal, int kolicina, int rabat)
        {
            DataRow red = tabelaProizvoda.NewRow();

            double poreskaOsnovica = Math.Round((double)(kolicina * (artikal.OsnovicaPoJM - (artikal.OsnovicaPoJM * rabat / 100))), 2);

            double prodajnaCena = Math.Round(poreskaOsnovica * 1.2, 2);

            red["Rb"] = tabelaProizvoda.Rows.Count + 1;
            red["Šifra"] = artikal.SifraArtikla;
            red["Naziv dobra"] = artikal.NazivArtikla;
            red["JM"] = "KOM";
            red["Količina"] = kolicina;
            red["Cena po JM"] = artikal.OsnovicaPoJM;
            red["Rabat %"] = rabat;
            red["Poreska osnovica"] = poreskaOsnovica;
            red["PDV stopa"] = "20";
            red["PDV iznos"] = Math.Round(poreskaOsnovica * 0.2, 2);
            red["Ukupno"] = prodajnaCena;
            tabelaProizvoda.Rows.Add(red);
            //dodaljeivanje tabele u dataGridView
            gridProizvoda.ItemsSource = tabelaProizvoda.AsDataView();

            //izracunavanje ukupno sve i ukupno rabat

            ukupnoFaktura = ukupnoFaktura + prodajnaCena;
            ukupnoBezRabata = (double)(ukupnoBezRabata + artikal.OsnovicaPoJM * kolicina);
            ukupnoRabat = (double)(ukupnoRabat + (artikal.OsnovicaPoJM * rabat / 100) * kolicina);
            ukupanPDV = ukupanPDV + Math.Round(poreskaOsnovica * 0.2, 2);
            poreskaOsnovicaPom = poreskaOsnovicaPom + poreskaOsnovica;

            tbUkupnoSve.Text = ukupnoFaktura.ToString();
            tbIznosRabata.Text = ukupnoRabat.ToString();
            tbUkupanPDV.Text = ukupanPDV.ToString();
            tbUkupnoBezRabata.Text = ukupnoBezRabata.ToString();
            tbPoreskaOsnovica.Text = poreskaOsnovicaPom.ToString();
        }

        public void praviDataTable(DataTable tabelaProizvoda)
        {

            //pravljenje hedera u tabeli
            if (tabelaProizvoda.Columns.Count == 0)
            {
                tabelaProizvoda.Columns.Add("Rb");
                tabelaProizvoda.Columns.Add("Šifra");
                tabelaProizvoda.Columns.Add("Naziv dobra");
                tabelaProizvoda.Columns.Add("JM");
                tabelaProizvoda.Columns.Add("Količina");
                tabelaProizvoda.Columns.Add("Cena po JM");
                tabelaProizvoda.Columns.Add("Rabat %");
                tabelaProizvoda.Columns.Add("Poreska osnovica");
                tabelaProizvoda.Columns.Add("PDV stopa");
                tabelaProizvoda.Columns.Add("PDV iznos");
                tabelaProizvoda.Columns.Add("Ukupno");
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            puniCombo();
        }

        private void cbCestiKlijenti_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
        //END combobox cesti klijenti

        private void btnObrisiRed_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //brisanje redova iz tabele
                int indeks = gridProizvoda.SelectedIndex;
                if (indeks > -1)
                {
                    tabelaProizvoda.Rows.RemoveAt(indeks);

                    //vracanje rednog broja artikla
                    for (int i = indeks; i < tabelaProizvoda.Rows.Count; i++)
                    {
                        DataRow red = tabelaProizvoda.Rows[i];
                        red.SetField("Rb", i + 1);
                    }

                    //azuriranje ukupno sve i ukupno rabat
                    double ukupnoSve = 0;
                    double ukupnoRabat = 0;
                    double ukupanPDV = 0;
                    foreach (DataRow red in tabelaProizvoda.Rows)
                    {
                        ukupnoSve = ukupnoSve + Convert.ToDouble(red["Ukupno"]);
                        ukupnoRabat = ukupnoRabat + Convert.ToDouble(red["Ukupno"]) * Convert.ToDouble(red["Rabat %"]);
                        ukupanPDV = ukupanPDV + Convert.ToDouble(red["PDV iznos"]);
                    }
                    tbUkupnoSve.Text = ukupnoSve.ToString();
                    tbIznosRabata.Text = ukupnoRabat.ToString();
                    tbUkupanPDV.Text = ukupanPDV.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Nije moguće obrisati red.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnObrisiSve_Click(object sender, RoutedEventArgs e)
        {

            ukupnoFaktura = 0;
            ukupnoBezRabata = 0;
            ukupnoRabat = 0;
            ukupanPDV = 0;
            poreskaOsnovicaPom = 0;

            tabelaProizvoda.Clear();
            tbUkupnoSve.Clear();
            tbIznosRabata.Clear();
            tbUkupanPDV.Clear();
        }

        private void btnPosalji_Click(object sender, RoutedEventArgs e)
        {
            if (tbRacunBr.Text.Length > 0)
            {
                if (tabelaProizvoda.Rows.Count > 0)
                {
                    try
                    {
                        string nazivFirme = tbNazivFirme.Text;
                        string adresaFirme = tbAdresaFirme.Text;
                        string mejlFirme = tbMejlAdresa.Text;
                        string pib = tbPIB.Text;
                        string mb = tbMB.Text;
                        string postanskiBroj = tbpostanskiBroj.Text;

                        string racunBroj = tbRacunBr.Text;
                        string mestoIzdavanja = tbMestoIzdavanja.Text;
                        string rokPlacanja;
                        string datum;

                        string ukupnoSvePOM = tbUkupnoSve.Text;
                        string ukupnoRabatPOM = tbIznosRabata.Text;
                        string ukupanPDVPOM = tbUkupanPDV.Text;
                        string iznosBezRabataPOM = tbUkupnoBezRabata.Text;
                        string poreskaOsnovicaPOM = tbPoreskaOsnovica.Text;

                        //provera za datume
                        if (dpRokPlacanja.SelectedDate.HasValue)
                        {
                            rokPlacanja = dpRokPlacanja.SelectedDate.Value.ToString("dd.MM.yyy.", System.Globalization.CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            rokPlacanja = "- .";
                        }

                        if (dpDatum.SelectedDate.HasValue)
                        {
                            datum = dpDatum.SelectedDate.Value.ToString("dd.MM.yyy.", System.Globalization.CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            datum = "- .";
                        }

                        //PRAVLJENJE PDF-A //
                        try
                        {
                            Document dokument = new Document(PageSize.A4);

                            //putanja foldera gde se cuvaju fakture
                            string putanjaDoFoldera = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                            putanjaDoFoldera += @"\Fakture\";
                            if (!Directory.Exists(putanjaDoFoldera))
                            {
                                Directory.CreateDirectory(putanjaDoFoldera);
                            }
                            string putanjaFakture = putanjaDoFoldera + "interboss.sm_racun_br_" + racunBroj + ".pdf";

                            FileStream os = new FileStream(putanjaFakture, FileMode.Create);

                            using (os)
                            {
                                PdfWriter writer = PdfWriter.GetInstance(dokument, os);

                                dokument.Open();

                                //logo
                                string putanjaSlike = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Logo za fakturu\logoInterBoss.png";
                                iTextSharp.text.Image slika = iTextSharp.text.Image.GetInstance(putanjaSlike);
                                slika.Alignment = Element.ALIGN_LEFT;
                                slika.ScaleToFit(150, 100);
                                dokument.Add(slika);
                                //END logo

                                PodaciONama podaciONama = new PodaciONama();
                                podaciONama.praviPodatkeONama(dokument);

                                PodaciOFirmi podaciOFirmi = new PodaciOFirmi();
                                podaciOFirmi.praviPodatkeOFirmi(dokument, nazivFirme, adresaFirme, postanskiBroj, pib, mb);

                                PodaciOFakturi podaciOFakturi = new PodaciOFakturi();
                                podaciOFakturi.praviPodatkeOFakturi(dokument, racunBroj, mestoIzdavanja, datum, rokPlacanja);

                                ListaArtikala listaArtikala = new ListaArtikala();
                                listaArtikala.praviListuArtikala(dokument, tabelaProizvoda);

                                UkupnoIRabatSve ukupnoIRabatSve = new UkupnoIRabatSve();
                                ukupnoIRabatSve.praviUkupnoIRabatSve(dokument, ukupnoSvePOM);

                                Rekapitulacija rekapitulacija = new Rekapitulacija();
                                rekapitulacija.praviRekapitulaciju(dokument, ukupnoRabatPOM, iznosBezRabataPOM, ukupnoSvePOM, ukupanPDVPOM, poreskaOsnovicaPOM);

                                Footer footer = new Footer();
                                footer.OnEndPage(writer, dokument);
                                dokument.Close();
                            }
                            //END PRAVLJENJE PDF-A //

                            Faktura faktura = new Faktura();
                            faktura.NazivKupca = tbNazivFirme.Text;
                            faktura.Prodavnica = appBazaDataContext.Prodavnicas.Single(u => u.ProdavnicaID == 1);
                            faktura.RacunBroj = racunBroj;
                            faktura.MestoIzdavanjaRacuna = mestoIzdavanja;
                            faktura.DatumIzdavanjaRacuna = dpDatum.SelectedDate;
                            faktura.DatumPrometaDobara = dpDatum.SelectedDate;
                            faktura.RokPlacanja = dpRokPlacanja.SelectedDate;
                            faktura.IznosRabata = Convert.ToDouble(ukupnoRabatPOM);
                            faktura.IznosBezRabata = Convert.ToDouble(iznosBezRabataPOM);
                            faktura.Ukupno = Convert.ToDouble(ukupnoSvePOM);

                            appBazaDataContext.Fakturas.InsertOnSubmit(faktura);
                            try
                            {
                                appBazaDataContext.SubmitChanges();
                            }
                            catch
                            {
                                MessageBox.Show("neuspesno");
                            }

                            for (int i = 0; i < tabelaProizvoda.Rows.Count; i++) 
                            {
                                FakturaStavka fakturaStavka = new FakturaStavka();
                                fakturaStavka.Faktura = faktura;
                                fakturaStavka.Artikal = appBazaDataContext.Artikals.Single(u => u.SifraArtikla == tabelaProizvoda.Rows[i][1].ToString());
                                fakturaStavka.KolicinaStavke = Convert.ToInt32(tabelaProizvoda.Rows[i][4].ToString());
                                fakturaStavka.Rabat = Convert.ToDouble(tabelaProizvoda.Rows[i][6].ToString());
                                fakturaStavka.PoreskaOsnovica = Convert.ToDouble(tabelaProizvoda.Rows[i][7].ToString());
                                fakturaStavka.PDVStopa = Convert.ToDouble(tabelaProizvoda.Rows[i][8].ToString());
                                fakturaStavka.PDVIznos = Convert.ToDouble(tabelaProizvoda.Rows[i][9].ToString());
                                fakturaStavka.Ukupno = Convert.ToDouble(tabelaProizvoda.Rows[i][10].ToString());

                                Artikal artikal = appBazaDataContext.Artikals.Single(u => u.SifraArtikla == tabelaProizvoda.Rows[i][1].ToString());
                                artikal.Kolicina -= fakturaStavka.KolicinaStavke;
                                appBazaDataContext.FakturaStavkas.InsertOnSubmit(fakturaStavka);

                                try
                                {
                                    appBazaDataContext.SubmitChanges();
                                }
                                catch
                                {
                                    MessageBox.Show("neuspesno");
                                }
                            }

                            SlanjeMejla slanjeMejla = new SlanjeMejla();
                            slanjeMejla.saljiMejl(mejlFirme, racunBroj, putanjaFakture);

                            resetujPolja();
                            ukupnoFaktura = 0;
                            ukupnoBezRabata = 0;
                            ukupnoRabat = 0;
                            ukupanPDV = 0;
                            poreskaOsnovicaPom = 0;

                            tabelaProizvoda.Clear();
                            tbUkupnoSve.Clear();
                            tbUkupanPDV.Clear();
                            tbIznosRabata.Clear();
                            tbUkupnoBezRabata.Clear();
                            tbPoreskaOsnovica.Clear();

                            //otvaranje nakon cuvanja
                            Process.Start(putanjaFakture);
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Neuspešno slanje mejla, molimo pokušajte ponovo. Greška: \n\n" + ex, "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Polja nisu u dobrom formatu.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Unesite artikle.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Unesite broj računa.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
        private void btnResetujPolja_Click(object sender, RoutedEventArgs e)
        {
            resetujPoljaZaArtikle();
            resetujPolja();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Odabir frmOdabir = new Odabir();
            frmOdabir.Show();
        }


        private void lbArtikli_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnUnesiArtikal_Click(object sender, RoutedEventArgs e)
        {
            UnesiArtikalNaFakturu frmUnesiArtikalNaFakturu = new UnesiArtikalNaFakturu(this);
            frmUnesiArtikalNaFakturu.Show();
        }

        private void btnStampaj_Click_1(object sender, RoutedEventArgs e)
        {
            if (tbRacunBr.Text.Length > 0)
            {
                if (tabelaProizvoda.Rows.Count > 0)
                {
                    try
                    {
                        string nazivFirme = tbNazivFirme.Text;
                        string adresaFirme = tbAdresaFirme.Text;
                        string mejlFirme = tbMejlAdresa.Text;
                        string pib = tbPIB.Text;
                        string mb = tbMB.Text;
                        string postanskiBroj = tbpostanskiBroj.Text;

                        string racunBroj = tbRacunBr.Text;
                        string mestoIzdavanja = tbMestoIzdavanja.Text;
                        string rokPlacanja;
                        string datum;

                        string ukupnoSvePOM = tbUkupnoSve.Text;
                        string ukupnoRabatPOM = tbIznosRabata.Text;
                        string ukupanPDVPOM = tbUkupanPDV.Text;
                        string iznosBezRabataPOM = tbUkupnoBezRabata.Text;
                        string poreskaOsnovicaPOM = tbPoreskaOsnovica.Text;

                        //provera za datume
                        if (dpRokPlacanja.SelectedDate.HasValue)
                        {
                            rokPlacanja = dpRokPlacanja.SelectedDate.Value.ToString("dd.MM.yyy.", System.Globalization.CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            rokPlacanja = "- .";
                        }

                        if (dpDatum.SelectedDate.HasValue)
                        {
                            datum = dpDatum.SelectedDate.Value.ToString("dd.MM.yyy.", System.Globalization.CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            datum = "- .";
                        }

                        //PRAVLJENJE PDF-A //
                        try
                        {
                            Document dokument = new Document(PageSize.A4);

                            //putanja foldera gde se cuvaju fakture
                            string putanjaDoFoldera = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                            putanjaDoFoldera += @"\Fakture\";
                            if (!Directory.Exists(putanjaDoFoldera))
                            {
                                Directory.CreateDirectory(putanjaDoFoldera);
                            }
                            string putanjaFakture = putanjaDoFoldera + "interboss.sm_racun_br_" + racunBroj + ".pdf";

                            FileStream os = new FileStream(putanjaFakture, FileMode.Create);

                            using (os)
                            {
                                PdfWriter writer = PdfWriter.GetInstance(dokument, os);

                                dokument.Open();

                                //logo
                                string putanjaSlike = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Logo za fakturu\logoInterBoss.png";
                                iTextSharp.text.Image slika = iTextSharp.text.Image.GetInstance(putanjaSlike);
                                slika.Alignment = Element.ALIGN_LEFT;
                                slika.ScaleToFit(150, 100);
                                dokument.Add(slika);
                                //END logo

                                PodaciONama podaciONama = new PodaciONama();
                                podaciONama.praviPodatkeONama(dokument);

                                PodaciOFirmi podaciOFirmi = new PodaciOFirmi();
                                podaciOFirmi.praviPodatkeOFirmi(dokument, nazivFirme, adresaFirme, postanskiBroj, pib, mb);

                                PodaciOFakturi podaciOFakturi = new PodaciOFakturi();
                                podaciOFakturi.praviPodatkeOFakturi(dokument, racunBroj, mestoIzdavanja, datum, rokPlacanja);

                                ListaArtikala listaArtikala = new ListaArtikala();
                                listaArtikala.praviListuArtikala(dokument, tabelaProizvoda);

                                UkupnoIRabatSve ukupnoIRabatSve = new UkupnoIRabatSve();
                                ukupnoIRabatSve.praviUkupnoIRabatSve(dokument, ukupnoSvePOM);

                                Rekapitulacija rekapitulacija = new Rekapitulacija();
                                rekapitulacija.praviRekapitulaciju(dokument, ukupnoRabatPOM, iznosBezRabataPOM, ukupnoSvePOM, ukupanPDVPOM, poreskaOsnovicaPOM);

                                Footer footer = new Footer();
                                footer.OnEndPage(writer, dokument);
                                dokument.Close();
                            }
                            //END PRAVLJENJE PDF-A //

                            Faktura faktura = new Faktura();
                            faktura.NazivKupca = tbNazivFirme.Text;
                            faktura.Prodavnica = appBazaDataContext.Prodavnicas.Single(u => u.ProdavnicaID == 1);
                            faktura.RacunBroj = racunBroj;
                            faktura.MestoIzdavanjaRacuna = mestoIzdavanja;
                            faktura.DatumIzdavanjaRacuna = dpDatum.SelectedDate;
                            faktura.DatumPrometaDobara = dpDatum.SelectedDate;
                            faktura.RokPlacanja = dpRokPlacanja.SelectedDate;
                            faktura.IznosRabata = Convert.ToDouble(ukupnoRabatPOM);
                            faktura.IznosBezRabata = Convert.ToDouble(iznosBezRabataPOM);
                            faktura.Ukupno = Convert.ToDouble(ukupnoSvePOM);

                            appBazaDataContext.Fakturas.InsertOnSubmit(faktura);
                            try
                            {
                                appBazaDataContext.SubmitChanges();
                            }
                            catch
                            {
                                MessageBox.Show("neuspesno");
                            }

                            for (int i = 0; i < tabelaProizvoda.Rows.Count; i++)
                            {
                                FakturaStavka fakturaStavka = new FakturaStavka();
                                fakturaStavka.Faktura = faktura;
                                fakturaStavka.Artikal = appBazaDataContext.Artikals.Single(u => u.SifraArtikla == tabelaProizvoda.Rows[i][1].ToString());
                                fakturaStavka.KolicinaStavke = Convert.ToInt32(tabelaProizvoda.Rows[i][4].ToString());
                                fakturaStavka.Rabat = Convert.ToDouble(tabelaProizvoda.Rows[i][6].ToString());
                                fakturaStavka.PoreskaOsnovica = Convert.ToDouble(tabelaProizvoda.Rows[i][7].ToString());
                                fakturaStavka.PDVStopa = Convert.ToDouble(tabelaProizvoda.Rows[i][8].ToString());
                                fakturaStavka.PDVIznos = Convert.ToDouble(tabelaProizvoda.Rows[i][9].ToString());
                                fakturaStavka.Ukupno = Convert.ToDouble(tabelaProizvoda.Rows[i][10].ToString());

                                Artikal artikal = appBazaDataContext.Artikals.Single(u => u.SifraArtikla == tabelaProizvoda.Rows[i][1].ToString());
                                artikal.Kolicina -= fakturaStavka.KolicinaStavke;
                                appBazaDataContext.FakturaStavkas.InsertOnSubmit(fakturaStavka);

                                try
                                {
                                    appBazaDataContext.SubmitChanges();
                                }
                                catch
                                {
                                    MessageBox.Show("neuspesno");
                                }
                            }


                            resetujPolja();

                            ukupnoFaktura = 0;
                            ukupnoBezRabata = 0;
                            ukupnoRabat = 0;
                            ukupanPDV = 0;
                            poreskaOsnovicaPom = 0;

                            tabelaProizvoda.Clear();
                            tbUkupnoSve.Clear();
                            tbUkupanPDV.Clear();
                            tbIznosRabata.Clear();
                            tbUkupnoBezRabata.Clear();
                            tbPoreskaOsnovica.Clear();

                            //otvaranje nakon cuvanja
                            Process.Start(putanjaFakture);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Neuspešno štampanje fakture, molimo pokušajte ponovo. Greška: \n\n" + ex, "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Polja nisu u dobrom formatu.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Unesite artikle.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Unesite broj računa.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}