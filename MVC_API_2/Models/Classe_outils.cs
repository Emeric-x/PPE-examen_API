using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace classes_outils
{ 

    public class Cdao
    {
        private string connectionString = "SERVER=127.0.0.1; DATABASE=final_gsb; UID=root; PASSWORD=";

        //public object MySqldataAdapter { get; private set; }

        public MySqlDataReader getReader(string squery)
        {
            MySql.Data.MySqlClient.MySqlConnection ocnx = new MySqlConnection(connectionString);
            ocnx.Open();
            MySqlCommand ocmd = new MySqlCommand(squery, ocnx);
            MySqlDataReader ord = ocmd.ExecuteReader();
            return ord;
        }

        public int insertEnreg(string squery)
        {
          
                MySqlConnection ocnx = new MySqlConnection(connectionString);
                ocnx.Open();
                MySqlCommand ocmd = new MySqlCommand(squery, ocnx);
                int nbEnregAffecte = ocmd.ExecuteNonQuery();
                return nbEnregAffecte;
          
        }

        public void deleteEnreg(string squery)
        {
          
                MySqlConnection ocnx = new MySqlConnection(connectionString);
                ocnx.Open();
                MySqlCommand ocmd = new MySqlCommand(squery, ocnx);
                int nbEnregAffecte = ocmd.ExecuteNonQuery();
                
              
        }

        public int updateEnreg(string squery)
        {
            MySqlConnection ocnx = new MySqlConnection(connectionString);
            ocnx.Open();
            MySqlCommand ocmd = new MySqlCommand(squery, ocnx);
            int nbEnregAffecte = ocmd.ExecuteNonQuery();
            return nbEnregAffecte;
        }

        public object recupMaxChampTable(string snomChamp, string snomTable)
        {
            try
            {
                //Solution avec des entiers (max utilise) 
                MySqlConnection ocnx = new MySqlConnection(connectionString);
                ocnx.Open();
                string query = "select max(" + snomChamp + ") from " + snomTable;
                MySqlCommand ocmd = new MySqlCommand(query, ocnx);
                object maxId = ocmd.ExecuteScalar(); //executeScalar renvoie un type object 
                return maxId;
            }
            catch (MySqlException e)
            {
                return (object)e.Message; //executeScalar renvoie un type object

            }

        }

        public DataSet getDataSet(string squery)
        {
            MySqlConnection ocnx = new MySqlConnection(connectionString);
            ocnx.Open();
            MySqlDataAdapter oda = new MySqlDataAdapter(squery, ocnx);
            DataSet ods = new DataSet();
            oda.Fill(ods, "dgVisiteur");
            return ods;

        }

        public MySqlDataAdapter getAdapter()
        {
            MySqlConnection ocnx = new MySqlConnection(connectionString);
            ocnx.Open();
            MySqlDataAdapter oda = new MySqlDataAdapter("select * from visiteur", ocnx);
            return oda;
        }


    }
    public static class CtraitementDate
    {
        public static string getMoisEnLettre(int snumMois)
        {
            string[] tabMoisLettre = new string[12];

            tabMoisLettre[0] = "Janvier";
            tabMoisLettre[1] = "Février";
            tabMoisLettre[2] = "Mars";
            tabMoisLettre[3] = "Avril";
            tabMoisLettre[4] = "Mai";
            tabMoisLettre[5] = "Juin";
            tabMoisLettre[6] = "Juillet";
            tabMoisLettre[7] = "Août";
            tabMoisLettre[8] = "Septembre";
            tabMoisLettre[9] = "Octobre";
            tabMoisLettre[10] = "Novembre";
            tabMoisLettre[11] = "Décembre";

            return tabMoisLettre[snumMois - 1];


        }

        public static string getAnneeMoisEnCours()
        {
            //return Convert.ToString(System.DateTime.Now.Year) + Convert.ToString(System.DateTime.Now.Month);
            return DateTime.Now.ToString("yyyyMM");
        }

        public static DateTime getDateCourante()
        {
            return System.DateTime.Now;
        }

        public static string getDateFormatMysql(DateTime sdateFr)
        {

            string dateMySql = sdateFr.ToString("yyyy-MM-dd");
            return dateMySql;

        }
    }
}