using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public int Num { get => num; set => num = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Rue { get => rue; set => rue = value; }
        public string Cp { get => cp; set => cp = value; }
        public string Ville { get => ville; set => ville = value; }
        public string Telephone { get => telephone; set => telephone = value; }
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




    }
}
