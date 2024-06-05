using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Text.RegularExpressions;

namespace SAE201_Intermarche.model
{
    public enum TypeBoite
    { MANUELLE, AUTOMATIQUE }

    public class EntiteVehicule
    {
        private string immatriculation;
        private TypeBoite typeBoite;
        private int numMagasin;
        private string nomVehicule;
        private string descriptionVehicule;
        private int nombrePlaces;
        private double prixLocation;
        private bool climatisation;
        private string lienPhotoURL;
        readonly Regex regexImmatriculation = new Regex("^[A-Z]{2}[0-9]{3}[A-Z]{2}$");

        public string Immatriculation
        {
            get { return immatriculation; }
            set
            {
                if (!regexImmatriculation.IsMatch(value)) { throw new ArgumentException("La plaque d'immatriculation n'est pas valide. "); }
                immatriculation = value;
            }
        }
        public int NumMagasin { get => numMagasin; set => numMagasin = value; }
        public string NomVehicule { get => nomVehicule; set => nomVehicule = value; }
        public string DescriptionVehicule { get => descriptionVehicule; set => descriptionVehicule = value; }
        public int NombrePlaces { get => nombrePlaces; set => nombrePlaces = value; }
        public double PrixLocation { get => prixLocation; set => prixLocation = value; }
        public bool Climatisation { get => climatisation; set => climatisation = value; }
        public string LienPhotoURL { get => lienPhotoURL; set => lienPhotoURL = value; }
        public TypeBoite TypeBoite { get => typeBoite; set => typeBoite = value; }

        private ObservableCollection<EntiteVehicule> lesVehicules;

        public ObservableCollection<EntiteVehicule> LesVehicules
        {
            get { return lesVehicules; }
            set { lesVehicules = value; }
        }


        public EntiteVehicule(string immatriculation, int numMagasin, string nom, string description, int nombrePlaces, double prixLocation, bool climatisation, string lienPhotoURL, TypeBoite typeBoite)
        {
            Immatriculation = immatriculation;
            NumMagasin = numMagasin;
            NomVehicule = nom;
            DescriptionVehicule = description;
            NombrePlaces = nombrePlaces;
            PrixLocation = prixLocation;
            Climatisation = climatisation;
            LienPhotoURL = lienPhotoURL;
            TypeBoite = typeBoite;
        }

        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            accesBD.SetData($"insert into vehicule (immatriculation, num_magasin, nom_vehicule, description_vehicule, nombres_places, prix_location, climatisation, lien_photo_url) " +
                $"values ('{}','{}','{}','{}','{}','{}','{}');");
        }

        public void Read()
        {
            DataAccess dataAccess = new DataAccess();
            String res = $"select * from reservation where num_reservation = '{}');";
            DataTable dataTable = dataAccess.GetData(res);
            if (dataTable != null)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                     = int.Parse(dataRow["num_reservation"].ToString());
                    break;
                }
            }
        }

        public void Update()
        {
            DataAccess dataAccess = new DataAccess();
            String res = $"update reservation set () " +
                $"values ('{}','{}','{}','{}','{}','{}','{}') where num_reservation = " +  + ";";
        }

        public void Delete()
        {
            foreach (EntiteReservation entiteReservation in LesReservations)
            { entiteReservation.Delete(); }

            DataAccess dataAccess = new DataAccess();
            String res = $"delete from reservation where num_reservation = '{}';";
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
                foreach (DataRow dataRow in dataTable.Rows)
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
