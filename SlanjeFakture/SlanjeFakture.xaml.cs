using iTextSharp.text;
using iTextSharp.text.pdf;
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
        public MainClass()
        {
            InitializeComponent();
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
            tbSifra.Clear();
            tbNazivDobra.Clear();
            tbKolicina.Clear();
            tbCenaPoJM.Clear();
            tbRabat.Clear();
        }

        //combobox cesti klijenti
        public void puniCombo()
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            puniCombo();
        }

        private void cbCestiKlijenti_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
        //END combobox cesti klijenti

        //tabela za proizvode
        DataTable tabelaProizvoda = new DataTable();

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int rb = tabelaProizvoda.Rows.Count + 1;
                string sifra = tbSifra.Text;
                string nazivDobra = tbNazivDobra.Text;
                string JM = "KOM";
                int kolicina = Convert.ToInt32(tbKolicina.Text);
                double cenaPoJM = Convert.ToDouble(tbCenaPoJM.Text);
                double rabat = Convert.ToDouble(tbRabat.Text);
                double poreskaOsnovica = (kolicina * cenaPoJM) - ((kolicina * cenaPoJM) * rabat / 100);
                double PDVStopa = 0;
                double PDVIznos = poreskaOsnovica * PDVStopa / 100;
                double ukupno = poreskaOsnovica + PDVIznos;

                if (rabat >= 0 && rabat <= 100)
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

                    //popunjavanje redova tabele na klik DODAJ
                    DataRow red = tabelaProizvoda.NewRow();
                    red["Rb"] = rb;
                    red["Šifra"] = sifra;
                    red["Naziv dobra"] = nazivDobra;
                    red["JM"] = JM;
                    red["Količina"] = kolicina;
                    red["Cena po JM"] = cenaPoJM;
                    red["Rabat %"] = rabat;
                    red["Poreska osnovica"] = poreskaOsnovica;
                    red["PDV stopa"] = PDVStopa;
                    red["PDV iznos"] = PDVIznos;
                    red["Ukupno"] = ukupno;
                    tabelaProizvoda.Rows.Add(red);

                    resetujPoljaZaArtikle();

                    //dodaljeivanje tabele u dataGridView
                    gridProizvoda.ItemsSource = tabelaProizvoda.AsDataView();

                    //izracunavanje ukupno sve i ukupno rabat
                    double ukupnoSve = 0;
                    double ukupnoRabat = 0;
                    foreach (DataRow redJedan in tabelaProizvoda.Rows)
                    {
                        ukupnoSve = ukupnoSve + Convert.ToDouble(redJedan["Ukupno"]);
                        ukupnoRabat = ukupnoRabat + (((Convert.ToDouble(redJedan["Cena po JM"])) * (Convert.ToDouble(redJedan["Količina"]))) - (Convert.ToDouble(redJedan["Poreska osnovica"])));
                    }
                    tbUkupnoSve.Text = ukupnoSve.ToString();
                    tbIznosRabata.Text = ukupnoRabat.ToString();
                }
                else
                {
                    MessageBox.Show("Rabat mora biti između 0 - 100%.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Pogrešan format.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

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
                    foreach (DataRow red in tabelaProizvoda.Rows)
                    {
                        ukupnoSve = ukupnoSve + Convert.ToDouble(red["Ukupno"]);
                        ukupnoRabat = ukupnoRabat + (((Convert.ToDouble(red["Cena po JM"])) * (Convert.ToDouble(red["Količina"]))) - (Convert.ToDouble(red["Poreska osnovica"])));
                    }
                    tbUkupnoSve.Text = ukupnoSve.ToString();
                    tbIznosRabata.Text = ukupnoRabat.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Nije moguće obrisati red.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnObrisiSve_Click(object sender, RoutedEventArgs e)
        {
            tabelaProizvoda.Clear();
            tbUkupnoSve.Clear();
            tbIznosRabata.Clear();
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

                        string ukupnoSve = tbUkupnoSve.Text;
                        string ukupnoRabat = tbIznosRabata.Text;
                        double iznosBezRabata = Convert.ToDouble(ukupnoSve) + Convert.ToDouble(ukupnoRabat);

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
                            string putanjaFakture = putanjaDoFoldera + "sudoper_racun_br_" + racunBroj + ".pdf";

                            FileStream os = new FileStream(putanjaFakture, FileMode.Create);

                            using (os)
                            {
                                PdfWriter writer = PdfWriter.GetInstance(dokument, os);

                                dokument.Open();

                                //logo
                                string putanjaSlike = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +@"\Logo za fakturu\logo.png";
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
                                ukupnoIRabatSve.praviUkupnoIRabatSve(dokument, ukupnoSve);

                                Rekapitulacija rekapitulacija = new Rekapitulacija();
                                rekapitulacija.praviRekapitulaciju(dokument, ukupnoRabat, iznosBezRabata, ukupnoSve);

                                Footer footer = new Footer();
                                footer.OnEndPage(writer, dokument);
                                dokument.Close();
                            }
                            //END PRAVLJENJE PDF-A //

                            SlanjeMejla slanjeMejla = new SlanjeMejla();
                            slanjeMejla.saljiMejl(mejlFirme, racunBroj, putanjaFakture);

                            resetujPolja();
                            tabelaProizvoda.Clear();
                            tbUkupnoSve.Clear();
                            tbIznosRabata.Clear();

                            //otvaranje nakon cuvanja
                            Process.Start(putanjaFakture);
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Neuspešno slanje mejla, molimo pokušajte ponovo. Greška: \n" + ex, "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Error);
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
            Application.Current.Shutdown();
        }

    }
}