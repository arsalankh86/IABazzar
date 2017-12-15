using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IInventoryRepositoryBase
	{
        
        Dictionary<string, string> GetInventoryBasicSearchColumns();
        List<SearchColumn> GetInventorySearchColumns();
        List<SearchColumn> GetInventoryAdvanceSearchColumns();
        

		Inventory GetInventory(System.Int32 InventoryId);
		Inventory UpdateInventory(Inventory entity);
		bool DeleteInventory(System.Int32 InventoryId);
		Inventory DeleteInventory(Inventory entity);
		List<Inventory> GetAllInventory();
		Inventory InsertInventory(Inventory entity);	}
	
	
}
