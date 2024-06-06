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



        private void ComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {


        }
        private void retourWin_Click(object sender, RoutedEventArgs e)
        {
            modeClientCreer = true;
            Client client = new Client();
            client.Show();
            this.Hide();
        }

        public static MainWindow getInstance()
        {
            return instance;
        }



        private void calPlanningReservation_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Console.WriteLine(calPlanningReservation.SelectedDate);
        }
    }
}
