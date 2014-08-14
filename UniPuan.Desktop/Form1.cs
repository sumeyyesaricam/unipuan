using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;   
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace UniPuan.Desktop
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            LoadLists();
        }
        public void LoadLists()
        {
            this.comboLic.DataSource = XData.LicenseList();
            this.comboUniType.DataSource = XData.TypeList();
            this.comboFaculty.DataSource = XData.FacultyList(new Filter());
            this.comboCity.DataSource = XData.CityList();
        }
        public void DataSearch()
        {
            Filter f = new Filter();
            if (this.comboFaculty.SelectedIndex > -1 && this.comboFaculty.SelectedValue!="0" )
                f.FacultyId = ((Faculty)this.comboFaculty.SelectedItem).Id;
            if (this.comboUni.SelectedIndex > -1 && this.comboUni.SelectedValue != "0")
                f.UniId = ((University)this.comboUni.SelectedItem).Id;
            if (this.comboCity.SelectedIndex > -1 && this.comboCity.SelectedValue != "0")
                f.CityId = ((City)this.comboCity.SelectedItem).Id;
            if (this.comboDepart.SelectedIndex > -1 && this.comboDepart.SelectedValue != "0")
                f.DepartmentId = ((Department)this.comboDepart.SelectedItem).Id;
            if (this.comboUniType.SelectedIndex > -1 && this.comboUniType.SelectedValue != "0")
                f.UniTypeId = ((UniType)this.comboUniType.SelectedItem).Id;
            if (this.comboScore.SelectedIndex > -1 && this.comboScore.SelectedValue != "0")
                f.ScoreId = ((ScoreType)this.comboScore.SelectedItem).Id;
            if (this.rdioScore.Checked)
            {
                f.ScoreMin = this.textScrMin.Text;
                f.ScoreMax = this.textScrMax.Text;
            }
            else if (this.rdioRank.Checked)
                f.Order = this.textRank.Text;

            var xdt = XData.DataList(f);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = xdt;
        }
        public void LicenseSelected()
        {
            if(this.comboLic.Enabled)
            {
                var f = new ScoreType();
                if (this.comboLic.SelectedValue != null && this.comboLic.SelectedValue != "0")
                    f.LicenseId = this.comboLic.SelectedValue.ToString();
                this.comboScore.DataSource = XData.ScoreList(f);
            } 
        }
        public void ScoreSelected()
        {
            var selected = ((ScoreType)this.comboScore.SelectedItem);
            if (this.comboScore.Enabled)
            {
                var f = new Department();
                if (selected!=null && selected.Id != "0")
                {
                    f.ScoreId = selected.Id;
                }
                if (this.comboFaculty.SelectedIndex > -1 && this.comboScore.SelectedValue != "0")
                    f.FacultyId = ((Faculty)this.comboFaculty.SelectedItem).Id;

                this.comboDepart.DataSource = XData.DepList(f);
            }
            if(selected!=null && selected.Id!="0")
            {
                this.comboLic.Enabled = false;
                this.comboLic.SelectedValue = selected.LicenseId;
            }
            else
            {
                this.comboLic.Enabled = true;
                this.comboLic.SelectedIndex = 0;
            }
            
        }
        public void FacultySelected()
        {
            var f = new Department();
            if (this.comboFaculty.SelectedIndex > -1 && this.comboFaculty.SelectedValue != "0")
                f.FacultyId = ((Faculty)this.comboFaculty.SelectedItem).Id;
            if (this.comboScore.SelectedIndex > -1 && this.comboScore.SelectedValue != "0")
                f.ScoreId = ((ScoreType)this.comboScore.SelectedItem).Id;
            this.comboDepart.DataSource = XData.DepList(f);
        }
        public void UniTypeSelected()
        {
            if(this.comboUniType.Enabled)
            {

            
            var f = new University();
            if (this.comboUniType.SelectedIndex > -1 && this.comboUniType.SelectedValue!="0")
                f.UniTypeId = ((UniType)this.comboUniType.SelectedItem).Id;

            if (this.comboCity.SelectedIndex > -1 && this.comboCity.SelectedValue != "0")
                f.CityTypeId = ((City)this.comboCity.SelectedItem).Id;

            this.comboUni.DataSource = XData.UniList(f);
            }
        }
        public void CitySelected()
        {
            if (this.comboCity.Enabled)
            {

                var f = new University();
                if (this.comboCity.SelectedIndex > -1 && this.comboCity.SelectedValue != "0")
                    f.CityTypeId = ((City)this.comboCity.SelectedItem).Id;
                if (this.comboUniType.SelectedIndex > -1 && this.comboUniType.SelectedValue != "0")
                    f.UniTypeId = ((UniType)this.comboUniType.SelectedItem).Id;
                this.comboUni.DataSource = XData.UniList(f);
            }
        }
        public void UniSelected()
        {
            var uni = ((University)this.comboUni.SelectedItem);
            if (uni != null)
            {
                if (uni.Id != "0")
                {
                    this.comboUniType.Enabled = false;
                    this.comboUniType.SelectedValue = uni.UniTypeId;
                    this.comboCity.Enabled = false;
                    this.comboCity.SelectedValue = uni.CityTypeId;
                    this.comboUni.SelectedValue = uni.Id;
                }
                else
                {
                    this.comboUniType.Enabled = true;
                   
                    this.comboCity.Enabled = true;
                }
            }
        }
        public void DepartmentSelected()
        {
            
            var selected = ((Department)this.comboDepart.SelectedItem);
            if (selected!=null && selected.Id != "0")
            {
                this.comboScore.Enabled = false;
                this.comboScore.SelectedValue = selected.ScoreId;
                this.comboDepart.SelectedValue = selected.Id;
            }
            else
            {
                this.comboScore.Enabled = true;
                //this.comboScore.SelectedIndex = 0;
            }
                
        }
        
         
        
        private void ara_Click(object sender, EventArgs e)
        {
            DataSearch();
        }

        #region "Combo_Selected"
        private void comboLic_SelectedIndexChanged(object sender, EventArgs e)
        {
            LicenseSelected();
        }
        private void comboScore_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScoreSelected();
        }
        private void comboFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            FacultySelected();
        }

        private void comboUniType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UniTypeSelected();
        }

        private void comboCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            CitySelected();
        }

        private void comboUni_SelectedIndexChanged(object sender, EventArgs e)
        {
            UniSelected();
        }

        private void comboDepart_SelectedIndexChanged(object sender, EventArgs e)
        {
            DepartmentSelected();
        }
        #endregion

        private void comboLic_TextChanged(object sender, EventArgs e)
        {
            LicenseSelected();
        }

    }
}
