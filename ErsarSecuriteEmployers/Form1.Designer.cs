namespace ErsarServiceEmployers
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.btnClose = new ImageProcessing.MyButton();
            this.btnMaximize = new ImageProcessing.MyButton();
            this.bntMinimize = new ImageProcessing.MyButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.versionLbl = new System.Windows.Forms.Label();
            this.dataBtn = new ImageProcessing.MyButton();
            this.listeBtn = new ImageProcessing.MyButton();
            this.NouvButton = new ImageProcessing.MyButton();
            this.saisir1 = new ErsarServiceEmployers.Saisir();
            this.dataControl1 = new ErsarServiceEmployers.DataControl();
            this.archiveControl1 = new ErsarServiceEmployers.ArchiveControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.TopPanel);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnMaximize);
            this.panel1.Controls.Add(this.bntMinimize);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1261, 43);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = global::ErsarServiceEmployers.Properties.Resources.securiteLogo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // TopPanel
            // 
            this.TopPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.TopPanel.Location = new System.Drawing.Point(851, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(147, 43);
            this.TopPanel.TabIndex = 8;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.CornerRadius = 50;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(1220, 9);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.RoundCorners = ((ImageProcessing.Corners)((((ImageProcessing.Corners.TopLeft | ImageProcessing.Corners.TopRight) 
            | ImageProcessing.Corners.BottomLeft) 
            | ImageProcessing.Corners.BottomRight)));
            this.btnClose.Size = new System.Drawing.Size(27, 25);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "✘";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.btnMaximize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMaximize.CornerRadius = 50;
            this.btnMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximize.ForeColor = System.Drawing.Color.Black;
            this.btnMaximize.Location = new System.Drawing.Point(1183, 9);
            this.btnMaximize.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.RoundCorners = ((ImageProcessing.Corners)((((ImageProcessing.Corners.TopLeft | ImageProcessing.Corners.TopRight) 
            | ImageProcessing.Corners.BottomLeft) 
            | ImageProcessing.Corners.BottomRight)));
            this.btnMaximize.Size = new System.Drawing.Size(27, 25);
            this.btnMaximize.TabIndex = 6;
            this.btnMaximize.Text = "⬜";
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // bntMinimize
            // 
            this.bntMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.bntMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bntMinimize.CornerRadius = 50;
            this.bntMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bntMinimize.ForeColor = System.Drawing.Color.Black;
            this.bntMinimize.Location = new System.Drawing.Point(1146, 9);
            this.bntMinimize.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.bntMinimize.Name = "bntMinimize";
            this.bntMinimize.RoundCorners = ((ImageProcessing.Corners)((((ImageProcessing.Corners.TopLeft | ImageProcessing.Corners.TopRight) 
            | ImageProcessing.Corners.BottomLeft) 
            | ImageProcessing.Corners.BottomRight)));
            this.bntMinimize.Size = new System.Drawing.Size(27, 25);
            this.bntMinimize.TabIndex = 5;
            this.bntMinimize.Text = "_";
            this.bntMinimize.Click += new System.EventHandler(this.bntMinimize_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.versionLbl);
            this.panel2.Controls.Add(this.dataBtn);
            this.panel2.Controls.Add(this.listeBtn);
            this.panel2.Controls.Add(this.NouvButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1261, 49);
            this.panel2.TabIndex = 1;
            // 
            // versionLbl
            // 
            this.versionLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.versionLbl.AutoSize = true;
            this.versionLbl.ForeColor = System.Drawing.Color.White;
            this.versionLbl.Location = new System.Drawing.Point(3, 29);
            this.versionLbl.Name = "versionLbl";
            this.versionLbl.Size = new System.Drawing.Size(51, 20);
            this.versionLbl.TabIndex = 8;
            this.versionLbl.Text = "v1.0.5";
            // 
            // dataBtn
            // 
            this.dataBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(171)))), ((int)(((byte)(37)))));
            this.dataBtn.CornerRadius = 12;
            this.dataBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dataBtn.Location = new System.Drawing.Point(851, -1);
            this.dataBtn.Name = "dataBtn";
            this.dataBtn.RoundCorners = ((ImageProcessing.Corners)((ImageProcessing.Corners.BottomLeft | ImageProcessing.Corners.BottomRight)));
            this.dataBtn.Size = new System.Drawing.Size(147, 43);
            this.dataBtn.TabIndex = 7;
            this.dataBtn.Text = "Data. Employer";
            this.dataBtn.Click += new System.EventHandler(this.dataBtn_Click);
            // 
            // listeBtn
            // 
            this.listeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(171)))), ((int)(((byte)(37)))));
            this.listeBtn.CornerRadius = 12;
            this.listeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listeBtn.Location = new System.Drawing.Point(698, -1);
            this.listeBtn.Name = "listeBtn";
            this.listeBtn.RoundCorners = ((ImageProcessing.Corners)((ImageProcessing.Corners.BottomLeft | ImageProcessing.Corners.BottomRight)));
            this.listeBtn.Size = new System.Drawing.Size(147, 43);
            this.listeBtn.TabIndex = 6;
            this.listeBtn.Text = "Liste. Employer";
            this.listeBtn.Click += new System.EventHandler(this.listeBtn_Click);
            // 
            // NouvButton
            // 
            this.NouvButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NouvButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(171)))), ((int)(((byte)(37)))));
            this.NouvButton.CornerRadius = 12;
            this.NouvButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NouvButton.Location = new System.Drawing.Point(545, -1);
            this.NouvButton.Name = "NouvButton";
            this.NouvButton.RoundCorners = ((ImageProcessing.Corners)((ImageProcessing.Corners.BottomLeft | ImageProcessing.Corners.BottomRight)));
            this.NouvButton.Size = new System.Drawing.Size(147, 43);
            this.NouvButton.TabIndex = 5;
            this.NouvButton.Text = "Nouv. Employer";
            this.NouvButton.Click += new System.EventHandler(this.NouvButton_Click);
            // 
            // saisir1
            // 
            this.saisir1.BackColor = System.Drawing.Color.White;
            this.saisir1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saisir1.Font = new System.Drawing.Font("Montserrat Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saisir1.Location = new System.Drawing.Point(0, 0);
            this.saisir1.Margin = new System.Windows.Forms.Padding(0);
            this.saisir1.MinimumSize = new System.Drawing.Size(1260, 586);
            this.saisir1.Name = "saisir1";
            this.saisir1.Size = new System.Drawing.Size(1261, 681);
            this.saisir1.TabIndex = 4;
            // 
            // dataControl1
            // 
            this.dataControl1.BackColor = System.Drawing.Color.White;
            this.dataControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataControl1.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataControl1.Location = new System.Drawing.Point(0, 0);
            this.dataControl1.Margin = new System.Windows.Forms.Padding(0);
            this.dataControl1.MinimumSize = new System.Drawing.Size(1260, 586);
            this.dataControl1.Name = "dataControl1";
            this.dataControl1.Size = new System.Drawing.Size(1261, 681);
            this.dataControl1.TabIndex = 3;
            // 
            // archiveControl1
            // 
            this.archiveControl1.BackColor = System.Drawing.Color.Black;
            this.archiveControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.archiveControl1.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.archiveControl1.Location = new System.Drawing.Point(0, 92);
            this.archiveControl1.Margin = new System.Windows.Forms.Padding(0);
            this.archiveControl1.MinimumSize = new System.Drawing.Size(1260, 586);
            this.archiveControl1.Name = "archiveControl1";
            this.archiveControl1.Size = new System.Drawing.Size(1261, 589);
            this.archiveControl1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1261, 681);
            this.Controls.Add(this.archiveControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.saisir1);
            this.Controls.Add(this.dataControl1);
            this.Font = new System.Drawing.Font("Montserrat Medium", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1277, 720);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ImageProcessing.MyButton btnClose;
        private ImageProcessing.MyButton btnMaximize;
        private ImageProcessing.MyButton bntMinimize;
        private System.Windows.Forms.Panel panel2;
        private ImageProcessing.MyButton NouvButton;
        private ImageProcessing.MyButton dataBtn;
        private ImageProcessing.MyButton listeBtn;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DataControl dataControl1;
        private Saisir saisir1;
        private ArchiveControl archiveControl1;
        private System.Windows.Forms.Label versionLbl;
    }
}

