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
using PagedList;

namespace ErsarServiceEmployers
{
    
    public partial class ArchiveControl : UserControl
    {

        public bool ColorIsCHnaged = false;
        public ArchiveControl()
        {
            InitializeComponent();
            
        }


        void FileCombosYear()
        {
            var res = Program.access.ExecQuery("SELECT * FROM archive",getYear:true);
            if(res.success)
            {
                YearCombo.DataSource = res.years;
                YearCombo.SelectedIndex = YearCombo.Items.Count - 1;
            }
            else
            {
                MessageBox.Show(res.Exception);
            }
            
        }

        public void RefreshData()
        {
            ChercheTXT.Text = "Chercher...";
            this.archive.DataSource = null;
            this.archive.Rows.Clear();
            if(YearCombo.SelectedItem.ToString() == "Tous")
            {
                var res = Program.access.ExecQuery(ConstantQuery.SelectAll);
                if (res.success)
                {
                    this.archive.DataSource = Program.access.DBDT;

                    //Properties.Settings.Default.rowsNum = archive.Rows.Count + 1;
                    archive.Sort(archive.Columns[0], ListSortDirection.Descending);
                    if (Instances.DATAPAGE != null)
                    {
                        Instances.DATAPAGE.LoadComboItems();
                    }
                }
            }else
            {
                string year = YearCombo.SelectedItem.ToString();
                Program.access.ClearParam();
                Program.access.AddParam("@user", "%" + "/" + year + "%");
                var res = Program.access.ExecQuery("SELECT * FROM archive WHERE [Date d'entré]  LIKE @user");
                if (res.success)
                {
                    this.archive.DataSource = Program.access.DBDT;

                    archive.Sort(archive.Columns[0], ListSortDirection.Descending);
                    if (Instances.DATAPAGE != null)
                    {
                        Instances.DATAPAGE.LoadComboItems();
                    }
                }
            }
            setColumnsWeight();


        }

        public void setColumnsWeight()
        {
            if (archive.DataSource == null) return;
            this.archive.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            this.archive.ColumnHeadersDefaultCellStyle.ForeColor = Program.LightGreenColor;
            this.archive.EnableHeadersVisualStyles = false;
            archive.Columns[0].FillWeight = 30;
            archive.Columns[1].FillWeight = 80;
            archive.Columns[2].FillWeight = 80;
            archive.Columns[3].FillWeight = 50;
            archive.Columns[4].FillWeight = 90;
            archive.Columns[5].FillWeight = 100;
            archive.Columns[6].FillWeight = 50;
            archive.Columns[7].FillWeight = 50;
            archive.Columns[8].FillWeight = 50;
            archive.Columns[9].FillWeight = 100;
            archive.Columns[10].FillWeight = 60;
            archive.Columns[11].FillWeight = 100;
            archive.Columns[12].FillWeight = 80;
        }
        public void ChangeColor()
        {
           
            foreach (DataGridViewRow row in archive.Rows)
            {
                if (row.Cells[7].Value != null)
                {
                    if (row.Cells[7].Value.ToString() == "")
                    {
                        row.DefaultCellStyle.BackColor = Color.Green;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }


            }

        }
        private void ArchiveControl_Load(object sender, EventArgs e)
        {

            FileCombosYear();
            RefreshData();
           

        }

        private void archive_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ChangeColor();
        }

        private void ChercheTXT_Enter(object sender, EventArgs e)
        {

            if (ChercheTXT.Text == "Chercher...")
            {
                ChercheTXT.Text = "";
            }
        }

        private void ChercheTXT_Leave(object sender, EventArgs e)
        {
            if (ChercheTXT.Text == "")
            {
                ChercheTXT.Text = "Chercher...";
                RefreshData();
            }
        }

