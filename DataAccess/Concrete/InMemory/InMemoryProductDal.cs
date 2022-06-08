using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;        // global değişkenler bu şekilde verilir. 

        public InMemoryProductDal()     // constructor
        {
            _products = new List<Product>
            {
                new Product{CategoryId=1,ProductId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{CategoryId=1,ProductId=2,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product{CategoryId=2,ProductId=3,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
                new Product{CategoryId=2,ProductId=4,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product{CategoryId=2,ProductId=5,ProductName="Fare",UnitPrice=85,UnitsInStock=1}

            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {



            //  tek tek dolaşır.  her p için p'nin productId'si benim gönderdiğim produrct'ın ProductId'sine eşit mi git bak demek.
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);


            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;    // business istedi, ona döndürüyoruz.
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();  // where, içindeki koşula uyan bütün elemanları yeni bir liste haline getirir ve onu döndürür.
        }

        public void Update(Product product)
        {           // gönderdiğim ürün id'sine sahip olan ürün id'sini (yani ürünü) bul demek.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
