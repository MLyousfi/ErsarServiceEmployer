namespace ErsarServiceEmployers
{
    partial class DataControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.listView = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.stateLbl = new System.Windows.Forms.Label();
            this.myButton1 = new ImageProcessing.MyButton();
            this.pictureBoxProfil = new System.Windows.Forms.PictureBox();
            this.DeletFileBtn = new ImageProcessing.MyButton();
            this.ADDbtn = new ImageProcessing.MyButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfil)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(154, 17);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(443, 35);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listView
            // 
            this.listView.AllowDrop = true;
            this.listView.BackColor = System.Drawing.Color.White;
            this.listView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.HideSelection = false;
            this.listView.LargeImageList = this.imageList;
            this.listView.Location = new System.Drawing.Point(14, 14);
            this.listView.Margin = new System.Windows.Forms.Padding(14, 14, 0, 14);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(616, 558);
            this.listView.SmallImageList = this.imageList;
            this.listView.TabIndex = 2;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView_ItemChecked);
            this.listView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView_ItemSelectionChanged);
            this.listView.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
            this.listView.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
            this.listView.DragLeave += new System.EventHandler(this.listView_DragLeave);
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.DeletFileBtn);
            this.panel2.Controls.Add(this.ADDbtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(630, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(630, 586);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.stateLbl);
            this.panel4.Controls.Add(this.myButton1);
            this.panel4.Controls.Add(this.pictureBoxProfil);
            this.panel4.Controls.Add(this.comboBox1);
            this.panel4.Location = new System.Drawing.Point(12, 14);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(614, 154);
            this.panel4.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(154, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 27);
            this.label1.TabIndex = 19;
            this.label1.Text = "Statut : ";
            // 
            // stateLbl
            // 
            this.stateLbl.AutoSize = true;
            this.stateLbl.Font = new System.Drawing.Font("Montserrat Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stateLbl.ForeColor = System.Drawing.Color.Lime;
            this.stateLbl.Location = new System.Drawing.Point(232, 52);
            this.stateLbl.Name = "stateLbl";
            this.stateLbl.Size = new System.Drawing.Size(76, 27);
            this.stateLbl.TabIndex = 18;
            this.stateLbl.Text = "ACTIF";
            // 
            // myButton1
            // 
            this.myButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.myButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(171)))), ((int)(((byte)(37)))));
            this.myButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.myButton1.CornerRadius = 15;
            this.myButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myButton1.Font = new System.Drawing.Font("Montserrat Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myButton1.ForeColor = System.Drawing.Color.Black;
            this.myButton1.Location = new System.Drawing.Point(443, 92);
            this.myButton1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.myButton1.Name = "myButton1";
            this.myButton1.RoundCorners = ((ImageProcessing.Corners)((((ImageProcessing.Corners.TopLeft | ImageProcessing.Corners.TopRight) 
            | ImageProcessing.Corners.BottomLeft) 
            | ImageProcessing.Corners.BottomRight)));
            this.myButton1.Size = new System.Drawing.Size(154, 55);
            this.myButton1.TabIndex = 17;
            this.myButton1.Text = "Fiche";
            this.myButton1.Click += new System.EventHandler(this.myButton1_Click_1);
            // 
            // pictureBoxProfil
            // 
            this.pictureBoxProfil.Image = global::ErsarServiceEmployers.Properties.Resources.empty_avatar;
            this.pictureBoxProfil.Location = new System.Drawing.Point(3, 2);
            this.pictureBoxProfil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxProfil.Name = "pictureBoxProfil";
            this.pictureBoxProfil.Size = new System.Drawing.Size(145, 145);
            this.pictureBoxProfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfil.TabIndex = 2;
            this.pictureBoxProfil.TabStop = false;
            // 
            // DeletFileBtn
            // 
            this.DeletFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeletFileBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(171)))), ((int)(((byte)(37)))));
            this.DeletFileBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.DeletFileBtn.CornerRadius = 50;
            this.DeletFileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeletFileBtn.Enabled = false;
            this.DeletFileBtn.Font = new System.Drawing.Font("Montserrat Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeletFileBtn.ForeColor = System.Drawing.Color.Black;
            this.DeletFileBtn.Location = new System.Drawing.Point(12, 535);
            this.DeletFileBtn.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.DeletFileBtn.Name = "DeletFileBtn";
            this.DeletFileBtn.RoundCorners = ((ImageProcessing.Corners)((((ImageProcessing.Corners.TopLeft | ImageProcessing.Corners.TopRight) 
            | ImageProcessing.Corners.BottomLeft) 
            | ImageProcessing.Corners.BottomRight)));
            this.DeletFileBtn.Size = new System.Drawing.Size(33, 34);
            this.DeletFileBtn.TabIndex = 14;
            this.DeletFileBtn.Text = "-";
            this.DeletFileBtn.Click += new System.EventHandler(this.DeletFileBtn_Click);
            // 
            // ADDbtn
            // 
            this.ADDbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ADDbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(171)))), ((int)(((byte)(37)))));
            this.ADDbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ADDbtn.CornerRadius = 50;
            this.ADDbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ADDbtn.Font = new System.Drawing.Font("Montserrat Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ADDbtn.ForeColor = System.Drawing.Color.Black;
            this.ADDbtn.Location = new System.Drawing.Point(12, 493);
            this.ADDbtn.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.ADDbtn.Name = "ADDbtn";
            this.ADDbtn.RoundCorners = ((ImageProcessing.Corners)((((ImageProcessing.Corners.TopLeft | ImageProcessing.Corners.TopRight) 
            | ImageProcessing.Corners.BottomLeft) 
            | ImageProcessing.Corners.BottomRight)));
            this.ADDbtn.Size = new System.Drawing.Size(33, 34);
            this.ADDbtn.TabIndex = 13;
            this.ADDbtn.Text = "+";
            this.ADDbtn.Click += new System.EventHandler(this.ADDbtn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.listView, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1260, 586);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // DataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(1260, 586);
            this.Name = "DataControl";
            this.Size = new System.Drawing.Size(1260, 586);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfil)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ImageProcessing.MyButton DeletFileBtn;
        private ImageProcessing.MyButton ADDbtn;
        private System.Windows.Forms.PictureBox pictureBoxProfil;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.ComboBox comboBox1;
        private ImageProcessing.MyButton myButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label stateLbl;
    }
}
