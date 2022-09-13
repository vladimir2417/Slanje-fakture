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
    /// Interaction logic for Otpad.xaml
    /// </summary>
    public partial class Otpad : Window
    {
        AppBazaDataContext appBazaDataContext = new AppBazaDataContext();
        public Otpad()
        {
            InitializeComponent();
            puniGrid();
            puniListBox();
        }

        public void puniGrid()
        {
            var Artikal = from a in appBazaDataContext.Artikals
                          where a.Otpad > 0
                          select a;
            gridProizvoda.ItemsSource = Artikal;
        }

        public void puniListBox()
        {
            var Artikal = (from a in appBazaDataContext.Artikals
                           where a.Kolicina > 0
                           select a).ToList();
            lbArtikli.ItemsSource = Artikal;
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
            tbKolicina.Text = artikal.Kolicina.ToString();
        }

        private void lbArtikli_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnDodajUOtpad_Click(object sender, RoutedEventArgs e)
        {
            if (tbSifra.Text.Length > 0)
            {
                if (tbKolicinaOtpad.Text.Length > 0)
                {
                    Artikal artikal = appBazaDataContext.Artikals.Single(u => u.SifraArtikla == tbSifra.Text);
                    if (Convert.ToInt32(tbKolicinaOtpad.Text) <= artikal.Kolicina)
                    {

                        MessageBoxResult messageBoxResult = MessageBox.Show("Da li ste sigurni da želite da dodate artikal u otpad?", "Dodaj artikal u otpad", MessageBoxButton.YesNo);
                        if (messageBoxResult == MessageBoxResult.Yes)
                        {
                            int kolicinaOtpad = Convert.ToInt32(tbKolicinaOtpad.Text);


                            artikal.Otpad = artikal.Otpad + kolicinaOtpad;
                            artikal.Kolicina = artikal.Kolicina - kolicinaOtpad;

                            try
                            {
                                appBazaDataContext.SubmitChanges();
                                puniGrid();
                                puniListBox();
                                tbKolicina.Text = "";
                                tbKolicinaOtpad.Text = "";
                                tbSifra.Text = "";
                                tbNaziv.Text = "";
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Neuspešna konekcija sa bazom, pokušajte ponovo. Opis: \n" + ex, "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Otpad je veći od broja artikala na stanju.", "Obavestenje");

                    }
                }
                else
                {
                    MessageBox.Show("Unesite količinu za otpad.", "Obavestenje");
                }
            }

            else
            {
                MessageBox.Show("Odaberite artikal.", "Obavestenje");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Magacin frmMagacin = new Magacin();
            frmMagacin.Show();
        }

        private void btnVratiIzOtpada_Click(object sender, RoutedEventArgs e)
        {
            if (tbSifra.Text.Length > 0)
            {
                if (tbKolicinaVratiOtpad.Text.Length > 0)
                {
                    Artikal artikal = appBazaDataContext.Artikals.Single(u => u.SifraArtikla == tbSifra.Text);
                    if (Convert.ToInt32(tbKolicinaVratiOtpad.Text) <= artikal.Otpad)
                    {

                        MessageBoxResult messageBoxResult = MessageBox.Show("Da li ste sigurni da želite da vratite artikle iz otpada?", "Vrati artikle iz otpada", MessageBoxButton.YesNo);
                        if (messageBoxResult == MessageBoxResult.Yes)
                        {
                            int kolicinaVratiOtpad = Convert.ToInt32(tbKolicinaVratiOtpad.Text);


                            artikal.Otpad = artikal.Otpad - kolicinaVratiOtpad;
                            artikal.Kolicina = artikal.Kolicina + kolicinaVratiOtpad;

                            try
                            {
                                appBazaDataContext.SubmitChanges();
                                puniGrid();
                                puniListBox();
                                tbKolicina.Text = "";
                                tbKolicinaVratiOtpad.Text = "";
                                tbSifra.Text = "";
                                tbNaziv.Text = "";
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Neuspešna konekcija sa bazom, pokušajte ponovo. Opis: \n" + ex, "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nema toliko artikala u otpadu.", "Obavestenje");

                    }
                }
                else
                {
                    MessageBox.Show("Unesite količinu za otpad.", "Obavestenje");
                }
            }

            else
            {
                MessageBox.Show("Odaberite artikal.", "Obavestenje");
            }
        }
    }
}
