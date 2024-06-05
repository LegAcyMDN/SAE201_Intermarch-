using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Intermarche.model
{
    public class EntiteReservation : ICrud<EntiteReservation>
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

		private ObservableCollection<EntiteReservation> lesReservations;

		public ObservableCollection<EntiteReservation> LesReservations
		{
			get { return lesReservations; }
			set { lesReservations = value; }
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

		public void Create() 
		{
			DataAccess accesBD = new DataAccess();
			accesBD.SetData($"insert into reservation (num_assurance, num_client, date_reservation, date_debut_reservation, date_fin_reservation, montant_reservation, forfait_km) " +
				$"values ('{NumAssurance}','{NumClient}','{DateReservation}','{DateDebut}','{DateFin}','{MontantReservation}','{ForfaitKM}');");
		}

		public void Read() 
		{
			DataAccess dataAccess = new DataAccess();
			String res = $"select * from reservation where num_reservation = '{NumReservation}');";
			DataTable dataTable = dataAccess.GetData(res);
			if (dataTable != null)
			{
				foreach(DataRow dataRow in dataTable.Rows)
				{
					NumReservation = int.Parse(dataRow["num_reservation"].ToString());
					break;
				}
			}
		}

		public void Update() 
		{
			DataAccess dataAccess = new DataAccess();
			String res = $"update reservation set (num_assurance, num_client, date_reservation, date_debut_reservation, date_fin_reservation, montant_reservation, forfait_km) " +
                $"values ('{NumAssurance}','{NumClient}','{DateReservation}','{DateDebut}','{DateFin}','{MontantReservation}','{ForfaitKM}') where num_reservation = " + NumReservation + ";";
        }

		public void Delete() 
		{ 
			foreach (EntiteReservation entiteReservation in LesReservations)
			{ entiteReservation.Delete(); }

			DataAccess dataAccess = new DataAccess();
			String res = $"delete from reservation where num_reservation = '{NumReservation}';";
			dataAccess.SetData(res);
		}

		public ObservableCollection<EntiteReservation> FindAll() 
		{
			ObservableCollection<EntiteReservation> lesReservations = new ObservableCollection<EntiteReservation>();
			DataAccess accesBD = new DataAccess();
			String res = $"";
			DataTable dataTable = accesBD.GetData(res);
			if (dataTable != null)
			{
				foreach(DataRow dataRow in dataTable.Rows)
				{
					EntiteReservation uneReservation = new EntiteReservation(int.Parse(dataRow["num_reservation"].ToString()),
						int.Parse(dataRow["num_assurance"].ToString()), int.Parse(dataRow["num_client"].ToString()),
						(DateTime)dataRow["date_reservation"], (DateTime)dataRow["date_debut_reservation"],
						(DateTime)dataRow["date_fin_reservation"], (double)dataRow["montant_reservation"],
						(String)dataRow["forfait_km"]);
				}
			}
			return lesReservations;
		}
    }
}
