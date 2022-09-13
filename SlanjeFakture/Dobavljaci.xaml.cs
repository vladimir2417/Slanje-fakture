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
    public partial class Dobavljaci : Window
    {
        AppBazaDataContext appBazaDataContext = new AppBazaDataContext();
        public Dobavljaci()
        {
            InitializeComponent();
            puniGrid();
        }
        public void puniGrid()
        {
            var Dobavljac = from a in appBazaDataContext.Dobavljacs
                          select a;
            gridProizvoda.ItemsSource = Dobavljac;
        }

        private void btnIzmeniRed_Click(object sender, RoutedEventArgs e)
        {
            IzmeniDobavljaca izmeniDobavljaca = new IzmeniDobavljaca();

            izmeniDobavljaca.tbDobavljacID.Text = ((Dobavljac)gridProizvoda.SelectedValue).DobavljacID.ToString();
            izmeniDobavljaca.tbNazivDobavljaca.Text = ((Dobavljac)gridProizvoda.SelectedValue).NazivDobavljaca.ToString();
            izmeniDobavljaca.tbPIB.Text = ((Dobavljac)gridProizvoda.SelectedValue).PIB.ToString();
            izmeniDobavljaca.tbMaticniBroj.Text = ((Dobavljac)gridProizvoda.SelectedValue).MaticniBroj.ToString();
            izmeniDobavljaca.tbAdresa.Text = ((Dobavljac)gridProizvoda.SelectedValue).Adresa.ToString();
            izmeniDobavljaca.tbMejl.Text = ((Dobavljac)gridProizvoda.SelectedValue).Mejl.ToString();
            izmeniDobavljaca.tbTelefon.Text = ((Dobavljac)gridProizvoda.SelectedValue).Telefon.ToString();
            izmeniDobavljaca.tbPostanskiBroj.Text = ((Dobavljac)gridProizvoda.SelectedValue).PostanskiBroj.ToString();


            izmeniDobavljaca.ShowDialog();
            this.Hide();
        }

        private void btnObrisiRed_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Obriši dobavljača:\n\n" + "Naziv: " + ((Dobavljac)gridProizvoda.SelectedValue).NazivDobavljaca + "\n" + "Adresa: " + ((Dobavljac)gridProizvoda.SelectedValue).Adresa, "Brisanje dobavljača", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Dobavljac dobavljac = (from p in appBazaDataContext.Dobavljacs
                                   where p.DobavljacID == ((Dobavljac)gridProizvoda.SelectedValue).DobavljacID
                                   select p).FirstOrDefault();

                appBazaDataContext.Dobavljacs.DeleteOnSubmit(dobavljac);

                try
                {
                    appBazaDataContext.SubmitChanges();
                    puniGrid();
                    MessageBox.Show("Uspešno obrisan dobavljač", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Neuspešna konekcija sa bazom, pokušajte ponovo. Opis greške: \n\n" + ex, "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void btnUnesiNovogDobavljaca_Click(object sender, RoutedEventArgs e)
        {
            UnesiDobavljaca frmUnesiDobavljaca = new UnesiDobavljaca(this);
            frmUnesiDobavljaca.Show();
        }

        private void tbPretraga_KeyUp(object sender, KeyEventArgs e)
        {
            if (tbPretraga.Text != "")
            {
                string pretragaParam = tbPretraga.Text;

                var Dobavljac = from a in appBazaDataContext.Dobavljacs
                              where a.NazivDobavljaca.Contains(pretragaParam) || Convert.ToInt32(a.MaticniBroj).ToString().Contains(pretragaParam) || a.PIB.ToString().Contains(pretragaParam) || a.Mejl.ToString().Contains(pretragaParam) || a.Adresa.ToString().Contains(pretragaParam) || a.Telefon.ToString().Contains(pretragaParam)
                                select a;

                if (Dobavljac.Count() == 0)
                {
                    lbPretraga.Visibility = Visibility.Visible;
                    gridProizvoda.ItemsSource = null;
                }
                else
                {
                    lbPretraga.Visibility = Visibility.Hidden;
                    gridProizvoda.ItemsSource = Dobavljac;
                }
            }
            else
            {
                puniGrid();
            }
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Odabir frmOdabir = new Odabir();
            frmOdabir.Show();
        }

        private void tbPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
