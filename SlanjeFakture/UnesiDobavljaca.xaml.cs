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
    /// Interaction logic for UnesiDobavljaca.xaml
    /// </summary>
    public partial class UnesiDobavljaca : Window
    {
        AppBazaDataContext appBazaDataContext = new AppBazaDataContext();

        Dobavljaci frmDobavljaci;
        public UnesiDobavljaca(Dobavljaci frmDob)
        {
            InitializeComponent();
            this.frmDobavljaci = frmDob;
        }

        private void btnUnesiDobavljaca_Click(object sender, RoutedEventArgs e)
        {
            if (tbNazivDobavljaca.Text.Length > 0)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Da li ste sigurni da želite da unesete novog dobavljača?", "Unos novog dobavljača", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    Dobavljac dobavljacProvera = (from a in appBazaDataContext.Dobavljacs
                                              where a.NazivDobavljaca == tbNazivDobavljaca.Text
                                              select a).FirstOrDefault();

                    if (dobavljacProvera == null)
                    {
                        try
                        {
                            Dobavljac dobavljac = new Dobavljac();

                            dobavljac.NazivDobavljaca = tbNazivDobavljaca.Text;
                            dobavljac.Adresa = tbAdresa.Text;
                            dobavljac.PIB = tbPIB.Text;
                            dobavljac.MaticniBroj = tbMaticniBroj.Text;
                            dobavljac.Mejl = tbMejl.Text;
                            dobavljac.Telefon = tbTelefon.Text;
                            dobavljac.PostanskiBroj = tbPostanskiBroj.Text;

                            appBazaDataContext.Dobavljacs.InsertOnSubmit(dobavljac);

                            try
                            {
                                appBazaDataContext.SubmitChanges();
                                this.Hide();
                                frmDobavljaci.puniGrid();

                                MessageBox.Show("Uspešno unet novi dobavljač", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Neuspešna konekcija sa bazom, pokušajte ponovo. Opis greške: \n\n" + ex, "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Polja nisu u dobrom formatu!", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Postoji dobavljač sa ovim nazivom!", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Popunite naziv dobavljača!", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
