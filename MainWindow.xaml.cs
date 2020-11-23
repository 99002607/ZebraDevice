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
using System.Data.SqlClient;
using System.Configuration;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
namespace Multi_Login
{

    public partial class MainWindow : Window
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        //SqlConnection con = new SqlConnection();
        //SqlCommand com = new SqlCommand();
        //SqlDataReader dr;
        IFirebaseConfig Config = new FirebaseConfig
        {
            AuthSecret = "JYXl4LILCYHYLgHHlmRmhZe2eusBrzkC9KTuEUzu",
            BasePath = "https://multi-login-88841.firebaseio.com/"
        };
        IFirebaseClient client;

        private void MainWindow_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(Config);
            }

            catch
            {
                MessageBox.Show("No Internet or Connection Problem");
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            //con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //if (con.State == System.Data.ConnectionState.Open)
            //{
            //    con.Close();
            //}
            //if (VerifyUser(txtUsername.Text, txtPassword.Password))
            //{
            //    MessageBox.Show("Login Successfully", "Congrats", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //else
            //{
            //    MessageBox.Show("Username or password is incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}

            if (string.IsNullOrWhiteSpace(txtUsername.Text) &&
               string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                MessageBox.Show("Please Fill All The Fields");
                return;
            }

            client = new FireSharp.FirebaseClient(Config);
            FirebaseResponse res = client.Get(@"Users/" + txtUsername.Text);
            MyUser ResUser = res.ResultAs<MyUser>();
            dashboard tab = new dashboard();
            MyUser CurUser = new MyUser() 
            {
                Username = txtUsername.Text,
                Password = txtPassword.Password
            };

            if (MyUser.IsEqual(ResUser, CurUser))
            {
                
                tab.Owner = this;
                this.Hide();
                tab.ShowDialog();
                
            }

            else
            {
                MessageBox.Show("Incorrect Credentials!");
            }



           
            
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
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

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnreg_Click(object sender, RoutedEventArgs e)
        {
            registration reg = new registration();
            reg.Owner = this;
            this.Hide();
            reg.ShowDialog();
        }

        
    }
}
