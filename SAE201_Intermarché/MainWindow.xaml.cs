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
        public MainWindow()
        {
            InitializeComponent();
            if (data.ClientEtIdComboBoxItems.Count > 0)
            {
                cbRechercheClientLocation.SelectedItem = data.ClientEtIdComboBoxItems[0];
                cbRechercheClient.SelectedItem = data.ClientComboBoxItems[0];
            }


            
            Connexion connexion = new Connexion();
            connexion.ShowDialog();
            instance = this;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void resa_Click(object sender, RoutedEventArgs e)
        {
            Location location = new Location();
            location.Show();
            this.Hide();
        }

        private void clientWin_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client();
            client.Show();
        }

        private void retourWin_Click(object sender, RoutedEventArgs e)
        {
            modeClientCreer = true;
            Client client = new Client();
            client.Show();
            this.Hide();
        }

        private void resume_Click(object sender, RoutedEventArgs e)
        {

            Resume resume = new Resume();
            resume.Show();
            this.Hide();
        }

        private void ComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {


        }


        public static MainWindow getInstance()
        {
            return instance;
        }

        private void calPlanningReservation_MouseDown(object sender, MouseButtonEventArgs e)
        {
           // calPlanningReservation.SelectedDate
        }

        private void cbRechercheClient_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            tbNumClient.Text = (cbRechercheClient.SelectedIndex + 1).ToString();
        }

        private void tbNumClient_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            bool bienParse = int.TryParse(tbNumClient.Text, out int num);
            if (bienParse)
            {
                cbRechercheClient.SelectedIndex = num - 1;
            }
        }

        private void butRechercherClient_Click(object sender, RoutedEventArgs e)
        {
            modeClientCreer = false;
            Client client = new Client();
            client.Show();
            this.Hide();
        }
    }
}
