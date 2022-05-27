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
        private string connectionString = "SERVER=localhost; DATABASE=final_gsb; UID=Emeric_test; PASSWORD=JU3GcFNZr2ho9*Y/";

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

        public static string GetAnneeEnCours()
        {
            return DateTime.Now.ToString("yyyy");
        }

        public static string MonthLetterToMonthNumber(string sMonth)
        {
            string convertedMonth = "";

            switch (sMonth)
            {
                case "Janvier":
                    convertedMonth = "01";
                break;
                case "Février":
                    convertedMonth = "02";
                    break;
                case "Mars":
                    convertedMonth = "03";
                    break;
                case "Avril":
                    convertedMonth = "04";
                    break;
                case "Mai":
                    convertedMonth = "05";
                    break;
                case "Juin":
                    convertedMonth = "06";
                    break;
                case "Juillet":
                    convertedMonth = "07";
                    break;
                case "Août":
                    convertedMonth = "08";
                    break;
                case "Septembre":
                    convertedMonth = "09";
                    break;
                case "Octobre":
                    convertedMonth = "10";
                    break;
                case "Novembre":
                    convertedMonth = "11";
                    break;
                case "Décembre":
                    convertedMonth = "12";
                    break;
            }

            return convertedMonth;
        }
    }
}