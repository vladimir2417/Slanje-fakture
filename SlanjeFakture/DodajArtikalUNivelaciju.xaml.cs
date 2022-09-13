using SlanjeFakture.LinqToSql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for DodajArtikalUNivelaciju.xaml
    /// </summary>
    public partial class DodajArtikalUNivelaciju : Window
    {
        AppBazaDataContext appBazaDataContext = new AppBazaDataContext();
        DataTable tabelaProizvoda = new DataTable();
        Nivelacija frmNivelacija;
        public DodajArtikalUNivelaciju(Nivelacija frmNive)
        {
            InitializeComponent();
            puniListBox();
            praviDataTable(tabelaProizvoda);
            this.frmNivelacija = frmNive;
        }

        public void puniListBox()
        {
            var artikliListBox = (from a in appBazaDataContext.Artikals
                                  select a).ToList();
            lbArtikli.ItemsSource = artikliListBox;
        }

        public void puniDataTable(Artikal artikal)
        {
            Boolean postojiArtikal = false;

            foreach (DataRow dtRow in tabelaProizvoda.Rows)
            {
                if (dtRow["Šifra"].ToString().Equals(artikal.SifraArtikla))
                {
                    postojiArtikal = true;
                }
            }
            if (postojiArtikal == false)
            {
                DataRow red = tabelaProizvoda.NewRow();

                red["Šifra"] = artikal.SifraArtikla;
                red["Naziv"] = artikal.NazivArtikla;
                red["Osnovica"] = artikal.OsnovicaPoJM;
                red["Iznos PDV"] = artikal.IznosPDVPoJM;
                red["Prodajna cena"] = artikal.ProdajnaCena;
                red["RUC"] = artikal.RUC;
                red["Marža"] = artikal.Marza;
                red["Količina"] = artikal.Kolicina;

                tabelaProizvoda.Rows.Add(red);
                gridProizvodaMagacin.ItemsSource = tabelaProizvoda.AsDataView();
            }
            else
            {
                MessageBox.Show("Artikal već dodat.", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void praviDataTable(DataTable tabelaProizvoda)
        {
            //pravljenje hedera u tabeli
            if (tabelaProizvoda.Columns.Count == 0)
            {
                tabelaProizvoda.Columns.Add("Šifra");
                tabelaProizvoda.Columns.Add("Naziv");
                tabelaProizvoda.Columns.Add("Osnovica");
                tabelaProizvoda.Columns.Add("Iznos PDV");
                tabelaProizvoda.Columns.Add("Prodajna cena");
                tabelaProizvoda.Columns.Add("RUC");
                tabelaProizvoda.Columns.Add("Marža");
                tabelaProizvoda.Columns.Add("Količina");
            }
        }

        private void lbArtikli_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Artikal artikal = lbArtikli.SelectedItem as Artikal;
            puniDataTable(artikal);
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void btnUnesi_Click(object sender, RoutedEventArgs e)
        {
            double unesiCenu = 0;
            if (tbUnesiCenu.Text.Length > 0)
            {
                unesiCenu = Convert.ToDouble(tbUnesiCenu.Text);
                if(rbPovecajCenu.IsChecked == false && rbUmanjiCenu.IsChecked == false && rbDodajZaradu.IsChecked == false)
                {
                    MessageBox.Show("Odaberite jednu od 3 opcije.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    foreach (DataRow dataRowPom in tabelaProizvoda.Rows)
                    {
                        Artikal artikal = appBazaDataContext.Artikals.Single(u => u.SifraArtikla.Equals(dataRowPom["Šifra"].ToString()));

                        double prodajnaCena = (double)artikal.ProdajnaCena;
                        double osnovicaPoJM = (double)artikal.OsnovicaPoJM;
                        double RUC = (double)artikal.RUC;
                        double marza = (double)artikal.Marza;
                        double iznosPDVPoJM = (double)artikal.IznosPDVPoJM;

                        double procenatPovecanja;
                        double prodajnaCenaNew;
                        double osnovicaPoJMNew;
                        double RUCNew;
                        double marzaNew;
                        double iznosPDVPoJMNew;
                        if (rbPovecajCenu.IsChecked == true)
                        {
                            prodajnaCenaNew = prodajnaCena + unesiCenu;
                            procenatPovecanja = prodajnaCenaNew / prodajnaCena;

                            osnovicaPoJMNew = Math.Round(osnovicaPoJM * procenatPovecanja, 2);
                            RUCNew = Math.Round(RUC * procenatPovecanja, 2);
                            marzaNew = Math.Round(marza * procenatPovecanja, 2);
                            iznosPDVPoJMNew = Math.Round(iznosPDVPoJM * procenatPovecanja, 2);

                            dataRowPom["Osnovica"] = osnovicaPoJMNew;
                            dataRowPom["Iznos PDV"] = iznosPDVPoJMNew;
                            dataRowPom["Prodajna cena"] = prodajnaCenaNew;
                            dataRowPom["RUC"] = RUCNew;
                            dataRowPom["Marža"] = marzaNew;
                        }
                        else if (rbUmanjiCenu.IsChecked == true)
                        {
                            prodajnaCenaNew = prodajnaCena - unesiCenu;
                            procenatPovecanja = prodajnaCenaNew / prodajnaCena;

                            osnovicaPoJMNew = Math.Round(osnovicaPoJM * procenatPovecanja, 2);
                            RUCNew = Math.Round(RUC * procenatPovecanja, 2);
                            marzaNew = Math.Round(marza * procenatPovecanja, 2);
                            iznosPDVPoJMNew = Math.Round(iznosPDVPoJM * procenatPovecanja, 2);

                            dataRowPom["Osnovica"] = osnovicaPoJMNew;
                            dataRowPom["Iznos PDV"] = iznosPDVPoJMNew;
                            dataRowPom["Prodajna cena"] = prodajnaCenaNew;
                            dataRowPom["RUC"] = RUCNew;
                            dataRowPom["Marža"] = marzaNew;
                        }
                        else if (rbDodajZaradu.IsChecked == true)
                        {
                            List<Kalkulacija> kalkulacija = (from a in appBazaDataContext.Kalkulacijas
                                                        where a.SifraArtikla.Equals(dataRowPom["Šifra"].ToString())
                                                        select a).ToList();
        
                            prodajnaCenaNew = Math.Round((double)((artikal.NabavnaCenaRSD + kalkulacija.Last().TroskoviPoJM + unesiCenu) * 1.20), 2);

                            RUCNew = unesiCenu;
                            marzaNew = Math.Round(unesiCenu / prodajnaCenaNew * 100, 2);
                            iznosPDVPoJMNew = Math.Round(prodajnaCenaNew * 0.2, 2);
                            osnovicaPoJMNew = Math.Round(prodajnaCenaNew - iznosPDVPoJM, 2);

                            dataRowPom["Osnovica"] = osnovicaPoJMNew;
                            dataRowPom["Iznos PDV"] = iznosPDVPoJMNew;
                            dataRowPom["Prodajna cena"] = prodajnaCenaNew;
                            dataRowPom["RUC"] = RUCNew;
                            dataRowPom["Marža"] = marzaNew;
                        }

                    }
                    List<string> sifreArtikla = frmNivelacija.proveriStanje(tabelaProizvoda);
                    if (sifreArtikla.Count < 1)
                    {
                        this.Hide();
                        frmNivelacija.puniDataTable(tabelaProizvoda);
                    }
                    else
                    {
                        MessageBox.Show("Postoji nivelacija za artikle sa šifrom: " + string.Join("  ", sifreArtikla), "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Unesite cenu.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void tbPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbPretraga.Text != "")
            {
                string pretragaParam = tbPretraga.Text;

                var Artikal = from a in appBazaDataContext.Artikals
                              where a.NazivArtikla.Contains(pretragaParam) || Convert.ToInt32(a.ProdajnaCena).ToString().Contains(pretragaParam) || a.SifraArtikla.ToString().Contains(pretragaParam)
                              select a;

                if (Artikal.Count() == 0)
                {
                    lbArtikli.ItemsSource = null;
                }
                else
                {
                    lbArtikli.ItemsSource = Artikal;
                }
            }
            else
            {
                puniListBox();
            }
        }

        private void btnObrisiRed_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int indeks = gridProizvodaMagacin.SelectedIndex;
                if (indeks > -1)
                {
                    tabelaProizvoda.Rows.RemoveAt(indeks);
                }
            }
            catch
            {
                MessageBox.Show("Nije moguće obrisati red.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
