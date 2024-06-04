using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Intermarche.model
{
    internal class DetailReservation
    {
		private int immatriculation;

		public int Immatriculation
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

        public DetailReservation(int immatriculation, int numReservation)
        {
            Immatriculation = immatriculation;
            NumReservation = numReservation;
        }
    }
}
