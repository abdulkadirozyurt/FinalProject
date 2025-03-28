﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NortwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NortwindContext context = new NortwindContext())
            {
                var result = from p in context.Products                     // ürünlerle kategorileri join et (birleştir) demek
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId            // neye göre  ==>  kategori id sine göre
                             select new ProductDetailDto                    // hangi kolonları istiyorsun?
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = p.UnitsInStock
                             };
                return result.ToList();  // IQueryable türünde bir döngü olduğu için ToList() kullanırız            
            }
        }
    }
}
