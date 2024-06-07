using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Intermarche.model
{
    public class DataGridMain
    {
        private string nomVehicule;
        private string categorieVehicule;
        private string immatriculationVehicule;
        private string typeBoite;
        private string numMagasinVehicule;
        private string descriptionVehicule;
        private string nombrePlaceVehicule;
        private string prixLocationVehicule;
        private bool climatisation;
        private string lienPhotoUrlVehicule;
        private bool dispo;

        public bool Dispo { get => dispo; set => dispo = value; }
        public string NomVehicule { get => nomVehicule; set => nomVehicule = value; }
        public string CategorieVehicule { get => categorieVehicule; set => categorieVehicule = value; }
        public string ImmatriculationVehicule { get => immatriculationVehicule; set => immatriculationVehicule = value; }
        public string TypeBoite { get => typeBoite; set => typeBoite = value; }
        public string NumMagasinVehicule { get => numMagasinVehicule; set => numMagasinVehicule = value; }
        public string DescriptionVehicule { get => descriptionVehicule; set => descriptionVehicule = value; }
        public string NombrePlaceVehicule { get => nombrePlaceVehicule; set => nombrePlaceVehicule = value; }
        public string PrixLocationVehicule { get => prixLocationVehicule; set => prixLocationVehicule = value; }
        public bool Climatisation { get => climatisation; set => climatisation = value; }
        public string LienPhotoUrlVehicule { get => lienPhotoUrlVehicule; set => lienPhotoUrlVehicule = value; }

        public DataGridMain(bool dispo, string nomVehicule, CategorieVehicule categorieVehicule, string immatriculationVehicule, TypeBoite typeBoite, int numMagasinVehicule, string descriptionVehicule, int nombrePlaceVehicule, double prixLocationVehicule, bool climatisation, string lienPhotoUrlVehicule)
        {
            Dispo = dispo;
            NomVehicule = nomVehicule;
            CategorieVehicule = categorieVehicule.ToString();
            ImmatriculationVehicule = immatriculationVehicule;
            TypeBoite = typeBoite.ToString();
            NumMagasinVehicule = numMagasinVehicule.ToString();
            DescriptionVehicule = descriptionVehicule;
            NombrePlaceVehicule = nombrePlaceVehicule.ToString();
            PrixLocationVehicule = prixLocationVehicule.ToString();
            Climatisation = climatisation;
            LienPhotoUrlVehicule = lienPhotoUrlVehicule;
        }
    }
}
