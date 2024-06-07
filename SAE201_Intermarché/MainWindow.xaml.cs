﻿using SAE201_Intermarché;
using SAE201_Intermarche.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        bool naturalClosing = true;
        ObservableCollection<DataGridMain> selection;
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
            ajout.ShowDialog();
        }

        private void clientExistant_Click(object sender, RoutedEventArgs e)
        {
            RechercheClient recherche = new RechercheClient();
            recherche.ShowDialog();
        }

        private void Corpo_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void vol_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void colonnegridmain_KeyDown(object sender, KeyEventArgs e)
        {
          //  selection.Add()
        }
    }
}
