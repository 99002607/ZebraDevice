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

namespace Multi_Login
{
    /// <summary>
    /// Interaction logic for dashboard.xaml
    /// </summary>
    public partial class dashboard : Window
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        public dashboard()
        {
            InitializeComponent();
        }

        private void todayBtnClicked(object sender, RoutedEventArgs e)
        {
            mainDrawer.IsLeftDrawerOpen = false;
            
        }

        private void weekBtnClicked(object sender, RoutedEventArgs e)
        {
            mainDrawer.IsLeftDrawerOpen = false;
            MainWindow login = new MainWindow();
            login.Owner = this;
            this.Hide();
            login.ShowDialog();

        }

        private void monthBtnClicked(object sender, RoutedEventArgs e)
        {
            mainDrawer.IsLeftDrawerOpen = false;
            Application.Current.Shutdown(); 

        }

        private void dragME(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {

                //throw;
            }
        }
    }
}