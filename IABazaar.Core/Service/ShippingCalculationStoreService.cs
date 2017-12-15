using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ShippingCalculationStoreService : IShippingCalculationStoreService 
	{
		private IShippingCalculationStoreRepository _iShippingCalculationStoreRepository;
        
		public ShippingCalculationStoreService(IShippingCalculationStoreRepository iShippingCalculationStoreRepository)
		{
			this._iShippingCalculationStoreRepository = iShippingCalculationStoreRepository;
		}
        
        public Dictionary<string, string> GetShippingCalculationStoreBasicSearchColumns()
        {
            
            return this._iShippingCalculationStoreRepository.GetShippingCalculationStoreBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetShippingCalculationStoreAdvanceSearchColumns()
        {
            
            return this._iShippingCalculationStoreRepository.GetShippingCalculationStoreAdvanceSearchColumns();
           
        }


		public ShippingCalculationStore GetShippingCalculationStore(System.Int32 StoreId)
		{
			return _iShippingCalculationStoreRepository.GetShippingCalculationStore(StoreId);
		}

		public ShippingCalculationStore UpdateShippingCalculationStore(ShippingCalculationStore entity)
		{
			return _iShippingCalculationStoreRepository.UpdateShippingCalculationStore(entity);
		}

		public bool DeleteShippingCalculationStore(System.Int32 StoreId)
		{
			return _iShippingCalculationStoreRepository.DeleteShippingCalculationStore(StoreId);
		}

		public List<ShippingCalculationStore> GetAllShippingCalculationStore()
		{
			return _iShippingCalculationStoreRepository.GetAllShippingCalculationStore();
		}

		public ShippingCalculationStore InsertShippingCalculationStore(ShippingCalculationStore entity)
		{
			 return _iShippingCalculationStoreRepository.InsertShippingCalculationStore(entity);
		}


	}
	
	
}
