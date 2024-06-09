using SAE201_Intermarche.model;
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
    /// Logique d'interaction pour Connexion.xaml
    /// </summary>
    public partial class Connexion : Window
    {
        public static string identifiant; //il faut mettre le login de la classe employe
        public static string mdp; //il faut mettre le mdp de la classe employe

        EntiteEmploye unEmploye = new EntiteEmploye(identifiant, mdp);

        bool naturalClosing = true;
        public Connexion()
        {
            naturalClosing = true;
            InitializeComponent();
        }

        private void but_Valider_Click(object sender, RoutedEventArgs e)
        {
            unEmploye.Login = identifiant;
            unEmploye.MDP = mdp;

            if (identifiant == tb_identifiant.Text && mdp == tb_mdp.Password.ToString())
            {
                this.DialogResult = true;
                Close();
            }
        }

        private void windowConnexion_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            //Si on ferme la fenêtre ça ferme l'application
            if (this.DialogResult != true)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
