using SlanjeFakture.LinqToSql;
using System;
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
    public partial class Kalkulacije : Window
    {
        DataTable tabelaProizvoda = new DataTable();
        AppBazaDataContext appBazaDataContext = new AppBazaDataContext();
        public Kalkulacije()
        {
            InitializeComponent();
            puniDobavljace();
            tbBrojKalkulacije.Text = (appBazaDataContext.Kalkulacijas.OrderByDescending(o => o.BrojKalkulacije).FirstOrDefault().BrojKalkulacije + 1).ToString();
            //tbBrojKalkulacije.Text = "32";
            praviDataTable(tabelaProizvoda);
        }

        private void puniDobavljace()
        {
            var dobavljaci = (from o in appBazaDataContext.Dobavljacs
                              select o);

            cbDobavljaci.ItemsSource = dobavljaci;
        }

        public void puniDataTable(Artikal artikal, string sifra, string nazivDobra, double nabavnaCenaINO, double nabavnaCenaRSD, int kolicina, double prodajnaCena, double zarada, double marza, double PDVPoJM, double trosakPoArtiklu)
        {
            DataRow red = tabelaProizvoda.NewRow();

            double ukupniTroskoviSvih = Convert.ToDouble(tbOdGranice.Text);
            //double trosakPoArtiklu = Convert.ToDouble(tbTrosakPoArtiklu.Text);
            double ukupniTroskoviPoArtiklu = trosakPoArtiklu * kolicina;

            red["Šifra"] = sifra;
            red["Naziv artikla"] = nazivDobra;
            red["Nabavna cena (INO)"] = nabavnaCenaINO;
            red["Nabavna cena (RSD)"] = nabavnaCenaRSD;
            red["Količina"] = kolicina;
            red["Vrednost (RSD)"] = nabavnaCenaRSD * kolicina;
            red["Marža"] = marza;
            red["Troškovi ukupno"] = trosakPoArtiklu * kolicina;
            red["Troškovi po JM"] = trosakPoArtiklu;
            red["Bruto vrednost ukupno"] = Math.Round((nabavnaCenaRSD * kolicina) + ukupniTroskoviPoArtiklu, 4);
            red["Bruto cena po JM"] = Math.Round(nabavnaCenaRSD + trosakPoArtiklu, 4);
            red["RUC po JM"] = zarada;
            red["Osnovica po JM"] = Math.Round(prodajnaCena - PDVPoJM, 4);
            red["PDV stopa"] = 20;
            red["Iznos PDV po JM"] = PDVPoJM;
            red["Prodajna cena"] = prodajnaCena;
            red["Osnovica ukupno"] = Math.Round((prodajnaCena - PDVPoJM) * kolicina, 4);
            red["PDV iznos ukupno"] = Math.Round(PDVPoJM * kolicina, 4);
            red["Prodajna vrednost ukupno"] = Math.Round(prodajnaCena * kolicina, 4);
            red["RUC ukupno"] = Math.Round(zarada * kolicina, 4);

            tabelaProizvoda.Rows.Add(red);

            gridProizvoda.ItemsSource = tabelaProizvoda.AsDataView();
        }

        public void praviDataTable(DataTable tabelaProizvoda)
        {
            //pravljenje hedera u tabeli
            if (tabelaProizvoda.Columns.Count == 0)
            {
                tabelaProizvoda.Columns.Add("Šifra");
                tabelaProizvoda.Columns.Add("Naziv artikla");
                tabelaProizvoda.Columns.Add("Nabavna cena (INO)");
                tabelaProizvoda.Columns.Add("Nabavna cena (RSD)");
                tabelaProizvoda.Columns.Add("Količina");
                tabelaProizvoda.Columns.Add("Vrednost (RSD)");
                tabelaProizvoda.Columns.Add("Troškovi ukupno");
                tabelaProizvoda.Columns.Add("Troškovi po JM");
                tabelaProizvoda.Columns.Add("Bruto vrednost ukupno");
                tabelaProizvoda.Columns.Add("Bruto cena po JM");
                tabelaProizvoda.Columns.Add("Marža");
                tabelaProizvoda.Columns.Add("RUC po JM");
                tabelaProizvoda.Columns.Add("Osnovica po JM");
                tabelaProizvoda.Columns.Add("PDV stopa");
                tabelaProizvoda.Columns.Add("Iznos PDV po JM");
                tabelaProizvoda.Columns.Add("Prodajna cena");
                tabelaProizvoda.Columns.Add("Osnovica ukupno");
                tabelaProizvoda.Columns.Add("PDV iznos ukupno");
                tabelaProizvoda.Columns.Add("Prodajna vrednost ukupno");
                tabelaProizvoda.Columns.Add("RUC ukupno");
            }
        }



        private void btnUnesiArtikal_Click(object sender, RoutedEventArgs e)
        {
            if (cbDobavljaci.SelectedValue != null && dpDatumPrijemaRobe.SelectedDate.HasValue == true && tbBrojDokumenta.Text.Length > 0 && tbKursSrednji.Text.Length > 0 && tbTrosakPoArtiklu.Text.Length > 0)
            {
                DodajArtikalUKalkulaciju frmDodajArtikalUKalkulaciju = new DodajArtikalUKalkulaciju(this);
                frmDodajArtikalUKalkulaciju.tbKurs.Text = tbKursSrednji.Text;
                frmDodajArtikalUKalkulaciju.tbTrosakPoArtiklu.Text = tbTrosakPoArtiklu.Text;

                frmDodajArtikalUKalkulaciju.Show();
            }
            else
            {
                MessageBox.Show("Obavezna polja su: Dobavljač, Datum, Broj dokumenta i troškovi", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            int br = 0;
            foreach (DataRow red in tabelaProizvoda.Rows)
            {
                Artikal artikalProvera = (from a in appBazaDataContext.Artikals
                                          where a.SifraArtikla == red["Šifra"].ToString()
                                          select a).FirstOrDefault();

                if (artikalProvera != null)
                {
                    try
                    {
                        Kalkulacija kalkulacija = new Kalkulacija();
                        kalkulacija.SifraArtikla = artikalProvera.SifraArtikla;
                        kalkulacija.NazivArtikla = artikalProvera.NazivArtikla;
                        kalkulacija.NabavnaCenaINO = Convert.ToDouble(red["Nabavna cena (INO)"]);
                        kalkulacija.NabavnaCenaRSD = Convert.ToDouble(red["Nabavna cena (RSD)"]);
                        kalkulacija.Kolicina = Convert.ToInt32(red["Količina"]);
                        kalkulacija.Vrednost = Convert.ToDouble(red["Vrednost (RSD)"]);
                        kalkulacija.UkupniTroskovi = Convert.ToDouble(red["Troškovi ukupno"]);
                        kalkulacija.TroskoviPoJM = Convert.ToDouble(red["Troškovi po JM"]);
                        kalkulacija.BrutoVrednostUkupno = Convert.ToDouble(red["Bruto vrednost ukupno"]);
                        kalkulacija.BrutoVrednostPoJM = Convert.ToDouble(red["Bruto cena po JM"]);
                        kalkulacija.Marza = Convert.ToDouble(red["Marža"]);
                        kalkulacija.RUC = Convert.ToDouble(red["RUC po JM"]);
                        kalkulacija.OsnovicaPoJM = Convert.ToDouble(red["Osnovica po JM"]);
                        kalkulacija.PDVStopa = Convert.ToInt32(red["PDV stopa"]);
                        kalkulacija.IznosPDVpoJM = Convert.ToDouble(red["Iznos PDV po JM"]);
                        kalkulacija.ProdajnaCena = Convert.ToDouble(red["Prodajna cena"]);
                        kalkulacija.OsnovicaUkupno = Convert.ToDouble(red["Osnovica ukupno"]);
                        kalkulacija.IznosPDVUkupno = Convert.ToDouble(red["PDV iznos ukupno"]);
                        kalkulacija.ProdajnaVrednostUkupno = Convert.ToDouble(red["Prodajna vrednost ukupno"]);
                        kalkulacija.RUCUkupno = Convert.ToDouble(red["RUC ukupno"]);
                        kalkulacija.DatumKalkulacije = dpDatumPrijemaRobe.SelectedDate.Value.Date;
                        kalkulacija.BrojKalkulacije = Convert.ToInt32(tbBrojKalkulacije.Text);
                        kalkulacija.Kurs = Convert.ToDouble(tbKursSrednji.Text);
                        kalkulacija.BrojDokumenta = tbBrojDokumenta.Text;
                        kalkulacija.DobavljacID = ((Dobavljac)cbDobavljaci.SelectedValue).DobavljacID;

                        artikalProvera.NabavnaCenaINO = Convert.ToDouble(red["Nabavna cena (INO)"]);
                        artikalProvera.NabavnaCenaRSD = Convert.ToDouble(red["Nabavna cena (RSD)"]);
                        artikalProvera.Kolicina += Convert.ToInt32(red["Količina"]);
                        artikalProvera.Marza = Convert.ToDouble(red["Marža"]);
                        artikalProvera.RUC = Convert.ToDouble(red["RUC po JM"]);
                        artikalProvera.OsnovicaPoJM = Convert.ToDouble(red["Osnovica po JM"]);
                        artikalProvera.PDVStopa = Convert.ToInt32(red["PDV stopa"]);
                        artikalProvera.IznosPDVPoJM = Convert.ToDouble(red["Iznos PDV po JM"]);
                        artikalProvera.ProdajnaCena = Convert.ToDouble(red["Prodajna cena"]);

                        appBazaDataContext.Kalkulacijas.InsertOnSubmit(kalkulacija);
                        appBazaDataContext.SubmitChanges();
                        br++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Neuspešna konekcija sa bazom, pokušajte ponovo. Opis greške: \n\n" + ex, "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("Greška. Ne postoji proizvod sa šifrom: " + red["Šifra"].ToString(), "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

            if (br > 0)
            {
                MessageBox.Show("Uspešno uneta kalkulacija", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Hide();
                Magacin frmMagacin = new Magacin();
                frmMagacin.Show();

            }
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Odabir frmOdabir = new Odabir();
            frmOdabir.Show();
        }

        private void tbKolicinaArtikalaUKal_KeyUp(object sender, KeyEventArgs e)
        {
            double ukupniTroskovi = 0;
            int kolicinaArtikala = 0;
            double trosakPoArtiklu = 0;

            if (tbOdGranice.Text.Length > 0)
            {
                ukupniTroskovi = Convert.ToDouble(tbOdGranice.Text);
            }
            else
            {
                ukupniTroskovi = 0;
            }

            if (tbKolicinaArtikalaUKal.Text.Length > 0)
            {
                kolicinaArtikala = Convert.ToInt32(tbKolicinaArtikalaUKal.Text);
            }
            else
            {
                kolicinaArtikala = 0;
            }

            trosakPoArtiklu = Math.Round((ukupniTroskovi / kolicinaArtikala), 2);
            tbTrosakPoArtiklu.Text = trosakPoArtiklu.ToString();
        }

        private void tbOdGranice_KeyUp(object sender, KeyEventArgs e)
        {
            double ukupniTroskovi = 0;
            int kolicinaArtikala = 0;
            double trosakPoArtiklu = 0;

            if (tbOdGranice.Text.Length > 0)
            {
                ukupniTroskovi = Convert.ToDouble(tbOdGranice.Text);
            }
            else
            {
                ukupniTroskovi = 0;
            }

            if (tbKolicinaArtikalaUKal.Text.Length > 0)
            {
                kolicinaArtikala = Convert.ToInt32(tbKolicinaArtikalaUKal.Text);
            }
            else
            {
                kolicinaArtikala = 0;
            }

            trosakPoArtiklu = Math.Round((ukupniTroskovi / kolicinaArtikala), 2);
            tbTrosakPoArtiklu.Text = trosakPoArtiklu.ToString();
        }
        private void btnObrisiRed_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int indeks = gridProizvoda.SelectedIndex;
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
