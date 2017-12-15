using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class InventoryService : IInventoryService 
	{
		private IInventoryRepository _iInventoryRepository;
        
		public InventoryService(IInventoryRepository iInventoryRepository)
		{
			this._iInventoryRepository = iInventoryRepository;
		}
        
        public Dictionary<string, string> GetInventoryBasicSearchColumns()
        {
            
            return this._iInventoryRepository.GetInventoryBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetInventoryAdvanceSearchColumns()
        {
            
            return this._iInventoryRepository.GetInventoryAdvanceSearchColumns();
           
        }


		public Inventory GetInventory(System.Int32 InventoryId)
		{
			return _iInventoryRepository.GetInventory(InventoryId);
		}

		public Inventory UpdateInventory(Inventory entity)
		{
			return _iInventoryRepository.UpdateInventory(entity);
		}

		public bool DeleteInventory(System.Int32 InventoryId)
		{
			return _iInventoryRepository.DeleteInventory(InventoryId);
		}

		public List<Inventory> GetAllInventory()
		{
			return _iInventoryRepository.GetAllInventory();
		}

		public Inventory InsertInventory(Inventory entity)
		{
			 return _iInventoryRepository.InsertInventory(entity);
		}


	}
	
	
}
