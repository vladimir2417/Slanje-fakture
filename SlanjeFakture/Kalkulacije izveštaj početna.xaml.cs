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
    /// Interaction logic for Kalkulacije_izveštaj_početna.xaml
    /// </summary>
    public partial class Kalkulacije_izveštaj_početna : Window
    {
        AppBazaDataContext appBazaDataContext = new AppBazaDataContext();
        public Kalkulacije_izveštaj_početna()
        {
            InitializeComponent();
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Odabir frmOdabir = new Odabir();
            frmOdabir.Show();
        }

        private void btnIzvrsi_Click(object sender, RoutedEventArgs e)
        {
            DateTime datumOd = Convert.ToDateTime(dpOd.SelectedDate);
            DateTime datumDo = Convert.ToDateTime(dpDo.SelectedDate);

            var kalkulacija = from f in appBazaDataContext.Kalkulacijas
                              where f.DatumKalkulacije >= datumOd && f.DatumKalkulacije <= datumDo
                              group f by new { f.BrojDokumenta, f.BrojKalkulacije, f.DatumKalkulacije } into kal
                              select new KalkulacijaGroup { BrojKalkulacije = kal.Key.BrojKalkulacije, BrojDokumenta = kal.Key.BrojDokumenta, DatumKalkulacije = kal.Key.DatumKalkulacije.Value.ToShortDateString() };

            gridProizvoda.ItemsSource = kalkulacija;
        }

        private void btnDetalji_Click(object sender, RoutedEventArgs e)
        {

            KalkulacijaGroup kalkulacijaGroup = (KalkulacijaGroup)gridProizvoda.SelectedValue;
            int? brojKalkulacije = kalkulacijaGroup.BrojKalkulacije;
            string brojDokumenta = kalkulacijaGroup.BrojDokumenta;
            string datumKalkulacije = kalkulacijaGroup.DatumKalkulacije;

            Kalkulacije_izvestaj kalkulacijeIzvestaj = new Kalkulacije_izvestaj(brojKalkulacije);

            kalkulacijeIzvestaj.tbDatumKalkulacije.Text = datumKalkulacije.ToString();
            kalkulacijeIzvestaj.tbBrojKalkulacije.Text = brojKalkulacije.ToString();
            kalkulacijeIzvestaj.tbPoRacunuBroj.Text = brojDokumenta.ToString();

            kalkulacijeIzvestaj.ShowDialog();
        }
    }
}
