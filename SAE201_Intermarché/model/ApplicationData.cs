﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Windows;

namespace SAE201_Intermarche.model
{
    public class ApplicationData
    {
        //selection pour resa 
        private EntiteClient selectionClient;
        private EntiteClient creationClient;
        private DateTime selectionDateEmprunt;
        private DateTime selectionDateRetour;
        private string prixFinal;
        private double prixVoituresSelectionnees;
        private bool selectionAssuCorpo = false;
        private bool selectionAssuVol = false;
        private bool boolTypeBoite; // false = manuelle, true = automatique. 
        // const calcul prix et date
        private const double ASSU_CORPO = 1.07;
        private const double ASSU_VOL = 1.05;
        private const double ASSU_VOL_CORPO = 1.10;

        //listes items
        private ObservableCollection<string> clientEtIdComboBoxItems;
        private ObservableCollection<string> clientComboBoxItems;
        private ObservableCollection<LignePremiereDataGrid> listePourPremiereDataGrid;
        private ObservableCollection<DetailReservation> listeDetailReservation;
        private ObservableCollection<DataGridMain> listeTousVehiculesDetail;
        private List<string> listeNomsMagasins;
        private List<EntiteMagasin> listeEntiteMagasins;
        private List<string> listeTypeVehicule;
        private List<int> listeIdClients;

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
        public DateTime SelectionDateEmprunt { get => selectionDateEmprunt; set => selectionDateEmprunt = value; }
        public DateTime SelectionDateRetour { get => selectionDateRetour; set => selectionDateRetour = value; }
        public string PrixFinal { get => prixFinal; set => prixFinal = value; }
        public bool SelectionAssuCorpo { get => selectionAssuCorpo; set => selectionAssuCorpo = value; }
        public bool SelectionAssuVol { get => selectionAssuVol; set => selectionAssuVol = value; }
        public double PrixVoituresSelectionnees { get => prixVoituresSelectionnees; set => prixVoituresSelectionnees = value; }
        public bool BoolTypeBoite { get => boolTypeBoite; set => boolTypeBoite = value; }
        public List<int> ListeIdClients { get => listeIdClients; set => listeIdClients = value; }
        public EntiteClient CreationClient { get => creationClient; set => creationClient = value; }

        public ApplicationData()
        {
            LesClients = new ObservableCollection<EntiteClient>();
            LesVehicules = new ObservableCollection<EntiteVehicule>();
            LesDetailsReserv = new ObservableCollection<DetailReservation>();

            ClientEtIdComboBoxItems = new ObservableCollection<string>();
            ClientComboBoxItems = new ObservableCollection<string>();
            ListeIdClients = new List<int>();

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

            LesClients = EntiteClient.Read();
            foreach (EntiteClient client in LesClients)
            {
                ClientEtIdComboBoxItems.Add(client.Nom + "; " + client.Num);
                ClientComboBoxItems.Add(client.Nom);
                ListeIdClients.Add(client.Num);
            }

            selectionDateEmprunt = DateTime.Now;
            selectionDateRetour = DateTime.Now;
            CalculPrixFinal();
            ChargeBD();

/*#if DEBUG
            AjouteDonneesDebug();
            Console.WriteLine("Les données ne sont pas prises de la BDD car tu es en debug mode (ApplicationData ligne 133)");
            foreach (EntiteClient client in LesClients)
            {
                ClientEtIdComboBoxItems.Add(client.Nom + "; " + client.Num);
                ClientComboBoxItems.Add(client.Nom);
            }
            return;
#endif*/

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


            foreach (EntiteReservation entiteReservation in LesReservations)
            {
                foreach (EntiteVehicule vehicule in entiteReservation.LesVehicules)
                {
                    ListeTousVehiculesDetail.Add(new DataGridMain(false, vehicule.NomVehicule, vehicule.UneCategorie, vehicule.Immatriculation, vehicule.TypeBoite, vehicule.UnMagasin.NumMagasin, vehicule.DescriptionVehicule, vehicule.NombrePlaces, vehicule.PrixLocation, vehicule.Climatisation, vehicule.LienPhotoURL, vehicule.UnMagasin.NomMagasin, entiteReservation.DateDebut, entiteReservation.DateFin));
                }
            }


            foreach (EntiteVehicule vehicule in LesVehicules)
            {
                if (ListeTousVehiculesDetail.ToList().Find(x => x.ImmatriculationVehicule == vehicule.Immatriculation) == null)
                {
                    ListeTousVehiculesDetail.Add(new DataGridMain(false, vehicule.NomVehicule, vehicule.UneCategorie, vehicule.Immatriculation, vehicule.TypeBoite, vehicule.UnMagasin.NumMagasin, vehicule.DescriptionVehicule, vehicule.NombrePlaces, vehicule.PrixLocation, vehicule.Climatisation, vehicule.LienPhotoURL, vehicule.UnMagasin.NomMagasin, null, null));


                    ListeTousVehiculesDetail.ToList().ForEach(x =>
                    {
                        LesReservations.ToList().ForEach(resa =>
                        {
                            if (resa.LesVehicules.Find(y => y.Immatriculation == x.ImmatriculationVehicule) != null)
                            {
                                x.Dispo = false;
                            }


                        });

                    });
                }


            }

        }
        public void CalculPrixFinal()

