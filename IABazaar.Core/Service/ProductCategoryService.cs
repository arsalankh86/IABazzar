using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ProductCategoryService : IProductCategoryService 
	{
		private IProductCategoryRepository _iProductCategoryRepository;
        
		public ProductCategoryService(IProductCategoryRepository iProductCategoryRepository)
		{
			this._iProductCategoryRepository = iProductCategoryRepository;
		}
        
        public Dictionary<string, string> GetProductCategoryBasicSearchColumns()
        {
            
            return this._iProductCategoryRepository.GetProductCategoryBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetProductCategoryAdvanceSearchColumns()
        {
            
            return this._iProductCategoryRepository.GetProductCategoryAdvanceSearchColumns();
           
        }


		public ProductCategory GetProductCategory(System.Int32 ProductId)
		{
			return _iProductCategoryRepository.GetProductCategory(ProductId);
		}

		public ProductCategory UpdateProductCategory(ProductCategory entity)
		{
			return _iProductCategoryRepository.UpdateProductCategory(entity);
		}

		public bool DeleteProductCategory(System.Int32 ProductId)
		{
			return _iProductCategoryRepository.DeleteProductCategory(ProductId);
		}

		public List<ProductCategory> GetAllProductCategory()
		{
			return _iProductCategoryRepository.GetAllProductCategory();
		}

		public ProductCategory InsertProductCategory(ProductCategory entity)
		{
			 return _iProductCategoryRepository.InsertProductCategory(entity);
		}


	}
	
	
}
