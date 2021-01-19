using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErsarServiceEmployers.Data;
using System.IO;
using ImageProcessing;

namespace ErsarServiceEmployers
{
    
    public partial class Saisir : UserControl
    {
        int TimeDellay = 3;
        public Bitmap EmployerImage;
        public string PhotoLocation = "";
        public List<string> Files = new List<string>();
        public Saisir()
        {
            InitializeComponent();
            
        }


        

        private void Saisir_Load(object sender, EventArgs e)
        {
            MatriculTXT.Text = Program.access.numFacture();
            SetIndex();
            dateTXT.Value = DateTime.Today;
            
        }


        void CreatTimer(int Inter)
        {
            TimeDellay =3;
            var t = new System.Timers.Timer();
            t.Interval = Inter;
            t.Enabled = true;
            t.Elapsed += OnTimeEvent;
        }

       
        private void OnTimeEvent(object sender , System.Timers.ElapsedEventArgs e)
        {
            
            
            Invoke(new Action(() => {
                TimeDellay -- ;
                if (TimeDellay == 0)
                {
                    MessageLbl.Text = "";
                    ((System.Timers.Timer)sender).Close();
                }
            }));
        }
        QueryResult Insert(string facNum, string nom, string prenom , string cin , string cnss,string rib, DateTime dateE , string tel , string ste , string ville ,string adresse, string obs )
        {
            Program.access.AddParam("@num", facNum);
            Program.access.AddParam("@nom", nom);
            Program.access.AddParam("@prenom", prenom);
            Program.access.AddParam("@cin", cin);
            Program.access.AddParam("@cnss",cnss);
            Program.access.AddParam("@rib",rib);
            Program.access.AddParam("@datee", dateE);
            Program.access.AddParam("@tel", tel);
            Program.access.AddParam("@ste", ste);
            Program.access.AddParam("@ville", ville);
            Program.access.AddParam("@adresse", adresse);
            Program.access.AddParam("@obs", obs);


            return Program.access.ExecQuery("insert into archive ([N° de Matricul action],Nom,Prenom ,[N° de CIN],[N° de CNSS],RIB,[Date d'entré],[N° Tél]," +
                "Site,Ville,Adresse,Obsertion) values"
                + "(@num,@nom,@prenom,@cin,@cnss,@rib,@detee,@tel,@ste,@ville,@adresse,@obs)");
            
        }
        private void EnregistrerBtn_Click(object sender, EventArgs e)
        {
            
            try
            {
                CreateNewFolder();
                var res = Insert(MatriculTXT.Text, NomTXT.Text, PrenomTXT.Text, CinTXT.Text, CnssTXT.Text,RIBTXT.Text,
                    dateTXT.Value.Date, TelTXT.Text, SteTXT.Text, VilleTXT.Text,AdresseTXT.Text, ObsertionTXT.Text);
                if(res.success)
                {
                    MessageLbl.ForeColor = Color.LimeGreen;
                    MessageLbl.Text = "Employer est ajoutée avec succès!";
                    CreatTimer(1000);
                    Instances.ARCHIVEPAGE.RefreshData();
                    ClearChamp();
                    MatriculTXT.Text = Program.access.numFacture();
                    ClearFolders();


                }
                else
                {
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
            }
        }

        private void CreateNewFolder()
        {
            string FolderName = MatriculTXT.Text + " " + NomTXT.Text + " " + PrenomTXT.Text;
            string EmployerFolderPath = Properties.Settings.Default.EmployerFolderPath;
            string ThisEmployerFolder = Path.Combine(EmployerFolderPath, FolderName);
            if (!Directory.Exists(ThisEmployerFolder))
                Directory.CreateDirectory(ThisEmployerFolder);

            if(PhotoLocation != "")
            {
                string Ext = Path.GetExtension(PhotoLocation);
                string Filename = "Photo" + Ext;
                File.Copy(PhotoLocation, Path.Combine(ThisEmployerFolder, Filename));
            }
            if(Files.Count != 0)
            {
                for (int i = 0; i < Files.Count; i++)
                {
                    string Filename = Path.GetFileName(Files[i]);
                    File.Copy(Files[i], Path.Combine(ThisEmployerFolder, Filename));
                }
                
            }
        }

        //Button CreateFileButton(string text , bool isPhoto)
        //{
        //    Button btn = new Button();
        //    btn.AutoEllipsis = true;
        //    btn.FlatStyle = FlatStyle.Flat;
        //    btn.TextAlign = ContentAlignment.MiddleLeft;
        //    btn.Font = new Font("montserrat", 8,FontStyle.Bold);
        //    if (isPhoto)
        //    {

        //        btn.Text = text;
        //        btn.Size = new Size(flowLayout.Size.Width - 30, 35);
        //        btn.Margin = new Padding(6);
        //        btn.BackColor = Color.Black;
        //        btn.ForeColor = Color.Red;
        //        btn.Click += PhotoBtnClicked;

        //    }
        //    else
        //    {

        //        btn.Text = text;
        //        btn.Size = new Size(flowLayout.Size.Width - 30, 35);
        //        btn.Margin = new Padding(6);
        //        btn.BackColor = Color.Red;
        //        btn.ForeColor = Color.Black;
        //        btn.Click += CVBtnClicked;
        //    }
        //    return btn;
        //}

        private void CVBtnClicked(object sender, EventArgs e)
        {

            string name = (sender as Button).Text;
            var split = name.Split(new string[] { ". " }, StringSplitOptions.None);

            var Element = Files.Single(s => s.EndsWith(split[1]));
            Files.Remove(Element);
        }

        private void PhotoBtnClicked(object sender, EventArgs e)
        {
            
            PhotoLocation = "";
            myButton2.Visible = true;
        }

        private void myButton2_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";
                dialog.Multiselect = false;

                dialog.Title = "Halfshield : Une photo a selectionner";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    EmployerImage = new Bitmap(dialog.FileName);
                    PhotoLocation = dialog.FileName;
                    string buttonName = "Photo"+ Path.GetExtension(PhotoLocation);
                    

                    ((MyButton)sender).Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Halfshield Exception" + ex.Message, "An Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void flowLayout_DragDrop(object sender, DragEventArgs e)
        {

            List<string> errors = new List<string>();
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (var file in files)
            {
                if(File.GetAttributes(file) == FileAttributes.Directory)
                {

                    errors.Add("Essaie de copier seulement les fichiers");
                }
                else if (Path.GetExtension(file) == ".png" || Path.GetExtension(file) == ".jpg" || Path.GetExtension(file) == ".jpeg")
                {
                    if(PhotoLocation != "")
                    {

                        errors.Add("Une seule photo requis");
                    }else
                    {
                        PhotoLocation = file;
                        myButton2.Enabled = true;
                    }
                }
                else
                {

                    if (Files.Contains(file))
                    {
                        errors.Add("Le fichier ' " + Path.GetFileName(file) + " ' est dupliqué une seule copie seura affectée");
                    }
                    else
                    {
                        Files.Add(file);
                        myButton2.Enabled = true;

                    }

                }

            }

            listView1.BackColor = Color.Black;
            if (errors.Count != 0)
            {
                string res = string.Empty;
                for (int i = 0; i < errors.Count; i++)
                {
                    res += "- " + errors[i] + "\n";
                }

                MessageBox.Show(this, res, "HalfShiel : " + errors.Count + " Remarque retournées", MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
            }

            RefreshListView();

        }
        void RefreshListView()
        {
            imageList1.Images.Clear();
            listView1.Items.Clear();
            foreach (var item in Files)
            {
                imageList1.Images.Add(System.Drawing.Icon.ExtractAssociatedIcon(item));
                listView1.Items.Add(Path.GetFileName(item), imageList1.Images.Count - 1);
            }
            if (PhotoLocation != "")
            {
                imageList1.Images.Add(System.Drawing.Icon.ExtractAssociatedIcon(PhotoLocation));
                listView1.Items.Add("Photo" + Path.GetExtension(PhotoLocation), imageList1.Images.Count - 1);
            }
            foreach (ListViewItem item in listView1.Items)
            {
                item.Font = new Font("montserrat", 8, FontStyle.Regular);
            }
        }

        private void flowLayout_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                listView1.BackColor = Color.DarkGray;
            }
                
        }

