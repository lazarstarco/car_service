﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Models
{
    public class Model
    {
        private int id;
        private string name;
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
