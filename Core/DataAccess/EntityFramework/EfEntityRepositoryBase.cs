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

    // entity framework kullanarak bir repository base'i oluştur.
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>          // bir tablo ver bir de context tipi ver, ben ona göre çalışacağım demek.
    where TEntity : class, IEntity, new()                                                        // generic constraint: sınırlamalarımızı koyduk.
    where TContext : DbContext, new()                                                            // bize sadece NorthwindContext gibi şeyler kullanma izni verecek.

    {
        // bir tabloyu ilgilendiren tüm operasyonları tekrar tekrar yazmamak için burayı kullanacağız. bir kere yazarız, her yerde kullanırız.


        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())       // using bloğu içine yazılan nesneler using bitince anında bellekten silinir.
            {   
                                                            // northwind bellekten işi bitince silinecek. bu hareketi yapınca daha performanslı. Direk metot içinde de newleyebilirdik ama böyle daha iyi.

                     // referansı yakalama kısmı
                var addedEntity = context.Entry(entity);    // git veri kaynağından, benim gönderdiğim product'a bir tane nesneyi eşleştir. (Şu an yeni ekliyoruz.)
                addedEntity.State = EntityState.Added;
                context.SaveChanges();


                /*
                sırasıyla 1-2-3 satırlar
                
                1- referansı yakala
                2- o aslında eklenecek bir nesne
                3- ve şimdi ekle

                anlamlarına gelir.
                */
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

                // veritabanındaki products tablosuna yerleş, onu listeye çevir ve bana döndür


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
