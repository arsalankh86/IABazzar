using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ShippingMethodStoreService : IShippingMethodStoreService 
	{
		private IShippingMethodStoreRepository _iShippingMethodStoreRepository;
        
		public ShippingMethodStoreService(IShippingMethodStoreRepository iShippingMethodStoreRepository)
		{
			this._iShippingMethodStoreRepository = iShippingMethodStoreRepository;
		}
        
        public Dictionary<string, string> GetShippingMethodStoreBasicSearchColumns()
        {
            
            return this._iShippingMethodStoreRepository.GetShippingMethodStoreBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetShippingMethodStoreAdvanceSearchColumns()
        {
            
            return this._iShippingMethodStoreRepository.GetShippingMethodStoreAdvanceSearchColumns();
           
        }


		public ShippingMethodStore GetShippingMethodStore(System.Int32 StoreId)
		{
			return _iShippingMethodStoreRepository.GetShippingMethodStore(StoreId);
		}

		public ShippingMethodStore UpdateShippingMethodStore(ShippingMethodStore entity)
		{
			return _iShippingMethodStoreRepository.UpdateShippingMethodStore(entity);
		}

		public bool DeleteShippingMethodStore(System.Int32 StoreId)
		{
			return _iShippingMethodStoreRepository.DeleteShippingMethodStore(StoreId);
		}

		public List<ShippingMethodStore> GetAllShippingMethodStore()
		{
			return _iShippingMethodStoreRepository.GetAllShippingMethodStore();
		}

		public ShippingMethodStore InsertShippingMethodStore(ShippingMethodStore entity)
		{
			 return _iShippingMethodStoreRepository.InsertShippingMethodStore(entity);
		}


	}
	
	
}
