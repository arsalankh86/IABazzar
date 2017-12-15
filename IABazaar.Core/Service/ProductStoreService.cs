using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ProductStoreService : IProductStoreService 
	{
		private IProductStoreRepository _iProductStoreRepository;
        
		public ProductStoreService(IProductStoreRepository iProductStoreRepository)
		{
			this._iProductStoreRepository = iProductStoreRepository;
		}
        
        public Dictionary<string, string> GetProductStoreBasicSearchColumns()
        {
            
            return this._iProductStoreRepository.GetProductStoreBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetProductStoreAdvanceSearchColumns()
        {
            
            return this._iProductStoreRepository.GetProductStoreAdvanceSearchColumns();
           
        }


		public ProductStore GetProductStore(System.Int32 ProductId)
		{
			return _iProductStoreRepository.GetProductStore(ProductId);
		}

		public ProductStore UpdateProductStore(ProductStore entity)
		{
			return _iProductStoreRepository.UpdateProductStore(entity);
		}

		public bool DeleteProductStore(System.Int32 ProductId)
		{
			return _iProductStoreRepository.DeleteProductStore(ProductId);
		}

		public List<ProductStore> GetAllProductStore()
		{
			return _iProductStoreRepository.GetAllProductStore();
		}

		public ProductStore InsertProductStore(ProductStore entity)
		{
			 return _iProductStoreRepository.InsertProductStore(entity);
		}


	}
	
	
}
