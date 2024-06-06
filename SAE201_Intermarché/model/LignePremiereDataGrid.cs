using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Intermarche.model
{
    public class LignePremiereDataGrid
    {
        private string nomVehicule;
        private string typeBoiteString;
        private string forfait;
        private string assurance;
        private string nom;
        private string prenom;

        public string NomVehicule { get => nomVehicule; set => nomVehicule = value; }

        public string TypeBoite
        {
            get { return typeBoiteString; }
            set { 
                if (value is )
                typeBoiteString = value; }
        }

        public string Forfait { get => forfait; set => forfait = value; }
        public string Assurance { get => assurance; set => assurance = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
    }
}
