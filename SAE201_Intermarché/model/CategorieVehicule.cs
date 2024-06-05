using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Intermarche.model
{
    public class CategorieVehicule : ICrud<CategorieVehicule>
    {
		private String nomCategroie;

		public String NomCategorie
		{
			get { return nomCategroie; }
			set { nomCategroie = value; }
		}

		private ObservableCollection<EntiteVehicule> lesVehicules = new ObservableCollection<EntiteVehicule>();

		public ObservableCollection<EntiteVehicule> LesVehicules
		{
			get { return lesVehicules; }
			set { lesVehicules = value; }
		}

		public CategorieVehicule() { }

        public CategorieVehicule(string nomCategorie)
        { NomCategorie = nomCategorie; }

        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            accesBD.SetData($"insert into reservation (nom_categorie) " +
                $"values ('{NomCategorie}');");
        }

        public void Read()
        {
            DataAccess dataAccess = new DataAccess();
            String res = "select * from categorie_vehicule;";
            DataTable dataTable = dataAccess.GetData(res);
            if (dataTable != null)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    NomCategorie = (String)dataRow["nom_categorie"];
                    break;
                }
            }
        }

        public void Update()
        {
            DataAccess dataAccess = new DataAccess();
            String res = $"update categorie_vehicule set (nom_categorie) " +
                $"values ('{NomCategorie}') where nom_categorie = " + NomCategorie + ";";
        }

        public void Delete()
        {
            foreach (EntiteVehicule entiteVehicule in lesVehicules)
            { entiteVehicule.Delete(); }

            DataAccess dataAccess = new DataAccess();
            String res = $"delete from categorie_vehicule where nom_categorie = '{NomCategorie}';";
            dataAccess.SetData(res);
        }

        public ObservableCollection<CategorieVehicule> FindAll()
        {
            ObservableCollection<CategorieVehicule> lesCategories = new ObservableCollection<CategorieVehicule>();
            DataAccess accesBD = new DataAccess();
            String res = $"select nom_categorie from categorie_vehicule where nom_categorie = '{NomCategorie}';";
            DataTable dataTable = accesBD.GetData(res);
            if (dataTable != null)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    CategorieVehicule uneCategorie = new CategorieVehicule((String)dataRow["nom_categorie"]);
                    lesCategories.Add(uneCategorie);
                }
            }
            return lesCategories;
        }
    }
}
