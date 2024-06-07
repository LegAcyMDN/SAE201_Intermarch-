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
        private EntiteMagasin unMagasin;
        private CategorieVehicule uneCategorie;
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
        public EntiteMagasin UnMagasin { get => unMagasin; set => unMagasin = value; }
        public CategorieVehicule UneCategorie { get => uneCategorie; set => uneCategorie = value; }
        public string NomVehicule { get => nomVehicule; set => nomVehicule = value; }
        public string DescriptionVehicule { get => descriptionVehicule; set => descriptionVehicule = value; }
        public int NombrePlaces { get => nombrePlaces; set => nombrePlaces = value; }
        public double PrixLocation { get => prixLocation; set => prixLocation = value; }
        public bool Climatisation { get => climatisation; set => climatisation = value; }
        public string LienPhotoURL { get => lienPhotoURL; set => lienPhotoURL = value; }
        public TypeBoite TypeBoite { get => typeBoite; set => typeBoite = value; }

        public EntiteVehicule(string immatriculation, TypeBoite typeBoite, EntiteMagasin numMagasin, CategorieVehicule nomCategorie, string nomVehicule, string description, int nombrePlaces, double prixLocation, bool climatisation, string lienPhotoURL)
        {
            Immatriculation = immatriculation;
            TypeBoite = typeBoite;
            UnMagasin = numMagasin;
            UneCategorie = nomCategorie;
            NomVehicule = nomVehicule;
            DescriptionVehicule = description;
            NombrePlaces = nombrePlaces;
            PrixLocation = prixLocation;
            Climatisation = climatisation;
            LienPhotoURL = lienPhotoURL;
        }

        public static ObservableCollection<EntiteVehicule> Read()
        {
            ObservableCollection<EntiteVehicule> lesVehicules = new ObservableCollection<EntiteVehicule>();
            DataAccess accesBD = new DataAccess();
            String res = $"select v.*, m.*, cv.* from vehicule v " +
                "join magasin m on v.num_magasin = m.num_magasin " +
                "join categorie_vehicule cv on v.nom_categorie = cv.nom_categorie;";
            DataTable dataTable = accesBD.GetData(res);
            if (dataTable != null)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    EntiteMagasin unMagasin = new EntiteMagasin((int)dataRow["num_magasin"], (String)dataRow["nom_magasin"],
                        (String)dataRow["adresse_rue_magasin"], (String)dataRow["adresse_cp_magasin"],
                        (String)dataRow["adresse_ville_magasin"], (String)dataRow["horaire_magasin"]);

                    CategorieVehicule uneCategorie = new CategorieVehicule((String)dataRow["nom_categorie"]);

                    EntiteVehicule unVehicule = new EntiteVehicule((String)dataRow["immatriculation"],
                        (TypeBoite)Enum.Parse(typeof(TypeBoite), dataRow["type_boite"].ToString().ToUpper()), unMagasin, uneCategorie,
                        (String)dataRow["nom_vehicule"], (String)dataRow["description_vehicule"],
                        int.Parse(dataRow["nombre_places"].ToString()), double.Parse(dataRow["prix_location"].ToString()),
                        (bool)dataRow["climatisation"], (String)dataRow["lien_photo_url"]);
                    lesVehicules.Add(unVehicule);
                }
            }
            return lesVehicules;
        }
    }
}
