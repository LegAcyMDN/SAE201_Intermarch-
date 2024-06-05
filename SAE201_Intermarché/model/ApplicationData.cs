using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SAE201_Intermarche.model
{
    public class ApplicationData
    {
        private ObservableCollection<EntiteClient> lesClients;
        private ObservableCollection<string> clientEtIdComboBoxItems;
        private ObservableCollection<string> clientComboBoxItems;
        private List<CategorieVehicule> listeTypeVehicule;


        public ObservableCollection<EntiteClient> LesClients
        {
            get { return lesClients; }
            set { lesClients = value; }
        }

        private ObservableCollection<CategorieVehicule> lesCategories;

        public ObservableCollection<CategorieVehicule> LesCategories
        {
            get { return lesCategories; }
            set { lesCategories = value; }
        }

        private ObservableCollection<EntiteVehicule> lesVehicules;

        public ObservableCollection<EntiteVehicule> LesVehicules 
        { 
            get { return lesVehicules; }
            set { lesVehicules = value; }
        }

        private ObservableCollection<EntiteReservation> lesReservations;

        public ObservableCollection<EntiteReservation> LesReservations
        {
            get { return lesReservations; }
            set { lesReservations = value; }
        }

        public ObservableCollection<string> ClientEtIdComboBoxItems { get => clientEtIdComboBoxItems; set => clientEtIdComboBoxItems = value; }
        public List<CategorieVehicule> ListeTypeVehicule { get => listeTypeVehicule; set => listeTypeVehicule = value; }
        public ObservableCollection<string> ClientComboBoxItems { get => clientComboBoxItems; set => clientComboBoxItems = value; }

        public ApplicationData()
        {
            LesClients = new ObservableCollection<EntiteClient>();

            LesCategories = new ObservableCollection<CategorieVehicule>();

            LesVehicules = new ObservableCollection<EntiteVehicule>();

            ClientEtIdComboBoxItems = new ObservableCollection<string>();

            ClientComboBoxItems = new ObservableCollection<string>();

            ListeTypeVehicule = new List<CategorieVehicule>();



            Charge();
        }

        public void Charge()
        {
            //TODO faire le lien avec la BDD pour remplir les valeurs
            LesClients.Add(new EntiteClient(1, "aaa", "bbb", "74000", "ccc", "0677777777", "bite@penis.com"));
            LesClients.Add(new EntiteClient(2, "iii", "jjj", "57000", "hhh", "0674890124", "test.bon@gmail.com"));

            foreach (EntiteClient client in LesClients)
            {
                ClientEtIdComboBoxItems.Add(client.Nom + "; " + client.Num);
                ClientComboBoxItems.Add(client.Nom);
            }

            ChargeBD();
            ChargeListes();
        }

        public void ChargeBD()
        {
            LesCategories = new ObservableCollection<CategorieVehicule>();
            CategorieVehicule categorie = new CategorieVehicule();
            LesCategories = categorie.FindAll();

            LesVehicules = new ObservableCollection<EntiteVehicule>();
            EntiteVehicule vehicule = new EntiteVehicule();
            LesVehicules = vehicule.FindAll();
        }

        public void ChargeListes()
        {
            ChargeCategorie();
            //ChargeVehicules();
        }

        public void ChargeCategorie()
        {
            foreach (CategorieVehicule cv in LesCategories)
            {
                ObservableCollection<EntiteVehicule> vehicules = new ObservableCollection<EntiteVehicule>();
                foreach (EntiteVehicule ev in LesVehicules)
                {
                    if (cv.NomCategorie == ev.NomCategorie)
                    { vehicules.Add(ev); }
                }
                cv.LesVehicules = vehicules;
            }
        }
    }
}
