using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
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

namespace SlanjeFakture.LinqToSql
{
    /// <summary>
    /// Interaction logic for UveziExcel.xaml
    /// </summary>
    public partial class UveziExcel : Window
    {
        AppBazaDataContext appBazaDataContext = new AppBazaDataContext();
        public UveziExcel()
        {
            InitializeComponent();
        }

        private void btnOdaberi_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Title = "Odaberite fajl";
            dialog.FileName = tbOdaberi.Text; 
            dialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;

            Nullable<bool> result = dialog.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                tbOdaberi.Text = dialog.FileName;
            }
        }
        private void btnUvezi_Click(object sender, RoutedEventArgs e)
        {

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + tbOdaberi.Text + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";
            OleDbConnection con = new OleDbConnection(connectionString);

            con.Open();
            OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter("Select * from[List1$]", con);
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            oleDbDataAdapter.Fill(dataTable);

            this.gridProizvoda.ItemsSource = dataTable.DefaultView;

            DataGridTemplateColumn dataGridTemplateColumn = new DataGridTemplateColumn();
            DataTemplate DttBtn = new DataTemplate();
            dataGridTemplateColumn.Header = "Obriši";
            FrameworkElementFactory btn = new FrameworkElementFactory(typeof(Button));

            DttBtn.VisualTree = btn;
            dataGridTemplateColumn.CellTemplate = DttBtn;

            gridProizvoda.Columns.Add(dataGridTemplateColumn);

            DataGridTemplateColumn dataGridTemplateColumn2 = new DataGridTemplateColumn();
            DataTemplate DttBtn2 = new DataTemplate();
            dataGridTemplateColumn2.Header = "Izmeni";
            FrameworkElementFactory btn2 = new FrameworkElementFactory(typeof(Button));

            DttBtn2.VisualTree = btn2;
            dataGridTemplateColumn2.CellTemplate = DttBtn2;

            gridProizvoda.Columns.Add(dataGridTemplateColumn2);
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Magacin frmMagacin = new Magacin();
            frmMagacin.Show();
        }
    }
}
