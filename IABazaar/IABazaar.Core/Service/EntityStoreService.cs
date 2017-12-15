using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class EntityStoreService : IEntityStoreService 
	{
		private IEntityStoreRepository _iEntityStoreRepository;
        
		public EntityStoreService(IEntityStoreRepository iEntityStoreRepository)
		{
			this._iEntityStoreRepository = iEntityStoreRepository;
		}
        
        public Dictionary<string, string> GetEntityStoreBasicSearchColumns()
        {
            
            return this._iEntityStoreRepository.GetEntityStoreBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetEntityStoreAdvanceSearchColumns()
        {
            
            return this._iEntityStoreRepository.GetEntityStoreAdvanceSearchColumns();
           
        }


		public EntityStore GetEntityStore(System.Int32 StoreId)
		{
			return _iEntityStoreRepository.GetEntityStore(StoreId);
		}

		public EntityStore UpdateEntityStore(EntityStore entity)
		{
			return _iEntityStoreRepository.UpdateEntityStore(entity);
		}

		public bool DeleteEntityStore(System.Int32 StoreId)
		{
			return _iEntityStoreRepository.DeleteEntityStore(StoreId);
		}

		public List<EntityStore> GetAllEntityStore()
		{
			return _iEntityStoreRepository.GetAllEntityStore();
		}

		public EntityStore InsertEntityStore(EntityStore entity)
		{
			 return _iEntityStoreRepository.InsertEntityStore(entity);
		}


	}
	
	
}
