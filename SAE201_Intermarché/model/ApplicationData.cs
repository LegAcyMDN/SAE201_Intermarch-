using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SAE201_Intermarche.model
{
    public class ApplicationData
    {
        private ObservableCollection<EntiteClient> lesClients;
        private List<string> clientComboBoxItems;


        public ObservableCollection<EntiteClient> LesClients
        {
            get
            {
                return lesClients;
            }

            set
            {
                lesClients = value;
            }
        }

        private ObservableCollection<EntiteReservation> lesReservations;

        public ObservableCollection<EntiteReservation> LesReservations
        {
            get { return lesReservations; }
            set { lesReservations = value; }
        }

        public List<string> ClientComboBoxItems { get => clientComboBoxItems; set => clientComboBoxItems = value; }

        public ApplicationData()
        {
            LesClients = new ObservableCollection<EntiteClient>();
            ClientComboBoxItems = new List<string>();
            Charge();
        }

        public void Charge()
        {
            //TODO faire le lien avec la BDD pour remplir les valeurs
            LesClients.Add(new EntiteClient(1, "aaa", "bbb", "74000", "ccc", "0677777777", "bite@penis.com"));
            LesClients.Add(new EntiteClient(2, "iii", "jjj", "57000", "hhh", "0674890124", "test.bon@gmail.com"));

            foreach (EntiteClient client in LesClients)
            {
                ClientComboBoxItems.Add(client.Nom + "; " + client.Num);

            }

            ChargeBD();
            ChargeListes();
        }

        public void ChargeBD()
        {
            
        }

        public void ChargeListes()
        {
            LesReservations = new ObservableCollection<EntiteReservation>();
            EntiteReservation entiteReservation = new EntiteReservation();
            LesReservations = entiteReservation.FindAll();

        }
    }
}
