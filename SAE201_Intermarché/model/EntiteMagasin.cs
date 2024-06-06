using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Intermarche.model
{
    internal class EntiteMagasin
    {
		private int numMagasin;

		public int NumMagasin
		{
			get { return numMagasin; }
			set { numMagasin = value; }
		}

		private String nomMagasin;

		public String NomMagasin
		{
			get { return nomMagasin; }
			set { nomMagasin = value; }
		}

		private String adresseRueMagasin;

		public String AdresseRueMagasin
		{
			get { return adresseRueMagasin; }
			set { adresseRueMagasin = value; }
		}

		private String adresseCPMagasin;

		public String AdresseCPMagasin
		{
			get { return adresseCPMagasin; }
			set { adresseCPMagasin = value; }
		}

		private String adresseVilleMagasin;

		public String AdresseVilleMagasin
		{
			get { return adresseVilleMagasin; }
			set { adresseVilleMagasin = value; }
		}

		private String horaireMagasin;

		public String HoraireMagasin
		{
			get { return horaireMagasin; }
			set { horaireMagasin = value; }
		}

        public EntiteMagasin(int numMagasin, string nomMagasin, string adresseRueMagasin, string adresseCPMagasin, string adresseVilleMagasin, string horaireMagasin)
        {
            NumMagasin = numMagasin;
            NomMagasin = nomMagasin;
            AdresseRueMagasin = adresseRueMagasin;
            AdresseCPMagasin = adresseCPMagasin;
            AdresseVilleMagasin = adresseVilleMagasin;
            HoraireMagasin = horaireMagasin;
        }


    }
}
