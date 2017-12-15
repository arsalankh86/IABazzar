using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class StoreService : IStoreService 
	{
		private IStoreRepository _iStoreRepository;
        
		public StoreService(IStoreRepository iStoreRepository)
		{
			this._iStoreRepository = iStoreRepository;
		}
        
        public Dictionary<string, string> GetStoreBasicSearchColumns()
        {
            
            return this._iStoreRepository.GetStoreBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetStoreAdvanceSearchColumns()
        {
            
            return this._iStoreRepository.GetStoreAdvanceSearchColumns();
           
        }


		public Store GetStore(System.Int32 StoreId)
		{
			return _iStoreRepository.GetStore(StoreId);
		}

		public Store UpdateStore(Store entity)
		{
			return _iStoreRepository.UpdateStore(entity);
		}

		public bool DeleteStore(System.Int32 StoreId)
		{
			return _iStoreRepository.DeleteStore(StoreId);
		}

		public List<Store> GetAllStore()
		{
			return _iStoreRepository.GetAllStore();
		}

		public Store InsertStore(Store entity)
		{
			 return _iStoreRepository.InsertStore(entity);
		}


	}
	
	
}
