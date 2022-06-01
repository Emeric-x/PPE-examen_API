using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using classes_outils;
using System.Data; //Dataset

namespace classes_metier
{
    #region Cemploye
    public abstract class Cemploye
    {
        protected Cemploye(string sid, string snom, string sprenom, string slogin, string smdp, string sadresse, int scp, string sville, DateTime sdateEmbauche, string smdp_hash, char sregion)
        {
            Id = sid;
            Nom = snom;
            Prenom = sprenom;
            Login = slogin;
            Mdp = smdp;
            Adresse = sadresse;
            Cp = scp;
            Ville = sville;
            DateEmbauche = sdateEmbauche;
            Mdp_hash = smdp_hash;
            Region = sregion;
        }

        public string Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Login { get; set; }
        public string Mdp { get; set; }
        public string Adresse { get; set; }
        public int Cp { get; set; }
        public string Ville { get; set; }
        public DateTime DateEmbauche { get; set; }
        public string Mdp_hash { get; set; }
        public char Region { get; set; }
    }
    #endregion

    #region Cvisiteur
    public class Cvisiteur : Cemploye
    {
        public Cvisiteur(string sid, string snom, string sprenom, string slogin, string smdp, string sadresse, int scp, string sville, DateTime sdateEmbauche, string smdp_hash, char sregion)
            : base (sid, snom, sprenom, slogin, smdp, sadresse, scp, sville, sdateEmbauche, smdp_hash, sregion)
        {

        }
    }

    public class Cvisiteurs
    {
        public List<Cvisiteur> oListVisiteurs { get; set; } = new List<Cvisiteur>();
        private Cvisiteurs()
        {
            Cdao odao = new Cdao();
            string query = "call SelectVisiteurs()";
            MySqlDataReader ord = odao.getReader(query);
            while (ord.Read())
            {
                Cvisiteur ovisiteur = new Cvisiteur(Convert.ToString(ord["id"]), Convert.ToString(ord["nom"]), Convert.ToString(ord["prenom"]), Convert.ToString(ord["login"]), Convert.ToString(ord["mdp"]), Convert.ToString(ord["adresse"]), Convert.ToInt32(ord["cp"]), Convert.ToString(ord["ville"]), Convert.ToDateTime(ord["dateEmbauche"]), Convert.ToString(ord["mdp_hash"]), Convert.ToChar(ord["region"]));
                oListVisiteurs.Add(ovisiteur);
            }
        }

        private static Cvisiteurs Instance = null;
        public static Cvisiteurs getInstance()
        {
            if (Instance == null)
            {
                Instance = new Cvisiteurs();
                return Instance;
            }
            else
            {
                return Instance;
            }
        }

        public Cvisiteur GetVisiteur(string slogin)
        {
            Cvisiteur ovisiteur = null;

            foreach(Cvisiteur oUnvisiteur in oListVisiteurs)
            {
                if(oUnvisiteur.Login == slogin)
                {
                    ovisiteur = oUnvisiteur;
                }
            }

            return ovisiteur;
        }
    }
    #endregion

    #region CchefRegion
    public class CchefRegion : Cemploye
    {
        public CchefRegion(string sid, string snom, string sprenom, string slogin, string smdp, string sadresse, int scp, string sville, DateTime sdateEmbauche, string smdp_hash, char sregion)
           : base(sid, snom, sprenom, slogin, smdp, sadresse, scp, sville, sdateEmbauche, smdp_hash, sregion)
        {

        }
    }

    public class CchefRegions
    {
        public List<CchefRegion> oListChefs { get; set; } = new List<CchefRegion>();
        private CchefRegions()
        {
            Cdao odao = new Cdao();
            string query = "call SelectChefsRegion()";
            MySqlDataReader ord = odao.getReader(query);
            while (ord.Read())
            {
                CchefRegion ochefRegion = new CchefRegion(Convert.ToString(ord["id"]), Convert.ToString(ord["nom"]), Convert.ToString(ord["prenom"]), Convert.ToString(ord["login"]), Convert.ToString(ord["mdp"]), Convert.ToString(ord["adresse"]), Convert.ToInt32(ord["cp"]), Convert.ToString(ord["ville"]), Convert.ToDateTime(ord["dateEmbauche"]), Convert.ToString(ord["mdp_hash"]), Convert.ToChar(ord["region"]));
                oListChefs.Add(ochefRegion);
            }
        }

