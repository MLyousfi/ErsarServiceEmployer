using ErsarServiceEmployers.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ErsarServiceEmployers
{
    public partial class FaireSortir : Form
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




        /*-------------------------*/
        public FaireSortir( string numEmp)
        {
            InitializeComponent();
            this.MatriculTXT.Text = numEmp;

            dateTXT.Value = DateTime.Today;
        }

        int TimeDellay = 1;

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
                    this.Close();
                    ((System.Timers.Timer)sender).Close();
                }
            }));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void bntMinimize_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Minimized;
        }

        private void myButton1_Click(object sender, EventArgs e)
        {
            Sortir(this.MatriculTXT.Text);
        }

        QueryResult FaireS(string facNum, DateTime dateS)
        {

            Program.access.AddParam("@num", facNum);
            Program.access.AddParam("@dates", dateS);


            return Program.access.ExecQuery("UPDATE archive SET [N° de Matricul action] = @num ,[Date de sortie] = @dates WHERE [N° de Matricul action] = @num");

        }

        private void Sortir(string text)
        {
            try
            {
                myButton1.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                var res = FaireS(MatriculTXT.Text,dateTXT.Value.Date);
                if (res.success)
                {
                    Instances.ARCHIVEPAGE.RefreshData();

                    this.Cursor = Cursors.Default;
                    paneltohide.Visible = false;
                    label3.Text = "Opération : Faire sortir '" + this.MatriculTXT.Text + "' accomplit avec succès";
                    label3.Visible = true;
                    CreatTimer(500);


                }
                else
                {
                    myButton1.Enabled = true;
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Erreur survenu : " + res.Exception, "HalfShield : Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur survenu : " + ex.Message, "HalfShield : Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
