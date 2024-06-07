using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Documents;
using System.Xml;

namespace SAE201_Intermarche.model
{
    public class ApplicationData
    {
        private EntiteClient selectionClient;
        private ObservableCollection<string> clientEtIdComboBoxItems;
        private ObservableCollection<string> clientComboBoxItems;
        private ObservableCollection<LignePremiereDataGrid> listePourPremiereDataGrid;
        private ObservableCollection<DetailReservation> listeDetailReservation;
        private ObservableCollection<DataGridMain> listeTousVehiculesDetail;
        private List<string> listeNomsMagasins;
        private List<EntiteMagasin> listeEntiteMagasins;
        private List<string> listeTypeVehicule;

        private ObservableCollection<EntiteClient> lesClients;
        public ObservableCollection<EntiteClient> LesClients
        { get { return lesClients; } set { lesClients = value; } }

        private ObservableCollection<EntiteVehicule> lesVehicules;
        public ObservableCollection<EntiteVehicule> LesVehicules
        { get { return lesVehicules; } set { lesVehicules = value; } }

        private ObservableCollection<EntiteReservation> lesReservations;
        public ObservableCollection<EntiteReservation> LesReservations
        { get { return lesReservations; } set { lesReservations = value; } }

        private ObservableCollection<DetailReservation> lesDetailsReserv;

        public ObservableCollection<DetailReservation> LesDetailsReserv
        {
            get { return lesDetailsReserv; }
            set { lesDetailsReserv = value; }
        }


        public ObservableCollection<string> ClientEtIdComboBoxItems { get => clientEtIdComboBoxItems; set => clientEtIdComboBoxItems = value; }
        public ObservableCollection<string> ClientComboBoxItems { get => clientComboBoxItems; set => clientComboBoxItems = value; }
        public List<string> ListeTypeVehicule { get => listeTypeVehicule; set => listeTypeVehicule = value; }
        public ObservableCollection<LignePremiereDataGrid> ListePourPremiereDataGrid { get => listePourPremiereDataGrid; set => listePourPremiereDataGrid = value; }
        public ObservableCollection<DetailReservation> ListeDetailReservation { get => listeDetailReservation; set => listeDetailReservation = value; }
        public List<string> ListeNomsMagasins { get => listeNomsMagasins; set => listeNomsMagasins = value; }
        public List<EntiteMagasin> ListeEntiteMagasins { get => listeEntiteMagasins; set => listeEntiteMagasins = value; }
        public ObservableCollection<DataGridMain> ListeTousVehiculesDetail { get => listeTousVehiculesDetail; set => listeTousVehiculesDetail = value; }
        public EntiteClient SelectionClient { get => selectionClient; set => selectionClient = value; }

        public ApplicationData()
        {
            LesClients = new ObservableCollection<EntiteClient>();
            LesVehicules = new ObservableCollection<EntiteVehicule>();
            LesDetailsReserv = new ObservableCollection<DetailReservation>();

            ClientEtIdComboBoxItems = new ObservableCollection<string>();
            ClientComboBoxItems = new ObservableCollection<string>();

            ListeTypeVehicule = new List<string>();
            ListePourPremiereDataGrid = new ObservableCollection<LignePremiereDataGrid>();

            ListeDetailReservation = new ObservableCollection<DetailReservation>();
            ListeEntiteMagasins = new List<EntiteMagasin>();
            ListeNomsMagasins = new List<string>();
            ListeTousVehiculesDetail = new ObservableCollection<DataGridMain>();

            Charge();
        }

        public void Charge()
        {
            //TODO faire le lien avec la BDD pour remplir les valeurs
            LesClients.Add(new EntiteClient(1, "aaa", "bbb", "74000", "ccc", "0677777777", "bite@penis.com"));
            LesClients.Add(new EntiteClient(2, "iii", "jjj", "57000", "hhh", "0674890124", "test.bon@gmail.com"));

            foreach (EntiteClient client in LesClients)
            {
                ClientEtIdComboBoxItems.Add(client.Nom + "; " + client.Num);
                ClientComboBoxItems.Add(client.Nom);
            }

            ChargeBD();
            ChargeListes();
        }

        public void ChargeBD()
        {
            LesVehicules = new ObservableCollection<EntiteVehicule>();
            //EntiteVehicule vehicule = new EntiteVehicule();

            LesReservations = new ObservableCollection<EntiteReservation>();
            //EntiteReservation reservation = new EntiteReservation();

            LesDetailsReserv = new ObservableCollection<DetailReservation>();
            
        }

        public void ChargeListes()
        {
            DataAccess dataAccess = new DataAccess();
            String res = $"select nom_categorie from categorie_vehicule;";
            DataTable dataTable = dataAccess.GetData(res);
            if (dataTable != null)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    //Console.WriteLine(dataRow["nom_categorie"]);
                    ListeTypeVehicule.Add((String)dataRow["nom_categorie"]);
                }
            }
            this.LesReservations = EntiteReservation.Read();
            this.LesVehicules = EntiteVehicule.Read();
            EntiteMagasin.Read().ToList().ForEach(x => this.ListeNomsMagasins.Add(x.NomMagasin));

            ChargeDataGridListe();

        }

        public void ChargeDataGridListe()
        {
            bool dispo = true;

            foreach (EntiteReservation resa in LesReservations)
            {
                //foreach (DetailReservation detaRes in LesDetailsReserv)
                //{
                    foreach (EntiteVehicule vehicule in resa.LesVehicules)
                    {


                        ListePourPremiereDataGrid.Add(new LignePremiereDataGrid(vehicule.NomVehicule, resa.ForfaitKM, resa.UneAssurance.DescriptionAssurance, resa.UnClient.Nom, vehicule.TypeBoite, resa.DateDebut, resa.DateFin));
                    }
                //}
            }

            foreach (EntiteVehicule vehicule in LesVehicules)
            {
                ListeTousVehiculesDetail.Add(new DataGridMain(vehicule, dispo));

                ListeTousVehiculesDetail.ToList().ForEach(x =>
                {
                    LesReservations.ToList().ForEach(resa =>
                    {
                        if(resa.LesVehicules.Find(y => y == x.Vehicule) != null)
                        {
                            x.Dispo = false;
                        }


                    });

                });


            }

        }




    }
}
