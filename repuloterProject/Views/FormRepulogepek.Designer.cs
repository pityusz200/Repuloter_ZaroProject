namespace repuloterProject.Views
{
    partial class FormRepulogepek
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRepulogepek));
            this.buttonVissza = new System.Windows.Forms.Button();
            this.toolStripTextBoxKereses = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonMentes = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonKereses = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewRepulogepek = new System.Windows.Forms.DataGridView();
            this.repulogepBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelosszesItem = new System.Windows.Forms.Label();
            this.buttonUtolso = new System.Windows.Forms.Button();
            this.buttonKövetkezo = new System.Windows.Forms.Button();
            this.labelElemPerItem = new System.Windows.Forms.Label();
            this.buttonElobbi = new System.Windows.Forms.Button();
            this.buttonElso = new System.Windows.Forms.Button();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.X = new System.Windows.Forms.Button();
            this.buttonSetting = new System.Windows.Forms.Button();
            this.rgepTarsNevDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meretekDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rgepkodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meretAzDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rgepTarsAzDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRepulogepek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repulogepBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonVissza
            // 
            this.buttonVissza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonVissza.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonVissza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonVissza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVissza.ForeColor = System.Drawing.Color.Cornsilk;
            this.buttonVissza.Location = new System.Drawing.Point(1160, 644);
            this.buttonVissza.Name = "buttonVissza";
            this.buttonVissza.Size = new System.Drawing.Size(92, 35);
            this.buttonVissza.TabIndex = 77;
            this.buttonVissza.Text = "Vissza";
            this.buttonVissza.UseVisualStyleBackColor = false;
            this.buttonVissza.Click += new System.EventHandler(this.buttonVissza_Click);
            // 
            // toolStripTextBoxKereses
            // 
            this.toolStripTextBoxKereses.Name = "toolStripTextBoxKereses";
            this.toolStripTextBoxKereses.Size = new System.Drawing.Size(140, 24);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonMentes,
            this.toolStripTextBoxKereses,
            this.toolStripButtonKereses});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1240, 24);
            this.toolStrip1.TabIndex = 72;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonMentes
            // 
            this.toolStripButtonMentes.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonMentes.Image")));
            this.toolStripButtonMentes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMentes.Name = "toolStripButtonMentes";
            this.toolStripButtonMentes.Size = new System.Drawing.Size(66, 21);
            this.toolStripButtonMentes.Text = "Mentés";
            this.toolStripButtonMentes.Click += new System.EventHandler(this.toolStripButtonMentes_Click);
            // 
            // toolStripButtonKereses
            // 
            this.toolStripButtonKereses.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonKereses.Image")));
            this.toolStripButtonKereses.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonKereses.Name = "toolStripButtonKereses";
            this.toolStripButtonKereses.Size = new System.Drawing.Size(66, 21);
            this.toolStripButtonKereses.Text = "Keresés";
            this.toolStripButtonKereses.Click += new System.EventHandler(this.toolStripButtonKereses_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.dataGridViewRepulogepek, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 95);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.918033F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.08197F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1240, 543);
            this.tableLayoutPanel2.TabIndex = 76;
            // 
            // dataGridViewRepulogepek
            // 
            this.dataGridViewRepulogepek.AutoGenerateColumns = false;
            this.dataGridViewRepulogepek.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRepulogepek.BackgroundColor = System.Drawing.Color.SkyBlue;
            this.dataGridViewRepulogepek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRepulogepek.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rgepTarsNevDataGridViewTextBoxColumn,
            this.tipusDataGridViewTextBoxColumn,
            this.meretekDataGridViewTextBoxColumn,
            this.rgepkodDataGridViewTextBoxColumn,
            this.meretAzDataGridViewTextBoxColumn,
            this.rgepTarsAzDataGridViewTextBoxColumn});
            this.dataGridViewRepulogepek.DataSource = this.repulogepBindingSource;
            this.dataGridViewRepulogepek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRepulogepek.Location = new System.Drawing.Point(3, 27);
            this.dataGridViewRepulogepek.Name = "dataGridViewRepulogepek";
            this.dataGridViewRepulogepek.Size = new System.Drawing.Size(1234, 458);
            this.dataGridViewRepulogepek.TabIndex = 68;
            this.dataGridViewRepulogepek.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewRepulogepek_ColumnHeaderMouseClick);
            // 
            // repulogepBindingSource
            // 
            this.repulogepBindingSource.DataSource = typeof(repuloterProject.Models.repulogep);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.45912F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.54088F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 227F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 219F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 214F));
            this.tableLayoutPanel1.Controls.Add(this.labelosszesItem, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonUtolso, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonKövetkezo, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelElemPerItem, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonElobbi, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonElso, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 491);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1234, 49);
            this.tableLayoutPanel1.TabIndex = 71;
            // 
            // labelosszesItem
            // 
            this.labelosszesItem.AutoSize = true;
            this.labelosszesItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.labelosszesItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelosszesItem.ForeColor = System.Drawing.Color.Cornsilk;
            this.labelosszesItem.Location = new System.Drawing.Point(0, 0);
            this.labelosszesItem.Margin = new System.Windows.Forms.Padding(0);
            this.labelosszesItem.Name = "labelosszesItem";
            this.labelosszesItem.Size = new System.Drawing.Size(236, 49);
            this.labelosszesItem.TabIndex = 72;
            this.labelosszesItem.Text = "0";
            this.labelosszesItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonUtolso
            // 
            this.buttonUtolso.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonUtolso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUtolso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonUtolso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUtolso.ForeColor = System.Drawing.Color.Cornsilk;
            this.buttonUtolso.Location = new System.Drawing.Point(1019, 0);
            this.buttonUtolso.Margin = new System.Windows.Forms.Padding(0);
            this.buttonUtolso.Name = "buttonUtolso";
            this.buttonUtolso.Size = new System.Drawing.Size(215, 49);
            this.buttonUtolso.TabIndex = 70;
            this.buttonUtolso.Text = ">>";
            this.buttonUtolso.UseVisualStyleBackColor = false;
            this.buttonUtolso.Click += new System.EventHandler(this.buttonUtolso_Click);
            // 
            // buttonKövetkezo
            // 
            this.buttonKövetkezo.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonKövetkezo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonKövetkezo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonKövetkezo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKövetkezo.ForeColor = System.Drawing.Color.Cornsilk;
            this.buttonKövetkezo.Location = new System.Drawing.Point(800, 0);
            this.buttonKövetkezo.Margin = new System.Windows.Forms.Padding(0);
            this.buttonKövetkezo.Name = "buttonKövetkezo";
            this.buttonKövetkezo.Size = new System.Drawing.Size(219, 49);
            this.buttonKövetkezo.TabIndex = 69;
            this.buttonKövetkezo.Text = ">";
            this.buttonKövetkezo.UseVisualStyleBackColor = false;
            this.buttonKövetkezo.Click += new System.EventHandler(this.buttonKövetkezo_Click);
            // 
            // labelElemPerItem
            // 
            this.labelElemPerItem.AutoSize = true;
            this.labelElemPerItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.labelElemPerItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelElemPerItem.ForeColor = System.Drawing.Color.Cornsilk;
            this.labelElemPerItem.Location = new System.Drawing.Point(668, 0);
            this.labelElemPerItem.Margin = new System.Windows.Forms.Padding(0);
            this.labelElemPerItem.Name = "labelElemPerItem";
            this.labelElemPerItem.Size = new System.Drawing.Size(132, 49);
            this.labelElemPerItem.TabIndex = 71;
            this.labelElemPerItem.Text = "0/0";
            this.labelElemPerItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonElobbi
            // 
            this.buttonElobbi.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonElobbi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonElobbi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonElobbi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonElobbi.ForeColor = System.Drawing.Color.Cornsilk;
            this.buttonElobbi.Location = new System.Drawing.Point(441, 0);
            this.buttonElobbi.Margin = new System.Windows.Forms.Padding(0);
            this.buttonElobbi.Name = "buttonElobbi";
            this.buttonElobbi.Size = new System.Drawing.Size(227, 49);
            this.buttonElobbi.TabIndex = 68;
            this.buttonElobbi.Text = "<";
            this.buttonElobbi.UseVisualStyleBackColor = false;
            this.buttonElobbi.Click += new System.EventHandler(this.buttonElobbi_Click);
            // 
            // buttonElso
            // 
            this.buttonElso.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonElso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonElso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonElso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonElso.ForeColor = System.Drawing.Color.Cornsilk;
            this.buttonElso.Location = new System.Drawing.Point(236, 0);
            this.buttonElso.Margin = new System.Windows.Forms.Padding(0);
            this.buttonElso.Name = "buttonElso";
            this.buttonElso.Size = new System.Drawing.Size(205, 49);
            this.buttonElso.TabIndex = 67;
            this.buttonElso.Text = "<<";
            this.buttonElso.UseVisualStyleBackColor = false;
            this.buttonElso.Click += new System.EventHandler(this.buttonElso_Click);
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
            this.panelTitleBar.TabIndex = 75;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
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
            // buttonSetting
            // 
            this.buttonSetting.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSetting.ForeColor = System.Drawing.Color.Cornsilk;
            this.buttonSetting.Location = new System.Drawing.Point(1194, 50);
            this.buttonSetting.Name = "buttonSetting";
            this.buttonSetting.Size = new System.Drawing.Size(58, 39);
            this.buttonSetting.TabIndex = 74;
            this.buttonSetting.Text = "Setting";
            this.buttonSetting.UseVisualStyleBackColor = false;
            this.buttonSetting.Click += new System.EventHandler(this.buttonSetting_Click);
            // 
            // rgepTarsNevDataGridViewTextBoxColumn
            // 
            this.rgepTarsNevDataGridViewTextBoxColumn.DataPropertyName = "rgepTarsNev";
            this.rgepTarsNevDataGridViewTextBoxColumn.HeaderText = "Repülőgép társaság neve";
            this.rgepTarsNevDataGridViewTextBoxColumn.Name = "rgepTarsNevDataGridViewTextBoxColumn";
            // 
            // tipusDataGridViewTextBoxColumn
            // 
            this.tipusDataGridViewTextBoxColumn.DataPropertyName = "tipus";
            this.tipusDataGridViewTextBoxColumn.HeaderText = "Repülőgép típusa";
            this.tipusDataGridViewTextBoxColumn.Name = "tipusDataGridViewTextBoxColumn";
            // 
            // meretekDataGridViewTextBoxColumn
            // 
            this.meretekDataGridViewTextBoxColumn.DataPropertyName = "meretek";
            this.meretekDataGridViewTextBoxColumn.HeaderText = "Ülőhelyek száma";
            this.meretekDataGridViewTextBoxColumn.Name = "meretekDataGridViewTextBoxColumn";
            this.meretekDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rgepkodDataGridViewTextBoxColumn
            // 
            this.rgepkodDataGridViewTextBoxColumn.DataPropertyName = "rgepkod";
            this.rgepkodDataGridViewTextBoxColumn.HeaderText = "rgepkod";
            this.rgepkodDataGridViewTextBoxColumn.Name = "rgepkodDataGridViewTextBoxColumn";
            this.rgepkodDataGridViewTextBoxColumn.Visible = false;
            // 
            // meretAzDataGridViewTextBoxColumn
            // 
            this.meretAzDataGridViewTextBoxColumn.DataPropertyName = "meretAz";
            this.meretAzDataGridViewTextBoxColumn.HeaderText = "meretAz";
            this.meretAzDataGridViewTextBoxColumn.Name = "meretAzDataGridViewTextBoxColumn";
            this.meretAzDataGridViewTextBoxColumn.Visible = false;
            // 
            // rgepTarsAzDataGridViewTextBoxColumn
            // 
            this.rgepTarsAzDataGridViewTextBoxColumn.DataPropertyName = "rgepTarsAz";
            this.rgepTarsAzDataGridViewTextBoxColumn.HeaderText = "rgepTarsAz";
            this.rgepTarsAzDataGridViewTextBoxColumn.Name = "rgepTarsAzDataGridViewTextBoxColumn";
            this.rgepTarsAzDataGridViewTextBoxColumn.Visible = false;
            // 
            // FormRepulogepek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 682);
            this.Controls.Add(this.buttonVissza);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.buttonSetting);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(820, 420);
            this.Name = "FormRepulogepek";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Repűlők";
            this.Load += new System.EventHandler(this.FormRepulogepek_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRepulogepek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repulogepBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelTitleBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonVissza;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxKereses;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonKereses;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dataGridViewRepulogepek;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelosszesItem;
        private System.Windows.Forms.Button buttonUtolso;
        private System.Windows.Forms.Button buttonKövetkezo;
        private System.Windows.Forms.Label labelElemPerItem;
        private System.Windows.Forms.Button buttonElobbi;
        private System.Windows.Forms.Button buttonElso;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Button X;
        private System.Windows.Forms.Button buttonSetting;
        private System.Windows.Forms.ToolStripButton toolStripButtonMentes;
        private System.Windows.Forms.BindingSource repulogepBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn rgepTarsNevDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn meretekDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rgepkodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn meretAzDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rgepTarsAzDataGridViewTextBoxColumn;
    }
}