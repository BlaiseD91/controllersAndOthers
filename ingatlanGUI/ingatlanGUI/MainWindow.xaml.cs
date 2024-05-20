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

using Microsoft.EntityFrameworkCore;

using ingatlanGUI.Models;


namespace ingatlanGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ingatlanguiContext context = new ingatlanguiContext();

        public MainWindow()
        {
            InitializeComponent();

            context.Sellers.Load();
            context.Realestates.Load();

            LB_sellers.ItemsSource = context.Sellers.Local.ToObservableCollection();

            this.DataContext = context.Sellers.Local.ToObservableCollection();
        }

        private void BTN_hirdetesekBetoltse_Click(object sender, RoutedEventArgs e)
        {
            LB_hirdetesekkSzama.Content = (from r in context.Realestates.Local
                                   where r.SellerId == ((Seller)LB_sellers.SelectedItem).Id
                                   select r).Count();
        }
    }
}
