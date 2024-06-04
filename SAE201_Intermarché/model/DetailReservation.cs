using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Intermarche.model
{
    internal class DetailReservation
    {
		private string immatriculation;

		public string Immatriculation
		{
			get { return immatriculation; }
			set { immatriculation = value; }
		}

		private int numReservation;

		public int NumReservation
		{
			get { return numReservation; }
			set { numReservation = value; }
		}

        public DetailReservation(string immatriculation, int numReservation)
        {
            Immatriculation = immatriculation;
            NumReservation = numReservation;
        }
    }
}