            {
            double pourcentageAssu = 0;
            TimeSpan difference = selectionDateRetour - selectionDateEmprunt;
            int nbjours = 1;
            if(difference.Days == 0)
            {
                nbjours = 1;
            }
            else if(difference.Days < 0)
            {
                MessageBox.Show("erreur ! la date d'emprunt est après la date de retour !");
            }
            else
            {
                nbjours = difference.Days+1;
            }
            if (selectionAssuCorpo == true && selectionAssuVol == false)
                pourcentageAssu = ASSU_CORPO;
            else if (selectionAssuVol == true && selectionAssuCorpo == false)
                pourcentageAssu = ASSU_VOL;
            else if (selectionAssuCorpo == true && selectionAssuVol == true)
                pourcentageAssu = ASSU_VOL_CORPO;
            else
                pourcentageAssu = 1;
            double prix = Math.Round(prixVoituresSelectionnees * nbjours + (prixVoituresSelectionnees * nbjours * pourcentageAssu),2); 
            PrixFinal = $"prix : {prix} euros";
        }



        public void AjouteDonneesDebug()
        {

            EntiteClient client1 = new EntiteClient(1, "aaa", "bbb", "74000", "ccc", "0677777777", "jackie@michel.com");

            LesClients.Add(client1);
            LesClients.Add(new EntiteClient(2, "iii", "jjj", "57000", "hhh", "0674890124", "test.bon@gmail.com"));

            EntiteMagasin magasin1 = new EntiteMagasin(1, "testMagasin1", "adresse du test", "74700", "Sallanches", "15-18h");

            EntiteAssurance assurance1 = new EntiteAssurance(1, "cette assurance existe", 169);

            EntiteVehicule vehicule4L = new EntiteVehicule("AI394OF", TypeBoite.MANUELLE, magasin1, new CategorieVehicule("testCategorie"), "LA 4L", "JACKIE, JACKIE, TA 4L, TA 4LLLLL", 4, 29, false, "https://images.caradisiac.com/logos/7/1/7/6/267176/S7-renault-sent-une-attente-pour-une-nouvelle-4l-190779.jpg");

            LesVehicules.Add(vehicule4L);

            EntiteReservation resa1 = new EntiteReservation(1, assurance1, client1, new DateTime(2023, 6, 6), new DateTime(2023, 6, 10), new DateTime(2023, 6, 25), 15, "Forfait -100km");

            LesReservations.Add(resa1);

            ListePourPremiereDataGrid.Add(new LignePremiereDataGrid(vehicule4L.NomVehicule, resa1.ForfaitKM, resa1.UneAssurance.DescriptionAssurance, resa1.UnClient.Nom, vehicule4L.TypeBoite, resa1.DateDebut, resa1.DateFin));
        }


    }

}
