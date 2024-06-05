using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Intermarche.model
{
    internal class EntiteAssurance
    {
        private int numAssurance;

        public int NumAssurance
        {
            get { return numAssurance; }
            set { numAssurance = value; }
        }

        private String descriptionAssurance;

        public String DescriptionAssurance
        {
            get { return descriptionAssurance; }
            set { descriptionAssurance = value; }
        }

        private double prixAssurance;

        public double PrixAssurance
        {
            get { return prixAssurance; }
            set { prixAssurance = value; }
        }

        private ObservableCollection<EntiteReservation> lesReservations = new ObservableCollection<EntiteReservation>();

        public ObservableCollection<EntiteReservation> LesReservations
        {
            get { return lesReservations; }
            set { lesReservations = value; }
        }


        public EntiteAssurance(int numAssurance, string descriptionAssurance, double prixAssurance)
        {
            NumAssurance = numAssurance;
            DescriptionAssurance = descriptionAssurance;
            PrixAssurance = prixAssurance;
        }
    }
}
