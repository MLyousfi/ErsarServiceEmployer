using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErsarServiceEmployers.Data
{
    public class SelectedModel
    {
        public string matricul { get; set; }
        public string nom { get; set; } = "";
        public string prenom { get; set; } = "";
        public string cin { get; set; } = "";
        public string cnss { get; set; } = "";
        public string rib { get; set; } = "";
        public DateTime dateE { get; set; }
        public DateTime dateS { get; set; }
        public string tel { get; set; } = "";
        public string site { get; set; } = "";
        public string ville { get; set; } = "";
        public string adresse { get; set; } = "";
        public string obsertion { get; set; } = "";
    }
    static class ConstantQuery
    {
        public static string TableName = "archive";
        public static string SelectAll = "SELECT * FROM " + TableName;
    }
    public class QueryResult
    {
        public bool success;
        public int RecordCount;
        public string Exception;
        public string DateDeSortie;
        public Stack<string> IDs = new Stack<string>();
        public List<string> ComboBoxDatSource = new List<string>();
        public List<string> years = new List<string>();
        public FicheModel model = new FicheModel();
    }
    class DataAccess
    {
        
      
        static AppSetting setting = new AppSetting();
        public OleDbConnection DBCon = new OleDbConnection(Properties.Settings.Default.DataCS);
        //commande
        //commande
        public OleDbCommand DBCmd = new OleDbCommand();

        //DB data
        public OleDbDataAdapter DBDA;
        public DataTable DBDT;

        //query parametres;
        public List<OleDbParameter> Params = new List<OleDbParameter>();

        //query statistics

        
        public List<DateTime> dates = new List<DateTime>();

        public string numFacture()
        {
            int index = 0;
            int rowNum = Properties.Settings.Default.rowsNum;
            string numRow,serie,year;
            if(rowNum <10)
            { numRow = "000" + rowNum.ToString(); }
            else if(rowNum >= 10 && rowNum < 100)
            { numRow = "00" + rowNum.ToString(); }
            else if(rowNum >= 100 && rowNum < 1000)
            { numRow = "0" + rowNum.ToString();}
            else
            {
                numRow = rowNum.ToString();
            }
            year = DateTime.Now.ToString("yy");
            serie = /*"BEST" + year + "-" +*/ numRow;
            AddParam("@num", serie);
            var FirstRes = ExecQuery("SELECT Nom FROM archive WHERE [N° de Matricul action] LIKE @num");
            if(FirstRes.success)
                index = FirstRes.RecordCount;
            while(index > 0)
            {
                rowNum++;
                if (rowNum < 10)
                { numRow = "000" + rowNum.ToString(); }
                else if (rowNum >= 10 && rowNum < 100)
                { numRow = "00" + rowNum.ToString(); }
                else if (rowNum >= 100 && rowNum < 1000)
                { numRow = "0" + rowNum.ToString(); }
                else
                {
                    numRow = rowNum.ToString();
                }
                year = DateTime.Now.ToString("yy");
                serie = /*"BEST" + year + "-" +*/ numRow;
                AddParam("@num", serie);
                var SecRes= ExecQuery("SELECT Nom FROM archive WHERE [N° de Matricul action] LIKE @num");
                if(SecRes.success)
                    index = SecRes.RecordCount;
            }
            
                return serie;
        }
        public void ClearParam()
        {
            Params.Clear();
        }
        public void AddParam(string Name, Object Value)
        {
            OleDbParameter NewParam = new OleDbParameter(Name, Value);
            Params.Add(NewParam);
        }
        public QueryResult ExecQuery(string Query, bool IsReader = false, bool ComboBoxReader = false, bool getFicheModel = false, bool status = false,bool getYear = false)
        {

            QueryResult result = new QueryResult() { success = false, RecordCount = 0, Exception = "" };
            

            try
            {
                //open connection
                DBCon.Open();
                //create command
                DBCmd = new OleDbCommand(Query, DBCon);

                // load params into command
                foreach (OleDbParameter p in Params)
                {
                    DBCmd.Parameters.Add(p);
                }
                //clear Params
                Params.Clear();

                //execute Command & fill database
                DBDT = new DataTable();
                DBDA = new OleDbDataAdapter(DBCmd);
                result.RecordCount = DBDA.Fill(DBDT);

                result.success = true;

                if(IsReader)
                {

                    if (DBDT.Rows.Count > 0)
                    {
                        foreach (DataRow row in DBDT.Rows)
                        {
                            result.IDs.Push(row["N° de Matricul action"].ToString() + " " + row["Nom"].ToString() + " " + row["Prenom"].ToString());
                        }
                    }

                   
                }
                if (getYear)
                {

                    if (DBDT.Rows.Count > 0)
                    {

                        foreach (DataRow row in DBDT.Rows)
                        {
                            if(row["Date d'entré"] != null && row["Date d'entré"].ToString() != string.Empty)
                            {
                                if(!result.years.Contains(Convert.ToDateTime(row["Date d'entré"]).Year.ToString()))
                                {
                                    result.years.Add(Convert.ToDateTime(row["Date d'entré"]).Year.ToString());
                                }
                            }
                        }

                        result.years.Sort();
                        result.years.Insert(0,"Tous");
                    }


                }

                if (ComboBoxReader)
                {
                    if (DBDT.Rows.Count > 0)
                    {
                        foreach (DataRow row in DBDT.Rows)
                        {
                            result.ComboBoxDatSource.Add(row["N° de Matricul action"].ToString()+" "+ row["Nom"].ToString()+" "+ row["Prenom"].ToString());
                        }
                    }
                }
                if(status)
                {
                    if(DBDT.Rows.Count > 0)
                    {
                        result.DateDeSortie = DBDT.Rows[0]["Date de sortie"].ToString();
                    }
                }
                if(getFicheModel)
                {
                    if (DBDT.Rows.Count > 0)
                    {
                        foreach (DataRow row in DBDT.Rows)
                        {
                            result.model.numMatricul = row["N° de Matricul action"].ToString();
                            result.model.nom = row["Nom"].ToString();
                            result.model.prenom = row["Prenom"].ToString();
                            result.model.adresse = row["Adresse"].ToString();
                            result.model.gsm = row["N° Tél"].ToString();
                            result.model.cin = row["N° de CIN"].ToString();
                            result.model.cnss = row["N° de CNSS"].ToString();
                            result.model.rib = row["RIB"].ToString();
                            result.model.site = row["Site"].ToString();
                        }
                    }
                }
              

                if (DBCon.State == ConnectionState.Open)
                {
                    DBCon.Close();
                }

                return result;
               


            }
            catch (Exception ex)
            {
                if (DBCon.State == ConnectionState.Open)
                {
                    DBCon.Close();
                }
                result.success = false;
                result.Exception = ex.Message;
                return result;
            }
           
        }


    }
}
