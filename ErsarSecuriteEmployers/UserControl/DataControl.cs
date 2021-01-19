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
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ErsarServiceEmployers
{
    public partial class DataControl : UserControl
    {

        string CurrentFolder = "";
        [DllImport("User32.dll")]
        private static extern int SendMessage(int Handle, int wMsg, int wParam, int lParam);

        const int LVM_FIRST = 0x1000;
        const int LVM_SETICONSPACING = LVM_FIRST + 53;

        public static void SetListViewSpacing(ListView lst, int x, int y)
        {
            SendMessage((int)lst.Handle, LVM_SETICONSPACING, 0, x * 65536 + y);
        }

        /*-----------------*/

        List<string> FilesString = new List<string>();
        FicheModel model;

        public DataControl()
        {
            InitializeComponent();
           
        }


        public void LoadComboItems()
        {
            var res = Program.access.ExecQuery(ConstantQuery.SelectAll , ComboBoxReader:true);
            if (res.success)
            {
                comboBox1.DataSource = res.ComboBoxDatSource;
                comboBox1.SelectedIndex = res.RecordCount - 1;
            }
        }

        

        public void LoadFiles(string employerFolder)
        {
            string photo = "";
            CurrentFolder = Path.Combine(Properties.Settings.Default.EmployerFolderPath, employerFolder);
            FilesString.Clear();
            listView.Items.Clear();
            var directoryPath = CurrentFolder;
            bool fileexcits = Directory.Exists(directoryPath);
            if (fileexcits)
            {
                foreach (var item in Directory.GetFiles(directoryPath))
                {
                    if(item.Contains("Photo."))
                    {
                        photo = item;
                    }

                    imageList.Images.Add(System.Drawing.Icon.ExtractAssociatedIcon(item));
                    FileInfo fi = new FileInfo(item);
                    FilesString.Add(fi.FullName);

                    listView.Items.Add(fi.Name, imageList.Images.Count - 1);
                }
            }


           
            

            


            if (photo != "")
            {
                pictureBoxProfil.Image = GetCopyImage(photo);
            }
            else
            {
                pictureBoxProfil.Image = Properties.Resources.empty_avatar;
            }
        }
        private Image GetCopyImage(string path)
        {
            using (Image im = Image.FromFile(path))
            {
                Bitmap bm = new Bitmap(im);
                return bm;
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text != "")
            {
                LoadFiles(comboBox1.Text);
                CreateModel(comboBox1.Text.Split(' ')[0]);
                if(comboBox1.Text.Split(' ')[0].Length>=4)
                {
                    GetStatus(comboBox1.Text.Split(' ')[0]);
                }
                else
                {
                    stateLbl.Text = "UNCONU";
                    stateLbl.ForeColor = Color.Yellow;
                }
            }
            


        }

        private void GetStatus(string v)
        {
            Program.access.AddParam("@num", v);
            var res = Program.access.ExecQuery("SELECT [Date de sortie] FROM archive WHERE [N° de Matricul action] = @num",status:true);
            if(res.success)
            {
                if (res.DateDeSortie == "")
                {
                    stateLbl.Text = "ACTIF";
                    stateLbl.ForeColor = Color.Lime;
                }
                else
                {
                    stateLbl.Text = "SORTIT";
                    stateLbl.ForeColor = Color.Red;
                }
            }else
            {
                stateLbl.Text = "UNCONU";
                stateLbl.ForeColor = Color.Yellow;
            }
            
        }

        void CreateModel(string matricul)
        {
            Program.access.ClearParam();
            Program.access.AddParam("@id", matricul);
            var res = Program.access.ExecQuery("SELECT [N° de Matricul action],Nom,Prenom ,[N° de CIN],[N° de CNSS],RIB,[N° Tél],Site," +
                "Adresse FROM archive WHERE [N° de Matricul action] = @id", getFicheModel:true);

            if (res.success)
            {
                model = res.model;
            }else
            {
                MessageBox.Show(res.Exception);
            }
        }

        private void listView_DragDrop(object sender, DragEventArgs e)
        {
            List<string> errors = new List<string>();
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (var file in files)
            {
                if (File.GetAttributes(file) == FileAttributes.Directory)
                {
                    errors.Add("Essaie de copier seulement les fichiers");
                    listView.BackColor = Color.White;
                }
                else if (Path.GetExtension(file) == ".png" || Path.GetExtension(file) == ".jpg" || Path.GetExtension(file) == ".jpeg")
                {
                    if((File.Exists(Path.Combine(CurrentFolder, "Photo.png"))) || (File.Exists(Path.Combine(CurrentFolder, "Photo.jpg"))) || (File.Exists(Path.Combine(CurrentFolder, "Photo.jpeg"))))
                    {
                        errors.Add("Fichier 'Photo' exist déja");

                        listView.BackColor = Color.White;
                    }else
                    {
                        File.Copy(file, Path.Combine(CurrentFolder, "Photo" + Path.GetExtension(file)));
                    }
                    
                    
                }
                else
                {
                    if(File.Exists(Path.Combine(CurrentFolder, Path.GetFileName(file))))
                    {

                        errors.Add("Fichiers ' " + Path.GetFileName(file) + " ' exist déja");
                    }
                    else
                    {
                        File.Copy(file, Path.Combine(CurrentFolder, Path.GetFileName(file)));
                    }
                    

                }


                

            }

            listView.BackColor = Color.White;
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

            LoadFiles(comboBox1.Text);
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(CurrentFolder, (sender as ListView).SelectedItems[0].Text));
            
        }

        private void listView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
        }

        private void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                DeletFileBtn.Enabled = true;
            }else
            {
                DeletFileBtn.Enabled = false;
            }
            

        }

        private void listView_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                listView.BackColor = Color.MistyRose;
            }
        }

        private void listView_DragLeave(object sender, EventArgs e)
        {

            listView.BackColor = Color.White;
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
                    if (dialog.FileNames.Length != 0)
                    {
                        foreach (var file in dialog.FileNames)
                        {
                            if (Path.GetExtension(file) == ".png" || Path.GetExtension(file) == ".jpg" || Path.GetExtension(file) == ".jpeg")
                            {
                                if ((File.Exists(Path.Combine(CurrentFolder, "Photo.png"))) || (File.Exists(Path.Combine(CurrentFolder, "Photo.jpg"))) || (File.Exists(Path.Combine(CurrentFolder, "Photo.jpeg"))))
                                {
                                    errors.Add("Fichier 'Photo' exist déja");

                                    listView.BackColor = Color.White;
                                }
                                else
                                {
                                    File.Copy(file, Path.Combine(CurrentFolder, "Photo" + Path.GetExtension(file)));
                                }


                            }
                            else
                            {
                                if (File.Exists(Path.Combine(CurrentFolder, Path.GetFileName(file))))
                                {

                                    errors.Add("Fichiers ' " + Path.GetFileName(file) + " ' exist déja");
                                }
                                else
                                {
                                    File.Copy(file, Path.Combine(CurrentFolder, Path.GetFileName(file)));
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

                        listView.BackColor = Color.White;
                        LoadFiles(comboBox1.Text);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Halfshield Exception" + ex.Message, "An Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }

           

            
        }

        private void DeletFileBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView.SelectedItems.Count > 0)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Displays the MessageBox.

                    result = MessageBox.Show("Clicker sur 'oui' pour confirmer la suppression de '" + listView.SelectedItems.Count + "' fichier(s).", "Confirmation", buttons, MessageBoxIcon.Question);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {

                        foreach (ListViewItem item in listView.SelectedItems)
                        {
                            //if (item.Text.Contains("Photo."))
                            //{
                            //    pictureBoxProfil.Image.Dispose();
                            //    pictureBoxProfil.Image = null;
                            //    pictureBoxProfil.ImageLocation = null;
                            //}
                            File.Delete(Path.Combine(CurrentFolder, item.Text));

                        }
                        LoadFiles(comboBox1.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Halfshield Exception" + ex.Message, "An Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void myButton1_Click(object sender, EventArgs e)
        {
        }

        private void myButton1_Click_1(object sender, EventArgs e)
        {

            try
            {

                myButton1.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                CreateModel(comboBox1.Text.Split(' ')[0]);
                model.EmployerFolder = CurrentFolder;
               FicheProvider fp = new FicheProvider(this, model);

                myButton1.Enabled = true;
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex )
            {

                myButton1.Enabled = true;
                this.Cursor = Cursors.Default;
                MessageBox.Show("Halfshield Exception" + ex.Message, "An Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
