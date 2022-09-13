using SlanjeFakture.LinqToSql;
using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class DodajArtikalUKalkulaciju : Window
    {
        AppBazaDataContext appBazaDataContext = new AppBazaDataContext();
        Kalkulacije frmKalkulacije;
        double ukupanTrosakPoArtiklu;
        public DodajArtikalUKalkulaciju(Kalkulacije frmKal)
        {
            InitializeComponent();
            this.frmKalkulacije = frmKal;
            
            puniListBox();
        }
        public void puniListBox()
        {
            var Artikal = (from a in appBazaDataContext.Artikals
                           select a).ToList();
            lbArtikli.ItemsSource = Artikal;
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
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

            tbMarza.Text = "";
            tbkolicina.Text = "";
            tbNabavnaCena.Text = "";
        }

        private void btnUnesi_Click(object sender, RoutedEventArgs e)
        {

            double prodajnaCena = 0;
            double nabavnaCenaINO = 0;
            double nabavnaCenaRSD = 0;
            double zarada = 0;
            double PDVPoJM = 0;
            double marza = 0;
            int kolicina = 0;

            if (tbNabavnaCena.Text.Length == 0)
            {
                nabavnaCenaINO = 0;
            }
            else
            {
                nabavnaCenaINO = Convert.ToDouble(tbNabavnaCena.Text);
            }

            if (tbNabavnaCenaRSD.Text.Length == 0)
            {
                nabavnaCenaRSD = 0;
            }
            else
            {
                nabavnaCenaRSD = Convert.ToDouble(tbNabavnaCenaRSD.Text);
            }

            if (tbkolicina.Text.Length == 0)
            {
                kolicina = 0;
            }
            else
            {
                kolicina = Convert.ToInt32(tbkolicina.Text);
            }

            if (tbProdajnaCena.Text.Length == 0)
            {
                prodajnaCena = 0;
            }
            else
            {
                prodajnaCena = Convert.ToDouble(tbProdajnaCena.Text);
            }

            if (tbZarada.Text.Length == 0)
            {
                zarada = 0;
            }
            else
            {
                zarada = Convert.ToDouble(tbZarada.Text);
            }

            if (tbMarza.Text.Length == 0)
            {
                marza = 0;
            }
            else
            {
                marza = Convert.ToDouble(tbMarza.Text);
            }

            if (tbPDV.Text.Length == 0)
            {
                PDVPoJM = 0;
            }
            else
            {
                PDVPoJM = Convert.ToDouble(tbPDV.Text);
            }

            if (tbTrosakPoArtiklu.Text.Length == 0)
            {
                ukupanTrosakPoArtiklu = 0;
            }
            else
            {
                ukupanTrosakPoArtiklu = Convert.ToDouble(tbTrosakPoArtiklu.Text);
            }



            Artikal artikal = appBazaDataContext.Artikals.Single(u => u.SifraArtikla == tbSifra.Text);
            string sifra = artikal.SifraArtikla;
            string nazivDobra = artikal.NazivArtikla;

            frmKalkulacije.puniDataTable(artikal, sifra, nazivDobra, nabavnaCenaINO, nabavnaCenaRSD, kolicina, prodajnaCena, zarada, marza, PDVPoJM, ukupanTrosakPoArtiklu);

            this.Hide();
        }

        private void tbNabavnaCena_KeyUp(object sender, KeyEventArgs e)
        {
            double nabavnaCenaINO = 0;
            double nabavnaCenaRSD = 0;
            double kurs = 0;

            tbProdajnaCena.Text = "";
            tbZarada.Text = "";
            tbMarza.Text = "";
            tbPDV.Text = "";

            if (tbNabavnaCena.Text.Length == 0)
            {
                nabavnaCenaINO = 0;
            }
            else
            {
                nabavnaCenaINO = Convert.ToDouble(tbNabavnaCena.Text);
            }

            if (tbKurs.Text.Length == 0)
            {
                kurs = 0;
            }
            else
            {
                kurs = Convert.ToDouble(tbKurs.Text);
            }

            nabavnaCenaRSD = nabavnaCenaINO * kurs;

            tbNabavnaCenaRSD.Text = nabavnaCenaRSD.ToString();
        }

        private void tbProdajnaCena_KeyUp(object sender, KeyEventArgs e)
        {
            double prodajnaCena = 0;
            double nabavnaCenaRSD = 0;
            double troskoviPoArtiklu = 0;
            double poreskaOsnovica = 0;
            double PDV = 0;
            double zarada = 0;
            double marza = 0;

            if (tbProdajnaCena.Text.Length == 0)
            {
                prodajnaCena = 0;
            }
            else
            {
                prodajnaCena = Convert.ToDouble(tbProdajnaCena.Text);
            }
            if (tbNabavnaCenaRSD.Text.Length == 0)
            {
                nabavnaCenaRSD = 0;
            }
            else
            {
                nabavnaCenaRSD = Convert.ToDouble(tbNabavnaCenaRSD.Text);
            }
            if (tbTrosakPoArtiklu.Text.Length == 0)
            {
                troskoviPoArtiklu = 0;
            }
            else
            {
                troskoviPoArtiklu = Convert.ToDouble(tbTrosakPoArtiklu.Text);
            }

            poreskaOsnovica = nabavnaCenaRSD + troskoviPoArtiklu;

            PDV = Math.Round(prodajnaCena * 0.166666667,2);

            zarada = prodajnaCena - nabavnaCenaRSD - troskoviPoArtiklu - PDV;
            marza = Math.Round(zarada / prodajnaCena * 100, 2);

            tbZarada.Text = zarada.ToString();
            tbMarza.Text = marza.ToString();
            tbPDV.Text = PDV.ToString();
        }

        private void tbZarada_KeyUp(object sender, KeyEventArgs e)
        {
            double prodajnaCena = 0;
            double nabavnaCenaRSD = 0;
            double troskoviPoArtiklu = 0;
            double PDV = 0;
            double zarada = 0;
            double marza = 0;

            if (tbZarada.Text.Length == 0)
            {
                zarada = 0;
            }
            else
            {
                zarada = Convert.ToDouble(tbZarada.Text);
            }
            if (tbNabavnaCenaRSD.Text.Length == 0)
            {
                nabavnaCenaRSD = 0;
            }
            else
            {
                nabavnaCenaRSD = Convert.ToDouble(tbNabavnaCenaRSD.Text);
            }
            if (tbTrosakPoArtiklu.Text.Length == 0)
            {
                troskoviPoArtiklu = 0;
            }
            else
            {
                troskoviPoArtiklu = Convert.ToDouble(tbTrosakPoArtiklu.Text);
            }

            prodajnaCena = (nabavnaCenaRSD + troskoviPoArtiklu + zarada) * 1.20;

            PDV = prodajnaCena * 0.2;

            marza = Math.Round(zarada / prodajnaCena * 100,2);

            tbProdajnaCena.Text = prodajnaCena.ToString();
            tbMarza.Text = marza.ToString();
            tbPDV.Text = PDV.ToString();
        }

        private void cbImaSifon_Checked(object sender, RoutedEventArgs e)
        {
            if(cbImaSifon.IsChecked == true)
            {
                tbCenaSifona.Visibility = Visibility.Visible;
                labelCenaSifona.Visibility = Visibility.Visible;
                btnUnesiSifon.Visibility = Visibility.Visible;
                btnObrisi.Visibility = Visibility.Visible;
            }
        }


        private void cbImaSifon_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cbImaSifon.IsChecked == false)
            {
                tbCenaSifona.Visibility = Visibility.Hidden;
                labelCenaSifona.Visibility = Visibility.Hidden;
                btnUnesiSifon.Visibility = Visibility.Hidden;
                btnObrisi.Visibility = Visibility.Hidden;
            }
        }


        private void btnUnesiSifon_Click(object sender, RoutedEventArgs e)
        {
            double cenaSifona;
            double trosak = Convert.ToDouble(tbTrosakPoArtiklu.Text);
            double ukupnoSaSifonom;

            if (tbCenaSifona.Text.Length == 0)
            {
                cenaSifona = 0;
            }
            else
            {
                cenaSifona = Convert.ToDouble(tbCenaSifona.Text);
            }

            ukupnoSaSifonom = cenaSifona + trosak;

            ukupanTrosakPoArtiklu = ukupnoSaSifonom;

            tbTrosakPoArtiklu.Text = ukupnoSaSifonom.ToString();
            tbProdajnaCena.Text = "";
            tbMarza.Text = "";
            tbZarada.Text = "";
            tbPDV.Text = "";
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            tbTrosakPoArtiklu.Text = frmKalkulacije.tbTrosakPoArtiklu.Text;
            tbCenaSifona.Text = "";

            tbProdajnaCena.Text = "";
            tbMarza.Text = "";
            tbZarada.Text = "";
            tbPDV.Text = "";
        }

        private void lbArtikli_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        //private void tbMarza_KeyUp(object sender, KeyEventArgs e)
        //{
        //    double prodajnaCena = 0;
        //    double nabavnaCenaRSD = 0;
        //    double troskoviPoArtiklu = 0;
        //    double PDV = 0;
        //    double zarada = 0;
        //    double marza = 0;

        //    if (tbMarza.Text.Length == 0)
        //    {
        //        marza = 0;
        //    }
        //    else
        //    {
        //        marza = Convert.ToDouble(tbMarza.Text);
        //    }
        //    if (tbNabavnaCenaRSD.Text.Length == 0)
        //    {
        //        nabavnaCenaRSD = 0;
        //    }
        //    else
        //    {
        //        nabavnaCenaRSD = Convert.ToDouble(tbNabavnaCenaRSD.Text);
        //    }
        //    if (tbTrosakPoArtiklu.Text.Length == 0)
        //    {
        //        troskoviPoArtiklu = 0;
        //    }
        //    else
        //    {
        //        troskoviPoArtiklu = Convert.ToDouble(tbTrosakPoArtiklu.Text);
        //    }

        //    marza = zarada / prodajnaCena * 100;

        //    prodajnaCena = (nabavnaCenaRSD + troskoviPoArtiklu + marza) * 1.25;
        //    zarada = marza / 100 * prodajnaCena;

        //    PDV = prodajnaCena * 0.2;

        //    tbProdajnaCena.Text = prodajnaCena.ToString();
        //    tbZarada.Text = zarada.ToString();
        //    tbPDV.Text = PDV.ToString();
        //}
    }
    
}
