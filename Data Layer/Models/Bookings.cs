using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Models
{
    public class Bookings
    {
        private int makerId;
        private int modelId;
        private int userId;
        private string date;
        private string defect;
        private bool repaired;

        public int MakerId { get => makerId; set => makerId = value; }
        public int ModelId { get => modelId; set => modelId = value; }
        public int UserId { get => userId; set => userId = value; }
        public string Date { get => date; set => date = value; }
        public string Defect { get => defect; set => defect = value; }
        public bool Repaired { get => repaired; set => repaired = value; }
    }
}
