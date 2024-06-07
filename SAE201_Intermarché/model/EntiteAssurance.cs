using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

		public static ObservableCollection<EntiteAssurance> Read()
		{
			ObservableCollection<EntiteAssurance> lesAssurances = new ObservableCollection<EntiteAssurance>();
            DataAccess accesBD = new DataAccess();
            String res = $"select * from assurance;";
            DataTable dataTable = accesBD.GetData(res);
            if (dataTable != null)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    EntiteAssurance uneAssurance = new EntiteAssurance((int)dataRow["num_assurance"], 
                        (String)dataRow["description_assurance"], (int)dataRow["prix_assurance"]);
                    lesAssurances.Add(uneAssurance);
                }
            }
            return lesAssurances;
        }
    }
}
