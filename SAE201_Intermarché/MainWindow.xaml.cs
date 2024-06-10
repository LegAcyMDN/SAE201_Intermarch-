using SAE201_Intermarche.model;
using System;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

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
        bool boiteManuelle;
        bool boiteAutomatique;
        public MainWindow()
        {
            InitializeComponent();
            Connexion connexion = new Connexion();
           // connexion.ShowDialog();
            instance = this;
            dgListeVehicules.Items.Filter = ContientMotClef;
        }


        // location 


        private void confirmLocation_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.getInstance().data.SelectionClient = null;
            MainWindow.getInstance().data.SelectionDateRetour = DateTime.Now;
            MainWindow.getInstance().data.SelectionDateEmprunt = DateTime.Now;

            MessageBox.Show("Location réalisé avec succès");

            EntiteReservation uneReservation = new EntiteReservation();
            uneReservation.Create();
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
            this.data.CalculPrixFinal();
            AffichagePrix.Text = this.data.PrixFinal;
        }

        private void dateRetourChoix_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            MainWindow.getInstance().data.SelectionDateRetour = (DateTime)dateRetourChoix.DataContext;
            this.data.CalculPrixFinal();
            AffichagePrix.Text = this.data.PrixFinal;
        }

        private void dgListeVehicules_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            colonnegridmain.ItemsSource = dgListeVehicules.SelectedItems;
            foreach (DataGridMain entite in dgListeVehicules.ItemsSource)
            {
               this.data.PrixVoituresSelectionnees += double.Parse(entite.PrixLocationVehicule);
                this.data.CalculPrixFinal();
                AffichagePrix.Text = this.data.PrixFinal;
            }
        }

        private bool ContientMotClef(object obj)
        {
            DataGridMain unClient = obj as DataGridMain;
            if (Manuelle.IsChecked != null && Automatique.IsChecked != null)
            {
                //Console.WriteLine(unClient.TypeBoite.ToString());
                if (boiteManuelle)
                {
                    //Console.WriteLine(unClient.TypeBoite.ToString());
                    if (String.IsNullOrEmpty(cbCategorieVehicule.Text) || String.IsNullOrEmpty(cbMagasin.Text) || dateEmpruntChoix.SelectedDate == DateTime.Today || dateRetourChoix.SelectedDate == DateTime.Today)
                            return true;
                        else
                            return (unClient.CategorieVehicule.Equals(cbCategorieVehicule.Text, StringComparison.OrdinalIgnoreCase)
                            && unClient.NomMagasin.Equals(cbMagasin.Text, StringComparison.OrdinalIgnoreCase)
                            && unClient.DateDebut.Value.ToString().StartsWith(dateEmpruntChoix.Text, StringComparison.OrdinalIgnoreCase)
                            && unClient.DateFin.Value.ToString().StartsWith(dateRetourChoix.Text, StringComparison.OrdinalIgnoreCase)
                            && unClient.TypeBoite == TypeBoite.MANUELLE.ToString());
                    
                }
                if (boiteAutomatique)
                {
                    //Console.WriteLine(unClient.TypeBoite.ToString());
                    if (String.IsNullOrEmpty(cbCategorieVehicule.Text) || String.IsNullOrEmpty(cbMagasin.Text) || dateEmpruntChoix.SelectedDate == DateTime.Today || dateRetourChoix.SelectedDate == DateTime.Today)
                            return true;
                        else
                            return (unClient.CategorieVehicule.Equals(cbCategorieVehicule.Text, StringComparison.OrdinalIgnoreCase)
                            && unClient.NomMagasin.Equals(cbMagasin.Text, StringComparison.OrdinalIgnoreCase)
                            && unClient.DateDebut.Value.ToString().StartsWith(dateEmpruntChoix.Text, StringComparison.OrdinalIgnoreCase)
                            && unClient.DateFin.Value.ToString().StartsWith(dateRetourChoix.Text, StringComparison.OrdinalIgnoreCase)
                            && unClient.TypeBoite == TypeBoite.AUTOMATIQUE.ToString());
                    
                }
            }
            return true;
        }

        private void cbCategorieVehicule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgListeVehicules.ItemsSource).Refresh();
        }

        private void dateEmpruntChoix_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgListeVehicules.ItemsSource).Refresh();
            this.data.CalculPrixFinal();
            AffichagePrix.Text = this.data.PrixFinal;
        }

        private void dateRetourChoix_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgListeVehicules.ItemsSource).Refresh();
            this.data.CalculPrixFinal();
            AffichagePrix.Text = this.data.PrixFinal;
        }

        private void cbMagasin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgListeVehicules.ItemsSource).Refresh();
        }

        private void Manuelle_Click(object sender, RoutedEventArgs e)
        {
            boiteManuelle = true;
            boiteAutomatique = false;
            CollectionViewSource.GetDefaultView(dgListeVehicules.ItemsSource).Refresh();
        }

        private void Automatique_Click(object sender, RoutedEventArgs e)
        {
            boiteAutomatique = true;
            boiteManuelle = false;
            CollectionViewSource.GetDefaultView(dgListeVehicules.ItemsSource).Refresh();
        }

        private void forfaitBas_Checked(object sender, RoutedEventArgs e)
        {

        }
            private void forfaitMoyen_Checked(object sender, RoutedEventArgs e)
        {

        }
            private void forfaitHaut_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void vol_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.getInstance().data.SelectionAssuVol == false)
                MainWindow.getInstance().data.SelectionAssuVol = true;
            else
                MainWindow.getInstance().data.SelectionAssuVol = false;
            MainWindow.getInstance().data.CalculPrixFinal();
            AffichagePrix.Text = this.data.PrixFinal;
        }

        private void Corpo_Click(object sender, RoutedEventArgs e)
        {
           if (MainWindow.getInstance().data.SelectionAssuCorpo == true)
                MainWindow.getInstance().data.SelectionAssuCorpo = false;
            else
                MainWindow.getInstance().data.SelectionAssuCorpo = true;
            MainWindow.getInstance().data.CalculPrixFinal();
            AffichagePrix.Text = this.data.PrixFinal;
        }

        private void cbNomClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbNumClient.Text = (cbNomClient.SelectedIndex + 1).ToString();
        }

        private void cbNumClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool bienParse = int.TryParse(cbNumClient.Text, out int num);
            if (bienParse)
            {
                cbNomClient.SelectedIndex = num - 1;
            }
        }
    }
}
