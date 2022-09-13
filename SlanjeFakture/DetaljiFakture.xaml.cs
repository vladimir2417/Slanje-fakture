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
    /// Interaction logic for DetaljiFakture.xaml
    /// </summary>
    public partial class DetaljiFakture : Window
    {
        AppBazaDataContext appBazaDataContext = new AppBazaDataContext();
        int fakID;
        public DetaljiFakture(int FakturaID)
        {
            InitializeComponent();
            this.fakID = FakturaID;
            puniGrid();


        }
        public void puniGrid()
        {
            var Stavke = from a in appBazaDataContext.FakturaStavkas
                         where a.FakturaID == fakID
                         select a;
            gridStavki.ItemsSource = Stavke;
        }

        private void btnZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
