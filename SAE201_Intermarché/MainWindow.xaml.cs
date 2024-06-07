using SAE201_Intermarché;
using SAE201_Intermarche.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace SAE201_Intermarche
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {

        public static MainWindow instance;
        bool naturalClosing = true;
        bool modif = false;
        public MainWindow()
        {
            InitializeComponent();
            Connexion connexion = new Connexion();
            connexion.ShowDialog();
            instance = this;
        }


        // location 


        private void confirmLocation_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Location réalisé avec succès");
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void nouveauClient_Click(object sender, RoutedEventArgs e)
        {
            AjoutClient ajout = new AjoutClient();
            nouveauClient.DataContext = new EntiteClient();
            ajout.ShowDialog();


            if (ajout.DialogResult == true)
            {
                data.LesClients.Add((EntiteClient)ajout.DataContext);
                modif = true;
                MainWindow.getInstance().data.SelectionClient = (EntiteClient)ajout.DataContext;
            }
        }

        private void clientExistant_Click(object sender, RoutedEventArgs e)
        {
            RechercheClient recherche = new RechercheClient();
            recherche.ShowDialog();
        }



        private void colonnegridmain_KeyDown(object sender, KeyEventArgs e)
        {

        }


        public static MainWindow getInstance()
        {
            return instance;
        }

        private void dateEmpruntChoix_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            MainWindow.getInstance().data.SelectionDateEmprunt = (DateTime)dateEmpruntChoix.DataContext;
            MainWindow.getInstance().data.CalculPrixFinal();
            AffichagePrix.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            
            
        }

        private void dateRetourChoix_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            MainWindow.getInstance().data.SelectionDateRetour = (DateTime)dateRetourChoix.DataContext;
            MainWindow.getInstance().data.CalculPrixFinal();
            AffichagePrix.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }

        private void forfaitHaut_Checked(object sender, RoutedEventArgs e)
        {
            MainWindow.getInstance().data.SelectionForfaitHaut = true;
            MainWindow.getInstance().data.CalculPrixFinal();
            AffichagePrix.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }

        private void forfaitMoyen_Checked(object sender, RoutedEventArgs e)
        {
            MainWindow.getInstance().data.SelectionForfaitMoyen = true;
            MainWindow.getInstance().data.CalculPrixFinal();
            AffichagePrix.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }

        private void forfaitBas_Checked(object sender, RoutedEventArgs e)
        {
            MainWindow.getInstance().data.SelectionForfaitBas = true;
           MainWindow.getInstance().data.CalculPrixFinal();
            AffichagePrix.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
        private void Corpo_Checked(object sender, RoutedEventArgs e)
        {
            MainWindow.getInstance().data.SelectionAssuCorpo = true;
            MainWindow.getInstance().data.CalculPrixFinal();
            AffichagePrix.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }

        private void vol_Checked(object sender, RoutedEventArgs e)
        {
            MainWindow.getInstance().data.SelectionAssuVol = true;
           MainWindow.getInstance().data.CalculPrixFinal();
            AffichagePrix.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
    }
}
