using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SAE201_Intermarche.model
{

    public enum CategorieVehicule
    {
        COMPACT, ECONOMIQUE, FAMILIALE, HYBRIDE, CAMION_BENNE
    }

    public enum TypeBoite
    {
        MANUELLE, AUTOMATIQUE
    }


    public class EntiteVehicule
    {
        private string immatriculation;
        private TypeBoite typeBoite;
        private int numMagasin;
        private CategorieVehicule categorie;
        private string nom;
        private string description;
        private int nombrePlaces;
        private double prixLocation;
        private bool climatisation;
        private string lienPhotoURL;

        readonly Regex regexImmatriculation = new Regex("^[A-Z]{2}[0-9]{3}[A-Z]{2}$");


        public string Immatriculation
        {
            get { return immatriculation; }
            set {
                if (!regexImmatriculation.IsMatch(value)) { throw new ArgumentException("La plaque d'immatriculation n'est pas valide. "); }
                immatriculation = value; }
        }

        public int NumMagasin { get => numMagasin; set => numMagasin = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Description { get => description; set => description = value; }
        public int NombrePlaces { get => nombrePlaces; set => nombrePlaces = value; }
        public double PrixLocation { get => prixLocation; set => prixLocation = value; }
        public bool Climatisation { get => climatisation; set => climatisation = value; }
        public string LienPhotoURL { get => lienPhotoURL; set => lienPhotoURL = value; }
        public TypeBoite TypeBoite { get => typeBoite; set => typeBoite = value; }
        public CategorieVehicule Categorie { get => categorie; set => categorie = value; }

        public EntiteVehicule(string immatriculation, int numMagasin, string nom, string description, int nombrePlaces, double prixLocation, bool climatisation, string lienPhotoURL, TypeBoite typeBoite, CategorieVehicule categorie)
        {
            Immatriculation = immatriculation;
            NumMagasin = numMagasin;
            Nom = nom;
            Description = description;
            NombrePlaces = nombrePlaces;
            PrixLocation = prixLocation;
            Climatisation = climatisation;
            LienPhotoURL = lienPhotoURL;
            TypeBoite = typeBoite;
            Categorie = categorie;
        }



    }
}
