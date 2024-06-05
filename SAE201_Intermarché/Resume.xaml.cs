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
    /// Logique d'interaction pour Retour.xaml
    /// </summary>
    public partial class Resume : Window
    {
        bool naturalClosing = true;
        public Resume()
        {
            naturalClosing = true;
            InitializeComponent();
        }

        private void windowResume_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (naturalClosing)
            {
                //Si on ferme la fenêtre ça ferme l'application
                Application.Current.Shutdown();
            }
        }

        private void imageIntermarche_MouseDown(object sender, MouseButtonEventArgs e)
        {
            naturalClosing = false;
            MainWindow.getInstance().Show();
            this.Close();
        }
    }
}
