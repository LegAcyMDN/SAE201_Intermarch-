using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Intermarche.model
{
    internal class CategorieVehicule
    {
		private String nomCategroie;

		public String NomCategorie
		{
			get { return nomCategroie; }
			set { nomCategroie = value; }
		}

		private ObservableCollection<EntiteMagasin> lesVehicules;

		public ObservableCollection<EntiteMagasin> LesVehicules
		{
			get { return lesVehicules; }
			set { lesVehicules = value; }
		}

		public CategorieVehicule() { }

        public CategorieVehicule(string nomCategorie)
        { NomCategorie = nomCategorie; }


    }
}