        private void flowLayout_DragLeave(object sender, EventArgs e)
        {

            listView1.BackColor = Color.Black;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            ClearChamp();
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
            ClearFolders();
            Files.Clear();
            PhotoLocation = "";
            myButton2.Enabled = false;
        }
       
        private void SetIndex()
        {
            Function.EnumerateChildren(this);
            NomTXT.TabIndex = 100;
            PrenomTXT.TabIndex = 101;
            CinTXT.TabIndex = 102;
            CnssTXT.TabIndex = 103;
            RIBTXT.TabIndex = 105;
            TelTXT.TabIndex = 104;
            VilleTXT.TabIndex = 106;
            AdresseTXT.TabIndex = 108;
            dateTXT.TabIndex = 105;
            SteTXT.TabIndex = 107;
            ObsertionTXT.TabIndex = 109;
        }

        void ClearFolders()
        {
            imageList1.Images.Clear();
            listView1.Items.Clear();
            Files.Clear();
            PhotoLocation = "";
            CheckVider();
        }
        private void Saisir_SizeChanged(object sender, EventArgs e)
        {
            if(this.Size.Width < 1143 && this.Size.Height<548)
            {
                panel1.Visible = false;
            }else
            {
                panel1.Visible = true;
            }
        }
        void CheckVider()
        {
            if(PrenomTXT.Text != "" || NomTXT.Text != "" || CnssTXT.Text != "" || CinTXT.Text != "" || RIBTXT.Text != "" 
                || TelTXT.Text != "" || VilleTXT.Text != "" || AdresseTXT.Text != "" || SteTXT.Text != "" ||ObsertionTXT.Text != "")
            {
                myButton2.Enabled = true;
            }else
            {
                myButton2.Enabled = false;
            }
        }
        private void PrenomTXT_TextChanged(object sender, EventArgs e)
        {
            if(PrenomTXT.Text != "" && NomTXT.Text != "" && CinTXT.Text != "" && AdresseTXT.Text != "")
            {
                EnregistrerBtn.Enabled = true;
            }else
            {
                EnregistrerBtn.Enabled = false;
            }
            CheckVider();
        }

