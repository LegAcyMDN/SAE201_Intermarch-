using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Intermarche.model
{
	public class EntiteReservation : ICrud
	{
		private List<EntiteVehicule> lesVehicules = EntiteVehicule.Read().ToList();

		public List<EntiteVehicule> LesVehicules
		{
			get { return lesVehicules; }
			set { lesVehicules = value; }
		}

		private int numReservation;

		public int NumReservation
		{
			get { return numReservation; }
			set { numReservation = value; }
		}

		private EntiteAssurance uneAssurance;

		public EntiteAssurance UneAssurance
        {
			get { return uneAssurance; }
			set { uneAssurance = value; }
		}

		private EntiteClient unClient;

		public EntiteClient UnClient
		{
			get { return unClient; }
			set { unClient = value; }
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

		public EntiteReservation(int numReservation, EntiteAssurance numAssurance, EntiteClient numClient, DateTime dateReservation, DateTime dateDebut, DateTime dateFin, double montantReservation, string forfaitKM)
		{
			NumReservation = numReservation;
            UneAssurance = numAssurance;
			UnClient = numClient;
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
				$"values ('{UneAssurance}','{UnClient}','{DateReservation}','{DateDebut}','{DateFin}','{MontantReservation}','{ForfaitKM}');");
		}

		public static ObservableCollection<EntiteReservation> Read()
		{
			ObservableCollection<EntiteReservation> lesReservations = new ObservableCollection<EntiteReservation>();
			DataAccess accesBD = new DataAccess();
			String res = $"select distinct r.*, a.*, c.* from reservation r " +
                "join assurance a on r.num_assurance = a.num_assurance " +
				"join client c on r.num_client = c.num_client;";
			DataTable dataTable = accesBD.GetData(res);
			if (dataTable != null)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
#if DEBUG
					Console.WriteLine(dataRow["description_assurance"].ToString());
#endif
					EntiteAssurance uneAssurance = new EntiteAssurance((int)dataRow["num_assurance"],
                        (String)dataRow["description_assurance"], (Int16)dataRow["prix_assurance"]);

                    EntiteClient unClient = new EntiteClient((int)dataRow["num_client"], (String)dataRow["nom_client"],
						(String)dataRow["adresse_rue_client"], (String)dataRow["adresse_cp_client"], (String)dataRow["adresse_ville_client"],
						(String)dataRow["telephone_client"], (String)dataRow["mail_client"]);

					EntiteReservation uneReservation = new EntiteReservation(int.Parse(dataRow["num_reservation"].ToString()),
						uneAssurance, unClient, (DateTime)dataRow["date_reservation"], 
						(DateTime)dataRow["date_debut_reservation"], (DateTime)dataRow["date_fin_reservation"], 
						double.Parse(dataRow["montant_reservation"].ToString()), (String)dataRow["forfait_km"]);
					lesReservations.Add(uneReservation);
				}
			}
			return lesReservations;
		}

		public void Update()
		{
			DataAccess dataAccess = new DataAccess();
			String res = $"update reservation set (num_assurance, num_client, date_reservation, date_debut_reservation, date_fin_reservation, montant_reservation, forfait_km) " +
				$"values ('{UneAssurance}','{UnClient}','{DateReservation}','{DateDebut}','{DateFin}','{MontantReservation}','{ForfaitKM}') where num_reservation = " + NumReservation + ";";
			dataAccess.SetData(res);
		}

		public void Delete()
		{
			ObservableCollection<EntiteReservation> lesReservations = new ObservableCollection<EntiteReservation>();
			foreach (EntiteReservation uneReservation in lesReservations)
			{ uneReservation.Delete(); }

			DataAccess dataAccess = new DataAccess();
			String res = $"delete from reservation where num_reservation = '{NumReservation}';";
			dataAccess.SetData(res);
		}

		//lesDetails = DetailReservation.Read().ToList();
		//lesVehicules = EntiteVehicule.Read().ToList();
		//lesClients = EntiteClient.Read().ToList();
	}
}
