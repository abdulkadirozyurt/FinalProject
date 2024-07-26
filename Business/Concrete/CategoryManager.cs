using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{





    public class CategoryManager : ICategoryService
    {
        // bağımlılığı minimize ediyoruz.


        ICategoryDal _categoryDal;



        // constructor injection.


        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        // Bu şu demek, ben CategoryManager olarak veri erişim katmanına bağımlıyım ama biraz zayıf bağımlılığım var, çünkü ben interface (yani referans) üzerinde bağımlıyım o yüzden sen DataAccess katmanında kurallara uymak şsrtıyla istediğini yapabilirsin.


        public List<Category> GetAll()
        {
            // iş kodları


            return _categoryDal.GetAll();
        }

        public Category GetById(int categoryId)
        {
            return _categoryDal.Get(c => c.CategoryId == categoryId);
        }
    }
}
