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
    public partial class Main : Form
    {
        private UserBusiness userBusiness;
        private BookingsBusiness bookingsBusiness;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            userBusiness = new UserBusiness();
            bookingsBusiness = new BookingsBusiness();
            listBox1.Items.Clear();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            labelRepairing.Text = "(0)";
            labelRepaired.Text = "(0)";

            AutoCompleteStringCollection autofillName = new AutoCompleteStringCollection();
            AutoCompleteStringCollection autofillSurname = new AutoCompleteStringCollection();
            foreach (User user in userBusiness.GetAllUsers())
            {
                autofillName.Add(user.Name);
                autofillSurname.Add(user.Surname);
            }
            textBoxName.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBoxName.AutoCompleteCustomSource = autofillName;

            textBoxSurname.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxSurname.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBoxSurname.AutoCompleteCustomSource = autofillSurname;
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSurname.Text.Length != 0)
            {
                fillData(userBusiness.UserExists(textBoxName.Text, textBoxSurname.Text));
            }
            if (textBoxName.Text.Length == 0)
            {
                listBox1.Items.Clear();
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                labelRepairing.Text = "(0)";
                labelRepaired.Text = "(0)";
            }
        }

        private void textBoxSurname_TextChanged(object sender, EventArgs e)
        {
            if (textBoxName.Text.Length != 0)
            {
                fillData(userBusiness.UserExists(textBoxName.Text, textBoxSurname.Text));
            }
            if (textBoxSurname.Text.Length == 0)
            {
                listBox1.Items.Clear();
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                labelRepairing.Text = "(0)";
                labelRepaired.Text = "(0)";
            }
        }

        private void fillData(int id)
        {
            if (id == -1)
            {
                textBoxAddress.Text = "";
                textBoxEmail.Text = "";
            }
            else
            {
                foreach (User user in userBusiness.GetAllUsers())
                {
                    if (user.Id == id)
                    {
                        textBoxAddress.Text = user.Address;
                        textBoxEmail.Text = user.Email;
                    }
                }
            }
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text.Length != 0 && textBoxSurname.Text.Length != 0 && textBoxAddress.Text.Length != 0 && textBoxEmail.Text.Length != 0)
            {
                userBusiness.InsertUser(new User(textBoxName.Text, textBoxSurname.Text, textBoxAddress.Text, textBoxEmail.Text));
            }
            else
            {
                MessageBox.Show("Nisu popunjena sva polja", "Greska");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text.Length != 0 && textBoxSurname.Text.Length != 0 && textBoxAddress.Text.Length != 0 && textBoxEmail.Text.Length != 0)
            {
                userBusiness.UpdateUser(userBusiness.UserExists(textBoxName.Text, textBoxSurname.Text), new User(textBoxName.Text, textBoxSurname.Text, textBoxAddress.Text, textBoxEmail.Text));
            }
            else
            {
                MessageBox.Show("Nisu popunjena sva polja", "Greska");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            fillCars(userBusiness.UserExists(textBoxName.Text.Trim(), textBoxSurname.Text.Trim()), checkBox1.Checked, checkBox2.Checked);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            fillCars(userBusiness.UserExists(textBoxName.Text.Trim(), textBoxSurname.Text.Trim()), checkBox1.Checked, checkBox2.Checked);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = listBox1.SelectedItem.ToString().Split(new string[] { "; " }, StringSplitOptions.None)[1];
        }

        private void buttonDefect_Click(object sender, EventArgs e)
        {
            string tmp = "";
            try
            {
                tmp = listBox1.SelectedItem.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Nije selektovano ni jedno vozilo", "Greska");
                return;
            }
            bookingsBusiness.UpdateBooking(richTextBox1.Text.Trim(), tmp.Contains("Na servisu") ? 0 : 1, tmp.Split(new string[] { "; " }, StringSplitOptions.None)[2]);
            fillCars(userBusiness.UserExists(textBoxName.Text, textBoxSurname.Text), checkBox1.Checked, checkBox2.Checked);
            richTextBox1.Text = "";
        }

        private void fillCars(int id, bool repairing, bool repaired)
        {
            listBox1.Items.Clear();

            int countRepairing = 0, countRepaired = 0;

            foreach (Bookings bookings in bookingsBusiness.GetAllBookings())
            {
                string item = (new MakerBusiness().returnName(bookings.MakerId)) + " " + (new ModelBusiness().returnName(bookings.ModelId))
                    + " " + (bookings.Repaired ? "Servis zavrsen" : "Na servisu") + ";  \t" + bookings.Defect + "; "
                    + bookings.MakerId + "." + bookings.ModelId + "." + bookings.UserId;
                if (bookings.UserId == id && repairing && repaired)
                {
                    listBox1.Items.Add(item);
                    if (!bookings.Repaired)
                    {
                        countRepairing++;
                    }
                    else
                    {
                        countRepaired++;
                    }
                }
                else if (bookings.UserId == id && repairing && bookings.Repaired == false)
                {
                    listBox1.Items.Add(item);
                    countRepairing++;
                }
                else if (bookings.UserId == id && repaired && bookings.Repaired == true)
                {
                    listBox1.Items.Add(item);
                    countRepaired++;
                }
            }
            labelRepairing.Text = "(" + countRepairing + ")";
            labelRepaired.Text = "(" + countRepaired + ")";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormManageUsers formManageUsers = new FormManageUsers();
            Hide();
            formManageUsers.ShowDialog();
            Close();
        }
    }
}
