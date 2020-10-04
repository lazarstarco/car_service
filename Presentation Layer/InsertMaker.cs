using Business_Layer;
using Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer
{
    public partial class InsertMaker : Form
    {
        MakerBusiness makerBusiness;
        public InsertMaker()
        {
            InitializeComponent();
        }
        private void InsertMaker_Load(object sender, EventArgs e)
        {
            makerBusiness = new MakerBusiness();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FormManageUsers formManageUsers = new FormManageUsers();
            Hide();
            formManageUsers.ShowDialog();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text.Length > 0)
            {

                Maker maker = new Maker();
                maker.Name = textBox1.Text;
                maker.City = textBox2.Text;
                maker.Country = textBox3.Text;
                maker.Email = textBox4.Text;
                makerBusiness.InsertMaker(maker);
                MessageBox.Show("Proizvodjac " + maker.Name + " uspesno dodat", "Uspesno dodat");
            }
            else
            {
                MessageBox.Show("Nisu popunjena sva polja", "Greska");
            }
        }

    }
}
