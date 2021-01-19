using DGVPrinterHelper;
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
    public partial class Form1 : Form
    {
        
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        public Color FirstColor = Program.DarkGreenColor;
        public Color SecColor = Program.BlueColor;
        public ImageProcessing.MyButton CurrentBtnClicked;
        bool IsMax = false;
        private Size InitSize;

        public Form1()
        {
            InitializeComponent();

            SetPageInstances();
            InitializeScreen();
            InitSize = this.Size;

        }

        void SetPageInstances()
        {
            Instances.MP = this;
            Instances.ARCHIVEPAGE = this.archiveControl1;
            Instances.SAISIRPAGE = this.saisir1;
            Instances.DATAPAGE = this.dataControl1;

        }
        void InitializeScreen()
        {
            this.Text = string.Empty;
            this.ControlBox = false;
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.versionLbl.Text ="v" + version.Major + "." + version.Minor + "." + version.Build;
            FirstClick();
        }

        

        private void bntMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (IsMax)
            {

                FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                this.Size = InitSize;
                this.Location = new Point((Screen.PrimaryScreen.Bounds.Size.Width / 2) - (this.Size.Width / 2), (Screen.PrimaryScreen.Bounds.Size.Height / 2) - (this.Size.Height / 2));
                
                IsMax = false;
            }
            else
            {

                FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                Left = Top = 0;
                Width = Screen.PrimaryScreen.WorkingArea.Width;
                Height = Screen.PrimaryScreen.WorkingArea.Height;

                IsMax = true;
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void FirstClick()
        {

            if (CurrentBtnClicked == null)
            {

                NouvButton.BackColor = SecColor;
                CurrentBtnClicked = NouvButton;
            }
            else
            {
                CurrentBtnClicked.BackColor = FirstColor;
                NouvButton.BackColor = SecColor;
                CurrentBtnClicked = NouvButton;
            }
            TopPanel.Location = new Point(CurrentBtnClicked.Location.X, TopPanel.Location.Y);
            this.saisir1.BringToFront();
        }
        private void NouvButton_Click(object sender, EventArgs e)
        {
            FirstClick();
            
        }

        private void listeBtn_Click(object sender, EventArgs e)
        {
            if (CurrentBtnClicked == null)
            {
                listeBtn.BackColor = SecColor;
                CurrentBtnClicked = listeBtn;

            }
            else
            {
                CurrentBtnClicked.BackColor = FirstColor;
                listeBtn.BackColor = SecColor;
                CurrentBtnClicked = listeBtn;
            }


            TopPanel.Location = new Point(CurrentBtnClicked.Location.X, TopPanel.Location.Y);
            this.archiveControl1.BringToFront();
        }

        private void dataBtn_Click(object sender, EventArgs e)
        {
            if (CurrentBtnClicked == null)
            {

                dataBtn.BackColor = SecColor;
                CurrentBtnClicked = dataBtn;
            }
            else
            {
                CurrentBtnClicked.BackColor = FirstColor;
                dataBtn.BackColor = SecColor;
                CurrentBtnClicked = dataBtn;
            }

            TopPanel.Location = new Point(CurrentBtnClicked.Location.X, TopPanel.Location.Y);
            this.dataControl1.BringToFront();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void myButton1_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Archive des employés";
            printer.SubTitle = string.Format("Date : {0}",DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PorportionalColumns = true ;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "ERSAR Securité";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(Instances.ARCHIVEPAGE.archive);

        }
    }
}
