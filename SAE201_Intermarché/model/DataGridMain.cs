using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Intermarche.model
{
    class DataGridMain
    {
        private EntiteVehicule vehicule;
        private bool dispo;

        public EntiteVehicule Vehicule { get => vehicule; set => vehicule = value; }
        public bool Dispo { get => dispo; set => dispo = value; }

        public DataGridMain(EntiteVehicule vehicule, bool dispo)
        {
            Vehicule = vehicule;
            Dispo = dispo;
        }
    }
}
