using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Intermarche.model
{
    public class EntiteAssurance
    {
		private int numAssurance;

		public int NumAssurance
		{
			get { return numAssurance; }
			set { numAssurance = value; }
		}

		private String descriptionAssurance;

		public String DescriptionAssurance
		{
			get { return descriptionAssurance; }
			set { descriptionAssurance = value; }
		}

		private int prixAssurance;

		public int PrixAssurance
		{
			get { return prixAssurance; }
			set { prixAssurance = value; }
		}

        public EntiteAssurance(int numAssurance, string descriptionAssurance, int prixAssurance)
        {
            NumAssurance = numAssurance;
            DescriptionAssurance = descriptionAssurance;
            PrixAssurance = prixAssurance;
        }
    }
}
