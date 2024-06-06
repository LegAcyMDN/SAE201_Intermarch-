using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201_Intermarche.model
{
    public class DetailReservation
    {
		private String immatriculation;

		public String Immatriculation
		{
			get { return immatriculation; }
			set { immatriculation = value; }
		}

		private int numReservation;

		public int NumReservation
		{
			get { return numReservation; }
			set { numReservation = value; }
		}

        public DetailReservation(string immatriculation, int numReservation)
        {
            Immatriculation = immatriculation;
            NumReservation = numReservation;
        }

        public static ObservableCollection<DetailReservation> Read()
		{
			ObservableCollection<DetailReservation> lesDetails = new ObservableCollection<DetailReservation>();
			DataAccess dataAccess = new DataAccess();
			String res = "select * from detail_reservation;";
			DataTable dataTable = dataAccess.GetData(res);
			if (dataTable != null)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					DetailReservation unDetail = new DetailReservation((String)dataRow["immatriculation"], 
						int.Parse(dataRow["num_reservation"].ToString()));
					lesDetails.Add(unDetail);
				}
			}
			return lesDetails;
		}
	}
}
