
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ErsarServiceEmployers.Data
{
    public class FicheModel
    {
        public string EmployerFolder { get; set; }
        public string numMatricul { get; set; }
        public string nom { get; set; } = "";
        public string prenom { get; set; } = "";
        public string adresse { get; set; } = "";
        public string gsm { get; set; } = "";
        public string cin { get; set; } = "";
        public string cnss { get; set; } = "";
        public string rib { get; set; } = "";
        public string site { get; set; } = "";
    }
    class FicheProvider
    {
        string path = "";
        Workbook wb;
        Worksheet ws;
        _Application excel = new _Excel.Application();
        float leftPosition , topPosition, height , width;
        private readonly DataControl dc;
        private readonly FicheModel model;

        public bool IsExcelInstalled { get; }

        public FicheProvider(DataControl dc, FicheModel model)
        {
            this.path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\Fiche.xlsx";//Environment.CurrentDirectory + "/" + fileName;
            this.dc = dc;
            this.model = model;

            IsExcelInstalled = Type.GetTypeFromProgID("Excel.Application") != null ? true : false;



            CreateFiche();
        }

        bool ResultBox(string caption, string message)
        {
            // Initializes the variables to pass to the MessageBox.Show method.

            
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons,MessageBoxIcon.Question);

            return (result == System.Windows.Forms.DialogResult.Yes);
            
        }

        public void WriteCell(int i, int j, string s)
        {
            i++;
            j++;
            ws.Cells[i, j].Value2 = s;
        }
        private void CreateFiche()
        {

            if(!IsExcelInstalled)
            {
                MessageBox.Show("Excel n'est pas installé sur cette machine!\nVeuillez installer Excel ou contactez 'Marouane Lyousfi' pour plus d'information", "Excel manqué", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                wb = excel.Workbooks.Open(this.path);
                ws = wb.Worksheets[1];

                var picture = ws.Shapes.Item(2);
                leftPosition = picture.Left;
                topPosition = picture.Top;
                height = picture.Height;
                width = picture.Width;
                
                List<string> file = Directory.GetFiles(model.EmployerFolder).ToList();
                string photo = file.SingleOrDefault(f => f.Contains("Photo."));
                if (photo == null)
                {
                    if (!ResultBox("Photo manquée", "Cet employé n'as pas de photo de profil\nVoulez-vous continuer avec la photo par défault? "))
                    {
                        return;
                    }


                }
                else
                {
                    picture.Delete();
                    
                    ws.Shapes.AddPicture(photo, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, leftPosition, topPosition, width, height);
                }



                ws.Cells[19 , 7].value2 = model.numMatricul;
                ws.Cells[23,5].value2 = model.nom;
                ws.Cells[25,5].value = model.prenom;
                ws.Cells[27,5].value2 = model.adresse;
                ws.Cells[32, 5].value2 = model.gsm;
                ws.Cells[34, 5].value2 = model.cin;
                ws.Cells[36, 5].value2 = model.cnss;
                ws.Cells[38, 5].value2 = model.rib;
                ws.Cells[40, 5].value2 = model.site;

                PrintingPDF(Path.Combine(model.EmployerFolder, "Fiche.pdf"));
                dc.LoadFiles(dc.comboBox1.Text);
                wb.Close(false);
                Process.Start(Path.Combine(model.EmployerFolder, "Fiche.pdf"));
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message, "Excel manqué", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (((Microsoft.Office.Interop.Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application")).Workbooks.Cast<Microsoft.Office.Interop.Excel.Workbook>().FirstOrDefault(x => x.Name == "Fiche.xlsx") != null)
                    wb.Close(false);
            }
            finally
            {
                if(((Microsoft.Office.Interop.Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application")).Workbooks.Cast<Microsoft.Office.Interop.Excel.Workbook>().FirstOrDefault(x => x.Name == "Fiche.xlsx") != null)
                    wb.Close(false);
            }


        }

        public void PrintingPDF(string filename)
        {
            try
            {
                ws.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, filename, 0, true, false, Type.Missing, Type.Missing, false, Type.Missing);
            }
            catch
            {
                MessageBox.Show("Vérifiez que vous avez 'Exporation PDF' sur Excel", "HalfShield : Exporation PDF requise!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        


    }
}
