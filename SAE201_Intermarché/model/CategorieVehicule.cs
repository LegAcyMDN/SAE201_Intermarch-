using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Intermarche.model
{
    public class CategorieVehicule
    {
		private String nomCategorie;

		public String NomCategorie
		{
			get { return nomCategorie; }
			set { nomCategorie = value; }
		}

        public CategorieVehicule(string nomCategorie)
        {
            NomCategorie = nomCategorie;
        }

        public static ObservableCollection<CategorieVehicule> Read()
        {
            ObservableCollection<CategorieVehicule> lesCategories = new ObservableCollection<CategorieVehicule>();
            DataAccess dataAccess = new DataAccess();
            String res = "select * from categorie_vehicule";
            DataTable dataTable = dataAccess.GetData(res);
            if (dataTable != null)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    CategorieVehicule uneCategorie = new CategorieVehicule((String)dataRow["nom_categorie"]);
                    lesCategories.Add(uneCategorie);
                }
            }
            return lesCategories;
        }
    }
}
