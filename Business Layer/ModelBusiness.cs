using Data_Layer;
using Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class ModelBusiness
    {
        private ModelRepository modelRepository;

        public ModelBusiness()
        {
            modelRepository = new ModelRepository();
        }

        public List<Model> GetAllModels()
        {
            return modelRepository.GetAllModels();
        }


        public bool InsertModel(Model model)
        {
            int result = 0;
            if (model != null)
            {
                result = modelRepository.InsertModel(model);
            }
            return result > 0 ? true : false;
        }

        public bool DeleteModel(int id)
        {
            int result = modelRepository.DeleteModel(id);
            return result > 0 ? true : false;
        }

        public string returnName(int id)
        {
            foreach (Model model in GetAllModels())
            {
                if (model.Id == id)
                {
                    return model.Name;
                }
            }
            return "";
        }
    }
}
