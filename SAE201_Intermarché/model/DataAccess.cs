﻿using Npgsql;
using System;
using System.Data;
using System.Windows;

namespace SAE201_Intermarche.model
{
    public class DataAccess
    {
        private static DataAccess instance;
        private string strConnexion = "Server=srv-peda.iut-acy.local;port=5433;" +
        "Database=sae_intermarche;Search Path=reserver_vehicule;uid=bonansej;password=dvHNbo;";

        public DataAccess() 
        {
            this.ConnexionBD();
        }

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
                Console.WriteLine("oui je suis co");
/*#if DEBUG
                Console.WriteLine("La connexion ne se fait pas car tu es en debug mode (DataAccess ligne 36)");
                return;
#endif*/
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
/*#if DEBUG
                Console.WriteLine("La connexion ne se fait pas car tu es en debug mode (DataAccess ligne 56)");
                return null;
#endif*/
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(selectSQL, NpgSQLConnection);
                DataTable dataTable = new DataTable();
                try
                {
                    dataAdapter.Fill(dataTable);
                }
                catch(Exception e) { Console.WriteLine(e.ToString()); }
               
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
