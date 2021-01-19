using ErsarServiceEmployers.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErsarServiceEmployers
{
    public partial class ModifierPopUp : Form
    {

        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x00020000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        /*-----------------------------------------------------------------------------------------------*/

        int TimeDellay = 3;
        private readonly SelectedModel employe;

        void CreatTimer(int Inter)
        {
            TimeDellay = 3;
            var t = new System.Timers.Timer();
            t.Interval = Inter;
            t.Enabled = true;
            t.Elapsed += OnTimeEvent;
        }


        private void OnTimeEvent(object sender, System.Timers.ElapsedEventArgs e)
        {


            Invoke(new Action(() => {
                TimeDellay--;
                if (TimeDellay == 0)
                {
                    MessageLbl.Text = "";
                    ((System.Timers.Timer)sender).Close();
                }
            }));
        }
        public ModifierPopUp( SelectedModel employe)
        {
            InitializeComponent();
            InitializeScreen();
            FillTextBox(employe);
            this.employe = employe;
        }

        private void FillTextBox(SelectedModel employe)
        {
            this.MatriculTXT.Text = employe.matricul;
            this.NomTXT.Text = employe.nom;
            this.PrenomTXT.Text = employe.prenom;
            this.CinTXT.Text = employe.cin;
            this.TelTXT.Text = employe.tel;
            this.CnssTXT.Text = employe.cnss;
            this.VilleTXT.Text = employe.ville;
            this.RIBTXT.Text = employe.rib;
            this.AdresseTXT.Text = employe.adresse;
            this.SteTXT.Text = employe.site;
            this.dateTXT.Value = employe.dateE;
            this.ObsertionTXT.Text = employe.obsertion;
        }

        void InitializeScreen()
        {
            this.Text = string.Empty;
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        void CheckFolderName()
        {
            if(this.NomTXT.Text != this.employe.nom || this.PrenomTXT.Text != this.employe.prenom)
            {
                string oldFolder = this.employe.matricul + " " + this.employe.nom + " " + this.employe.prenom;
                string newFolder = this.employe.matricul + " " + this.NomTXT.Text + " " + this.PrenomTXT.Text;
                Directory.Move(Path.Combine(Properties.Settings.Default.EmployerFolderPath,oldFolder) , Path.Combine(Properties.Settings.Default.EmployerFolderPath, newFolder));
            }
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bntMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        

        QueryResult UpdateData(string facNum, string nom, string prenom, string cin, string cnss, string rib, DateTime dateE, string tel, string ste, string ville, string adresse, string obs)
        {

            Program.access.AddParam("@num", facNum);
            Program.access.AddParam("@nom", nom);
            Program.access.AddParam("@prenom", prenom);
            Program.access.AddParam("@cin", cin);
            Program.access.AddParam("@cnss", cnss);
            Program.access.AddParam("@rib", rib);
            Program.access.AddParam("@datee", dateE);
            Program.access.AddParam("@tel", tel);
            Program.access.AddParam("@ste", ste);
            Program.access.AddParam("@ville", ville);
            Program.access.AddParam("@adresse", adresse);
            Program.access.AddParam("@obs", obs);


            return Program.access.ExecQuery("UPDATE archive SET [N° de Matricul action] = @num ,Nom = @nom,Prenom = @prenom ,[N° de CIN] = @cin,[N° de CNSS]= @cnss,RIB= @rib,[Date d'entré] = @datee,[N° Tél] = @tel," +
                "Site = @ste,Ville = @ville,Adresse = @adresse,Obsertion = @obs WHERE [N° de Matricul action] = @num");

        }

        private void EnregistrerBtn_Click(object sender, EventArgs e)
        {
            
            try
            {
                EnregistrerBtn.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                CheckFolderName();
                var res = UpdateData(MatriculTXT.Text, NomTXT.Text, PrenomTXT.Text, CinTXT.Text, CnssTXT.Text, RIBTXT.Text,
                    dateTXT.Value.Date, TelTXT.Text, SteTXT.Text, VilleTXT.Text, AdresseTXT.Text, ObsertionTXT.Text);
                if (res.success)
                {
                    Instances.ARCHIVEPAGE.RefreshData();
                    MessageBox.Show("Modification est accompli avec succès!", "HalfShield : Réussite", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    

                    this.Close();


                }
                else
                {
                    EnregistrerBtn.Enabled = true;
                    this.Cursor = Cursors.Default;
                    MessageLbl.ForeColor = Color.Red;
                    MessageLbl.Text = res.Exception;
                    CreatTimer(1000);
                }
            }
            catch (Exception ex)
            {

                MessageLbl.ForeColor = Color.Red;
                MessageLbl.Text = ex.Message;
                CreatTimer(1000);
                EnregistrerBtn.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }
        private void ClearChamp()
        {
            NomTXT.Text = "";
            PrenomTXT.Text = "";
            CinTXT.Text = "";
            CnssTXT.Text = "";
            RIBTXT.Text = "";
            TelTXT.Text = "";
            RIBTXT.Text = "";
            VilleTXT.Text = "";
            AdresseTXT.Text = "";
            dateTXT.Value = DateTime.Today;
            SteTXT.Text = "";
            ObsertionTXT.Text = "";
            myButton2.Enabled = false;
        }
        private void myButton2_Click(object sender, EventArgs e)
        {
            ClearChamp();
        }
        void CheckVider()
        {
            if (PrenomTXT.Text != "" || NomTXT.Text != "" || CnssTXT.Text != "" || CinTXT.Text != "" || RIBTXT.Text != ""
                || TelTXT.Text != "" || VilleTXT.Text != "" || AdresseTXT.Text != "" || SteTXT.Text != "" || ObsertionTXT.Text != "")
            {
                myButton2.Enabled = true;
            }
            else
            {
                myButton2.Enabled = false;
            }
        }
        
        private void NomTXT_TextChanged(object sender, EventArgs e)
        {
            if (PrenomTXT.Text != "" && NomTXT.Text != "" && CinTXT.Text != "" )
            {
                EnregistrerBtn.Enabled = true;
            }
            else
            {
                EnregistrerBtn.Enabled = false;
            }
            CheckVider();
        }
    }
}
