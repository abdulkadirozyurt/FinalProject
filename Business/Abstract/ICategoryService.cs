using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{

    // kategoriyle ilgili, dış dünyaya neyi servis etmek istiyorsam onu yazıyorum

    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int categoryId);       // id'ye göre çekeceğim için tek bir kategori gelecek, başındaki List<Category> kısmını sildik.



    }
}
