using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IEntityStoreRepositoryBase
	{
        
        Dictionary<string, string> GetEntityStoreBasicSearchColumns();
        List<SearchColumn> GetEntityStoreSearchColumns();
        List<SearchColumn> GetEntityStoreAdvanceSearchColumns();
        

		EntityStore GetEntityStore(System.Int32 StoreId);
		EntityStore UpdateEntityStore(EntityStore entity);
		bool DeleteEntityStore(System.Int32 StoreId);
		EntityStore DeleteEntityStore(EntityStore entity);
		List<EntityStore> GetAllEntityStore();
		EntityStore InsertEntityStore(EntityStore entity);	}
	
	
}
