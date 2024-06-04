using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Intermarche.model
{
    public class EntiteReservation : 
    {
		private int numReservation;

		public int NumReservation
		{
			get { return numReservation; }
			set { numReservation = value; }
		}

		private int numAssurance;

		public int NumAssurance
		{
			get { return numAssurance; }
			set { numAssurance = value; }
		}

		private int numClient;

		public int NumClient
		{
			get { return numClient; }
			set { numClient = value; }
		}

		private DateTime dateReservation;

		public DateTime DateReservation
		{
			get { return dateReservation; }
			set { dateReservation = value; }
		}

		private DateTime dateDebut;

		public DateTime DateDebut
		{
			get { return dateDebut; }
			set { dateDebut = value; }
		}

		private DateTime dateFin;

		public DateTime DateFin
		{
			get { return dateFin; }
			set { dateFin = value; }
		}

		private double montantReservation;

		public double MontantReservation
		{
			get { return montantReservation; }
			set { montantReservation = value; }
		}

		private String forfaitKM;

		public String ForfaitKM
		{
			get { return forfaitKM; }
			set { forfaitKM = value; }
		}

		public EntiteReservation() { }

        public EntiteReservation(int numReservation, int numAssurance, int numClient, DateTime dateReservation, DateTime dateDebut, DateTime dateFin, double montantReservation, string forfaitKM)
        {
            NumReservation = numReservation;
            NumAssurance = numAssurance;
            NumClient = numClient;
            DateReservation = dateReservation;
            DateDebut = dateDebut;
            DateFin = dateFin;
            MontantReservation = montantReservation;
            ForfaitKM = forfaitKM;
        }

		
    }
}
