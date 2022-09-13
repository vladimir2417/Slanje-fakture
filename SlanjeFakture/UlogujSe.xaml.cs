using System.Windows;
using System.Data; 
using System.Linq;
using SlanjeFakture.LinqToSql;

namespace SlanjeFakture
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        AppBazaDataContext appBazaDataContext = new AppBazaDataContext();
        private void btnUlogujSe_Click(object sender, RoutedEventArgs e)
        {
            //if (tbKorisnickoIme.Text.Length > 0 && pbLozinka.Password.Length > 0)
            //{
                Prodavac prodavac = (from p in appBazaDataContext.Prodavacs
                                     where p.KorisnickoIme == tbKorisnickoIme.Text && p.Lozinka == pbLozinka.Password
                                     select p).FirstOrDefault();

                if (prodavac == null)
                {
                    MessageBox.Show("Pogrešno korisničko ime ili lozinka. Molimo unesite ponovo.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                Application.Current.Properties["KorisnickoIme"] = prodavac.KorisnickoIme;
                var Odabir = new Odabir();
                    Odabir.Show();
                    this.Close();
                }
            //}
            //else
            //{
            //    MessageBox.Show("Unesite parametre.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

      
    }
}
