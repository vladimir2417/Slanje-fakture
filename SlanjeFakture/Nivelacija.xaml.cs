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
    /// <summary>
    /// Interaction logic for Nivelacija.xaml
    /// </summary>
    public partial class Nivelacija : Window
    {
        AppBazaDataContext appBazaDataContext = new AppBazaDataContext();
        DataTable tabelaProizvodaNivelacija = new DataTable();

        public Nivelacija()
        {
            InitializeComponent();
            praviDataTable(tabelaProizvodaNivelacija);
            tbBrojNivelacije.Text = (appBazaDataContext.Nivelacijes.OrderByDescending(o => o.BrojNivelacije).FirstOrDefault().BrojNivelacije + 1).ToString();
        }

        public void puniDataTable(DataTable tabelaProizvoda)
        {
            foreach (DataRow dataRowPom in tabelaProizvoda.Rows)
            {
                DataRow red = tabelaProizvodaNivelacija.NewRow();
                Artikal artikal = appBazaDataContext.Artikals.Single(u => u.SifraArtikla.Equals(dataRowPom["Šifra"].ToString()));
                double nivelacija = (double)(Convert.ToDouble(dataRowPom["Prodajna cena"]) - artikal.ProdajnaCena);

                red["Šifra"] = artikal.SifraArtikla;
                red["Naziv"] = artikal.NazivArtikla;
                red["Količina"] = artikal.Kolicina;
                red["Stara cena"] = artikal.ProdajnaCena;
                red["Nova prodajna cena"] = dataRowPom["Prodajna cena"].ToString();
                red["Nivelacija po JM"] = nivelacija.ToString();
                red["Stara osnovica"] = artikal.OsnovicaPoJM;
                red["Stari PDV"] = artikal.IznosPDVPoJM;
                red["Nova osnovica"] = dataRowPom["Osnovica"].ToString();
                red["Novi PDV"] = dataRowPom["Iznos PDV"].ToString();
                red["Stara marža"] = artikal.Marza;
                red["Nova marža"] = dataRowPom["Marža"].ToString();
                red["Stara RUC"] = artikal.RUC;
                red["Nova RUC"] = dataRowPom["RUC"].ToString();

                tabelaProizvodaNivelacija.Rows.Add(red);
            }

            gridProizvodaNivelacija.ItemsSource = tabelaProizvodaNivelacija.AsDataView();
        }

        public void praviDataTable(DataTable tabelaProizvodaNivelacija)
        {
            if (tabelaProizvodaNivelacija.Columns.Count == 0)
            {
                tabelaProizvodaNivelacija.Columns.Add("Šifra");
                tabelaProizvodaNivelacija.Columns.Add("Naziv");
                tabelaProizvodaNivelacija.Columns.Add("Količina");
                tabelaProizvodaNivelacija.Columns.Add("Stara cena");
                tabelaProizvodaNivelacija.Columns.Add("Nova prodajna cena");
                tabelaProizvodaNivelacija.Columns.Add("Nivelacija po JM");
                tabelaProizvodaNivelacija.Columns.Add("Stara osnovica");
                tabelaProizvodaNivelacija.Columns.Add("Stari PDV");
                tabelaProizvodaNivelacija.Columns.Add("Nova osnovica");
                tabelaProizvodaNivelacija.Columns.Add("Novi PDV");
                tabelaProizvodaNivelacija.Columns.Add("Stara marža");
                tabelaProizvodaNivelacija.Columns.Add("Nova marža");
                tabelaProizvodaNivelacija.Columns.Add("Stara RUC");
                tabelaProizvodaNivelacija.Columns.Add("Nova RUC");
            }
        }

        List<string> sifreArtikla = new List<string>();
        public List<string> proveriStanje(DataTable tabelaProizvoda)
        {
            sifreArtikla.Clear();
            if (tabelaProizvoda != null)
            {
                foreach (DataRow dataRowPom in tabelaProizvodaNivelacija.Rows)
                {
                    foreach (DataRow dataRowPom2 in tabelaProizvoda.Rows)
                        if (dataRowPom["Šifra"].ToString().Equals(dataRowPom2["Šifra"].ToString()))
                        {
                            sifreArtikla.Add(dataRowPom["Šifra"].ToString());
                        }
                }
                return sifreArtikla;
            }
            return sifreArtikla;
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Odabir frmOdabir = new Odabir();
            frmOdabir.Show();
        }

        private void btnUpisi_Click(object sender, RoutedEventArgs e)
        {
            DodajArtikalUNivelaciju dodajArtikalUNivelaciju = new DodajArtikalUNivelaciju(this);
            dodajArtikalUNivelaciju.Show();
        }

        private void btnObrisiRed_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int indeks = gridProizvodaNivelacija.SelectedIndex;
                if (indeks > -1)
                {
                    tabelaProizvodaNivelacija.Rows.RemoveAt(indeks);
                }
            }
            catch
            {
                MessageBox.Show("Nije moguće obrisati red.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            
            if (dpDatumNivelacije.SelectedDate.HasValue == true)
            {
                int br = 0;
                foreach (DataRow red in tabelaProizvodaNivelacija.Rows)
                {
                    Artikal artikalProvera = (from a in appBazaDataContext.Artikals
                                              where a.SifraArtikla == red["Šifra"].ToString()
                                              select a).FirstOrDefault();

                    if (artikalProvera != null)
                    {
                        try
                        {
                            Nivelacije nivelacije = new Nivelacije();
                            nivelacije.SifraArtikla = artikalProvera.SifraArtikla;
                            nivelacije.NazivArtikla = artikalProvera.NazivArtikla;
                            nivelacije.Kolicina = artikalProvera.Kolicina;
                            nivelacije.StaraCena = artikalProvera.ProdajnaCena;
                            nivelacije.NovaProdajnaCena = Convert.ToDouble(red["Nova prodajna cena"]);
                            nivelacije.NivelacijaPoJM = Convert.ToDouble(red["Nivelacija po JM"]);
                            nivelacije.StaraOsnovica = artikalProvera.OsnovicaPoJM;
                            nivelacije.StariPDV = artikalProvera.IznosPDVPoJM;
                            nivelacije.NovaOsnovica = Convert.ToDouble(red["Nova osnovica"]);
                            nivelacije.NoviPDV = Convert.ToDouble(red["Novi PDV"]);
                            nivelacije.StaraMarza = artikalProvera.Marza;
                            nivelacije.NovaMarza = Convert.ToDouble(red["Nova marža"]);
                            nivelacije.StaraRUC = artikalProvera.RUC;
                            nivelacije.NovaRUC = Convert.ToDouble(red["Nova RUC"]);
                            nivelacije.DatumNivelacije = dpDatumNivelacije.SelectedDate.Value.Date;
                            nivelacije.BrojNivelacije = Convert.ToInt32(tbBrojNivelacije.Text);

                            artikalProvera.Marza = Convert.ToDouble(red["Nova marža"]);
                            artikalProvera.RUC = Convert.ToDouble(red["Nova RUC"]);
                            artikalProvera.OsnovicaPoJM = Convert.ToDouble(red["Nova osnovica"]);
                            artikalProvera.IznosPDVPoJM = Convert.ToDouble(red["Novi PDV"]);
                            artikalProvera.ProdajnaCena = Convert.ToDouble(red["Nova prodajna cena"]);

                            appBazaDataContext.Nivelacijes.InsertOnSubmit(nivelacije);
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
                    MessageBox.Show("Uspešno sačuvana nivelacija", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Hide();
                    Magacin frmMagacin = new Magacin();
                    frmMagacin.Show();
                }
            }
            else
            {
                MessageBox.Show("Unesite datum nivelacije.", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }


            
        }
    }
}
