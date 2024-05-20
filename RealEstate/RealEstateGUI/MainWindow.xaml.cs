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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using RealEstate;

namespace RealEstateGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Seller> sellers = new List<Seller>();
        // a DB kapcsolathoz kell egy pkg: msql.data
        //mindenképp egy 4.7.2-es dotnet verió kell majd

        MySqlConnection conn = new MySqlConnection("server=localhost; user=root; database=ingatlan; port=3306 ");

        public MainWindow()
        {
            InitializeComponent();
            try 
            { 
                conn.Open();
                string sql = "SELECT id, name, phone FROM sellers";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    sellers.Add(new Seller()
                    {
                        Id = Convert.ToInt32(rdr["Id"].ToString()),
                        Name = rdr["Name"].ToString(),
                        Phone = rdr["Phone"].ToString()
                    });
                }
                rdr.Close();
            } catch (Exception e) { }
            conn.Close();

            this.Seller.ItemsSource = sellers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();

                string sql = "SELECT COUNT(id) AS AdCount FROM realestates WHERE sellerid = @sellerid";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add(new MySqlParameter("@sellerid", (this.Seller.SelectedItem as Seller).Id));
                MySqlDataReader rdr = cmd.ExecuteReader();


                rdr.Read();
                this.AdCount.Content = rdr["AdCount"].ToString();
                rdr.Close();
            }
            catch (Exception ex)
            {
            }
            conn.Close();
        }
    }
}
