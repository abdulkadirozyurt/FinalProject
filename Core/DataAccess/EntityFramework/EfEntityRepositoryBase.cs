using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{   
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            // IDisposable pattern implementation of c#
            // using bloğu içine yazılan nesneler using bitince anında bellekten silinir.
            // context nesnesi biraz pahalıdır. bu yüzden using kullanırız.
            // northwind bellekten işi bitince silinecek. bu hareketi yapınca daha performanslı.
            // Direk metot içinde de newleyebilirdik ama böyle daha iyi.
            using (TContext context = new TContext())
            {
                // first, get the reference of the entity
                // normally, Entry(): It means that map an object with the Product we sent.
                // But we are adding a new product now.
                var addedEntity = context.Entry(entity);

                // Notify the adding operation
                addedEntity.State = EntityState.Added;

                // perform operations
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                // eğer filtre vermediyse ilgili tablodaki tüm veriyi getir, filtre vermişse uygula ve ona göre datayı listele
                // set<>() -> veritabanındaki ilgili tabloya yerleş, onu listeye çevir ve bana döndür

                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
                // lambda gibi
            }
        }

        public List<TEntity> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {

                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();



            }
        }



    }
}
