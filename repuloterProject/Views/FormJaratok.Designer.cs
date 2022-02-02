
namespace repuloterProject.Views
{
    partial class FormJaratok
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJaratok));
            this.buttonKövetkezo = new System.Windows.Forms.Button();
            this.buttonUtolso = new System.Windows.Forms.Button();
            this.buttonElobbi = new System.Windows.Forms.Button();
            this.buttonElso = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelosszesItem = new System.Windows.Forms.Label();
            this.labelElemPerItem = new System.Windows.Forms.Label();
            this.dataGridViewJarat = new System.Windows.Forms.DataGridView();
            this.buttonSetting = new System.Windows.Forms.Button();
            this.X = new System.Windows.Forms.Button();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonMentes = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBoxKereses = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonKereses = new System.Windows.Forms.ToolStripButton();
            this.buttonVissza = new System.Windows.Forms.Button();
            this.visszaindulasido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aJaratonUtazokSzama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jegyar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jaratszamDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.honnanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hovaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indulasidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.terminalDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.rgepkodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jaratBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJarat)).BeginInit();
            this.panelTitleBar.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jaratBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonKövetkezo
            // 
            this.buttonKövetkezo.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonKövetkezo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonKövetkezo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonKövetkezo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKövetkezo.ForeColor = System.Drawing.Color.Cornsilk;
            this.buttonKövetkezo.Location = new System.Drawing.Point(764, 0);
            this.buttonKövetkezo.Margin = new System.Windows.Forms.Padding(0);
            this.buttonKövetkezo.Name = "buttonKövetkezo";
            this.buttonKövetkezo.Size = new System.Drawing.Size(219, 49);
            this.buttonKövetkezo.TabIndex = 69;
            this.buttonKövetkezo.Text = ">";
            this.buttonKövetkezo.UseVisualStyleBackColor = false;
            this.buttonKövetkezo.Click += new System.EventHandler(this.buttonKövetkezo_Click);
            // 
            // buttonUtolso
            // 
            this.buttonUtolso.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonUtolso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUtolso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonUtolso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUtolso.ForeColor = System.Drawing.Color.Cornsilk;
            this.buttonUtolso.Location = new System.Drawing.Point(983, 0);
            this.buttonUtolso.Margin = new System.Windows.Forms.Padding(0);
            this.buttonUtolso.Name = "buttonUtolso";
            this.buttonUtolso.Size = new System.Drawing.Size(251, 49);
            this.buttonUtolso.TabIndex = 70;
            this.buttonUtolso.Text = ">>";
            this.buttonUtolso.UseVisualStyleBackColor = false;
            this.buttonUtolso.Click += new System.EventHandler(this.buttonUtolso_Click);
            // 
            // buttonElobbi
            // 
            this.buttonElobbi.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonElobbi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonElobbi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonElobbi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonElobbi.ForeColor = System.Drawing.Color.Cornsilk;
            this.buttonElobbi.Location = new System.Drawing.Point(405, 0);
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
            this.buttonElso.Location = new System.Drawing.Point(217, 0);
            this.buttonElso.Margin = new System.Windows.Forms.Padding(0);
            this.buttonElso.Name = "buttonElso";
            this.buttonElso.Size = new System.Drawing.Size(188, 49);
            this.buttonElso.TabIndex = 67;
            this.buttonElso.Text = "<<";
            this.buttonElso.UseVisualStyleBackColor = false;
            this.buttonElso.Click += new System.EventHandler(this.buttonElso_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.45912F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.54088F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 227F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 219F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.Controls.Add(this.labelosszesItem, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonUtolso, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonKövetkezo, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelElemPerItem, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonElobbi, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonElso, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 492);
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
            this.labelosszesItem.Size = new System.Drawing.Size(217, 49);
            this.labelosszesItem.TabIndex = 72;
            this.labelosszesItem.Text = "0";
            this.labelosszesItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelElemPerItem
            // 
            this.labelElemPerItem.AutoSize = true;
            this.labelElemPerItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.labelElemPerItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelElemPerItem.ForeColor = System.Drawing.Color.Cornsilk;
            this.labelElemPerItem.Location = new System.Drawing.Point(632, 0);
            this.labelElemPerItem.Margin = new System.Windows.Forms.Padding(0);
            this.labelElemPerItem.Name = "labelElemPerItem";
            this.labelElemPerItem.Size = new System.Drawing.Size(132, 49);
            this.labelElemPerItem.TabIndex = 71;
            this.labelElemPerItem.Text = "0/0";
            this.labelElemPerItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewJarat
            // 
            this.dataGridViewJarat.AutoGenerateColumns = false;
            this.dataGridViewJarat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewJarat.BackgroundColor = System.Drawing.Color.SkyBlue;
            this.dataGridViewJarat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewJarat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewJarat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.jaratszamDataGridViewTextBoxColumn,
            this.honnanDataGridViewTextBoxColumn,
            this.hovaDataGridViewTextBoxColumn,
            this.indulasidoDataGridViewTextBoxColumn,
            this.visszaindulasido,
            this.terminalDataGridViewCheckBoxColumn,
            this.aJaratonUtazokSzama,
            this.jegyar,
            this.rgepkodDataGridViewTextBoxColumn});
            this.dataGridViewJarat.DataSource = this.jaratBindingSource;
            this.dataGridViewJarat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewJarat.Location = new System.Drawing.Point(0, 34);
            this.dataGridViewJarat.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridViewJarat.Name = "dataGridViewJarat";
            this.dataGridViewJarat.Size = new System.Drawing.Size(1240, 455);
            this.dataGridViewJarat.TabIndex = 68;
            this.dataGridViewJarat.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewJarat_ColumnHeaderMouseClick);
            this.dataGridViewJarat.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewJarat_DataError);
            // 
            // buttonSetting
            // 
            this.buttonSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetting.BackColor = System.Drawing.Color.SkyBlue;
            this.buttonSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSetting.ForeColor = System.Drawing.Color.Cornsilk;
            this.buttonSetting.Location = new System.Drawing.Point(1194, 46);
            this.buttonSetting.Name = "buttonSetting";
            this.buttonSetting.Size = new System.Drawing.Size(58, 39);
            this.buttonSetting.TabIndex = 69;
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
            this.panelTitleBar.TabIndex = 70;
            this.panelTitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseMove);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.dataGridViewJarat, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 90);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.952965F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.04704F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1240, 544);
            this.tableLayoutPanel2.TabIndex = 72;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonMentes,
            this.toolStripTextBoxKereses,
            this.toolStripButtonKereses});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1240, 25);
            this.toolStrip1.TabIndex = 72;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonMentes
            // 
            this.toolStripButtonMentes.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonMentes.Image")));
            this.toolStripButtonMentes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMentes.Name = "toolStripButtonMentes";
            this.toolStripButtonMentes.Size = new System.Drawing.Size(66, 22);
            this.toolStripButtonMentes.Text = "Mentés";
            this.toolStripButtonMentes.Click += new System.EventHandler(this.toolStripButtonMentes_Click);
            // 
            // toolStripTextBoxKereses
            // 
            this.toolStripTextBoxKereses.Name = "toolStripTextBoxKereses";
            this.toolStripTextBoxKereses.Size = new System.Drawing.Size(140, 25);
            // 
            // toolStripButtonKereses
            // 
            this.toolStripButtonKereses.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonKereses.Image")));
            this.toolStripButtonKereses.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonKereses.Name = "toolStripButtonKereses";
            this.toolStripButtonKereses.Size = new System.Drawing.Size(66, 22);
            this.toolStripButtonKereses.Text = "Keresés";
            this.toolStripButtonKereses.Click += new System.EventHandler(this.toolStripButtonKereses_Click);
            // 
            // buttonVissza
            // 
            this.buttonVissza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonVissza.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonVissza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonVissza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVissza.ForeColor = System.Drawing.Color.Cornsilk;
            this.buttonVissza.Location = new System.Drawing.Point(1160, 640);
            this.buttonVissza.Name = "buttonVissza";
            this.buttonVissza.Size = new System.Drawing.Size(92, 35);
            this.buttonVissza.TabIndex = 73;
            this.buttonVissza.Text = "Vissza";
            this.buttonVissza.UseVisualStyleBackColor = false;
            this.buttonVissza.Click += new System.EventHandler(this.buttonVissza_Click);
            // 
            // visszaindulasido
            // 
            this.visszaindulasido.DataPropertyName = "visszaindulasido";
            this.visszaindulasido.HeaderText = "Vissza indulás ideje";
            this.visszaindulasido.Name = "visszaindulasido";
            // 
            // aJaratonUtazokSzama
            // 
            this.aJaratonUtazokSzama.DataPropertyName = "aJaratonUtazokSzama";
            this.aJaratonUtazokSzama.HeaderText = "A járaton utazók létszáma";
            this.aJaratonUtazokSzama.Name = "aJaratonUtazokSzama";
            this.aJaratonUtazokSzama.ReadOnly = true;
            // 
            // jegyar
            // 
            this.jegyar.DataPropertyName = "jegyar";
            this.jegyar.HeaderText = "Jegy ár";
            this.jegyar.MaxInputLength = 500000;
            this.jegyar.Name = "jegyar";
            // 
            // jaratszamDataGridViewTextBoxColumn
            // 
            this.jaratszamDataGridViewTextBoxColumn.DataPropertyName = "jaratszam";
            this.jaratszamDataGridViewTextBoxColumn.HeaderText = "jaratszam";
            this.jaratszamDataGridViewTextBoxColumn.Name = "jaratszamDataGridViewTextBoxColumn";
            this.jaratszamDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // honnanDataGridViewTextBoxColumn
            // 
            this.honnanDataGridViewTextBoxColumn.DataPropertyName = "honnan";
            this.honnanDataGridViewTextBoxColumn.HeaderText = "Honnan";
            this.honnanDataGridViewTextBoxColumn.Name = "honnanDataGridViewTextBoxColumn";
            // 
            // hovaDataGridViewTextBoxColumn
            // 
            this.hovaDataGridViewTextBoxColumn.DataPropertyName = "hova";
            this.hovaDataGridViewTextBoxColumn.HeaderText = "Hova";
            this.hovaDataGridViewTextBoxColumn.Name = "hovaDataGridViewTextBoxColumn";
            // 
            // indulasidoDataGridViewTextBoxColumn
            // 
            this.indulasidoDataGridViewTextBoxColumn.DataPropertyName = "indulasido";
            this.indulasidoDataGridViewTextBoxColumn.HeaderText = "Indulás ideje";
            this.indulasidoDataGridViewTextBoxColumn.Name = "indulasidoDataGridViewTextBoxColumn";
            // 
            // terminalDataGridViewCheckBoxColumn
            // 
            this.terminalDataGridViewCheckBoxColumn.DataPropertyName = "terminal";
            this.terminalDataGridViewCheckBoxColumn.HeaderText = "Terminál";
            this.terminalDataGridViewCheckBoxColumn.Name = "terminalDataGridViewCheckBoxColumn";
            // 
            // rgepkodDataGridViewTextBoxColumn
            // 
            this.rgepkodDataGridViewTextBoxColumn.DataPropertyName = "rgepkod";
            this.rgepkodDataGridViewTextBoxColumn.HeaderText = "rgepkod";
            this.rgepkodDataGridViewTextBoxColumn.Name = "rgepkodDataGridViewTextBoxColumn";
            this.rgepkodDataGridViewTextBoxColumn.Visible = false;
            // 
            // jaratBindingSource
            // 
            this.jaratBindingSource.DataSource = typeof(repuloterProject.Models.jarat);
            // 
            // FormJaratok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 682);
            this.Controls.Add(this.buttonVissza);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.buttonSetting);
            this.Controls.Add(this.panelTitleBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(820, 420);
            this.Name = "FormJaratok";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Járatok";
            this.Load += new System.EventHandler(this.FormJaratok_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJarat)).EndInit();
            this.panelTitleBar.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jaratBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonKövetkezo;
        private System.Windows.Forms.Button buttonUtolso;
        private System.Windows.Forms.Button buttonElobbi;
        private System.Windows.Forms.Button buttonElso;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelElemPerItem;
        private System.Windows.Forms.DataGridView dataGridViewJarat;
        private System.Windows.Forms.Button buttonSetting;
        private System.Windows.Forms.Button X;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxKereses;
        private System.Windows.Forms.ToolStripButton toolStripButtonKereses;
        private System.Windows.Forms.Label labelosszesItem;
        private System.Windows.Forms.Button buttonVissza;
        private System.Windows.Forms.ToolStripButton toolStripButtonMentes;
        private System.Windows.Forms.BindingSource jaratBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn erkezesidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jaratszamDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn honnanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hovaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indulasidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn visszaindulasido;
        private System.Windows.Forms.DataGridViewCheckBoxColumn terminalDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aJaratonUtazokSzama;
        private System.Windows.Forms.DataGridViewTextBoxColumn jegyar;
        private System.Windows.Forms.DataGridViewTextBoxColumn rgepkodDataGridViewTextBoxColumn;
    }
}