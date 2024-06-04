using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Intermarche.model
{
    internal class EntiteCaracteristique
    {
		private int numCaracteristique;

		public int NumCaracteristique
		{
			get { return numCaracteristique; }
			set { numCaracteristique = value; }
		}

		private String nomCaracteristique;

		public String NomCaracteristique
		{
			get { return nomCaracteristique; }
			set { nomCaracteristique = value; }
		}

		private ObservableCollection<EntiteVehicule> lesVehicules = new ObservableCollection<EntiteVehicule>();

		public ObservableCollection<EntiteVehicule> LesVehicules
		{
			get { return lesVehicules; }
			set { lesVehicules = value; }
		}


		public EntiteCaracteristique(int numCaracteristique, string nomCaracteristique)
        {
            NumCaracteristique = numCaracteristique;
            NomCaracteristique = nomCaracteristique;
        }
    }
}
