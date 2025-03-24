using Business.Abstract;
using Business.Constants;
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
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            var products = _productDal.GetAll();
            return new SuccessDataResult<List<Product>>(products);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            var products = _productDal.GetAll(p => p.CategoryId == id);
            return new SuccessDataResult<List<Product>>(products);
        }

        public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
        {
            var products = _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
            return new SuccessDataResult<List<Product>>(products);
        }

        public IDataResult<Product> GetById(int id)
        {
            var product = _productDal.Get(p => p.ProductId == id);
            return new SuccessDataResult<Product>(product);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
