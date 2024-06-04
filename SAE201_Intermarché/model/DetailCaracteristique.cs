using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Intermarche.model
{
    internal class DetailCaracteristique
    {
		private int immatriculation;

		public int Immatriculation
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

        public DetailCaracteristique(int immatriculation, int numCaracteristique, string valeurCaracteristique)
        {
            Immatriculation = immatriculation;
            NumCaracteristique = numCaracteristique;
            ValeurCaracteristique = valeurCaracteristique;
        }
    }
}
