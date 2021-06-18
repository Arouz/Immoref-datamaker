using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataMaker
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string[] depart = {
                        "01","02","2A","2B","03","04","05","06","07","08","09",
                        "10",
                        "11",
                        "12",
                        "13",
                        "14",
                        "15",
                        "16",
                        "17",
                        "18",
                        "19",
                        "21",
                        "22",
                        "23",
                        "24",
                        "25",
                        "26",
                        "27",
                        "28",
                        "29",
                        "30",
                        "31",
                        "32",
                        "33",
                        "34",
                        "35",
                        "36",
                        "37",
                        "38",
                        "39",
                        "40",
                        "41",
                        "42",
                        "43",
                        "44",
                        "45",
                        "46",
                        "47",
                        "48",
                        "49",
                        "50",
                        "51",
                        "52",
                        "53",
                        "54",
                        "55",
                        "56",
                        "57",
                        "58",
                        "59",
                        "60",
                        "61",
                        "62",
                        "63",
                        "64",
                        "65",
                        "66",
                        "67",
                        "68",
                        "69",
                        "70",
                        "71",
                        "72",
                        "73",
                        "74",
                        "75",
                        "76",
                        "77",
                        "78",
                        "79",
                        "80",
                        "81",
                        "82",
                        "83",
                        "84",
                        "85",
                        "86",
                        "87",
                        "88",
                        "89",
                        "90",
                        "91",
                        "92",
                        "93",
                        "94",
                        "95",
                        "971",
                        "972",
                        "973",
                        "974",
                        "976"};

        
        class Mutation
        {
            public string id_mutation { get; set; }
            public int valeur_fonciere { get; set; }
            public int code_type_local { get; set; }
            public decimal surface_reelle_bati { get; set; }
            public decimal surface_terrain { get; set; }
            public int prix_metre_carre { get; set; }
            public int nombre_pieces_principales { get; set; }
        }

        class Communes
        {
            public string commune { get; set; }
            public List<StatsCommune> proprerties { get; set; }
        }

        class StatsCommune
        {
            public string year { get; set; }
            public StatsCommuneAnnee proprerties { get; set; }
        }

        class StatsCommuneAnnee
        {
            public Appartements appartements { get; set; }
            public Maisons maisons { get; set; }
        }

        class Appartements
        {
            public int nombre_vente { get; set; }
            public RepartitionPrix prix { get; set; }
            public RepartitionPrix prix_metre_carre { get; set; }
            public RepartitionSurfaceAppartement repartition_surface { get; set; }
            public RepartitionPiece repartition_piece { get; set; }
        }

        class Maisons
        {
            public Type_maison avec_terrain { get; set; }
            // Maison avec terrain
            public Type_maison sans_terrain { get; set; }
        }

        class Type_maison
        {
            public int nombre_vente { get; set; }
            public RepartitionPrix prix { get; set; }
            public RepartitionPrix prix_metre_carre { get; set; }
            public RepartitionSurfaceMaison repartition_surface { get; set; }
        }

        class RepartitionSurfaceAppartement
        {
            public int S0to30 { get; set; }
            public int S30to50 { get; set; }
            public int S50to70 { get; set; }
            public int S70to100 { get; set; }
            public int S100to150 { get; set; }
            public int S150to200 { get; set; }
            public int S200EP { get; set; }
        }

        class RepartitionSurfaceMaison
        {
            public int S0to50 { get; set; }
            public RepartitionPrix RS0to50 { get; set; }
            public int S50to100 { get; set; }
            public RepartitionPrix RS50to100 { get; set; }
            public int S100to150 { get; set; }
            public RepartitionPrix RS100to150 { get; set; }
            public int S150to200 { get; set; }
            public RepartitionPrix RS150to200 { get; set; }
            public int S200to250 { get; set; }
            public RepartitionPrix RS200to250 { get; set; }
            public int S250to300 { get; set; }
            public RepartitionPrix RS250to300 { get; set; }
            public int S300EP { get; set; }
            public RepartitionPrix RS300EP { get; set; }
        }

        class StatsParSurface
        {
            public List<int> RS0to50 { get; set; }
            public List<int> RS50to100 { get; set; }
            public List<int> RS100to150 { get; set; }
            public List<int> RS150to200 { get; set; }
            public List<int> RS200to250 { get; set; }
            public List<int> RS250to300 { get; set; }
            public List<int> RS300EP { get; set; }
        }

        class RepartitionPiece
        {
            public int PP1 { get; set; }
            public RepartitionPrix RPP1 { get; set; }
            public int PP2 { get; set; }
            public RepartitionPrix RPP2 { get; set; }
            public int PP3 { get; set; }
            public RepartitionPrix RPP3 { get; set; }
            public int PP4 { get; set; }
            public RepartitionPrix RPP4 { get; set; }
            public int PP5 { get; set; }
            public RepartitionPrix RPP5 { get; set; }
            public int PP6EP { get; set; }
            public RepartitionPrix RPP6 { get; set; }
        }

        class StatsParPiece
        {
            public List<int> PP1 { get; set; }
            public List<int> PP2 { get; set; }
            public List<int> PP3 { get; set; }
            public List<int> PP4 { get; set; }
            public List<int> PP5 { get; set; }
            public List<int> PP6EP { get; set; }
        }

        class RepartitionPrix
        {
            public int pmc_minimum { get; set; }
            public int pmc_maximum { get; set; }
            public int pmc_premier_quartile { get; set; }
            public int pmc_troisieme_quartile { get; set; }
            public int pmc_median { get; set; }
            public int pmc_moyen { get; set; }
        }

        private void BT_GETCODE_Click(object sender, RoutedEventArgs e)
        {
            PG_CODE_INSEE.Maximum = depart.Length;
            for (int i = 0; i < depart.Length; i++)
            {
                Application.Current.Dispatcher.Invoke(DispatcherPriority.ApplicationIdle, (Action)(() =>
                {
                    PG_CODE_INSEE.Value = i+1;
                    TB_FILENAME_CODE.Text = depart[i]+".json";
                }));
                List<string> code_insee = new List<string>();
                string file_path = @"C:\\Users\\Arouzmist-\\Desktop\\json\\lib\\commune\\"+ depart[i] + ".json";

                using (StreamReader r = new StreamReader(file_path))
                {
                    string Json = r.ReadToEnd();
                    JObject Jobj = JObject.Parse(Json);
                    JArray Jarr = JArray.Parse(Jobj["features"].ToString());

                    foreach (JObject z in Jarr)
                        code_insee.Add(z["properties"]["code"].ToString());
                }
                string ResultCode = JsonConvert.SerializeObject(code_insee.ToArray(), Formatting.Indented);
                string cipr = @"C:\\Users\\Arouzmist-\\Desktop\\json\\lib\\code_insee_par_region\\";
                File.WriteAllText(cipr + depart[i] + "-CODES.json", ResultCode);
            }
            TB_FILENAME_CODE.Text = "Terminé !";
        }

        private void BT_PROCESS_Click(object sender, RoutedEventArgs e)
        {
            PG_BAR.Maximum = depart.Length;
            for (int i = 0; i < depart.Length; i++)
            {
                Application.Current.Dispatcher.Invoke(DispatcherPriority.ApplicationIdle, (Action)(() =>
                {
                    PG_BAR.Value = i + 1;
                    TB_REGION.Text = depart[i];
                }));
                string code_file_path = "";
                if (depart[i] == "75")
                    code_file_path = @"C:\\Users\\Arouzmist-\\Desktop\\json\\lib\\code_insee_par_region\\paris-arrondissements.json";
                else if (depart[i] == "13")
                    code_file_path = @"C:\\Users\\Arouzmist-\\Desktop\\json\\lib\\code_insee_par_region\\marseille-arrondissements.json";
                else if (depart[i] == "69")
                    code_file_path = @"C:\\Users\\Arouzmist-\\Desktop\\json\\lib\\code_insee_par_region\\lyon-arrondissements.json";
                else
                    code_file_path = @"C:\\Users\\Arouzmist-\\Desktop\\json\\lib\\code_insee_par_region\\" + depart[i] + "-CODES.json";

                using (StreamReader r = new StreamReader(code_file_path))
                {
                    string JsonCodes = r.ReadToEnd();
                    string[] Codes = JsonConvert.DeserializeObject<string[]>(JsonCodes);
                    PG_REGION.Maximum = Codes.Length;
                    for (int j = 0; j < Codes.Length; j++)
                    {
                        Application.Current.Dispatcher.Invoke(DispatcherPriority.ApplicationIdle, (Action)(() =>
                        {
                            PG_REGION.Value = j + 1;
                        }));
                        for (int k = 2014; k < 2021; k++)
                        {
                            Application.Current.Dispatcher.Invoke(DispatcherPriority.ApplicationIdle, (Action)(() =>
                            {
                                TB_REGION_FILE.Text = Codes[j] + "-" + k.ToString();
                            }));
                            string csv_file_path = @"C:\\Users\\Arouzmist-\\Desktop\\json\\lib\\data\\" + k.ToString() + "\\communes\\" + depart[i] +"\\" + Codes[j] + ".csv";
                            if (File.Exists(csv_file_path))
                            {
                                var csv = new List<string[]>();
                                var lines = File.ReadAllLines(csv_file_path);

                                foreach (string line in lines)
                                    csv.Add(line.Split(','));

                                var properties = lines[0].Split(',');

                                var listObjResult = new List<Dictionary<string, string>>();

                                for (int l = 1; l < lines.Length; l++)
                                {
                                    var objResult = new Dictionary<string, string>();
                                    for (int m = 0; m < properties.Length; m++)
                                        objResult.Add(properties[m], csv[l][m]);

                                    listObjResult.Add(objResult);
                                }

                                string root = @"C:\\Users\\Arouzmist-\\Desktop\\json\\data_json\\"+ k.ToString() + "\\";
                                string sous_dossier_departement = root + depart[i] + "\\";
                                // Create a sub directory
                                if (!Directory.Exists(sous_dossier_departement))
                                {
                                    Directory.CreateDirectory(sous_dossier_departement);
                                }
                                var jsonString = JsonConvert.SerializeObject(listObjResult);
                                File.WriteAllText("C:\\Users\\Arouzmist-\\Desktop\\json\\data_json\\" + k.ToString() +"\\" + depart[i] + "\\" + Codes[j] + ".json", jsonString);
                            }
                        }
                    }
                }
            }
            TB_REGION.Text = "Terminé !";
            TB_REGION_FILE.Text = "Terminé !";
        }
    
        private void BT_STATS_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < depart.Length; i++)
            {
                // Une liste d'object "Communes" est créé pour la région
                List<Communes> Liste_Communes = new List<Communes>();
                Application.Current.Dispatcher.Invoke(DispatcherPriority.ApplicationIdle, (Action)(() =>
                {
                    PG_STATS.Value = i + 1;
                    TB_STATS_CHECK.Text = depart[i];
                }));
                string code_file_path = "";

                if (depart[i] == "75")
                    code_file_path = @"C:\\Users\\Arouzmist-\\Desktop\\json\\lib\\code_insee_par_region\\paris-arrondissements.json";
                else if (depart[i] == "13")
                    code_file_path = @"C:\\Users\\Arouzmist-\\Desktop\\json\\lib\\code_insee_par_region\\marseille-arrondissements.json";
                else if (depart[i] == "69")
                    code_file_path = @"C:\\Users\\Arouzmist-\\Desktop\\json\\lib\\code_insee_par_region\\lyon-arrondissements.json";
                else
                    code_file_path = @"C:\\Users\\Arouzmist-\\Desktop\\json\\lib\\code_insee_par_region\\" + depart[i] + "-CODES.json";

                using (StreamReader r = new StreamReader(code_file_path))
                {
                    string JsonCodes = r.ReadToEnd();
                    string[] Codes = JsonConvert.DeserializeObject<string[]>(JsonCodes);
                    PG_REGION_STATS.Maximum = Codes.Length;
                    // Boucle sur la liste des communes de la région
                    for (int j = 0; j < Codes.Length; j++)
                    {
                        // Créer un object commune
                        Communes RC = new Communes();
                        RC.commune = Codes[j];
                        //ICI UN FICHIER POUR CHAQUE VILLE
                        Application.Current.Dispatcher.Invoke(DispatcherPriority.ApplicationIdle, (Action)(() =>
                        {
                            PG_REGION_STATS.Value = j + 1;
                        }));

                        //StatsCommune SCommune = new StatsCommune();
                        List<StatsCommune> Scommune = new List<StatsCommune>();
                        for (int k = 2014; k < 2021; k++)
                        {
                            StatsCommune SC = new StatsCommune();
                            SC.year = k.ToString();
                            Application.Current.Dispatcher.Invoke(DispatcherPriority.ApplicationIdle, (Action)(() =>
                            {
                                TB_REGION_FILE_STATS.Text = Codes[j] + "-" + k.ToString();
                            }));
                            // Selectionne une commune
                            string filename_json = @"C:\\Users\\Arouzmist-\\Desktop\\json\\data_json\\" + k.ToString() + "\\" + depart[i] + "\\" + Codes[j] + ".json";
                            if (File.Exists(filename_json))
                            {
                                using (StreamReader v = new StreamReader(filename_json))
                                {
                                    string JsonFile = v.ReadToEnd();
                                    JArray ArrJson = JArray.Parse(JsonFile);

                                    // La class qui sera convertie en Json, c'est elle qui contient toutes les statistiques
                                    StatsCommuneAnnee StatsCommuneA = new StatsCommuneAnnee();
                                    
                                    // Un premier sous objet qui contiendra les statistiques des maisons
                                    Maisons Maisons = new Maisons();
                                    // Le deuxième sous objet qui contiendra les statistiques des appartements
                                    Appartements Appartements = new Appartements();

                                    // Les sous objet de l'objet Maisons, l'un stockeras les stats des maisons sans terrain alors que l'autre celle qui possède un terrain
                                    Type_maison Maison = new Type_maison();
                                    Type_maison Maison_terrain = new Type_maison();

                                    // Deux sous objet qui contiendront une repartition des surfaces habitables
                                    RepartitionSurfaceMaison RSM = new RepartitionSurfaceMaison();
                                    RepartitionSurfaceMaison RSMT = new RepartitionSurfaceMaison();

                                    // Deux sous objet qui contiendront une repartition des prix en fonction de la surface habitable
                                    StatsParSurface SPSM = new StatsParSurface();
                                    StatsParSurface SPSMT = new StatsParSurface();
                                    SPSM = setListSPS(SPSM);
                                    SPSMT = setListSPS(SPSMT);

                                    // Sous objet de appartements, il contiendra la repartition des ventes par nombre de pièces
                                    RepartitionPiece RPA = new RepartitionPiece();
                                    // Sous objet de appartements, il contiendra une repartition des surfaces habitables
                                    RepartitionSurfaceAppartement RSA = new RepartitionSurfaceAppartement();
                                    // Sous objet de RepartitionPiece, il contiendra une repartition des prix en fonction du nombre de pièce
                                    StatsParPiece SPPA = new StatsParPiece();
                                    SPPA = setListSPP(SPPA);

                                    // Liste qui aura pour but de stocker toutes les mutations
                                    List<Mutation> mutas = new List<Mutation>();
                                    // Liste qui contiendra toutes les id qui seront présentent plus d'une fois
                                    List<string> duplicate_id = new List<string>();

                                    foreach (var item in ArrJson)
                                    {
                                        string stritem = item.ToString();
                                        var res = JObject.Parse(stritem);

                                        // Gestion des doublons, ils seront stockés dans une liste : duplicate_id
                                        for (int x = 0; x < mutas.Count; x++)
                                            if (mutas[x].id_mutation == res["id_mutation"].ToString())
                                                duplicate_id.Add(mutas[x].id_mutation);

                                        int valeur_f = 0,
                                            surface_rb = 0,
                                            code_tl = 0,
                                            nombre_p = 0;

                                       
                                        if (!Int32.TryParse(res["valeur_fonciere"].ToString(), out valeur_f))
                                            continue;
                                        if (!Int32.TryParse(res["surface_reelle_bati"].ToString(), out surface_rb))
                                            continue;
                                        if (!Int32.TryParse(res["nombre_pieces_principales"].ToString(), out nombre_p))
                                            continue;
                                        if (!Int32.TryParse(res["code_type_local"].ToString(), out code_tl))
                                            continue;
                                        if (valeur_f / surface_rb < 1)
                                            continue;
                                        // On ne garde que les appartements et les maisons
                                        if (code_tl != 1 && code_tl != 2)
                                            continue;

                                        // Créer un objet mutation puis lui accorde ses valeurs
                                        Mutation mutation = new Mutation
                                        {
                                            id_mutation = res["id_mutation"].ToString(),
                                            valeur_fonciere = valeur_f,
                                            code_type_local = code_tl,
                                            surface_reelle_bati = surface_rb,
                                            surface_terrain = res["surface_terrain"].ToString().Length > 0 ? Convert.ToDecimal(res["surface_terrain"].ToString()) : 0,
                                            prix_metre_carre = valeur_f / surface_rb,
                                            nombre_pieces_principales = nombre_p
                                        };

                                        mutas.Add(mutation);
                                    }
                                    // Transforme la liste en un tableau de mutations
                                    Mutation[] mutations = mutas.ToArray();
                                    // Retrait des doublons et des valeurs nulles
                                    mutations = mutations.Where(val => val != null && duplicate_id.IndexOf(val.id_mutation) == -1).ToArray();

                                    List<int>   PrixGMaison = new List<int>(),
                                                PrixGAppartement = new List<int>(),
                                                PrixMCMaison = new List<int>(),
                                                PrixMCAppartement = new List<int>(),
                                                PrixGMaisonTerrain = new List<int>(),
                                                PrixMCMaisonTerrain = new List<int>();


                                    foreach (Mutation muta in mutations)
                                    {
                                        if (muta.code_type_local == 2)
                                        {
                                            PrixGAppartement.Add(Decimal.ToInt32(muta.valeur_fonciere));
                                            PrixMCAppartement.Add(muta.prix_metre_carre);
                                            RSA = RSurfaceAppartement(RSA, muta.surface_reelle_bati);
                                            RPA = RPiece(RPA, muta.nombre_pieces_principales, muta.prix_metre_carre, SPPA);
                                        }
                                        else
                                        {
                                            if (muta.surface_terrain <= 0)
                                            {
                                                PrixGMaison.Add(Decimal.ToInt32(muta.valeur_fonciere));
                                                PrixMCMaison.Add(muta.prix_metre_carre);
                                                RSM = RSurfaceMaison(RSM, muta.surface_reelle_bati, muta.prix_metre_carre, SPSM);
                                            }
                                            else
                                            {
                                                PrixGMaisonTerrain.Add(Decimal.ToInt32(muta.valeur_fonciere));
                                                PrixMCMaisonTerrain.Add(muta.prix_metre_carre);
                                                RSMT = RSurfaceMaison(RSMT, muta.surface_reelle_bati, muta.prix_metre_carre, SPSMT);
                                            }
                                        }
                                    }

                                    // Repartition des prix par nombre de piece
                                    // Traitement uniquement appliqué aux appartements
                                    TamponSPP(SPPA, RPA);

                                    // Repartition des prix par surface habitable
                                    // Traitement uniquement appliqué aux maisons
                                    TamponSPS(SPSM, RSM);
                                    TamponSPS(SPSMT, RSMT);

                                    if (PrixGAppartement.Count > 0)
                                        StatsCommuneA.appartements = MakeStatsAppartement(Appartements, RPA, RSA, PrixGAppartement, PrixMCAppartement);
                                    if (PrixGMaison.Count > 0)
                                        Maisons.sans_terrain = MakeStatsMaison(Maison, RSM, PrixGMaison, PrixMCMaison);
                                    if (PrixGMaisonTerrain.Count > 0)
                                        Maisons.avec_terrain = MakeStatsMaison(Maison_terrain, RSMT, PrixGMaisonTerrain, PrixMCMaisonTerrain);

                                    StatsCommuneA.maisons = Maisons;

                                    SC.proprerties = StatsCommuneA;
                                }
                            }
                            // Ajoute les statistiques de l'année aux stats globales de la commune
                            Scommune.Add(SC);
                        }
                        // Une fois toutes les années de la commune enregistré nous créons le fichier
                        string root_c = @"C:\\Users\\Arouzmist-\\Desktop\\json\\\statistiques\\";
                        string root_code_c = root_c + depart[i] + "\\";
                        string Result = JsonConvert.SerializeObject(Scommune.ToArray(), Formatting.Indented);
                        // Create a sub directory
                        if (!Directory.Exists(root_code_c))
                            Directory.CreateDirectory(root_code_c);
                        File.WriteAllText(root_code_c + Codes[j] + ".json", Result);

                        RC.proprerties = Scommune;
                        Liste_Communes.Add(RC);
                    }
                }
                // Création des stats par régions
                string root_r = @"C:\\Users\\Arouzmist-\\Desktop\\json\\\statistiques\\";
                string root_code_r = root_r + depart[i] + "\\_all\\";
                // Create a sub directory
                if (!Directory.Exists(root_code_r))
                    Directory.CreateDirectory(root_code_r);
                string R = JsonConvert.SerializeObject(Liste_Communes.ToArray(), Formatting.Indented);
                File.WriteAllText(root_code_r + depart[i] + ".json", R);

            }
            TB_STATS_CHECK.Text = "Terminé !";
            TB_REGION_FILE_STATS.Text = "Terminé !";
        }


        private void BT_DEBUG_Click(object sender, RoutedEventArgs e)
        {
            string code_file_path = @"C:\\Users\\Arouzmist-\\Desktop\\json\\lib\\data\\arrondissement.json";
            List<string> paris_arrondissements = new List<string>();
            List<string> marseille_arrondissements = new List<string>();
            List<string> lyon_arrondissements = new List<string>();
            using (StreamReader r = new StreamReader(code_file_path))
            {
                string Json = r.ReadToEnd();
                JObject Jobj = JObject.Parse(Json);
                JArray Jarr = JArray.Parse(Jobj["features"].ToString());

                foreach (JObject z in Jarr)
                {
                    if (z["properties"]["code"].ToString().Substring(0,2) == "75")
                        paris_arrondissements.Add(z["properties"]["code"].ToString());
                    if (z["properties"]["code"].ToString().Substring(0, 2) == "13")
                        marseille_arrondissements.Add(z["properties"]["code"].ToString());
                    if (z["properties"]["code"].ToString().Substring(0, 2) == "69")
                        lyon_arrondissements.Add(z["properties"]["code"].ToString());

                }
            }

            string ParisCode = JsonConvert.SerializeObject(paris_arrondissements.ToArray(), Formatting.Indented);
            string MarseilleCode = JsonConvert.SerializeObject(marseille_arrondissements.ToArray(), Formatting.Indented);
            string LyonCode = JsonConvert.SerializeObject(lyon_arrondissements.ToArray(), Formatting.Indented);
            string cipr = @"C:\\Users\\Arouzmist-\\Desktop\\json\\lib\\code_insee_par_region\\";
            File.WriteAllText(cipr+"paris-arrondissements.json", ParisCode);
            File.WriteAllText(cipr + "marseille-arrondissements.json", MarseilleCode);
            File.WriteAllText(cipr + "lyon-arrondissements.json", LyonCode);
        }

        private Appartements MakeStatsAppartement(Appartements b, RepartitionPiece rp, RepartitionSurfaceAppartement rs, List<int> pga, List<int> pmca)
        {
            b.nombre_vente = pga.Count;
            b.prix = MakeRP(pga);
            b.prix_metre_carre = MakeRP(pmca);
            b.repartition_piece = rp;
            b.repartition_surface = rs;
            return b;
        }

        private Type_maison MakeStatsMaison(Type_maison b, RepartitionSurfaceMaison rs, List<int> pga, List<int> pmca)
        {
            b.nombre_vente = pga.Count;
            b.prix = MakeRP(pga);
            b.prix_metre_carre = MakeRP(pmca);
            b.repartition_surface = rs;
            return b;
        }

        private RepartitionSurfaceAppartement RSurfaceAppartement(RepartitionSurfaceAppartement RS, decimal s)
        {
            if (s < 31)
                RS.S0to30++;
            else if (s < 51)
                RS.S30to50++;
            else if (s < 71)
                RS.S50to70++;
            else if (s < 101)
                RS.S70to100++;
            else if (s < 151)
                RS.S100to150++;
            else if (s < 201)
                RS.S150to200++;
            else
                RS.S200EP++;

            return RS;
        }

        private RepartitionSurfaceMaison RSurfaceMaison(RepartitionSurfaceMaison RS, decimal s, int pmc, StatsParSurface SPS)
        {
            if (s < 51)
            {
                RS.S0to50++;
                SPS.RS0to50.Add(pmc);
            }
            else if (s < 101)
            {
                RS.S50to100++;
                SPS.RS50to100.Add(pmc);
            }
            else if (s < 151)
            {
                RS.S100to150++;
                SPS.RS100to150.Add(pmc);
            }
            else if (s < 201)
            {
                RS.S150to200++;
                SPS.RS150to200.Add(pmc);
            }
            else if (s < 251)
            {
                RS.S200to250++;
                SPS.RS200to250.Add(pmc);
            }
            else if (s < 301)
            {
                RS.S250to300++;
                SPS.RS250to300.Add(pmc);
            }
            else
            {
                RS.S300EP++;
                SPS.RS300EP.Add(pmc);
            }

            return RS;
        }

        private RepartitionPrix MakeRP(List<int> li)
        {
            RepartitionPrix RPPP = new RepartitionPrix();
            if (li.Count > 0)
            {
                int[] arr = ListToSortedArr(li);
                RPPP.pmc_maximum = arr.Last();
                RPPP.pmc_minimum = arr.First();
                RPPP.pmc_median = getMedianne(arr);
                RPPP.pmc_moyen = getMoyenne(arr);
                RPPP.pmc_premier_quartile = getQ1(arr);
                RPPP.pmc_troisieme_quartile = getQ3(arr);
            } else
            {
                RPPP = null;
            }
            return RPPP;
        }

        private void TamponSPP(StatsParPiece SPP, RepartitionPiece RP)
        {
            RP.RPP1 = MakeRP(SPP.PP1);
            RP.RPP2 = MakeRP(SPP.PP2);
            RP.RPP3 = MakeRP(SPP.PP3);
            RP.RPP4 = MakeRP(SPP.PP4);
            RP.RPP5 = MakeRP(SPP.PP5);
            RP.RPP6 = MakeRP(SPP.PP6EP);
        }

        private void TamponSPS(StatsParSurface SPS, RepartitionSurfaceMaison RSM)
        {
            RSM.RS0to50 = MakeRP(SPS.RS0to50);
            RSM.RS50to100 = MakeRP(SPS.RS50to100);
            RSM.RS100to150 = MakeRP(SPS.RS100to150);
            RSM.RS150to200 = MakeRP(SPS.RS150to200);
            RSM.RS200to250 = MakeRP(SPS.RS200to250);
            RSM.RS250to300 = MakeRP(SPS.RS250to300);
            RSM.RS300EP = MakeRP(SPS.RS300EP);
        }

        // Retourne un tableau trié à partir d'une list d'int
        private int[] ListToSortedArr(List<int> List)
        {
            int[] Arr = List.ToArray();
            Array.Sort(Arr);
            return Arr;
        }
        // Retourne le troisème quartile d'un array d'int
        private int getQ3(int[] Arr)
        {
            return Arr[(int)(Arr.Length * 0.75)];
        }
        // Retourne le premier quartile d'un array d'int
        private int getQ1(int[] Arr)
        {
            return Arr[(int)(Arr.Length * 0.25)];
        }
        // Retourne la moyenne d'un array d'int
        private int getMoyenne(int[] Arr)
        {
            return Arr.Sum() / Arr.Length;
        }
        // Retourne la médianne d'un array d'int
        private int getMedianne(int[] Arr)
        {
            return Arr[Arr.Length / 2];
        }

        private StatsParPiece setListSPP(StatsParPiece SPS)
        {
            SPS.PP1 = new List<int>();
            SPS.PP2 = new List<int>();
            SPS.PP3 = new List<int>();
            SPS.PP4 = new List<int>();
            SPS.PP5 = new List<int>();
            SPS.PP6EP = new List<int>();
            return SPS;
        }

        private StatsParSurface setListSPS(StatsParSurface SPS)
        {
            SPS.RS0to50 = new List<int>();
            SPS.RS50to100 = new List<int>();
            SPS.RS100to150 = new List<int>();
            SPS.RS150to200 = new List<int>();
            SPS.RS200to250 = new List<int>();
            SPS.RS250to300 = new List<int>();
            SPS.RS300EP = new List<int>();
            return SPS;
        }

        private RepartitionPiece RPiece(RepartitionPiece RP, int s, int pmc, StatsParPiece spp)
        {
            if (s > 0 && s < 2)
            {
                RP.PP1++;
                spp.PP1.Add(pmc);
            }
            else if (s < 3)
            {
                RP.PP2++;
                spp.PP2.Add(pmc);
            }
            else if (s < 4)
            {
                RP.PP3++;
                spp.PP3.Add(pmc);
            }
            else if (s < 5)
            {
                RP.PP4++;
                spp.PP4.Add(pmc);
            } 
            else if (s < 6)
            {
                RP.PP5++;
                spp.PP5.Add(pmc);
            }
            else
            {
                RP.PP6EP++;
                spp.PP6EP.Add(pmc);
            }

            return RP;
        }
    }
}