        private static CchefRegions Instance = null;
        public static CchefRegions getInstance()
        {
            if (Instance == null)
            {
                Instance = new CchefRegions();
                return Instance;
            }
            else
            {
                return Instance;
            }
        }

        public CchefRegion GetChef(string slogin)
        {
            CchefRegion ochefRegion = null;

            foreach (CchefRegion oUnChef in oListChefs)
            {
                if (oUnChef.Login == slogin)
                {
                    ochefRegion = oUnChef;
                }
            }

            return ochefRegion;
        }
    }
    #endregion

    #region Ccomptable
    public class Ccomptable : Cemploye
    {
        public Ccomptable(string sid, string snom, string sprenom, string slogin, string smdp, string sadresse, int scp, string sville, DateTime sdateEmbauche, string smdp_hash, char sregion)
            : base(sid, snom, sprenom, slogin, smdp, sadresse, scp, sville, sdateEmbauche, smdp_hash, sregion)
        {

        }
    }

    public class Ccomptables
    {
        public List<Ccomptable> oListComptables { get; set; } = new List<Ccomptable>();
        private Ccomptables()
        {
            Cdao odao = new Cdao();
            string query = "call SelectComptables()";
            MySqlDataReader ord = odao.getReader(query);
            while (ord.Read())
            {
                Ccomptable oComptable = new Ccomptable(Convert.ToString(ord["id"]), Convert.ToString(ord["nom"]), Convert.ToString(ord["prenom"]), Convert.ToString(ord["login"]), Convert.ToString(ord["mdp"]), Convert.ToString(ord["adresse"]), Convert.ToInt32(ord["cp"]), Convert.ToString(ord["ville"]), Convert.ToDateTime(ord["dateEmbauche"]), Convert.ToString(ord["mdp_hash"]), Convert.ToChar(ord["region"]));
                oListComptables.Add(oComptable);
            }
        }

        private static Ccomptables Instance = null;
        public static Ccomptables getInstance()
        {
            if (Instance == null)
            {
                Instance = new Ccomptables();
                return Instance;
            }
            else
            {
                return Instance;
            }
        }
    }
    #endregion

    #region Cmedicament
    public class Cmedicament
    {
        public Cmedicament(string id, string nom, string photo, string description, string categorie)
        {
            Id = id;
            Nom = nom;
            Photo = photo;
            Description = description;
            Categorie = categorie;
        }

        public string Id { get; set; }
        public string Nom { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public string Categorie { get; set; }
    }

    public class Cmedicaments
    {
        public List<Cmedicament> oListMedicaments { get; set; } = new List<Cmedicament>();
        private Cmedicaments()
        {
            Cdao odao = new Cdao();
            string query = "call SelectMedicaments()";
            MySqlDataReader ord = odao.getReader(query);
            while (ord.Read())
            {
                Cmedicament omedicament = new Cmedicament(Convert.ToString(ord["id"]), Convert.ToString(ord["nom"]), Convert.ToBase64String((byte[]) ord["photo"]), Convert.ToString(ord["description"]), Convert.ToString(ord["categorie"]));
                oListMedicaments.Add(omedicament);
            }
        }

        private static Cmedicaments Instance = null;
        public static Cmedicaments getInstance()
        {
            if (Instance == null)
            {
                Instance = new Cmedicaments();
                return Instance;
            }
            else
            {
                return Instance;
            }
        }
    }
    #endregion

    #region Cnote
    public class Cnote
    {
        public Cnote(int id, string id_visit, string id_med, string note)
        {
            Id = id;
            Id_visit = id_visit;
            Id_med = id_med;
            Note = note;
        }

        public int Id { get; set; }
        public string Id_visit { get; set; }
        public string Id_med { get; set; }
        public string Note { get; set; }
    }

