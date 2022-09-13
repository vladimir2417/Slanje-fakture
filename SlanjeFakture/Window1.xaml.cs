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
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        AppBazaDataContext appBazaDataContext = new AppBazaDataContext();
        DataTable tabelaProizvoda = new DataTable();
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            var kalkulacije = (from a in appBazaDataContext.Kalkulacijas
                               where a.NazivArtikla.Contains("TOLERO")
                               select a
                          ).ToList();

            foreach(Kalkulacija kal2 in kalkulacije)
            {



                double trosakPoArtiklu = 528.97;
                //double trosakPoArtiklu = 1228.97;

                Kalkulacija kalkulacija = new Kalkulacija();
                kalkulacija.SifraArtikla = kal2.SifraArtikla;
                kalkulacija.NazivArtikla = kal2.NazivArtikla;
                kalkulacija.NabavnaCenaINO = kal2.NabavnaCenaINO;
                kalkulacija.NabavnaCenaRSD = kal2.NabavnaCenaRSD;
                kalkulacija.Kolicina = kal2.Kolicina;
                kalkulacija.Vrednost = kal2.Vrednost;
                kalkulacija.UkupniTroskovi = Math.Round((double)(trosakPoArtiklu * kal2.Kolicina), 4);
                kalkulacija.TroskoviPoJM = trosakPoArtiklu;
                kalkulacija.BrutoVrednostUkupno = Math.Round((double)((kal2.NabavnaCenaRSD * kal2.Kolicina) + trosakPoArtiklu * kal2.Kolicina), 4);
                kalkulacija.BrutoVrednostPoJM = Math.Round((double)(kal2.NabavnaCenaRSD + trosakPoArtiklu), 4);

                double poreskaOsnovica = (double)(kal2.NabavnaCenaRSD + trosakPoArtiklu);
                double PDV = Math.Round((double)(kal2.ProdajnaCena * 0.166666667), 2);
                double zarada = Math.Round((double)(kal2.ProdajnaCena - kal2.NabavnaCenaRSD - trosakPoArtiklu - PDV),4);
                double marza = Math.Round((double)(zarada / kal2.ProdajnaCena * 100), 2);

                kalkulacija.Marza = marza;
                kalkulacija.RUC = zarada;
                kalkulacija.OsnovicaPoJM = Math.Round((double)(kal2.ProdajnaCena - PDV), 4);
                kalkulacija.PDVStopa = 20;
                kalkulacija.IznosPDVpoJM = PDV;
                kalkulacija.ProdajnaCena = kal2.ProdajnaCena;
                kalkulacija.OsnovicaUkupno = Math.Round((double)((kal2.ProdajnaCena - PDV) * kal2.Kolicina), 4);
                kalkulacija.IznosPDVUkupno = Math.Round((double)(PDV * kal2.Kolicina), 4);
                kalkulacija.ProdajnaVrednostUkupno = Math.Round((double)(kal2.ProdajnaVrednostUkupno * kal2.Kolicina), 4);
                kalkulacija.RUCUkupno = Math.Round((double)(zarada * kal2.Kolicina), 4);
                kalkulacija.DatumKalkulacije = kal2.DatumKalkulacije;
                kalkulacija.BrojKalkulacije = 2;
                kalkulacija.Kurs = 103;
                kalkulacija.BrojDokumenta = "001";
                kalkulacija.DobavljacID = 5;

                //artikalProvera.NabavnaCenaINO = kal2.NabavnaCenaINO;
                //artikalProvera.NabavnaCenaRSD = kal2.NabavnaCenaRSD;
                

                Artikal artikalProvera = (from a in appBazaDataContext.Artikals
                                          where a.SifraArtikla == kal2.SifraArtikla
                                          select a).FirstOrDefault();
                if(artikalProvera != null)
                {

                artikalProvera.Kolicina = kal2.Kolicina;
                artikalProvera.Marza = marza;
                artikalProvera.RUC = zarada;
                artikalProvera.OsnovicaPoJM = Math.Round((double)(kal2.ProdajnaCena - PDV), 4);
                artikalProvera.PDVStopa = 20;
                artikalProvera.IznosPDVPoJM = PDV;
                artikalProvera.ProdajnaCena = kal2.ProdajnaCena;
                }

                appBazaDataContext.Kalkulacijas.InsertOnSubmit(kalkulacija);
                appBazaDataContext.SubmitChanges();
            }

        }
    }
}
