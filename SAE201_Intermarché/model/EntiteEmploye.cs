using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Intermarche.model
{
    public class EntiteEmploye
    {
		private int numEmploye;

		public int NumEmploye
		{
			get { return numEmploye; }
			set { numEmploye = value; }
		}

		private EntiteMagasin numMagasin;

		public EntiteMagasin NumMagasin
		{
			get { return numMagasin; }
			set { numMagasin = value; }
		}

		private String login;

		public String Login
		{
			get { return login; }
			set { login = value; }
		}

		private String mdp;

		public String MDP
		{
			get { return mdp; }
			set { mdp = value; }
		}

        public EntiteEmploye(int numEmploye, EntiteMagasin numMagasin, string login, string mDP)
        {
            NumEmploye = numEmploye;
            NumMagasin = numMagasin;
            Login = login;
            MDP = mDP;
        }

		public static ObservableCollection<EntiteEmploye> Read()
		{
			ObservableCollection<EntiteEmploye> lesEmployes = new ObservableCollection<EntiteEmploye>();
            DataAccess dataAccess = new DataAccess();
            String res = "select distinct e.*, m.* from employe e " +
                "join magasin m on e.num_magasin = m.num_magasin;";
            DataTable dataTable = dataAccess.GetData(res);
            if (dataTable != null)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    EntiteMagasin unMagasin = new EntiteMagasin((int)dataRow["num_magasin"], (String)dataRow["nom_magasin"],
                                (String)dataRow["adresse_rue_magasin"], (String)dataRow["adresse_cp_magasin"],
                                (String)dataRow["adresse_ville_magasin"], (String)dataRow["horaire_magasin"]);

                    EntiteEmploye unEmploye = new EntiteEmploye((int)dataRow["num_employe"], unMagasin,
                        (String)dataRow["login"], (String)dataRow["mdp"]);
                    lesEmployes.Add(unEmploye);
                }
            }
            return lesEmployes;
        }
    }
}