    public class Cnotes
    {
        public List<Cnote> oListNotes { get; set; } = new List<Cnote>();
        public Cnotes() // constructeur en public pour pouvoir récupérer les notes mises à jour une fois modifiées
        {
            Cdao odao = new Cdao();
            string query = "call SelectNote()";
            MySqlDataReader ord = odao.getReader(query);
            while (ord.Read())
            {
                Cnote onote = new Cnote(Convert.ToInt16(ord["id"]), Convert.ToString(ord["id_visit"]), Convert.ToString(ord["id_med"]), Convert.ToString(ord["note"]));
                oListNotes.Add(onote);
            }
        }

        private static Cnotes Instance = null;
        public static Cnotes getInstance()
        {
            if (Instance == null)
            {
                Instance = new Cnotes();
                return Instance;
            }
            else
            {
                return Instance;
            }
        }

        public int UpdateNote(string sText, string sId_med, string sId_visit)
        {
            Cdao odao = new Cdao();
            string query = $"call UpdateNote('{sId_visit}', '{sId_med}', '{sText}')";
            int nbEnregAffecte = odao.updateEnreg(query);

            /*
             Ici, on ne peut pas simplement inserer la note dans la liste car elle y est déjà
             il faut faire un nouvel appel à la base pour y récupérer sa modification
             */

            return nbEnregAffecte;
        }

        public int InsertNote(string sText, string sId_med, string sId_visit)
        {
            Cdao odao = new Cdao();
            string query = $"call InsertNote('{sId_visit}', '{sId_med}', '{sText}')";
            int nbEnregAffecte = odao.insertEnreg(query);

            /* 
             Pour éviter de faire un nouvel appel à la base, on créer un nouvel objet que l'on ajoute manuellement
             à la liste
             Dans la query id=NULL car autoincrement
             Ci-dessous id=oListNotes.Count+1 (obligé d'y spécifier pour éviter un nouvel appel à la base)
             */
            Cnote onote = new Cnote(oListNotes.Count+1, sId_visit, sId_med, sText);
            oListNotes.Add(onote);

            return nbEnregAffecte;
        }
    }
    #endregion

    #region Cmedecin
    public class Cmedecin
    {
        public Cmedecin(int id, string nom, string prenom, string adresse, int cp, string ville)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            Cp = cp;
            Ville = ville;
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public int Cp { get; set; }
        public string Ville { get; set; }
    }

    public class Cmedecins
    {
        public List<Cmedecin> oListMedecins { get; set; } = new List<Cmedecin>();
        private Cmedecins()
        {
            Cdao odao = new Cdao();
            string query = "call SelectMedecins()";
            MySqlDataReader ord = odao.getReader(query);
            while (ord.Read())
            {
                Cmedecin omedecin = new Cmedecin(Convert.ToInt16(ord["id"]), Convert.ToString(ord["nom"]), Convert.ToString(ord["prenom"]), Convert.ToString(ord["adresse"]), Convert.ToInt32(ord["cp"]), Convert.ToString(ord["ville"]));
                oListMedecins.Add(omedecin);
            }
        }

        private static Cmedecins Instance = null;
        public static Cmedecins getInstance()
        {
            if (Instance == null)
            {
                Instance = new Cmedecins();
                return Instance;
            }
            else
            {
                return Instance;
            }
        }
    }
    #endregion

    #region CcompteRendu
    public class CcompteRendu
    {
        public CcompteRendu(int id, string id_visit, string lienFichier, string anneeMois)
        {
            Id = id;
            Id_visit = id_visit;
            LienFichier = lienFichier;
            AnneeMois = anneeMois;
        }

        public int Id { get; set; }
        public string Id_visit { get; set; }
        public string LienFichier { get; set; }
        public string AnneeMois { get; set; }
    }

    public class CcompteRendus
    {
        public List<CcompteRendu> oListCompteRendus { get; set; } = new List<CcompteRendu>();
        private CcompteRendus()
        {
            Cdao odao = new Cdao();
            string query = "call SelectCompteRendu()";
            MySqlDataReader ord = odao.getReader(query);
            while (ord.Read())
            {
                CcompteRendu ocompteRendu = new CcompteRendu(Convert.ToInt16(ord["id"]), Convert.ToString(ord["id_visit"]), Convert.ToString(ord["lienFichier"]), Convert.ToString(ord["anneeMois"]));
                oListCompteRendus.Add(ocompteRendu);
            }
        }

