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
        private string typeBoiteData;
        private string forfait;
        private string assurance;
        private string nom;

        public string NomVehicule { get => nomVehicule; set => nomVehicule = value; }
        public string Forfait { get => forfait; set => forfait = value; }
        public string Assurance { get => assurance; set => assurance = value; }
        public string Nom { get => nom; set => nom = value; }
        public string TypeBoiteData { get => typeBoiteData; set => typeBoiteData = value; }

        public LignePremiereDataGrid(string nomVehicule, string forfait, string assurance, string nom, TypeBoite typeBoiteData)
        {
            NomVehicule = nomVehicule;
            Forfait = forfait;
            Assurance = assurance;
            Nom = nom;
            TypeBoiteData = typeBoiteData.ToString();
        }
    }
}
