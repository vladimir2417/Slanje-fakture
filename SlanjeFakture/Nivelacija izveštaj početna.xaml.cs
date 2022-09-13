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
    /// Interaction logic for Nivelacija_izveštaj_početna.xaml
    /// </summary>
    public partial class Nivelacija_izveštaj_početna : Window
    {
        AppBazaDataContext appBazaDataContext = new AppBazaDataContext();
        public Nivelacija_izveštaj_početna()
        {
            InitializeComponent();
        }

        private void btnIzvrsi_Click(object sender, RoutedEventArgs e)
        {
            DateTime datumOd = Convert.ToDateTime(dpOd.SelectedDate);
            DateTime datumDo = Convert.ToDateTime(dpDo.SelectedDate);

            var nivelacija = from f in appBazaDataContext.Nivelacijes
                              where f.DatumNivelacije >= datumOd && f.DatumNivelacije <= datumDo
                              group f by new { f.BrojNivelacije, f.DatumNivelacije } into niv
                              select new NivelacijaGroup { BrojNivelacije = niv.Key.BrojNivelacije, DatumNivelacije = niv.Key.DatumNivelacije.Value.ToShortDateString()};

            gridProizvoda.ItemsSource = nivelacija;
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Odabir frmOdabir = new Odabir();
            frmOdabir.Show();
        }

        private void btnDetalji_Click(object sender, RoutedEventArgs e)
        {

            NivelacijaGroup nivelacijaGroup = (NivelacijaGroup)gridProizvoda.SelectedValue;
            string datumNivelacije = nivelacijaGroup.DatumNivelacije;
            int? brojNivelacije = nivelacijaGroup.BrojNivelacije;

            Nivelacija_izveštaj nivelacijaIzvestaj = new Nivelacija_izveštaj(brojNivelacije);

            nivelacijaIzvestaj.tbDatumNivelacije.Text = datumNivelacije;
            nivelacijaIzvestaj.tbBrojNivelacije.Text = brojNivelacije.ToString();

            nivelacijaIzvestaj.ShowDialog();
        }
    }
}
