using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SAE201_Intermarche
{
    public class ApplicationData
    {
        private ObservableCollection<EntiteClient> lesClients;
        private List<String> clientComboBoxItems;


        public ObservableCollection<EntiteClient> LesClients
        {
            get
            {
                return this.lesClients;
            }

            set
            {
                this.lesClients = value;
            }
        }

        public List<String> ClientComboBoxItems { get => clientComboBoxItems; set => clientComboBoxItems = value; }

        public ApplicationData()
        {
            this.LesClients = new ObservableCollection<EntiteClient>();
            this.ClientComboBoxItems = new List<string>();
            this.Charge();
        }

        public void Charge()
        {
            //TODO faire le lien avec la BDD pour remplir les valeurs
            this.LesClients.Add(new EntiteClient(1, "aaa", "bbb", "74000", "ccc", "0677777777", "bite@penis.com"));
            this.LesClients.Add(new EntiteClient(2, "iii", "jjj", "57000", "hhh", "0674890124", "test.bon@gmail.com"));

            foreach(EntiteClient client in this.LesClients)
            {
                this.ClientComboBoxItems.Add(client.Nom + "; " + client.Num);

            }

        }



    }
}
