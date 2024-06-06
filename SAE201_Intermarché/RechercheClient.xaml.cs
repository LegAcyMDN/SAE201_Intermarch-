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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SAE201_Intermarche
{
    /// <summary>
    /// Logique d'interaction pour RechercheClient.xaml
    /// </summary>
    public partial class RechercheClient : Window
    {
        public static bool modeClientCreer;
        public RechercheClient()
        {
            InitializeComponent();
      

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

        }
        private void clientWin_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
