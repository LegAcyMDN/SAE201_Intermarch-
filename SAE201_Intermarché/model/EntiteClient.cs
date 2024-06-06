using SAE201_Intermarche.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SAE201_Intermarche
{
    public class EntiteClient : ICrud
    {
        private int num;
        private string nom;
        private string rue;
        private string cp;
        private string ville;
        private string telephone;
        private string mail;
        readonly Regex regexCp = new Regex("^[0-9]{5}$");
        readonly Regex regexTelephone = new Regex("^0[6-7][0-9]{8}$");

        public int Num { get => num; set => num = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Rue { get => rue; set => rue = value; }


        public string Cp
        {
            get { return cp; }
            set {
                if (!regexCp.IsMatch(value)) { throw new ArgumentException("Le code postal ne respecte pas le bon format. "); }
                cp = value; 
            }
        }


        public string Ville { get => ville; set => ville = value; }


        public string Telephone
        {
            get { return telephone; }
            set { 
                if (!regexTelephone.IsMatch(value)) { throw new ArgumentException("Le numéro de téléphone n'est pas formaté correctement. "); }
                
                telephone = value; }
        }


        public string Mail { get => mail; set => mail = value; }

        public EntiteClient(int num, string nom, string rue, string cp, string ville, string telephone, string mail)
        {
            Num = num;
            Nom = nom;
            Rue = rue;
            Cp = cp;
            Ville = ville;
            Telephone = telephone;
            Mail = mail;
        }

        public void Create()
        {
            DataAccess dataAccess = new DataAccess();
            dataAccess.SetData("insert into client (num_client, nom_client, adresse_rue_client, adresse_cp_client, adresse_ville_client, telephone_client, mail_client) " +
                $"values ('{Num}','{Nom}','{Rue}','{Cp}','{Ville}','{Telephone}','{Mail}');");
        }

        public void Delete()
        {

            ObservableCollection<EntiteClient> lesClients = new ObservableCollection<EntiteClient>();
            foreach (EntiteClient unClient in lesClients)
            { unClient.Delete(); }

            DataAccess dataAccess = new DataAccess();
            String res = $"delete from cleitn where num_client = '{Num}';";
            dataAccess.SetData(res);
        }

        public static ObservableCollection<EntiteClient> Read()
        {
            ObservableCollection<EntiteClient> lesClients = new ObservableCollection<EntiteClient>();
            DataAccess dataAccess = new DataAccess();
            String res = $"select * from client;";
            DataTable dataTable = dataAccess.GetData(res);
            if (dataTable != null)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    EntiteClient unclient = new EntiteClient((int)dataRow["num_client"], (String)dataRow["nom_client"],
                        (String)dataRow["adresse_rue_client"], (String)dataRow["adresse_cp_client"], (String)dataRow["adresse_ville_client"],
                        (String)dataRow["telephone_client"], (String)dataRow["mail_client"]);
                    lesClients.Add(unclient);
                }
            }
            return lesClients;
        }

        public void Update()
        {
            DataAccess dataAccess = new DataAccess();
            String res = "update client set (num_client, nom_client, adresse_rue_client, adresse_cp_client, adresse_ville_client, telephone_client, mail_client) " + 
                $"= ('{Num}','{Nom}','{Rue}','{Cp}','{Ville}','{Telephone}','{Mail}');";
            dataAccess.SetData(res);
        }
    }
}
