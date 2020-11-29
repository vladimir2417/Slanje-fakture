using System.Windows;

namespace SlanjeFakture
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnUlogujSe_Click(object sender, RoutedEventArgs e)
        {
            if (tbKorisnickoIme.Text.Length > 0 && pbLozinka.Password.Length > 0)
            {
                string korisnickoIme = "sandra";
                string lozinka = "stefanmatija";

                if (tbKorisnickoIme.Text != korisnickoIme)
                {
                    MessageBox.Show("Pogrešno korisničko ime. Molimo unesite ponovo.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (pbLozinka.Password != lozinka)
                {
                    MessageBox.Show("Pogrešna lozinka. Molimo unesite ponovo.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    var slanjeFakture = new MainClass();
                    slanjeFakture.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Unesite parametre.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
