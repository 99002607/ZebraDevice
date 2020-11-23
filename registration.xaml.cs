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
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace Multi_Login
{
    
    public partial class registration : Window
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        public registration()
        {
            InitializeComponent();
        }
        IFirebaseConfig ifc = new FirebaseConfig()
        
        {
            AuthSecret = "JYXl4LILCYHYLgHHlmRmhZe2eusBrzkC9KTuEUzu",
            BasePath = "https://multi-login-88841.firebaseio.com/"
        };
        IFirebaseClient client;

        private void registrarion_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(ifc);
            }

            catch
            {
                MessageBox.Show("No Internet or Connection Problem");
            }
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) &&
                string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                MessageBox.Show("Please fill all the feilds");
                return;
            }


            MyUser user = new MyUser()
            {
                Username = txtUsername.Text,
                Password = txtPassword.Password
            };
            client = new FireSharp.FirebaseClient(ifc);
            SetResponse set = client.Set(@"Users/" + txtUsername.Text, user);
            MessageBox.Show("Succesfully Registerd!");
            MainWindow login = new MainWindow();
            login.Owner = this;
            this.Hide();
            login.ShowDialog();
        }



        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        

        
    }
}
