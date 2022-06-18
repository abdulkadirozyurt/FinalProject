using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess

{   // T yi sınırlandırmamız lazım, veritabanı nesneleri, customer, category,product gibi...  ----> generic constraint (generic kısıt)

    // class demek "referans tip olabilir" demek (int'leri vs engellemiş oluruz IProductDal'a giremez kimse int.)
    
    // new() : new'lenebilir olmalı demek. (Interface'ler newlenemez.)
    
    public interface IEntityRepository<T> where T : class, IEntity,new()   // --> bir referans tip olabilir, o referans tip ya IEntity olabilir ya da ondan implemente olan bir şey olabilir.
    {
        // örnek olarak ürünlerin hepsi her zaman listelenmez. filtre uygulayarak listeleyebilmenin syntax'ı. Kategoriye göre getir, fiyatına göre getir gibi ayrı ayrı yazmaya gerek kalmayacak.
        List<T> GetAll(Expression<Func<T, bool>> filter = null);         // filter = null demek filtre vermeyedebilirsin demek. vermemişse tüm datayı istiyordur demektir

        T Get(Expression<Func<T, bool>> filter);                         /* ancak burada filtre zorunlu. Bu tek bir şeyin detayına gitmek için kullanılır. Örnek olarak bankacılık uygulamasında bir kredinin detayına inmek, tüm hesaplarımızın arasından bir tanesinin detayına inmek gibi */


        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);



        // Bunlar CRUD operasyonları.









        // List<T> GetAllByCategory(int categoryId);        bu koda ihtiyacımız kalmadı
    }
}






// Mesela product, category, customer, employee, order gibi nesneler burada olabilir.

// her seferinde bunların içini doldurmakla uğraşmayacağız, T dedik, hangi tip verilirse o tip olarak (generic yapılar.)