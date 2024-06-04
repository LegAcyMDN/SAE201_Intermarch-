using System;
using System.Collections.Generic;
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

        public EntiteCaracteristique(int numCaracteristique, string nomCaracteristique)
        {
            NumCaracteristique = numCaracteristique;
            NomCaracteristique = nomCaracteristique;
        }
    }
}
