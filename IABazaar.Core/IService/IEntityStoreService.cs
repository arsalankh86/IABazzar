using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IEntityStoreService
	{
        Dictionary<string, string> GetEntityStoreBasicSearchColumns();
        
        List<SearchColumn> GetEntityStoreAdvanceSearchColumns();

		EntityStore GetEntityStore(System.Int32 StoreId);
		EntityStore UpdateEntityStore(EntityStore entity);
		bool DeleteEntityStore(System.Int32 StoreId);
		List<EntityStore> GetAllEntityStore();
		EntityStore InsertEntityStore(EntityStore entity);

	}
	
	
}
