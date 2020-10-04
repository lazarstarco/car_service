using Data_Layer;
using Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class MakerBusiness
    {
        private MakerRepository makerRepository;

        public MakerBusiness()
        {
            makerRepository = new MakerRepository();
        }

        public List<Maker> GetAllMakers()
        {
            return makerRepository.GetAllMakers();
        }


        public bool InsertMaker(Maker maker)
        {
            int result = 0;
            if (maker != null)
            {
                result = makerRepository.InsertMaker(maker);
            }
            return result > 0 ? true : false;
        }

        public bool DeleteMaker(int id)
        {
            int result = makerRepository.DeleteMaker(id);
            return result > 0 ? true : false;
        }

        public string returnName (int id)
        {
            foreach (Maker maker in GetAllMakers())
            {
                if (maker.Id == id)
                {
                    return maker.Name;
                }
            }
            return "";
        }
    }
}
