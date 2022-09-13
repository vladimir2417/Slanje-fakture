using SlanjeFakture.LinqToSql;
using System;
using System.Collections.Generic;
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
    public partial class UnesiArtikalNaFakturu : Window
    {
        AppBazaDataContext appBazaDataContext = new AppBazaDataContext();
        MainClass frmSlanjeFakture;
        public UnesiArtikalNaFakturu(MainClass frmSlaFak)
        {
            InitializeComponent();
            this.frmSlanjeFakture = frmSlaFak;
            puniListBox();
        }

        public void puniListBox()
        {
            var Artikal = (from a in appBazaDataContext.Artikals
                           where a.Kolicina > 0
                           select a).ToList();
            lbArtikli.ItemsSource = Artikal;
        }

        private void btnUnesi_Click(object sender, RoutedEventArgs e)
        {
            
            Artikal artikal = appBazaDataContext.Artikals.Single(u => u.SifraArtikla == tbSifra.Text);

            int kolicina = 0;
            int rabat = 0;
  

            if (tbkolicina.Text.Length>0)

            {
                if (artikal.Kolicina >= Convert.ToInt32(tbkolicina.Text))
                {
                    kolicina = Convert.ToInt32(tbkolicina.Text);
                    rabat = Convert.ToInt32(tbRabat.Text);

                    frmSlanjeFakture.puniDataTable(artikal, kolicina, rabat);
                    appBazaDataContext.SubmitChanges();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Nema dovoljno artikala na stanju", "Obavestenje");
                }
            }
            else
            {
                MessageBox.Show("Unesite količinu", "Obavestenje");
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

        private void lbArtikli_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Artikal artikal = lbArtikli.SelectedItem as Artikal;
            tbSifra.Text = artikal.SifraArtikla;
            tbNaziv.Text = artikal.NazivArtikla;
            tbRabat.Text = artikal.Rabat.ToString();
            tbProdajnaCena.Text = artikal.ProdajnaCena.ToString();
        }

        private void lbArtikli_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
