using System;
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

        public ObservableCollection<EntiteClient> LesClients
        {
            get
            {
                return lesClients;
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
        public ObservableCollection<string> ClientComboBoxItems { get => clientComboBoxItems; set => clientComboBoxItems = value; }

        public ApplicationData()
        {
            LesClients = new ObservableCollection<EntiteClient>();

            LesVehicules = new ObservableCollection<EntiteVehicule>();

            ClientEtIdComboBoxItems = new ObservableCollection<string>();
            ClientComboBoxItems = new ObservableCollection<string>();

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
            LesVehicules = new ObservableCollection<EntiteVehicule>();
            EntiteVehicule vehicule = new EntiteVehicule();
            LesVehicules = vehicule.FindAll();
        }

        public void ChargeListes()
        { }
    }
}
