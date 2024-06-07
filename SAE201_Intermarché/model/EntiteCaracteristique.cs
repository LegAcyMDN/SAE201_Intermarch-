using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Intermarche.model
{
    public class EntiteCaracteristique
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

		public ObservableCollection<EntiteCaracteristique> Read()
		{
			ObservableCollection<EntiteCaracteristique> lesCaracteristiques = new ObservableCollection<EntiteCaracteristique>();
			DataAccess dataAccess = new DataAccess();
			String res = "select * from caracteristique;";
			DataTable dataTable = dataAccess.GetData(res);
			if (dataTable != null)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					EntiteCaracteristique uneCaracteristique = new EntiteCaracteristique(int.Parse(dataRow["num_caracteristique"].ToString()),
						(String)dataRow["nom_caracteristique"]);
					lesCaracteristiques.Add(uneCaracteristique);
				}
			}
			return lesCaracteristiques;
		}
    }
}
