using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IStoreService
	{
        Dictionary<string, string> GetStoreBasicSearchColumns();
        
        List<SearchColumn> GetStoreAdvanceSearchColumns();

		Store GetStore(System.Int32 StoreId);
		Store UpdateStore(Store entity);
		bool DeleteStore(System.Int32 StoreId);
		List<Store> GetAllStore();
		Store InsertStore(Store entity);

	}
	
	
}
