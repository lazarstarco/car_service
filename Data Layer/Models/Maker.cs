using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Models
{
    public class Maker
    {
        private int id;
        private string name;
        private string city;
        private string country;
        private string email;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string City { get => city; set => city = value; }
        public string Country { get => country; set => country = value; }
        public string Email { get => email; set => email = value; }
        override
        public string ToString()
        {
            return id + " - " + name + " " + country + " " + email;
        }
    }
}
