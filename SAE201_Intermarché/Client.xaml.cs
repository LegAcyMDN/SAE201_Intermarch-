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

namespace SAE201_Intermarche
{
    /// <summary>
    /// Logique d'interaction pour Client.xaml
    /// </summary>
    public partial class Client : Window
    {
        bool naturalClosing = true;







        public Client()
        {
            naturalClosing = true;
            InitializeComponent();
            if (MainWindow.modeClientCreer)
            {
                butEnregistrerModifier.Content = "Enregistrer le client";
                butSupprimer.Visibility = Visibility.Hidden;
                tbNom.IsEnabled = true;
                tbTelephone.IsEnabled = true;
                tbEmail.IsEnabled = true;
                tbAdresse.IsEnabled = true;
                tbCp.IsEnabled = true;
                tbVille.IsEnabled = true;
                rbParticulier.IsEnabled = true;
                rbEntreprise.IsEnabled = true;
            } else
            {
                butEnregistrerModifier.Content = "Modifier le client";
                butSupprimer.Visibility = Visibility.Visible;
                tbNom.IsEnabled = false;
                tbTelephone.IsEnabled = false;
                tbEmail.IsEnabled = false;
                tbAdresse.IsEnabled = false;
                tbCp.IsEnabled = false;
                tbVille.IsEnabled = false;
                rbParticulier.IsEnabled = false;
                rbEntreprise.IsEnabled = false;
            }

        }



        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            naturalClosing = false;
            MainWindow.getInstance().Show();
            this.Close();
        }

        private void windowClient_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (naturalClosing)
            {
                //Si on ferme la fenêtre ça ferme l'application
                Application.Current.Shutdown();
            }
        }

        private void pieceJointePermis_Click(object sender, RoutedEventArgs e)
        {

        }

        private void pieceJointeid_Click(object sender, RoutedEventArgs e)
        {

        }

        private void pieceJointeAssurance_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PieceJointeOuvrirPermis_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PieceJointeOuvririd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PieceJointeOuvrirAssurance_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
