using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Models
{
    public class User
    {
        private int id;
        private string name;
        private string surname;
        private string address;
        private string email;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }

        public User(string name, string surname, string address, string email)
        {
            this.name = name;
            this.surname = surname;
            this.address = address;
            this.email = email;
        }

        public User()
        {
        }

        override
        public string ToString()
        {
            return id + " - " + name + " " + surname;
        }
    }
}