//b.prix_minimum = pga.First();
//b.prix_maximum = pga.Last();
//b.prix_mediant = pga[pga.Length / 2];
//b.prix_moyen = pg / pga.Length;
//b.prix_premier_quartile = pga[(int)(pga.Length * 0.25)];
//b.prix_troisieme_quartile = pga[(int)(pga.Length * 0.75)];

//b.pmc_minimum = pmca.First();
//b.pmc_maximum = pmca.Last();
//b.pmc_mediant = pmca[pmca.Length / 2];
//b.pmc_moyen = pmc / pmca.Length;
//b.pmc_premier_quartile = pmca[(int)(pmca.Length * 0.25)];
//b.pmc_troisieme_quartile = pmca[(int)(pmca.Length * 0.75)];

//public int pmc_minimum { get; set; }
//public int pmc_maximum { get; set; }
//public int pmc_premier_quartile { get; set; }
//public int pmc_troisieme_quartile { get; set; }
//public int pmc_mediant { get; set; }
//public int pmc_moyen { get; set; }


//File.Exists(curFile)
//{ "id_mutation"
//"date_mutation"
//"numero_disposition"
//"valeur_fonciere"
//"adresse_numero"
//"adresse_suffixe"
//"adresse_code_voie"
//"adresse_nom_voie"
//"code_postal"
//"code_commune"
//"nom_commune"
//"ancien_code_commune"
//"ancien_nom_commune"
//"code_departement"
//"id_parcelle"
//"ancien_id_parcelle"
//"numero_volume"
//"lot_1_numero"
//"lot_1_surface_carrez"
//"lot_2_numero"
//"lot_2_surface_carrez"
//"lot_3_numero"
//"lot_3_surface_carrez"
//"lot_4_numero"
//"lot_4_surface_carrez"
//"lot_5_numero"
//"lot_5_surface_carrez"
//"nombre_lots"
//"code_type_local"
//"type_local"
//"surface_reelle_bati"
//"nombre_pieces_principales"
//"code_nature_culture"
//"nature_culture"
//"code_nature_culture_speciale"
//"nature_culture_speciale"
//"surface_terrain"
//"longitude"
//"latitude"



