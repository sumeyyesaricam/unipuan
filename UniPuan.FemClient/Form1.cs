﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniPuan.FemClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            BolumYukle();

        }
        public void BolumYukle()
        {
            var bolumler = FemHelper.LisansBolumler();
            this.lbBolum.DisplayMember = "BolumAdi";
            this.lbBolum.ValueMember = "BolumId";
            this.lbBolum.DataSource = bolumler;
        }
        public void SehirYukle()
        {
            this.lbSehir.DataSource = new List<Sehir>();
            this.lbUniversite.DataSource = new List<Universite>();
            var secilenBolumler = new List<Bolum>();
            if(this.lbBolumSecilen.Items.Count>0)
            {
                foreach (var item in this.lbBolumSecilen.Items)
                {
                    secilenBolumler.Add((Bolum)item);
                }
                var sehirler = FemHelper.LisansSehirler(secilenBolumler);
                this.lbSehir.DisplayMember = "ilAdi";
                this.lbSehir.ValueMember = "ilId";
                this.lbSehir.DataSource = sehirler;
            }
        }
        public void UniversiteYukle()
        {
            this.lbUniversite.DisplayMember = "Universitead";
            this.lbUniversite.ValueMember = "UNIVERSITEID";
            if (this.lbBolumSecilen.Items.Count > 0 && this.lbSehirSecilen.Items.Count > 0)
            {
                var secilenBolumler = new List<Bolum>();
                foreach (var item in this.lbBolumSecilen.Items)
                {
                    secilenBolumler.Add((Bolum)item);
                }

                var secilenSehirler = new List<Sehir>();
                foreach (var item in this.lbSehirSecilen.Items)
                {
                    secilenSehirler.Add((Sehir)item);
                }

                var universiteler = FemHelper.LisansUniversiteler(secilenBolumler, secilenSehirler);
                this.lbUniversite.DataSource = universiteler;

            }
            else
            {
                this.lbUniversite.DataSource = null;
            }
        }
        public void PuanYukle()
        {
          
            if (this.lbBolumSecilen.Items.Count > 0 && this.lbSehirSecilen.Items.Count > 0)
            {
                var secilenBolumler = new List<Bolum>();
                foreach (var item in this.lbBolumSecilen.Items)
                {
                    secilenBolumler.Add((Bolum)item);
                }

                var secilenSehirler = new List<Sehir>();
                foreach (var item in this.lbSehirSecilen.Items)
                {
                    secilenSehirler.Add((Sehir)item);
                }
                 var secilenUniversiteler = new List<Universite>();
                foreach (var item in this.lbUniversiteSecilen.Items)
                {
                    secilenUniversiteler.Add((Universite)item);
                }

                this.dataGridView1.DataSource = FemHelper.LisansPuan(secilenBolumler, secilenSehirler, secilenUniversiteler);
              

            }
             
        }
        private void lbBolum_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbBolum.SelectedItem != null)
            {
                Bolum secilen = (Bolum)this.lbBolum.SelectedItem;
                if (this.lbBolumSecilen.Items.OfType<Bolum>().Count(t => t.BolumId == secilen.BolumId) == 0)
                    this.lbBolumSecilen.Items.Add(secilen);
                SehirYukle();
            }
            
        }

        private void lbBolumSecilen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbBolumSecilen.SelectedItem != null)
            {
                Bolum secilen = (Bolum)this.lbBolumSecilen.SelectedItem;
                this.lbBolumSecilen.Items.Remove(secilen);
                SehirYukle();
            }
        }

        private void lbSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSehir.SelectedItem != null)
            {
                Sehir secilen = (Sehir)this.lbSehir.SelectedItem;
                if (this.lbSehirSecilen.Items.OfType<Sehir>().Count(t => t.ilId == secilen.ilId) == 0)
                    this.lbSehirSecilen.Items.Add(secilen);
                UniversiteYukle();
            }
        }
        private void lbSehirSecilen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSehirSecilen.SelectedItem != null)
            {
                Sehir secilen = (Sehir)this.lbSehirSecilen.SelectedItem;
                this.lbSehirSecilen.Items.Remove(secilen);
                UniversiteYukle();
            }
        }
        private void lbUniversite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbUniversite.SelectedItem != null)
            {
                Universite secilen = (Universite)this.lbUniversite.SelectedItem;
                if (this.lbUniversiteSecilen.Items.OfType<Universite>().Count(t => t.UNIVERSITEID == secilen.UNIVERSITEID) == 0)
                    this.lbUniversiteSecilen.Items.Add(secilen);
                PuanYukle();
            }
        }

        private void lbUniversiteSecilen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbUniversiteSecilen.SelectedItem != null)
            {
                Universite secilen = (Universite)this.lbUniversiteSecilen.SelectedItem;
                this.lbUniversiteSecilen.Items.Remove(secilen);
                
            }
        }

        
       
    }
}