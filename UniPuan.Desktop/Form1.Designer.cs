namespace UniPuan.Desktop
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboLic = new System.Windows.Forms.ComboBox();
            this.comboUniType = new System.Windows.Forms.ComboBox();
            this.comboUni = new System.Windows.Forms.ComboBox();
            this.comboCity = new System.Windows.Forms.ComboBox();
            this.comboDepart = new System.Windows.Forms.ComboBox();
            this.comboFaculty = new System.Windows.Forms.ComboBox();
            this.comboScore = new System.Windows.Forms.ComboBox();
            this.ara = new System.Windows.Forms.Button();
            this.rdioRank = new System.Windows.Forms.RadioButton();
            this.rdioScore = new System.Windows.Forms.RadioButton();
            this.textScrMin = new System.Windows.Forms.TextBox();
            this.textScrMax = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textRank = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboLic);
            this.groupBox2.Controls.Add(this.comboUniType);
            this.groupBox2.Controls.Add(this.comboUni);
            this.groupBox2.Controls.Add(this.comboCity);
            this.groupBox2.Controls.Add(this.comboDepart);
            this.groupBox2.Controls.Add(this.comboFaculty);
            this.groupBox2.Controls.Add(this.comboScore);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(38, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 401);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seçiniz";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(60, 327);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Üniversite";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(60, 274);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "İL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Bölüm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Fakülte";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Üniversite Türü";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Puan Türü";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(60, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lisans Türü";
            // 
            // comboLic
            // 
            this.comboLic.DisplayMember = "Name";
            this.comboLic.FormattingEnabled = true;
            this.comboLic.Location = new System.Drawing.Point(13, 49);
            this.comboLic.Name = "comboLic";
            this.comboLic.Size = new System.Drawing.Size(271, 21);
            this.comboLic.TabIndex = 16;
            this.comboLic.ValueMember = "Id";
            this.comboLic.SelectedIndexChanged += new System.EventHandler(this.comboLic_SelectedIndexChanged);
            this.comboLic.TextChanged += new System.EventHandler(this.comboLic_TextChanged);
            // 
            // comboUniType
            // 
            this.comboUniType.DisplayMember = "Name";
            this.comboUniType.FormattingEnabled = true;
            this.comboUniType.Location = new System.Drawing.Point(13, 144);
            this.comboUniType.Name = "comboUniType";
            this.comboUniType.Size = new System.Drawing.Size(271, 21);
            this.comboUniType.TabIndex = 15;
            this.comboUniType.ValueMember = "Id";
            this.comboUniType.SelectedIndexChanged += new System.EventHandler(this.comboUniType_SelectedIndexChanged);
            // 
            // comboUni
            // 
            this.comboUni.DisplayMember = "Name";
            this.comboUni.FormattingEnabled = true;
            this.comboUni.Location = new System.Drawing.Point(13, 343);
            this.comboUni.Name = "comboUni";
            this.comboUni.Size = new System.Drawing.Size(271, 21);
            this.comboUni.TabIndex = 13;
            this.comboUni.ValueMember = "Id";
            this.comboUni.SelectedIndexChanged += new System.EventHandler(this.comboUni_SelectedIndexChanged);
            // 
            // comboCity
            // 
            this.comboCity.DisplayMember = "Name";
            this.comboCity.FormattingEnabled = true;
            this.comboCity.Location = new System.Drawing.Point(13, 290);
            this.comboCity.Name = "comboCity";
            this.comboCity.Size = new System.Drawing.Size(271, 21);
            this.comboCity.TabIndex = 12;
            this.comboCity.ValueMember = "Id";
            this.comboCity.SelectedIndexChanged += new System.EventHandler(this.comboCity_SelectedIndexChanged);
            // 
            // comboDepart
            // 
            this.comboDepart.DisplayMember = "Name";
            this.comboDepart.FormattingEnabled = true;
            this.comboDepart.Location = new System.Drawing.Point(13, 240);
            this.comboDepart.Name = "comboDepart";
            this.comboDepart.Size = new System.Drawing.Size(271, 21);
            this.comboDepart.TabIndex = 11;
            this.comboDepart.ValueMember = "Id";
            this.comboDepart.SelectedIndexChanged += new System.EventHandler(this.comboDepart_SelectedIndexChanged);
            // 
            // comboFaculty
            // 
            this.comboFaculty.DisplayMember = "Name";
            this.comboFaculty.FormattingEnabled = true;
            this.comboFaculty.Location = new System.Drawing.Point(13, 188);
            this.comboFaculty.Name = "comboFaculty";
            this.comboFaculty.Size = new System.Drawing.Size(271, 21);
            this.comboFaculty.TabIndex = 10;
            this.comboFaculty.ValueMember = "Id";
            this.comboFaculty.SelectedIndexChanged += new System.EventHandler(this.comboFaculty_SelectedIndexChanged);
            // 
            // comboScore
            // 
            this.comboScore.DisplayMember = "Name";
            this.comboScore.FormattingEnabled = true;
            this.comboScore.Location = new System.Drawing.Point(13, 99);
            this.comboScore.Name = "comboScore";
            this.comboScore.Size = new System.Drawing.Size(271, 21);
            this.comboScore.TabIndex = 9;
            this.comboScore.ValueMember = "Id";
            this.comboScore.SelectedIndexChanged += new System.EventHandler(this.comboScore_SelectedIndexChanged);
            // 
            // ara
            // 
            this.ara.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ara.Location = new System.Drawing.Point(424, 372);
            this.ara.Name = "ara";
            this.ara.Size = new System.Drawing.Size(140, 46);
            this.ara.TabIndex = 11;
            this.ara.Text = "Araştır";
            this.ara.UseVisualStyleBackColor = true;
            this.ara.Click += new System.EventHandler(this.ara_Click);
            // 
            // rdioRank
            // 
            this.rdioRank.AutoSize = true;
            this.rdioRank.Location = new System.Drawing.Point(6, 112);
            this.rdioRank.Name = "rdioRank";
            this.rdioRank.Size = new System.Drawing.Size(115, 17);
            this.rdioRank.TabIndex = 12;
            this.rdioRank.TabStop = true;
            this.rdioRank.Text = "Sıralamaya göre";
            this.rdioRank.UseVisualStyleBackColor = true;
            // 
            // rdioScore
            // 
            this.rdioScore.AutoSize = true;
            this.rdioScore.Location = new System.Drawing.Point(11, 49);
            this.rdioScore.Name = "rdioScore";
            this.rdioScore.Size = new System.Drawing.Size(90, 17);
            this.rdioScore.TabIndex = 13;
            this.rdioScore.TabStop = true;
            this.rdioScore.Text = "Puana göre";
            this.rdioScore.UseVisualStyleBackColor = true;
            // 
            // textScrMin
            // 
            this.textScrMin.Location = new System.Drawing.Point(6, 83);
            this.textScrMin.Name = "textScrMin";
            this.textScrMin.Size = new System.Drawing.Size(95, 20);
            this.textScrMin.TabIndex = 14;
            // 
            // textScrMax
            // 
            this.textScrMax.Location = new System.Drawing.Point(128, 83);
            this.textScrMax.Name = "textScrMax";
            this.textScrMax.Size = new System.Drawing.Size(95, 20);
            this.textScrMax.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Değer aralığını giriniz";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textRank);
            this.groupBox3.Controls.Add(this.rdioRank);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.rdioScore);
            this.groupBox3.Controls.Add(this.textScrMax);
            this.groupBox3.Controls.Add(this.textScrMin);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.Location = new System.Drawing.Point(356, 34);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(245, 179);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            // 
            // textRank
            // 
            this.textRank.Location = new System.Drawing.Point(6, 149);
            this.textRank.Name = "textRank";
            this.textRank.Size = new System.Drawing.Size(100, 20);
            this.textRank.TabIndex = 17;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 482);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(958, 203);
            this.dataGridView1.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(975, 697);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.ara);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "Tercih Rehberi";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ara;
        private System.Windows.Forms.RadioButton rdioRank;
        private System.Windows.Forms.RadioButton rdioScore;
        private System.Windows.Forms.TextBox textScrMin;
        private System.Windows.Forms.TextBox textScrMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboLic;
        private System.Windows.Forms.ComboBox comboUniType;
        private System.Windows.Forms.ComboBox comboUni;
        private System.Windows.Forms.ComboBox comboCity;
        private System.Windows.Forms.ComboBox comboDepart;
        private System.Windows.Forms.ComboBox comboFaculty;
        private System.Windows.Forms.ComboBox comboScore;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textRank;
    }
}

