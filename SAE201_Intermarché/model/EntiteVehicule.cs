using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text.RegularExpressions;

namespace SAE201_Intermarche.model
{
    public enum TypeBoite
    { MANUELLE, AUTOMATIQUE }

    public class EntiteVehicule //: ICrud
    {
        private string immatriculation;
        private TypeBoite typeBoite;
        private EntiteMagasin unMagasin;
        private string nomCategorie;
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
        public string NomCategorie { get => nomCategorie; set => nomCategorie = value; }
        public string NomVehicule { get => nomVehicule; set => nomVehicule = value; }
        public string DescriptionVehicule { get => descriptionVehicule; set => descriptionVehicule = value; }
        public int NombrePlaces { get => nombrePlaces; set => nombrePlaces = value; }
        public double PrixLocation { get => prixLocation; set => prixLocation = value; }
        public bool Climatisation { get => climatisation; set => climatisation = value; }
        public string LienPhotoURL { get => lienPhotoURL; set => lienPhotoURL = value; }
        public TypeBoite TypeBoite { get => typeBoite; set => typeBoite = value; }

        public EntiteVehicule() { }

        public EntiteVehicule(string immatriculation, TypeBoite typeBoite, EntiteMagasin numMagasin, string nomCategorie, string nomVehicule, string description, int nombrePlaces, double prixLocation, bool climatisation, string lienPhotoURL)
        {
            Immatriculation = immatriculation;
            TypeBoite = typeBoite;
            UnMagasin = numMagasin;
            NomCategorie = nomCategorie;
            NomVehicule = nomVehicule;
            DescriptionVehicule = description;
            NombrePlaces = nombrePlaces;
            PrixLocation = prixLocation;
            Climatisation = climatisation;
            LienPhotoURL = lienPhotoURL;
        }

        /*public void Create()
        {
            DataAccess accesBD = new DataAccess();
            accesBD.SetData($"insert into vehicule (immatriculation, type_boite, num_magasin, nom_vehicule, description_vehicule, nombre_places, prix_location, climatisation, lien_photo_url) " +
                $"values ('{Immatriculation}','{TypeBoite}','{NumMagasin}','{NomVehicule}','{DescriptionVehicule}','{NombrePlaces}','{PrixLocation}','{Climatisation}','{LienPhotoURL}');");
        }*/

        public static ObservableCollection<EntiteVehicule> Read()
        {
            ObservableCollection<EntiteVehicule> lesVehicules = new ObservableCollection<EntiteVehicule>();
            DataAccess accesBD = new DataAccess();
            String res = $"select * from vehicule;";
            DataTable dataTable = accesBD.GetData(res);
            if (dataTable != null)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    try
                    {
                        DataTable autreTable = accesBD.GetData($"select * from magasin where num_magasin={(int)dataRow["num_magasin"]}");
                        EntiteMagasin entMag = new EntiteMagasin((int)dataRow["num_magasin"], (String)dataRow["nom_magasin"], 
                            (String)dataRow["adresse_rue_magasin"], (String)dataRow["adresse_cp_magasin"], 
                            (String)dataRow["adresse_ville_magasin"], (String)dataRow["horaire_magasin"]);


                        EntiteVehicule unVehicule = new EntiteVehicule((String)dataRow["immatriculation"],
                            (TypeBoite)Enum.Parse(typeof(TypeBoite), dataRow["type_boite"].ToString().ToUpper()), entMag, (String)dataRow["nom_categorie"],
                            (String)dataRow["nom_vehicule"], (String)dataRow["description_vehicule"],
                            int.Parse(dataRow["nombre_places"].ToString()), double.Parse(dataRow["prix_location"].ToString()),
                            (bool)dataRow["climatisation"], (String)dataRow["lien_photo_url"]);
                        lesVehicules.Add(unVehicule);
                    } catch (Exception ex)
                    {
                        Console.WriteLine("Il y a eu une erreur dans le read d'EntiteVehicule : " + ex.StackTrace);
                    }
                }
            }
            return lesVehicules;
        }

        /*public void Update()
        {
            DataAccess dataAccess = new DataAccess();
            String res = $"update vehicule set (immatriculation, type_boite, num_magasin, nom_vehicule, description_vehicule, nombres_places, prix_location, climatisation, lien_photo_url) " +
                $"values ('{Immatriculation}','{TypeBoite}','{NumMagasin}','{NomVehicule}','{DescriptionVehicule}','{NombrePlaces}','{PrixLocation}','{Climatisation}','{LienPhotoURL}') where immatriculation = " + Immatriculation + ";";
            dataAccess.SetData(res);
        }*/

        /*public void Delete()
        {
            ObservableCollection<EntiteVehicule> lesVehicules = new ObservableCollection<EntiteVehicule>();
            foreach (EntiteVehicule unVehicule in lesVehicules)
            { unVehicule.Delete(); }

            DataAccess dataAccess = new DataAccess();
            String res = $"delete from vehicule where immatriculation = '{Immatriculation}';";
            dataAccess.SetData(res);
        }*/
    }
}
