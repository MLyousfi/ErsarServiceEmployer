namespace ErsarServiceEmployers
{
    partial class ArchiveControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.YearCombo = new System.Windows.Forms.ComboBox();
            this.ChercheTXT = new System.Windows.Forms.TextBox();
            this.archive = new System.Windows.Forms.DataGridView();
            this.myButton2 = new ImageProcessing.MyButton();
            this.myButton1 = new ImageProcessing.MyButton();
            this.ModifierBtn = new ImageProcessing.MyButton();
            this.SortirBtn = new ImageProcessing.MyButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.archive)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.YearCombo);
            this.panel1.Controls.Add(this.ChercheTXT);
            this.panel1.Controls.Add(this.myButton2);
            this.panel1.Controls.Add(this.myButton1);
            this.panel1.Controls.Add(this.ModifierBtn);
            this.panel1.Controls.Add(this.SortirBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 536);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1260, 50);
            this.panel1.TabIndex = 0;
            // 
            // YearCombo
            // 
            this.YearCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.YearCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.YearCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.YearCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.YearCombo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.YearCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.YearCombo.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YearCombo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(171)))), ((int)(((byte)(37)))));
            this.YearCombo.FormattingEnabled = true;
            this.YearCombo.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.YearCombo.Location = new System.Drawing.Point(476, 8);
            this.YearCombo.Name = "YearCombo";
            this.YearCombo.Size = new System.Drawing.Size(121, 35);
            this.YearCombo.TabIndex = 6;
            this.YearCombo.SelectedIndexChanged += new System.EventHandler(this.YearCombo_SelectedIndexChanged);
            // 
            // ChercheTXT
            // 
            this.ChercheTXT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChercheTXT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.ChercheTXT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ChercheTXT.Font = new System.Drawing.Font("Montserrat", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChercheTXT.ForeColor = System.Drawing.Color.White;
            this.ChercheTXT.Location = new System.Drawing.Point(3, 3);
            this.ChercheTXT.Name = "ChercheTXT";
            this.ChercheTXT.Size = new System.Drawing.Size(436, 41);
            this.ChercheTXT.TabIndex = 0;
            this.ChercheTXT.Text = "Chercher...";
            this.ChercheTXT.TextChanged += new System.EventHandler(this.ChercheTXT_TextChanged);
            this.ChercheTXT.Enter += new System.EventHandler(this.ChercheTXT_Enter);
            this.ChercheTXT.Leave += new System.EventHandler(this.ChercheTXT_Leave);
            // 
            // archive
            // 
            this.archive.AccessibleRole = System.Windows.Forms.AccessibleRole.Alert;
            this.archive.AllowUserToAddRows = false;
            this.archive.AllowUserToDeleteRows = false;
            this.archive.AllowUserToResizeRows = false;
            this.archive.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.archive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.archive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.archive.Location = new System.Drawing.Point(0, 0);
            this.archive.MultiSelect = false;
            this.archive.Name = "archive";
            this.archive.ReadOnly = true;
            this.archive.RowHeadersWidth = 51;
            this.archive.RowTemplate.Height = 24;
            this.archive.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.archive.Size = new System.Drawing.Size(1260, 536);
            this.archive.TabIndex = 1;
            this.archive.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.archive_CellFormatting);
            this.archive.SelectionChanged += new System.EventHandler(this.archive_SelectionChanged);
            // 
            // myButton2
            // 
            this.myButton2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(171)))), ((int)(((byte)(37)))));
            this.myButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myButton2.Font = new System.Drawing.Font("Montserrat Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myButton2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.myButton2.Location = new System.Drawing.Point(719, 6);
            this.myButton2.Margin = new System.Windows.Forms.Padding(6);
            this.myButton2.Name = "myButton2";
            this.myButton2.RoundCorners = ((ImageProcessing.Corners)((((ImageProcessing.Corners.TopLeft | ImageProcessing.Corners.TopRight) 
            | ImageProcessing.Corners.BottomLeft) 
            | ImageProcessing.Corners.BottomRight)));
            this.myButton2.Size = new System.Drawing.Size(130, 38);
            this.myButton2.TabIndex = 5;
            this.myButton2.Text = "Faire retourner";
            this.myButton2.Click += new System.EventHandler(this.myButton2_Click);
            // 
            // myButton1
            // 
            this.myButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(171)))), ((int)(((byte)(37)))));
            this.myButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myButton1.Font = new System.Drawing.Font("Montserrat Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myButton1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.myButton1.Location = new System.Drawing.Point(861, 6);
            this.myButton1.Margin = new System.Windows.Forms.Padding(6);
            this.myButton1.Name = "myButton1";
            this.myButton1.RoundCorners = ((ImageProcessing.Corners)((((ImageProcessing.Corners.TopLeft | ImageProcessing.Corners.TopRight) 
            | ImageProcessing.Corners.BottomLeft) 
            | ImageProcessing.Corners.BottomRight)));
            this.myButton1.Size = new System.Drawing.Size(123, 38);
            this.myButton1.TabIndex = 4;
            this.myButton1.Text = "Supprimer";
            this.myButton1.Click += new System.EventHandler(this.myButton1_Click);
            // 
            // ModifierBtn
            // 
            this.ModifierBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ModifierBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(171)))), ((int)(((byte)(37)))));
            this.ModifierBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ModifierBtn.Font = new System.Drawing.Font("Montserrat Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModifierBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ModifierBtn.Location = new System.Drawing.Point(996, 6);
            this.ModifierBtn.Margin = new System.Windows.Forms.Padding(6);
            this.ModifierBtn.Name = "ModifierBtn";
            this.ModifierBtn.RoundCorners = ((ImageProcessing.Corners)((((ImageProcessing.Corners.TopLeft | ImageProcessing.Corners.TopRight) 
            | ImageProcessing.Corners.BottomLeft) 
            | ImageProcessing.Corners.BottomRight)));
            this.ModifierBtn.Size = new System.Drawing.Size(123, 38);
            this.ModifierBtn.TabIndex = 3;
            this.ModifierBtn.Text = "Modifier";
            this.ModifierBtn.Click += new System.EventHandler(this.ModifierBtn_Click);
            // 
            // SortirBtn
            // 
            this.SortirBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SortirBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.SortirBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SortirBtn.Font = new System.Drawing.Font("Montserrat Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortirBtn.ForeColor = System.Drawing.Color.Black;
            this.SortirBtn.Location = new System.Drawing.Point(1131, 6);
            this.SortirBtn.Margin = new System.Windows.Forms.Padding(6);
            this.SortirBtn.Name = "SortirBtn";
            this.SortirBtn.RoundCorners = ((ImageProcessing.Corners)((((ImageProcessing.Corners.TopLeft | ImageProcessing.Corners.TopRight) 
            | ImageProcessing.Corners.BottomLeft) 
            | ImageProcessing.Corners.BottomRight)));
            this.SortirBtn.Size = new System.Drawing.Size(123, 38);
            this.SortirBtn.TabIndex = 2;
            this.SortirBtn.Text = "Faire. S";
            this.SortirBtn.Click += new System.EventHandler(this.SortirBtn_Click);
            // 
            // ArchiveControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.archive);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(1260, 586);
            this.Name = "ArchiveControl";
            this.Size = new System.Drawing.Size(1260, 586);
            this.Load += new System.EventHandler(this.ArchiveControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.archive)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox ChercheTXT;
        private ImageProcessing.MyButton ModifierBtn;
        private ImageProcessing.MyButton SortirBtn;
        private ImageProcessing.MyButton myButton1;
        private ImageProcessing.MyButton myButton2;
        public System.Windows.Forms.DataGridView archive;
        private System.Windows.Forms.ComboBox YearCombo;
    }
}
