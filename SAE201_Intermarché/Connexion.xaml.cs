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
        bool naturalClosing = true;
        public Connexion()
        {
            naturalClosing = true;
            InitializeComponent();
        }

        private void but_Valider_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
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
