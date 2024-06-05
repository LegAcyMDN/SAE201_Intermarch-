using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Intermarche.model
{
    internal class EntiteEmploye
    {
		private int numEmploye;

		public int NumEmploye
		{
			get { return numEmploye; }
			set { numEmploye = value; }
		}

		private int numMagasin;

		public int NumMagasin
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

		public String Mdp
		{
			get { return mdp; }
			set { mdp = value; }
		}

        private ObservableCollection<EntiteMagasin> lesMagasins = new ObservableCollection<EntiteMagasin>();

        public ObservableCollection<EntiteMagasin> LesMagasins
        {
            get { return lesMagasins; }
            set { lesMagasins = value; }
        }

        public EntiteEmploye(int numEmploye, int numMagasin, string login, string mdp)
        {
            NumEmploye = numEmploye;
            NumMagasin = numMagasin;
            Login = login;
            Mdp = mdp;
        }
    }
}
