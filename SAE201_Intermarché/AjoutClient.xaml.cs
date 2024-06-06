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
    /// Logique d'interaction pour AjoutClient.xaml
    /// </summary>
    public partial class AjoutClient : Window
    {
        public AjoutClient()
        {
            InitializeComponent();
        }

        private void nouveauClient_Click(object sender, RoutedEventArgs e)
        {
            bool ok = true;
            foreach (UIElement uie in ajoutClientReponses.Children)
            {
                if (uie is TextBox)
                {
                    TextBox txt = (TextBox)uie;
                    txt.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }
                if (Validation.GetHasError(uie))
                    ok = false;
            }
            if (ok == true)
            {
                DialogResult = true;
                MessageBox.Show(this,"Client ajouté", "Récap", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("erreur");
        }
    }
}