        private void ModifierBtn_Click(object sender, EventArgs e)
        {
            ModifierPopUp mod = new ModifierPopUp(new SelectedModel
            {
                matricul = archive.CurrentRow.Cells[0].Value.ToString(),
                nom = archive.CurrentRow.Cells[1].Value.ToString(),
                prenom = archive.CurrentRow.Cells[2].Value.ToString(),
                cin = archive.CurrentRow.Cells[3].Value.ToString(),
                cnss = archive.CurrentRow.Cells[4].Value.ToString(),
                rib = archive.CurrentRow.Cells[5].Value.ToString(),
                dateE = Convert.ToDateTime(archive.CurrentRow.Cells[6].Value.ToString()),
                tel = archive.CurrentRow.Cells[8].Value.ToString(),
                site = archive.CurrentRow.Cells[9].Value.ToString(),
                ville = archive.CurrentRow.Cells[10].Value.ToString(),
                adresse = archive.CurrentRow.Cells[11].Value.ToString(),
                obsertion = archive.CurrentRow.Cells[12].Value.ToString()


            });
            mod.Show();
        }
        void SearchFor(string name)
        {
            myButton1.Enabled = false;
            Program.access.ClearParam();
            Program.access.AddParam("@user", "%" + name + "%");
            var res = Program.access.ExecQuery("SELECT * FROM archive WHERE [N° de Matricul action]  LIKE @user OR Nom LIKE @user OR Prenom  LIKE @user OR [N° de CIN] LIKE @user OR [N° de CNSS] LIKE @user OR [Date d'entré] LIKE @user OR Site LIKE @user OR Ville LIKE @user OR [Date de sortie] LIKE @user OR RIB LIKE @user");
            if (res.success)
            {
                this.archive.DataSource = Program.access.DBDT;

                archive.Sort(archive.Columns[0], ListSortDirection.Descending);
            }
            else
            {
                RefreshData();
            }
            
        }
        private void ChercheTXT_TextChanged(object sender, EventArgs e)
        {
            if(this.ChercheTXT.Text != "Chercher..." && this.ChercheTXT.Text != string.Empty)
                SearchFor(this.ChercheTXT.Text);
        }
        #region ForInitDataJustTesting
        void changeNum()
        {
            foreach (DataGridViewRow row in archive.Rows)
            {
                if (row.Cells[0].Value.ToString() != null)
                {
                    if (row.Cells[8].Value.ToString() != null)
                    {
                        if (row.Cells[8].Value.ToString() != string.Empty)
                        {
                            Program.access.AddParam("@num", row.Cells[0].Value.ToString());
                            Program.access.AddParam("@tel", "0" + row.Cells[8].Value.ToString());
                            Program.access.ExecQuery("UPDATE archive SET [N° de Matricul action] = @num ,[N° Tél] = @tel WHERE [N° de Matricul action] = @num");
                        }
                    }
                }
            }

            RefreshData();
        }
        void changeMatricule()
        {
            foreach (DataGridViewRow row in archive.Rows)
            {
                if (row.Cells[0].Value.ToString() != null)
                {
                    if (row.Cells[0].Value.ToString() != string.Empty)
                    {
                        string num = row.Cells[0].Value.ToString();
                        if (num.Length == 1)
                        {
                            num = "000" + num;
                        }
                        else if (num.Length == 2)
                        {
                            num = "00" + num;
                        }
                        else if (num.Length == 3)
                        {
                            num = "0" + num;
                        }

                        Program.access.AddParam("@num", num);
                        Program.access.AddParam("@oldnum", row.Cells[0].Value.ToString());
                        Program.access.ExecQuery("UPDATE archive SET [N° de Matricul action] = @num  WHERE [N° de Matricul action] = @oldnum");

                    }
                }
            }

            RefreshData();
        }

        #endregion

        private void SortirBtn_Click(object sender, EventArgs e)
        {
            FaireSortir fs = new FaireSortir(archive.CurrentRow.Cells[0].Value.ToString());
            fs.Show();
        }

        QueryResult FaireR(string facNum)
        {

            Program.access.AddParam("@num", facNum);


            return Program.access.ExecQuery("UPDATE archive SET [N° de Matricul action] = @num ,[Date de sortie] = Null WHERE [N° de Matricul action] = @num");

        }
        private void myButton2_Click(object sender, EventArgs e)
        {

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show("Voulez-vous vraiment faire retourner Employé(e) ' "+ archive.CurrentRow.Cells[1].Value.ToString() + " " + archive.CurrentRow.Cells[2].Value.ToString() + " ' ?\nClicker sur 'oui' pour confirmer.", "Confirmation", buttons, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    myButton2.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;
                    var res = FaireR(archive.CurrentRow.Cells[0].Value.ToString());
                    if (res.success)
                    {
                        Instances.ARCHIVEPAGE.RefreshData();

                        this.Cursor = Cursors.Default;
                        


                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("Erreur survenu : " + res.Exception, "HalfShield : Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                }
                catch (Exception ex)
                {

                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Erreur survenu : " + ex.Message, "HalfShield : Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
        }

        private void archive_SelectionChanged(object sender, EventArgs e)
        {
            if (archive.CurrentRow == null || archive.CurrentRow.Cells[0].Value == null || archive.CurrentRow.Cells[0].Value.ToString() == "")
            {
                myButton1.Enabled = false;
                return;
            }


            myButton1.Enabled = true;
            if (archive.CurrentRow.Cells[7].Value != null )
            {
                if(archive.CurrentRow.Cells[7].Value.ToString() == "")
                {

                    myButton2.Enabled = false;
                }else
                {
                    myButton2.Enabled = true ;
                }
            }else
            {
                myButton2.Enabled = false;
            }
        }

        private void myButton1_Click(object sender, EventArgs e)
        {
            if(archive.CurrentRow == null)
            {
                myButton1.Enabled = false;
                return;
            }
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show("Voulez-vous vraiment supprimer Employé(e) ' " + archive.CurrentRow.Cells[1].Value.ToString() + " " + archive.CurrentRow.Cells[2].Value.ToString() + " ' ?\nClicker sur 'oui' pour confirmer.", "Confirmation", buttons, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    Program.access.AddParam("@num", archive.CurrentRow.Cells[0].Value.ToString());
                    var res = Program.access.ExecQuery("DELETE FROM archive WHERE [N° de Matricul action]=@num ");
                    if (res.success)
                    {
                        Instances.ARCHIVEPAGE.RefreshData();
                        Properties.Settings.Default.rowsNum--;
                        Instances.SAISIRPAGE.MatriculTXT.Text =  Program.access.numFacture();

                        this.Cursor = Cursors.Default;



                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("Erreur survenu : " + res.Exception, "HalfShield : Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Erreur survenu : " + ex.Message, "HalfShield : Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void YearCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