        private static CcompteRendus Instance = null;
        public static CcompteRendus getInstance()
        {
            if (Instance == null)
            {
                Instance = new CcompteRendus();
                return Instance;
            }
            else
            {
                return Instance;
            }
        }

        public int ajouterCompteRendu(CcompteRendu soCompteRendu)
        {
            Cdao odao = new Cdao();
            string query = $"call InsertCompteRendu('{soCompteRendu.Id_visit}', '{soCompteRendu.LienFichier}', '{soCompteRendu.AnneeMois}')";
            int nbEnregAffecte = odao.insertEnreg(query);

            /* 
             Pour éviter de faire un nouvel appel à la base, on créer un nouvel objet que l'on ajoute manuellement
             à la liste
            */
            CcompteRendu oCompteRendu = new CcompteRendu(oListCompteRendus.Count()+1, soCompteRendu.Id_visit, soCompteRendu.LienFichier, soCompteRendu.AnneeMois);
            oListCompteRendus.Add(oCompteRendu);

            return nbEnregAffecte;
        }
    }
    #endregion

    #region Cpresenter
    public class Cpresenter
    {
        public Cpresenter(string id_med, string id_visit, int id_medecin, string anneeMois, bool isVisite)
        {
            Id_med = id_med;
            Id_visit = id_visit;
            Id_medecin = id_medecin;
            AnneeMois = anneeMois;
            IsVisite = isVisite;
        }

        public string Id_med { get; set; }
        public string Id_visit { get; set; }
        public int Id_medecin { get; set; }
        public string AnneeMois { get; set; }
        public bool IsVisite { get; set; }
    }

    public class Cpresenters
    {
        public List<Cpresenter> oListPresenters { get; set; } = new List<Cpresenter>();
        public Cpresenters()
        {
            Cdao odao = new Cdao();
            string query = "call SelectPresenter()";
            MySqlDataReader ord = odao.getReader(query);
            while (ord.Read())
            {
                Cpresenter opresenter = new Cpresenter(Convert.ToString(ord["id_med"]), Convert.ToString(ord["id_visit"]), Convert.ToInt16(ord["id_medecin"]), Convert.ToString(ord["anneeMois"]), Convert.ToBoolean(ord["isVisite"]));
                oListPresenters.Add(opresenter);
            }
        }

        private static Cpresenters Instance = null;
        public static Cpresenters getInstance()
        {
            if (Instance == null)
            {
                Instance = new Cpresenters();
                return Instance;
            }
            else
            {
                return Instance;
            }
        }

