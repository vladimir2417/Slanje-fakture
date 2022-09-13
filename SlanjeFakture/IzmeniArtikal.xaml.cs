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
    /// <summary>
    /// Interaction logic for IzmeniArtikal.xaml
    /// </summary>
    public partial class IzmeniArtikal : Window
    {
        AppBazaDataContext appBazaDataContext = new AppBazaDataContext();
        
        public IzmeniArtikal()
        {
            InitializeComponent();
        }

        private void btnOtkaziIzmene_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Magacin frmMagacin = new Magacin();
            frmMagacin.Show();
        }

        private void btnSacuvajIzmene_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBoxResult messageBoxResult = MessageBox.Show("Da li ste sigurni da želite da sačuvate izmene?", "Sačuvaj izmene artikla", MessageBoxButton.YesNo);
            if(messageBoxResult == MessageBoxResult.Yes)
            { 

            Artikal artikal = appBazaDataContext.Artikals.Single(u => u.SifraArtikla == tbSifraArtikla.Text);

            artikal.SifraArtikla = tbSifraArtikla.Text;
            artikal.NazivArtikla = tbNazivArtikla.Text;
            artikal.Kolicina = Convert.ToInt32(tbKolicina.Text);

                if (tbCena.Text.Length == 0)
                {
                    artikal.ProdajnaCena = 0;
                }
                else
                {
                    artikal.ProdajnaCena = Convert.ToDouble(tbCena.Text);
                }

                try
                {
                    appBazaDataContext.SubmitChanges();
                    
                    this.Hide();

                    Magacin frmMagacin = new Magacin();
                    frmMagacin.Show();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Neuspešna konekcija sa bazom, pokušajte ponovo. Opis: \n" + ex, "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Magacin frmMagacin = new Magacin();
            frmMagacin.Show();
        }
    }
}
