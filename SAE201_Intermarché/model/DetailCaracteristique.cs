using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Intermarche.model
{
    public class DetailCaracteristique
    {
		private EntiteVehicule uneImmatriculation;

		public EntiteVehicule UneImmatriculation
		{
			get { return uneImmatriculation; }
			set { uneImmatriculation = value; }
		}

		private EntiteCaracteristique uneCaracteristique;

		public EntiteCaracteristique UneCaracteristique
		{
			get { return uneCaracteristique; }
			set { uneCaracteristique = value; }
		}

		private String valeurCaracteristique;

		public String ValeurCaracteristique
		{
			get { return valeurCaracteristique; }
			set { valeurCaracteristique = value; }
		}

        public DetailCaracteristique(EntiteVehicule uneImmatriculation, EntiteCaracteristique uneCaracteristique, string valeurCaracteristique)
        {
            UneImmatriculation = uneImmatriculation;
            UneCaracteristique = uneCaracteristique;
            ValeurCaracteristique = valeurCaracteristique;
        }

		public static ObservableCollection<DetailCaracteristique> Read()
		{
			ObservableCollection<DetailCaracteristique> lesDetailsCaract = new ObservableCollection<DetailCaracteristique>();
			DataAccess dataAccess = new DataAccess();
			String res = "select dc.*, v.*, c.* from detail_caracteristique " +
				"join vehicule v on dc.immatriculation = v.immatriculation " +
				"join caracteristique c on dc.num_caracteristique = c.num_caracteristique;";
			DataTable dataTable = dataAccess.GetData(res);
			if (dataTable != null)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					EntiteVehicule unVehicule = new EntiteVehicule((String)dataRow["immatriculation"], (TypeBoite)Enum.Parse(typeof(TypeBoite), 
						dataRow["type_boite"].ToString().ToUpper()), (EntiteMagasin)dataRow["num_magasin"], (CategorieVehicule)dataRow["nom_categorie"], 
						(String)dataRow["nom_vehicule"], (String)dataRow["description_vehicule"], int.Parse(dataRow["nombre_places"].ToString()), 
						double.Parse(dataRow["prix_location"].ToString()), (bool)dataRow["climatisation"], (String)dataRow["lien_photo_url"]);

					EntiteCaracteristique uneCaracteristique = new EntiteCaracteristique(int.Parse(dataRow["num_caracteristique"].ToString()),
						(String)dataRow["nom_caracteristique"]);

					DetailCaracteristique unDetailCaract = new DetailCaracteristique(unVehicule, uneCaracteristique, (String)dataRow["valeur_caracteristique"]);
					lesDetailsCaract.Add(unDetailCaract);
				}
			}
			return lesDetailsCaract;
		}
    }
}
