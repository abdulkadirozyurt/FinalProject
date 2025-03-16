using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    /// <summary>
    ///    GENERIC CONSTRAINT -> We should restrict to T with Database objects; Customer, Category, Product etc. 
    ///    class              -> It means that it can be a reference type. (It prevents value types like int, string etc. to enter IProductDal.)
    ///    new()              -> It means that it should be instantiable. (Interfaces cannot be instantiated.)    ///     
    /// </summary>    
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        /// <summary>
        ///     örnek olarak ürünlerin hepsi her zaman listelenmez. filtre uygulayarak listeleyebilmenin syntax'ı.
        ///     Kategoriye göre getir, fiyatına göre getir gibi ayrı ayrı yazmaya gerek kalmayacak.
        ///     filter = null demek filtre vermeyedebilirsin demek. vermemişse tüm datayı istiyordur demektir
        /// </summary>    
        List<T> GetAll(Expression<Func<T, bool>> filter = null);

        ///  <summary> 
        ///      ancak burada filtre zorunlu. Bu tek bir şeyin detayına gitmek için kullanılır. 
        ///      Örnek olarak bankacılık uygulamasında bir kredinin detayına inmek, 
        ///      tüm hesaplarımızın arasından bir tanesinin detayına inmek gibi 
        ///  </summary>         
        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}