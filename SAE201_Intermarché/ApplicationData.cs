using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Intermarche
{
    public class ApplicationData
    {
        private ObservableCollection<Client> lesClients;


        public ObservableCollection<Client> LesClients
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


        public ApplicationData()
        {

            this.Charge();
        }

        public void Charge()
        {
            //TODO faire le lien avec la BDD pour remplir les valeurs


        }



    }
}
