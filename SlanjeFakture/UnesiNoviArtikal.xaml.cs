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
    public partial class UnesiNoviArtikal : Window
    {
        AppBazaDataContext appBazaDataContext = new AppBazaDataContext();

        Magacin frmMagacin;
        public UnesiNoviArtikal(Magacin frmMag)
        {
            InitializeComponent();
            tbRabat.Text = "0";
            tbStopaPDV.Text = "20";
            this.frmMagacin = frmMag;
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if(tbSifraArtikla.Text.Length > 0 && tbNazivArtikla.Text.Length>0 && tbStopaPDV.Text.Length > 0)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Da li ste sigurni da želite da unesete novi artikal?", "Unos novog artikla", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    Artikal artikalProvera = (from a in appBazaDataContext.Artikals
                                              where a.SifraArtikla == tbSifraArtikla.Text
                                              select a).FirstOrDefault();

                    if (artikalProvera == null)
                    {
                        try
                        {
                            Artikal artikal = new Artikal();
                            artikal.SifraArtikla = tbSifraArtikla.Text;
                            artikal.NazivArtikla = tbNazivArtikla.Text;
                            artikal.IznosPDVPoJM = Convert.ToInt32(tbStopaPDV.Text);
                            artikal.Rabat = Convert.ToInt32(tbRabat.Text);
                            artikal.Kolicina = 0;

//#pragma warning disable CS0253 // Possible unintended reference comparison; right hand side needs cast
//                            Prodavac prodavac = appBazaDataContext.Prodavacs.Single(u => u.KorisnickoIme == Application.Current.Properties["KorisnickoIme"]);
//#pragma warning restore CS0253 // Possible unintended reference comparison; right hand side needs cast
//                            Prodavnica prodavnica = appBazaDataContext.Prodavnicas.Single(u => u.ProdavnicaID == 1);

//                            UnosUMagacin unosUMagacin = new UnosUMagacin();
//                            unosUMagacin.ProdavacID = prodavac.ProdavacID;
//                            unosUMagacin.ProdavnicaID = prodavnica.ProdavnicaID;
//                            unosUMagacin.SifraArtikla = artikal.SifraArtikla;
//                            unosUMagacin.DatumPrijemaRobe = DateTime.Now;

                            appBazaDataContext.Artikals.InsertOnSubmit(artikal);
                            //appBazaDataContext.UnosUMagacins.InsertOnSubmit(unosUMagacin);

                            try
                            {
                                appBazaDataContext.SubmitChanges();
                                this.Hide();
                                frmMagacin.puniGrid();

                                MessageBox.Show("Uspešno unet novi artikal", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
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
                        MessageBox.Show("Postoji proizvod sa ovom šifrom!", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Popunite sva polja!", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnOtkaziIzmene_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