        private void ADDbtn_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> errors = new List<string>();
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = true;

                dialog.Title = "Halfshield";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if(dialog.FileNames.Length != 0)
                    {
                        foreach (var file in dialog.FileNames)
                        {
                            if (Path.GetExtension(file) == ".png" || Path.GetExtension(file) == ".jpg" || Path.GetExtension(file) == ".jpeg")
                            {
                                if (PhotoLocation != "")
                                {

                                    errors.Add("Une seule photo requis");
                                }
                                else
                                {
                                    PhotoLocation = file;

                                    myButton2.Enabled = true;
                                }
                            }
                            else
                            {

                                if (Files.Contains(file))
                                {
                                    errors.Add("Le fichier ' " + Path.GetFileName(file) + " ' est dupliqué une seule copie seura affectée");
                                }
                                else
                                {
                                    Files.Add(file);
                                    myButton2.Enabled = true;

                                }

                            }

                        }

                        if (errors.Count != 0)
                        {
                            string res = string.Empty;
                            for (int i = 0; i < errors.Count; i++)
                            {
                                res += "- " + errors[i] + "\n";
                            }

                            MessageBox.Show(this, res, "HalfShiel : " + errors.Count + " Remarque retournées", MessageBoxButtons.OK,
                                           MessageBoxIcon.Warning);
                        }

                        RefreshListView();
                    }
                    
                   


                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Halfshield Exception" + ex.Message, "An Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            var file = (sender as ListView).SelectedItems[0].Text;
            
            if (Path.GetExtension(file) == ".png" || Path.GetExtension(file) == ".jpg" || Path.GetExtension(file) == ".jpeg")
            {
                PhotoLocation = "";

            }else
            {
                var Element = Files.Single(s => s.EndsWith(file));
                Files.Remove(Element);
            }

            listView1.Items.Remove((sender as ListView).SelectedItems[0]);
        }

     
    }
}
