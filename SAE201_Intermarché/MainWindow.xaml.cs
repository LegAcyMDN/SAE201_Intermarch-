using SAE201_Intermarché;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Input;

namespace SAE201_Intermarche
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public static ApplicationData data = new ApplicationData();
        public MainWindow()
        {
            InitializeComponent();
            Connexion connexion = new Connexion();
            connexion.ShowDialog();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void resa_Click(object sender, RoutedEventArgs e)
        {
            Location location = new Location();
            location.Show();
        }

        private void clientWin_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client();
            client.Show();
        }

        private void retourWin_Click(object sender, RoutedEventArgs e)
        {
            Resume resume = new Resume();
            resume.Show();
        }

        private void loc_Click(object sender, RoutedEventArgs e)
        {



        }


    }
}
