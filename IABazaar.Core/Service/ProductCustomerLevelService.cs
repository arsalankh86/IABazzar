using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ProductCustomerLevelService : IProductCustomerLevelService 
	{
		private IProductCustomerLevelRepository _iProductCustomerLevelRepository;
        
		public ProductCustomerLevelService(IProductCustomerLevelRepository iProductCustomerLevelRepository)
		{
			this._iProductCustomerLevelRepository = iProductCustomerLevelRepository;
		}
        
        public Dictionary<string, string> GetProductCustomerLevelBasicSearchColumns()
        {
            
            return this._iProductCustomerLevelRepository.GetProductCustomerLevelBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetProductCustomerLevelAdvanceSearchColumns()
        {
            
            return this._iProductCustomerLevelRepository.GetProductCustomerLevelAdvanceSearchColumns();
           
        }


		public ProductCustomerLevel GetProductCustomerLevel(System.Int32 ProductId)
		{
			return _iProductCustomerLevelRepository.GetProductCustomerLevel(ProductId);
		}

		public ProductCustomerLevel UpdateProductCustomerLevel(ProductCustomerLevel entity)
		{
			return _iProductCustomerLevelRepository.UpdateProductCustomerLevel(entity);
		}

		public bool DeleteProductCustomerLevel(System.Int32 ProductId)
		{
			return _iProductCustomerLevelRepository.DeleteProductCustomerLevel(ProductId);
		}

		public List<ProductCustomerLevel> GetAllProductCustomerLevel()
		{
			return _iProductCustomerLevelRepository.GetAllProductCustomerLevel();
		}

		public ProductCustomerLevel InsertProductCustomerLevel(ProductCustomerLevel entity)
		{
			 return _iProductCustomerLevelRepository.InsertProductCustomerLevel(entity);
		}


	}
	
	
}
