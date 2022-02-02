namespace repuloterProject.Views
{
    partial class FormBejelentkezes
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBejelentkezes));
            this.buttonSetting = new System.Windows.Forms.Button();
            this.X = new System.Windows.Forms.Button();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonBejelentkezes = new System.Windows.Forms.Button();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labe2 = new System.Windows.Forms.Label();
            this.textBoxJelszo = new System.Windows.Forms.TextBox();
            this.labelElfelejtettJelszo = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.labelKeszitoNeve = new System.Windows.Forms.Label();
            this.panelTitleBar.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSetting
            // 
            this.buttonSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetting.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSetting.Location = new System.Drawing.Point(1194, 46);
            this.buttonSetting.Name = "buttonSetting";
            this.buttonSetting.Size = new System.Drawing.Size(58, 39);
            this.buttonSetting.TabIndex = 12;
            this.buttonSetting.Text = "Setting";
            this.buttonSetting.UseVisualStyleBackColor = false;
            this.buttonSetting.Click += new System.EventHandler(this.buttonSetting_Click);
            // 
            // X
            // 
            this.X.Cursor = System.Windows.Forms.Cursors.Hand;
            this.X.Dock = System.Windows.Forms.DockStyle.Right;
            this.X.FlatAppearance.BorderSize = 0;
            this.X.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.X.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(238)));
            this.X.ForeColor = System.Drawing.Color.Crimson;
            this.X.Location = new System.Drawing.Point(1198, 0);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(66, 40);
            this.X.TabIndex = 8;
            this.X.Text = "X";
            this.X.UseVisualStyleBackColor = true;
            this.X.Click += new System.EventHandler(this.X_Click);
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.SkyBlue;
            this.panelTitleBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelTitleBar.Controls.Add(this.X);
            this.panelTitleBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1264, 40);
            this.panelTitleBar.TabIndex = 14;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 15, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 37);
            this.label2.TabIndex = 18;
            this.label2.Text = "Jelszó:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.buttonBejelentkezes, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxUsername, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labe2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxJelszo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelElfelejtettJelszo, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(106, 178);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(545, 188);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // buttonBejelentkezes
            // 
            this.buttonBejelentkezes.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonBejelentkezes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBejelentkezes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBejelentkezes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonBejelentkezes.Location = new System.Drawing.Point(211, 80);
            this.buttonBejelentkezes.Name = "buttonBejelentkezes";
            this.buttonBejelentkezes.Size = new System.Drawing.Size(325, 77);
            this.buttonBejelentkezes.TabIndex = 2;
            this.buttonBejelentkezes.Text = "Bejelentkezes";
            this.buttonBejelentkezes.UseVisualStyleBackColor = false;
            this.buttonBejelentkezes.Click += new System.EventHandler(this.buttonBejelentkezes_Click);
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxUsername.Location = new System.Drawing.Point(211, 6);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(328, 31);
            this.textBoxUsername.TabIndex = 0;
            this.textBoxUsername.Text = "Felhasználónév";
            this.textBoxUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labe2
            // 
            this.labe2.AutoSize = true;
            this.labe2.BackColor = System.Drawing.Color.Transparent;
            this.labe2.Dock = System.Windows.Forms.DockStyle.Right;
            this.labe2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labe2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labe2.ForeColor = System.Drawing.Color.White;
            this.labe2.Location = new System.Drawing.Point(6, 3);
            this.labe2.Margin = new System.Windows.Forms.Padding(3, 0, 15, 0);
            this.labe2.Name = "labe2";
            this.labe2.Size = new System.Drawing.Size(187, 37);
            this.labe2.TabIndex = 17;
            this.labe2.Text = "Felhasználónév:";
            this.labe2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxJelszo
            // 
            this.textBoxJelszo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxJelszo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxJelszo.Location = new System.Drawing.Point(211, 43);
            this.textBoxJelszo.Name = "textBoxJelszo";
            this.textBoxJelszo.Size = new System.Drawing.Size(328, 31);
            this.textBoxJelszo.TabIndex = 1;
            this.textBoxJelszo.Text = "Jelszó";
            this.textBoxJelszo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelElfelejtettJelszo
            // 
            this.labelElfelejtettJelszo.AutoSize = true;
            this.labelElfelejtettJelszo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelElfelejtettJelszo.Location = new System.Drawing.Point(211, 160);
            this.labelElfelejtettJelszo.Name = "labelElfelejtettJelszo";
            this.labelElfelejtettJelszo.Size = new System.Drawing.Size(328, 25);
            this.labelElfelejtettJelszo.TabIndex = 19;
            this.labelElfelejtettJelszo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // labelKeszitoNeve
            // 
            this.labelKeszitoNeve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelKeszitoNeve.AutoSize = true;
            this.labelKeszitoNeve.BackColor = System.Drawing.Color.SkyBlue;
            this.labelKeszitoNeve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelKeszitoNeve.Cursor = System.Windows.Forms.Cursors.Help;
            this.labelKeszitoNeve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelKeszitoNeve.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelKeszitoNeve.ForeColor = System.Drawing.Color.Black;
            this.labelKeszitoNeve.Location = new System.Drawing.Point(987, 648);
            this.labelKeszitoNeve.Name = "labelKeszitoNeve";
            this.labelKeszitoNeve.Size = new System.Drawing.Size(267, 27);
            this.labelKeszitoNeve.TabIndex = 22;
            this.labelKeszitoNeve.Text = "Készítetette: Makán István";
            // 
            // FormBejelentkezes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 682);
            this.Controls.Add(this.labelKeszitoNeve);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.buttonSetting);
            this.ForeColor = System.Drawing.Color.Cornsilk;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(819, 46);
            this.MinimumSize = new System.Drawing.Size(820, 420);
            this.Name = "FormBejelentkezes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bejelentkezés";
            this.panelTitleBar.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSetting;
        private System.Windows.Forms.Button X;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonBejelentkezes;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labe2;
        private System.Windows.Forms.TextBox textBoxJelszo;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label labelElfelejtettJelszo;
        private System.Windows.Forms.Label labelKeszitoNeve;
    }
}