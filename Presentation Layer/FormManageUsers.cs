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
    public partial class FormManageUsers : Form
    {
        private UserBusiness userBusiness;
        private MakerBusiness makerBusiness;
        private ModelBusiness modelBusiness;
        private BookingsBusiness bookingsBusiness;

        private int UserId;
        private int MakerId;
        private int ModelId;

        public FormManageUsers()
        {
            InitializeComponent();
        }

        private void FormManageUsers_Load(object sender, EventArgs e)
        {
            userBusiness = new UserBusiness();
            makerBusiness = new MakerBusiness();
            modelBusiness = new ModelBusiness();
            bookingsBusiness = new BookingsBusiness();

            fillUsers();
            fillMakers();
            fillModels();

            button7.Hide();
            button8.Hide();
            button1.Show();
            button2.Show();
            button3.Show();
            button4.Show();
            button5.Show();
            button6.Show();
            panel1.Hide();
        }

        private void fillUsers()
        {
            listBox1.Items.Clear();

            foreach (User user in userBusiness.GetAllUsers())
            {
                listBox1.Items.Add(user.ToString());
            }
        }
        private void fillMakers()
        {
            listBox2.Items.Clear();

            foreach (Maker maker in makerBusiness.GetAllMakers())
            {
                listBox2.Items.Add(maker.ToString());
            }
        }
        private void fillModels()
        {
            listBox3.Items.Clear();

            foreach (Model model in modelBusiness.GetAllModels())
            {
                listBox3.Items.Add(model.Id + " - " + model.Name);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = listBox1.SelectedItem.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = listBox2.SelectedItem.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox3.Text = listBox3.SelectedItem.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            foreach (User user in userBusiness.GetAllUsers())
            {
                if (textBox1.Text.Equals(user.ToString()))
                {
                    textBox1.BackColor = Color.Lime;
                    break;
                }
                else
                {
                    textBox1.BackColor = Color.White;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            foreach (Maker maker in makerBusiness.GetAllMakers())
            {
                if (textBox2.Text.Equals(maker.ToString()))
                {
                    textBox2.BackColor = Color.Lime;
                    break;
                }
                else
                {
                    textBox2.BackColor = Color.White;
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            foreach (Model model in modelBusiness.GetAllModels())
            {
                if (textBox3.Text.Equals(model.Id + " - " + model.Name))
                {
                    textBox3.BackColor = Color.Lime;
                    break;
                }
                else
                {
                    textBox3.BackColor = Color.White;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                UserId = Int32.Parse(textBox1.Text.Split(new string[] { " - " }, StringSplitOptions.None)[0]);
                fillUsers(textBox1.Text);
                button1.Hide();
                button2.Hide();
                display();
            }
            catch (Exception) { }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                MakerId = Int32.Parse(textBox2.Text.Split(new string[] { " - " }, StringSplitOptions.None)[0]);
                fillMakers(textBox2.Text);
                button4.Hide();
                button3.Hide();
                display();
            }
            catch (Exception) { }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                ModelId = Int32.Parse(textBox3.Text.Split(new string[] { " - " }, StringSplitOptions.None)[0]);
                fillModels(textBox3.Text);
                button6.Hide();
                button5.Hide();
                display();
            }
            catch (Exception) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            Hide();
            main.ShowDialog();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InsertMaker insertMaker = new InsertMaker();
            Hide();
            insertMaker.ShowDialog();
            Close();
        
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Model model = new Model();
            model.Name = textBox3.Text;
            modelBusiness.InsertModel(model);
        }
        private void fillUsers(string onlyUser)
        {
            listBox1.Items.Clear();

            foreach (User user in userBusiness.GetAllUsers())
            {
                if (user.ToString().Equals(onlyUser))
                {
                    listBox1.Items.Add(user.ToString());
                }
            }
        }
        private void fillMakers(string onlyMaker)
        {
            listBox2.Items.Clear();

            foreach (Maker maker in makerBusiness.GetAllMakers())
            {
                if (maker.ToString().Equals(onlyMaker))
                {
                    listBox2.Items.Add(maker.ToString());
                }
            }
        }
        private void fillModels(string onlyModel)
        {
            listBox3.Items.Clear();

            foreach (Model model in modelBusiness.GetAllModels())
            {
                if ((model.Id + " - " + model.Name).Equals(onlyModel))
                {
                    listBox3.Items.Add(model.Id + " - " + model.Name);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            fillUsers();
            fillMakers();
            fillModels();

            button7.Hide();
            button8.Hide();
            button1.Show();
            button2.Show();
            button3.Show();
            button4.Show();
            button5.Show();
            button6.Show();
            panel1.Hide();
        }

        private void display()
        {
            if (!button1.Visible && !button3.Visible && !button5.Visible)
            {
                button7.Show();
                button8.Show();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel1.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Bookings bookings = new Bookings();
            bookings.UserId = UserId;
            bookings.MakerId = MakerId;
            bookings.ModelId = ModelId;
            bookings.Defect = textBox4.Text;
            bookings.Date = DateTime.Now.ToString("dd'/'MM'/'yyyy");
            bookings.Repaired = false;
            bookingsBusiness.InsertBookings(bookings);
            MessageBox.Show("Vozilo sa sifrom " + MakerId + "-" + ModelId + " je uspesno dodato. Datum: " + bookings.Date, "Uspesno dodato");
            Main main = new Main();
            Hide();
            main.ShowDialog();
            Close();
        }
    }
}
