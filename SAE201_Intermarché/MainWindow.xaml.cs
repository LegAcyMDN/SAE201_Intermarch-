using SAE201_Intermarché;
using SAE201_Intermarche.model;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace SAE201_Intermarche
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 




    public partial class MainWindow : Window
    {
        //public static ApplicationData appData = new ApplicationData();
        public static MainWindow instance;
        public static bool modeClientCreer;
        bool naturalClosing = true;
        public MainWindow()
        {
            InitializeComponent();
       

            
            Connexion connexion = new Connexion();
            connexion.ShowDialog();
            instance = this;


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
            }
            else
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
        }

        private void resa_Click(object sender, RoutedEventArgs e)
        {

        }



        private void ComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {


        }
        private void retourWin_Click(object sender, RoutedEventArgs e)
        {
 
        }

        public static MainWindow getInstance()
        {
            return instance;
        }



        private void calPlanningReservation_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Console.WriteLine(calPlanningReservation.SelectedDate);
        }

        //Client 
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

        // location 


        private void imageIntermarche_MouseDown(object sender, MouseButtonEventArgs e)
        {
            naturalClosing = false;
            MainWindow.getInstance().Show();
            this.Close();
        }


        private void confirmLocation_Click(object sender, RoutedEventArgs e)
        {

        }

        // resumé 

  



    }
}
