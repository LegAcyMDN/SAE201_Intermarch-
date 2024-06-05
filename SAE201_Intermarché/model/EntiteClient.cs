using SAE201_Intermarche.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SAE201_Intermarche
{
    public class EntiteClient
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

        private ObservableCollection<EntiteReservation> lesReservations = new ObservableCollection<EntiteReservation>();

        public ObservableCollection<EntiteReservation> LesReservations
        {
            get { return lesReservations; }
            set { lesReservations = value; }
        }

        private ObservableCollection<EntiteClient> lesClients = new ObservableCollection<EntiteClient>();

        public ObservableCollection<EntiteClient> LesClients
        {
            get { return lesClients; }
            set { lesClients = value; }
        }

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




    }
}
