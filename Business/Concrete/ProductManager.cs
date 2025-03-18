using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {

        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            if (product.ProductName.Length < 2)
                return new ErrorResult("Product name must be at least 2 characters long");

            _productDal.Add(product);

            return new SuccessResult("Product added successfully");
        }

        public IDataResult<List<Product>> GetAll()
        {
            var products = _productDal.GetAll();
            return new DataResult<List<Product>>(true, products);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            var products = _productDal.GetAll(p => p.CategoryId == id);
            return new DataResult<List<Product>>(true, products);
        }

        public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
        {
            var products = _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
            return new DataResult<List<Product>>(true, products);
        }

        public IDataResult<Product> GetById(int id)
        {
            var product = _productDal.Get(p => p.ProductId == id);
            return new DataResult<Product>(true, product);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
