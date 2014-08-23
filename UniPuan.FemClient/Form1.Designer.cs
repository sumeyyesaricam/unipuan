namespace UniPuan.FemClient
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbBolum = new System.Windows.Forms.ListBox();
            this.lbSehir = new System.Windows.Forms.ListBox();
            this.lbBolumSecilen = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbSehirSecilen = new System.Windows.Forms.ListBox();
            this.lbUniversiteSecilen = new System.Windows.Forms.ListBox();
            this.lbUniversite = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.rbLisans = new System.Windows.Forms.RadioButton();
            this.rbOnlisans = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bölümler";
            // 
            // lbBolum
            // 
            this.lbBolum.FormattingEnabled = true;
            this.lbBolum.Location = new System.Drawing.Point(15, 72);
            this.lbBolum.Name = "lbBolum";
            this.lbBolum.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbBolum.Size = new System.Drawing.Size(260, 264);
            this.lbBolum.TabIndex = 2;
            this.lbBolum.SelectedValueChanged += new System.EventHandler(this.lbBolum_SelectedValueChanged);
            // 
            // lbSehir
            // 
            this.lbSehir.DisplayMember = "ilAdi";
            this.lbSehir.FormattingEnabled = true;
            this.lbSehir.Location = new System.Drawing.Point(15, 371);
            this.lbSehir.Name = "lbSehir";
            this.lbSehir.Size = new System.Drawing.Size(260, 264);
            this.lbSehir.TabIndex = 3;
            this.lbSehir.ValueMember = "ilId";
            this.lbSehir.SelectedIndexChanged += new System.EventHandler(this.lbSehir_SelectedIndexChanged);
            // 
            // lbBolumSecilen
            // 
            this.lbBolumSecilen.DisplayMember = "BolumAdi";
            this.lbBolumSecilen.FormattingEnabled = true;
            this.lbBolumSecilen.Location = new System.Drawing.Point(281, 72);
            this.lbBolumSecilen.Name = "lbBolumSecilen";
            this.lbBolumSecilen.Size = new System.Drawing.Size(250, 264);
            this.lbBolumSecilen.TabIndex = 4;
            this.lbBolumSecilen.ValueMember = "BolumId";
            this.lbBolumSecilen.SelectedIndexChanged += new System.EventHandler(this.lbBolumSecilen_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Seçilen Bölümler";
            // 
            // lbSehirSecilen
            // 
            this.lbSehirSecilen.DisplayMember = "ilAdi";
            this.lbSehirSecilen.FormattingEnabled = true;
            this.lbSehirSecilen.Location = new System.Drawing.Point(281, 371);
            this.lbSehirSecilen.Name = "lbSehirSecilen";
            this.lbSehirSecilen.Size = new System.Drawing.Size(250, 264);
            this.lbSehirSecilen.TabIndex = 6;
            this.lbSehirSecilen.ValueMember = "ilId";
            this.lbSehirSecilen.SelectedIndexChanged += new System.EventHandler(this.lbSehirSecilen_SelectedIndexChanged);
            // 
            // lbUniversiteSecilen
            // 
            this.lbUniversiteSecilen.DisplayMember = "Universitead";
            this.lbUniversiteSecilen.FormattingEnabled = true;
            this.lbUniversiteSecilen.Location = new System.Drawing.Point(812, 371);
            this.lbUniversiteSecilen.Name = "lbUniversiteSecilen";
            this.lbUniversiteSecilen.Size = new System.Drawing.Size(250, 264);
            this.lbUniversiteSecilen.TabIndex = 8;
            this.lbUniversiteSecilen.ValueMember = "UNIVERSITEID";
            this.lbUniversiteSecilen.SelectedIndexChanged += new System.EventHandler(this.lbUniversiteSecilen_SelectedIndexChanged);
            // 
            // lbUniversite
            // 
            this.lbUniversite.DisplayMember = "Universitead";
            this.lbUniversite.FormattingEnabled = true;
            this.lbUniversite.Location = new System.Drawing.Point(546, 371);
            this.lbUniversite.Name = "lbUniversite";
            this.lbUniversite.Size = new System.Drawing.Size(260, 264);
            this.lbUniversite.TabIndex = 7;
            this.lbUniversite.ValueMember = "UNIVERSITEID";
            this.lbUniversite.SelectedIndexChanged += new System.EventHandler(this.lbUniversite_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 355);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Şehirler";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 355);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Seçilen Şehirler";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(543, 355);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Üniversiteler";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(809, 355);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Seçilen Üniversiteler";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(546, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(536, 273);
            this.dataGridView1.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(207, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 30);
            this.button1.TabIndex = 14;
            this.button1.Text = "Verileri Al";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rbLisans
            // 
            this.rbLisans.AutoSize = true;
            this.rbLisans.Checked = true;
            this.rbLisans.Location = new System.Drawing.Point(15, 12);
            this.rbLisans.Name = "rbLisans";
            this.rbLisans.Size = new System.Drawing.Size(55, 17);
            this.rbLisans.TabIndex = 15;
            this.rbLisans.TabStop = true;
            this.rbLisans.Text = "Lisans";
            this.rbLisans.UseVisualStyleBackColor = true;
            this.rbLisans.CheckedChanged += new System.EventHandler(this.rbLisans_CheckedChanged);
            // 
            // rbOnlisans
            // 
            this.rbOnlisans.AutoSize = true;
            this.rbOnlisans.Location = new System.Drawing.Point(85, 12);
            this.rbOnlisans.Name = "rbOnlisans";
            this.rbOnlisans.Size = new System.Drawing.Size(69, 17);
            this.rbOnlisans.TabIndex = 16;
            this.rbOnlisans.Text = "ÖnLisans";
            this.rbOnlisans.UseVisualStyleBackColor = true;
            this.rbOnlisans.CheckedChanged += new System.EventHandler(this.rbOnlisans_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 741);
            this.Controls.Add(this.rbOnlisans);
            this.Controls.Add(this.rbLisans);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbUniversiteSecilen);
            this.Controls.Add(this.lbUniversite);
            this.Controls.Add(this.lbSehirSecilen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbBolumSecilen);
            this.Controls.Add(this.lbSehir);
            this.Controls.Add(this.lbBolum);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbBolum;
        private System.Windows.Forms.ListBox lbSehir;
        private System.Windows.Forms.ListBox lbBolumSecilen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbSehirSecilen;
        private System.Windows.Forms.ListBox lbUniversiteSecilen;
        private System.Windows.Forms.ListBox lbUniversite;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rbLisans;
        private System.Windows.Forms.RadioButton rbOnlisans;
    }
}

