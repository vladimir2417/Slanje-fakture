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
    /// Interaction logic for IzmeniDobavljaca.xaml
    /// </summary>
    public partial class IzmeniDobavljaca : Window
    {
        AppBazaDataContext appBazaDataContext = new AppBazaDataContext();
        public IzmeniDobavljaca()
        {
            InitializeComponent();
        }

        private void btnSacuvajIzmene_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Da li ste sigurni da želite da sačuvate izmene?", "Sačuvaj izmene dobavljača", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {

                Dobavljac dobavljac = appBazaDataContext.Dobavljacs.Single(u => u.DobavljacID == Convert.ToInt32(tbDobavljacID.Text));

                dobavljac.NazivDobavljaca = tbNazivDobavljaca.Text;
                dobavljac.Adresa = tbAdresa.Text;
                dobavljac.PIB = tbPIB.Text;
                dobavljac.MaticniBroj = tbMaticniBroj.Text;
                dobavljac.Mejl = tbMejl.Text;
                dobavljac.Telefon = tbTelefon.Text;
                dobavljac.PostanskiBroj = tbPostanskiBroj.Text;

                try
                {
                    appBazaDataContext.SubmitChanges();

                    this.Hide();

                    Dobavljaci frmDobavljaci = new Dobavljaci();
                    frmDobavljaci.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Neuspešna konekcija sa bazom, pokušajte ponovo. Opis: \n" + ex, "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
        }

        private void btnOtkaziIzmene_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Dobavljaci frmDobavljaci = new Dobavljaci();
            frmDobavljaci.Show();
        }
    }
}
