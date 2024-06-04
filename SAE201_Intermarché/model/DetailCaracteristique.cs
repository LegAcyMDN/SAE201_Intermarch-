using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Intermarche.model
{
    internal class DetailCaracteristique
    {
		private string immatriculation;

		public string Immatriculation
		{
			get { return immatriculation; }
			set { immatriculation = value; }
		}

		private int numCaracteristique;

		public int NumCaracteristique
		{
			get { return numCaracteristique; }
			set { numCaracteristique = value; }
		}

		private String valeurCaracteristique;

		public String ValeurCaracteristique
		{
			get { return valeurCaracteristique; }
			set { valeurCaracteristique = value; }
		}

		private ObservableCollection<EntiteCaracteristique> lesCaracteristiques = new ObservableCollection<EntiteCaracteristique>();

		public ObservableCollection<EntiteCaracteristique> LesCaracteristiques
		{
			get { return lesCaracteristiques; }
			set { lesCaracteristiques = value; }
		}


		public DetailCaracteristique(string immatriculation, int numCaracteristique, string valeurCaracteristique)
        {
            Immatriculation = immatriculation;
            NumCaracteristique = numCaracteristique;
            ValeurCaracteristique = valeurCaracteristique;
        }
    }
}
