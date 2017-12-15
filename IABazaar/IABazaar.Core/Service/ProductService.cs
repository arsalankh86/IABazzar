using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ProductService : IProductService 
	{
		private IProductRepository _iProductRepository;
        
		public ProductService(IProductRepository iProductRepository)
		{
			this._iProductRepository = iProductRepository;
		}
        
        public Dictionary<string, string> GetProductBasicSearchColumns()
        {
            
            return this._iProductRepository.GetProductBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetProductAdvanceSearchColumns()
        {
            
            return this._iProductRepository.GetProductAdvanceSearchColumns();
           
        }


		public Product GetProduct(System.Int32 ProductId)
		{
			return _iProductRepository.GetProduct(ProductId);
		}

		public Product UpdateProduct(Product entity)
		{
			return _iProductRepository.UpdateProduct(entity);
		}

		public bool DeleteProduct(System.Int32 ProductId)
		{
			return _iProductRepository.DeleteProduct(ProductId);
		}

		public List<Product> GetAllProduct()
		{
			return _iProductRepository.GetAllProduct();
		}

		public Product InsertProduct(Product entity)
		{
			 return _iProductRepository.InsertProduct(entity);
		}


	}
	
	
}
