using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Intermarche.model
{
    public class DetailReservation : ICrud
    {
		private EntiteVehicule uneImmatriculation;

		public EntiteVehicule UneImmatriculation
		{
			get { return uneImmatriculation; }
			set { uneImmatriculation = value; }
		}

		private EntiteReservation uneRservation;

		public EntiteReservation UneReservation
		{
			get { return uneRservation; }
			set { uneRservation = value; }
		}

        public DetailReservation(EntiteVehicule immatriculation, EntiteReservation numReservation)
        {
            UneImmatriculation = immatriculation;
            UneReservation = numReservation;
        }

        public static ObservableCollection<DetailReservation> Read()
		{
			ObservableCollection<DetailReservation> lesDetailsReserv = new ObservableCollection<DetailReservation>();
			DataAccess dataAccess = new DataAccess();
			String res = "select dr.*, v.*, r.* from detail_reservation dr " +
				"join vehicule v on dr.immatriculation = v.immatriculation " +
				"join reservation r on dr.num_reservation = r.num_reservation;";
			DataTable dataTable = dataAccess.GetData(res);
			if (dataTable != null)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					EntiteVehicule unVehicule = new EntiteVehicule((String)dataRow["immatriculation"],
							(TypeBoite)Enum.Parse(typeof(TypeBoite), dataRow["type_boite"].ToString().ToUpper()), (EntiteMagasin)dataRow["num_magasin"], 
							(CategorieVehicule)dataRow["nom_categorie"], (String)dataRow["nom_vehicule"], (String)dataRow["description_vehicule"],
							int.Parse(dataRow["nombre_places"].ToString()), double.Parse(dataRow["prix_location"].ToString()),
							(bool)dataRow["climatisation"], (String)dataRow["lien_photo_url"]);

					EntiteReservation uneReservation = new EntiteReservation(int.Parse(dataRow["num_reservation"].ToString()),
						(EntiteAssurance)dataRow["num_assurance"], (EntiteClient)dataRow["num_client"],
                        (DateTime)dataRow["date_reservation"], (DateTime)dataRow["date_debut_reservation"],
                        (DateTime)dataRow["date_fin_reservation"], double.Parse(dataRow["montant_reservation"].ToString()),
                        (String)dataRow["forfait_km"]);

					DetailReservation unDetailReserv = new DetailReservation( unVehicule, uneReservation);
					lesDetailsReserv.Add(unDetailReserv);
				}
			}
            return lesDetailsReserv;
		}

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
			DataAccess dataAccess = new DataAccess();
			String res = $"update detail_reservation set (immatriculation, numreservation) values ('{UneImmatriculation}', '{UneReservation}')";
			dataAccess.SetData(res);
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
