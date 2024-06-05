using System;
using System.Collections.Generic;
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
        private string nomCategorie;
        private string nomVehicule;
        private string descriptionVehicule;
        private int nombrePlaces;
        private double prixLocation;
        private bool climatisation;
        private string lienPhotoURL;
        public static List<CategorieVehicule> lesCategories = new List<CategorieVehicule>();
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
        public string NomCategorie { get => nomCategorie; set => nomCategorie = value; }
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

        public EntiteVehicule() { }

        public EntiteVehicule(string immatriculation, TypeBoite typeBoite, int numMagasin, string nomCategorie, string nomVehicule, string description, int nombrePlaces, double prixLocation, bool climatisation, string lienPhotoURL)
        {
            Immatriculation = immatriculation;
            TypeBoite = typeBoite;
            NumMagasin = numMagasin;
            NomCategorie = nomCategorie;
            NomVehicule = nomVehicule;
            DescriptionVehicule = description;
            NombrePlaces = nombrePlaces;
            PrixLocation = prixLocation;
            Climatisation = climatisation;
            LienPhotoURL = lienPhotoURL;
        }

        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            accesBD.SetData($"insert into vehicule (immatriculation, type_boite, num_magasin, nom_vehicule, description_vehicule, nombres_places, prix_location, climatisation, lien_photo_url) " +
                $"values ('{Immatriculation}','{TypeBoite}','{NumMagasin}','{NomVehicule}','{DescriptionVehicule}','{NombrePlaces}','{PrixLocation}','{Climatisation}','{LienPhotoURL}');");
        }

        public void Read()
        {
            DataAccess dataAccess = new DataAccess();
            String res = $"select * from vehicule where immatricualtion = '{Immatriculation}');";
            DataTable dataTable = dataAccess.GetData(res);
            if (dataTable != null)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Immatriculation = (String)dataRow["num_reservation"];
                    break;
                }
            }
        }

        public void Update()
        {
            DataAccess dataAccess = new DataAccess();
            String res = $"update vehicule set (immatriculation, type_boite, num_magasin, nom_vehicule, description_vehicule, nombres_places, prix_location, climatisation, lien_photo_url) " +
                $"values ('{Immatriculation}','{TypeBoite}','{NumMagasin}','{NomVehicule}','{DescriptionVehicule}','{NombrePlaces}','{PrixLocation}','{Climatisation}','{LienPhotoURL}') where immatriculation = " + Immatriculation + ";";
        }

        public void Delete()
        {
            foreach (EntiteVehicule entiteVehicule in LesVehicules)
            { entiteVehicule.Delete(); }

            DataAccess dataAccess = new DataAccess();
            String res = $"delete from vehicule where immatriculation = '{Immatriculation}';";
            dataAccess.SetData(res);
        }

        public ObservableCollection<EntiteVehicule> FindAll()
        {
            ObservableCollection<EntiteVehicule> lesVehicules = new ObservableCollection<EntiteVehicule>();
            DataAccess accesBD = new DataAccess();
            String res = $"select immatriculation from vehicule where immatriculation = '{Immatriculation}';";
            DataTable dataTable = accesBD.GetData(res);
            if (dataTable != null)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    EntiteVehicule unVehicule = new EntiteVehicule((String)dataRow["immatriculation"],
                        (TypeBoite)dataRow["type_boite"], int.Parse(dataRow["num_magasin"].ToString()), (String)dataRow["nom_categorie"], 
                        (String)dataRow["nom_vehicule"], (String)dataRow["description_vehicule"], 
                        int.Parse(dataRow["nombres_places"].ToString()), int.Parse(dataRow["prix_location"].ToString()), 
                        (bool)dataRow["climatisation"], (String)dataRow["lien_photo_url"]);
                    lesVehicules.Add(unVehicule);
                }
            }
            return lesVehicules;
        }
    }
}
