using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

		private ObservableCollection<EntiteReservation> lesReservations = new ObservableCollection<EntiteReservation>();

		public ObservableCollection<EntiteReservation> LesReservations
		{
			get { return lesReservations; }
			set { lesReservations = value; }
		}

        public DetailReservation(string immatriculation, int numReservation)
        {
            Immatriculation = immatriculation;
            NumReservation = numReservation;
        }
    }
}
