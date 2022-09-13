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
    /// Interaction logic for Odabir.xaml
    /// </summary>
    public partial class Odabir : Window
    {
        public Odabir()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Magacin = new Magacin();
            Magacin.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var SlanjeFakture = new MainClass();
            SlanjeFakture.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var Izvestaji = new Izvestaji();
            Izvestaji.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var Window1 = new Window1();
            Window1.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var Kalkulacije_izvestaj = new Kalkulacije_izveštaj_početna();
            Kalkulacije_izvestaj.Show();
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var Dobavljaci = new Dobavljaci();
            Dobavljaci.Show();
            this.Close();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            var ArtikalIzvestaj = new Artikli_izvestaj();
            ArtikalIzvestaj.Show();
            this.Close();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            var Kalkulacije = new Kalkulacije();
            Kalkulacije.Show();
            this.Close();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            var Nivelacija = new Nivelacija();
            Nivelacija.Show();
            this.Close();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            var NivelacijaIzvestaj = new Nivelacija_izveštaj_početna();
            NivelacijaIzvestaj.Show();
            this.Close();
        }
    }
}
