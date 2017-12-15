using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IInventoryService
	{
        Dictionary<string, string> GetInventoryBasicSearchColumns();
        
        List<SearchColumn> GetInventoryAdvanceSearchColumns();

		Inventory GetInventory(System.Int32 InventoryId);
		Inventory UpdateInventory(Inventory entity);
		bool DeleteInventory(System.Int32 InventoryId);
		List<Inventory> GetAllInventory();
		Inventory InsertInventory(Inventory entity);

	}
	
	
}
