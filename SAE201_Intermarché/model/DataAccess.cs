using Npgsql;
using System;
using System.Data;
using System.Windows;

namespace SAE201_Intermarche.model
{
    public class DataAccess
    {
        private static DataAccess instance;
        private string strConnexion = "Server=srv-peda-new;port=5433;" +
        "Database=sae_intermarche;Search Path=reserver_vehicule;uid=bonansej;password=dvHNbo;";

        private DataAccess() { }

        public static DataAccess Instance
        {
            get
            {
                if (instance == null) { instance = new DataAccess(); }
                return instance;
            }
        }

        public NpgsqlConnection NpgSQLConnection { get; set; }

        public void ConnexionBD()
        {
            try
            {
                NpgSQLConnection = new NpgsqlConnection();
                NpgSQLConnection.ConnectionString = strConnexion;
                NpgSQLConnection.Open();
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
        }

        public void DeconnexionBD()
        {
            try { NpgSQLConnection.Close(); }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
        }

        public DataTable GetData(string selectSQL)
        {
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(selectSQL, NpgSQLConnection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception e)
            {
                MessageBox.Show(selectSQL + e.ToString()); 
                return null;
            }
        }

        public int SetData(string setSQL)
        {
            try
            {
                NpgsqlCommand sqlCommand = new NpgsqlCommand(setSQL, NpgSQLConnection);
                int nbLines = sqlCommand.ExecuteNonQuery();
                return nbLines;
            }
            catch (Exception e) 
            { 
                MessageBox.Show(e.ToString());
                return 0;
            }
        }
    }
}
