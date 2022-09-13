using SlanjeFakture.LinqToSql;
using System;
using System.Data;
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
using WebSocket4Net;

namespace SlanjeFakture
{
    public partial class Magacin : Window
    {
        AppBazaDataContext appBazaDataContext = new AppBazaDataContext();

        public Magacin()
        {
            InitializeComponent();
            puniGrid();
        }

        public void puniGrid()
        {
            var Artikal = from a in appBazaDataContext.Artikals
                           select a;
            gridProizvoda.ItemsSource = Artikal;
        }

        private void btnObrisiSve_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnObrisiRed_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Obriši artikal:\n\n" + "Šifra artikla: " + ((Artikal)gridProizvoda.SelectedValue).SifraArtikla + "\n" + "Naziv artikla: " + ((Artikal)gridProizvoda.SelectedValue).NazivArtikla, "Brisanje artikla", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Artikal artikal = (from p in appBazaDataContext.Artikals
                                   where p.SifraArtikla == ((Artikal)gridProizvoda.SelectedValue).SifraArtikla
                                   select p).FirstOrDefault();

                appBazaDataContext.Artikals.DeleteOnSubmit(artikal);

                try
                {
                    appBazaDataContext.SubmitChanges();
                    puniGrid();
                    MessageBox.Show("Uspešno obrisan artikal", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Neuspešna konekcija sa bazom, pokušajte ponovo. Opis greške: \n\n" + ex, "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            } 
        }
        
        private void btnIzmeniRed_Click(object sender, RoutedEventArgs e)
        {
            IzmeniArtikal izmeniArtikal = new IzmeniArtikal();

            izmeniArtikal.tbSifraArtikla.Text = ((Artikal)gridProizvoda.SelectedValue).SifraArtikla.ToString();
            izmeniArtikal.tbNazivArtikla.Text = ((Artikal)gridProizvoda.SelectedValue).NazivArtikla.ToString();
            izmeniArtikal.tbCena.Text = ((Artikal)gridProizvoda.SelectedValue).ProdajnaCena.ToString();
            izmeniArtikal.tbKolicina.Text = ((Artikal)gridProizvoda.SelectedValue).Kolicina.ToString();

            izmeniArtikal.ShowDialog();
            this.Hide();
          
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Odabir frmOdabir = new Odabir();
            frmOdabir.Show();
        }

        private void btnUnesiNoviArtikal_Click(object sender, RoutedEventArgs e)
        {
            UnesiNoviArtikal frmUnesiNoviArtikal = new UnesiNoviArtikal(this);
            frmUnesiNoviArtikal.Show();
        }

        private void btnUveziArtikle_Click(object sender, RoutedEventArgs e)
        {
            UveziExcel frmUveziExcel = new UveziExcel();
            this.Hide();
            frmUveziExcel.ShowDialog();
            
        }

        private void tbPretraga_KeyUp(object sender, KeyEventArgs e)
        {
            if (tbPretraga.Text != "")
            {
                string pretragaParam = tbPretraga.Text;

                var Artikal = from a in appBazaDataContext.Artikals
                              where a.NazivArtikla.Contains(pretragaParam) || Convert.ToInt32(a.ProdajnaCena).ToString().Contains(pretragaParam) || a.SifraArtikla.ToString().Contains(pretragaParam)
                              select a;

                if (Artikal.Count() == 0)
                {
                    lbPretraga.Visibility = Visibility.Visible;
                    gridProizvoda.ItemsSource = null;
                }
                else
                {
                    lbPretraga.Visibility = Visibility.Hidden;
                    gridProizvoda.ItemsSource = Artikal;
                }
            }
            else
            {
                puniGrid();
            }
        }

        private void btnOtpad_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Otpad otpad = new Otpad();
            otpad.Show();
        }

        private void tbPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }  
}
