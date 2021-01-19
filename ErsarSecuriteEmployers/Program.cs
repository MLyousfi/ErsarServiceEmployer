using ErsarServiceEmployers.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErsarServiceEmployers
{
    static class Program 
    {
        public static Color BlueColor = ColorTranslator.FromHtml("#00A8FF");
        public static Color LightGreenColor = ColorTranslator.FromHtml("#8EC40A");
        public static Color DarkGreenColor = ColorTranslator.FromHtml("#5BAB26");
        public static string databaseName = "ServiceEmployerData.accdb";
        public static DataAccess access;
       public static string localAppFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
       public static string localAppFolderPath = Path.Combine(localAppFolder, "HalfShieldStudio");
       public static string localAppFolderPathJunior = Path.Combine(localAppFolderPath, "EmployerData");

       public static string EmployerFolderPath = Path.Combine(localAppFolderPathJunior, "Service");
       public static string sourceFilePath = Path.Combine(System.Windows.Forms.Application.StartupPath, databaseName);
       public static string destFilePath = Path.Combine(localAppFolderPath, databaseName);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            

            var oledb12Installed = new System.Data.OleDb.OleDbEnumerator()
                                        .GetElements().AsEnumerable()
                                        .Any(x => x.Field<string>("SOURCES_NAME") ==
                                            "Microsoft.ACE.OLEDB.12.0");
            //MessageBox.Show(oledb12Installed.ToString());
            CreateEmployerFolder();
            Application.Run(new Form1());
        }

        public static void CreateEmployerFolder()
        {
            
            if (!File.Exists(destFilePath))
            {
                File.Copy(sourceFilePath, destFilePath);

            }

            Properties.Settings.Default.DataCS = string.Format("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = {0}", destFilePath);
            access = new DataAccess();
            if (!Directory.Exists(EmployerFolderPath))
                Directory.CreateDirectory(EmployerFolderPath);

            
            Properties.Settings.Default.EmployerFolderPath = EmployerFolderPath;

            var res = access.ExecQuery(ConstantQuery.SelectAll, true);
            if (res.success)
            {
                Properties.Settings.Default.rowsNum = res.RecordCount;
                for (int i = 0; i < res.RecordCount; i++)
                {
                    Directory.CreateDirectory(Path.Combine(EmployerFolderPath, res.IDs.Pop()));
                }
            }


        }

    }
   
       
}