        public bool ajouterPresenter(string sId_med, string sId_visit, int sId_medecin, string sMonth)
        {
            try
            {
                string AnneeMois = CtraitementDate.GetAnneeEnCours();
                AnneeMois += CtraitementDate.MonthLetterToMonthNumber(sMonth);
                Cdao odao = new Cdao();
                string query = string.Format($"call InsertPresenter('{sId_med}', '{sId_visit}', {sId_medecin}, '{AnneeMois}')");
                odao.insertEnreg(query);

                Cpresenter opresenter = new Cpresenter(sId_med, sId_visit, sId_medecin, AnneeMois, false);
                oListPresenters.Add(opresenter);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
    #endregion

    #region Cregion
    public class Cregion
    {
        public Cregion(char id, string id_chef)
        {
            Id = id;
            Id_chef = id_chef;
        }

        public char Id { get; set; }
        public string Id_chef { get; set; }
    }

    public class Cregions
    {
        public List<Cregion> oListRegions { get; set; } = new List<Cregion>();
        private Cregions()
        {
            Cdao odao = new Cdao();
            string query = "call SelectRegion()";
            MySqlDataReader ord = odao.getReader(query);
            while (ord.Read())
            {
                Cregion oregion = new Cregion(Convert.ToChar(ord["id"]), Convert.ToString(ord["chef"]));
                oListRegions.Add(oregion);
            }
        }

        private static Cregions Instance = null;
        public static Cregions getInstance()
        {
            if (Instance == null)
            {
                Instance = new Cregions();
                return Instance;
            }
            else
            {
                return Instance;
            }
        }
    }
    #endregion

    #region CficheFrais
    public class CficheFrais
    {
        public CficheFrais(string idVisiteur, string mois, int nbJustificatifs, double montantValide, DateTime dateModif, string idEtat)
        {
            IdVisiteur = idVisiteur;
            Mois = mois;
            NbJustificatifs = nbJustificatifs;
            MontantValide = montantValide;
            DateModif = dateModif;
            IdEtat = idEtat;
        }

        public string IdVisiteur { get; set; }
        public string Mois { get; set; }
        public int NbJustificatifs { get; set; }
        public double MontantValide { get; set; }
        public DateTime DateModif { get; set; }
        public string IdEtat { get; set; }
    }

    public class CficheFraiss
    {
        public List<CficheFrais> oListFicheFrais { get; set; } = new List<CficheFrais>();
        private CficheFraiss()
        {
            Cdao odao = new Cdao();
            string query = "call SelectFicheFrais()";
            MySqlDataReader ord = odao.getReader(query);
            while (ord.Read())
            {
                CficheFrais oFicheFrais = new CficheFrais(Convert.ToString(ord["idVisiteur"]), Convert.ToString(ord["mois"]), Convert.ToInt16(ord["nbJustificatifs"]), Convert.ToDouble(ord["montantValide"]), Convert.ToDateTime(ord["dateModif"]), Convert.ToString(ord["idEtat"]));
                oListFicheFrais.Add(oFicheFrais);
            }
        }

        private static CficheFraiss Instance = null;
        public static CficheFraiss getInstance()
        {
            if (Instance == null)
            {
                Instance = new CficheFraiss();
                return Instance;
            }
            else
            {
                return Instance;
            }
        }
    }
    #endregion

    #region CFraisForfait
    public class CfraisForfait
    {
        public CfraisForfait(string id, string libelle, double montant)
        {
            Id = id;
            Libelle = libelle;
            Montant = montant;
        }

        public string Id { get; set; }
        public string Libelle { get; set; }
        public double Montant { get; set; }
    }

    public class CfraisForfaits
    {
        public List<CfraisForfait> oListFraisForfaits { get; set; } = new List<CfraisForfait>();
        private CfraisForfaits()
        {
            Cdao odao = new Cdao();
            string query = "call SelectFraisForfaits()";
            MySqlDataReader ord = odao.getReader(query);
            while (ord.Read())
            {
                CfraisForfait oFraisForfait = new CfraisForfait(Convert.ToString(ord["id"]), Convert.ToString(ord["libelle"]), Convert.ToDouble(ord["montant"]));
                oListFraisForfaits.Add(oFraisForfait);
            }
        }

        private static CfraisForfaits Instance = null;
        public static CfraisForfaits getInstance()
        {
            if (Instance == null)
            {
                Instance = new CfraisForfaits();
                return Instance;
            }
            else
            {
                return Instance;
            }
        }
    }
    #endregion

    #region CligneFF
    public class CligneFF
    {
        public CligneFF(string idVisiteur, string mois, string idFraisForfait, int quantite)
        {
            IdVisiteur = idVisiteur;
            Mois = mois;
            IdFraisForfait = idFraisForfait;
            Quantite = quantite;
        }

        public string IdVisiteur { get; set; }
        public string Mois { get; set; }
        public string IdFraisForfait { get; set; }
        public int Quantite { get; set; }
    }

    public class CligneFFs
    {
        public List<CligneFF> oListLigneFFs { get; set; } = new List<CligneFF>();
        private CligneFFs()
        {
            Cdao odao = new Cdao();
            string query = "call SelectLigneFF()";
            MySqlDataReader ord = odao.getReader(query);
            while (ord.Read())
            {
                CligneFF oLigneFF = new CligneFF(Convert.ToString(ord["idVisiteur"]), Convert.ToString(ord["mois"]), Convert.ToString(ord["idFraisForfait"]), Convert.ToInt16(ord["quantite"]));
                oListLigneFFs.Add(oLigneFF);
            }
        }

        private static CligneFFs Instance = null;
        public static CligneFFs getInstance()
        {
            if (Instance == null)
            {
                Instance = new CligneFFs();
                return Instance;
            }
            else
            {
                return Instance;
            }
        }

        public int ajouterLigneFF(CligneFF soLigneFF)
        {
            Cdao odao = new Cdao();
            string query = $"call InsertLigneFF('{soLigneFF.IdVisiteur}', '{soLigneFF.Mois}', '{soLigneFF.IdFraisForfait}', {soLigneFF.Quantite})";
            int nbEnregAffecte = odao.insertEnreg(query);

            /* 
             Pour éviter de faire un nouvel appel à la base, on créer un nouvel objet que l'on ajoute manuellement
             à la liste
            */
            CligneFF oLigneFF = new CligneFF(soLigneFF.IdVisiteur, soLigneFF.Mois, soLigneFF.IdFraisForfait, soLigneFF.Quantite);
            oListLigneFFs.Add(oLigneFF);

            return nbEnregAffecte;
        }
    }
    #endregion

    #region CligneFHF
    public class CligneFHF
    {
        public CligneFHF(int id, string idVisiteur, string mois, string libelle, double montant)
        {
            Id = id;
            IdVisiteur = idVisiteur;
            Mois = mois;
            Libelle = libelle;
            Montant = montant;
        }

        public int Id { get; set; }
        public string IdVisiteur { get; set; }
        public string Mois { get; set; }
        public string Libelle { get; set; }
        public double Montant { get; set; }
    }

    public class CligneFHFs
    {
        public List<CligneFHF> oListLigneFHFs { get; set; } = new List<CligneFHF>();
        private CligneFHFs()
        {
            Cdao odao = new Cdao();
            string query = "call SelectLigneFHF()";
            MySqlDataReader ord = odao.getReader(query);
            while (ord.Read())
            {
                CligneFHF oLigneFHF = new CligneFHF(Convert.ToInt16(ord["id"]), Convert.ToString(ord["idVisiteur"]), Convert.ToString(ord["mois"]), Convert.ToString(ord["libelle"]), Convert.ToDouble(ord["montant"]));
                oListLigneFHFs.Add(oLigneFHF);
            }
        }

        private static CligneFHFs Instance = null;
        public static CligneFHFs getInstance()
        {
            if (Instance == null)
            {
                Instance = new CligneFHFs();
                return Instance;
            }
            else
            {
                return Instance;
            }
        }

        public int ajouterLigneFHF(CligneFHF soLigneFHF)
        {
            Cdao odao = new Cdao();
            string query = $"call InsertLigneFHF('{oListLigneFHFs.Count+1}', '{soLigneFHF.IdVisiteur}', '{soLigneFHF.Mois}', '{soLigneFHF.Libelle}', '{soLigneFHF.Montant}')";
            int nbEnregAffecte = odao.insertEnreg(query);

            /* 
             Pour éviter de faire un nouvel appel à la base, on créer un nouvel objet que l'on ajoute manuellement
             à la liste
            */
            CligneFHF oLigneFHF = new CligneFHF(oListLigneFHFs.Count + 1, soLigneFHF.IdVisiteur, soLigneFHF.Mois, soLigneFHF.Libelle, soLigneFHF.Montant);
            oListLigneFHFs.Add(oLigneFHF);

            return nbEnregAffecte;
        }

        public List<CligneFHF> supprimerLigneFHF(int sIdLigneFHF)
        {
            Cdao odao = new Cdao();
            string query = $"call DeleteLigneFHF('{sIdLigneFHF}')";
            int nbEnregAffecte = odao.deleteEnreg(query);

            // suppression de l'objet correspondant dans la liste des lignesFHF
            if(nbEnregAffecte > 0)
            {
                foreach(CligneFHF uneLigneFHF in oListLigneFHFs)
                {
                    if(uneLigneFHF.Id == sIdLigneFHF)
                    {
                        oListLigneFHFs.Remove(uneLigneFHF);
                        break;
                    }
                }
            }

            return oListLigneFHFs;
        }
    }
    #endregion
}
