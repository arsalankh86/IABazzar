using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class KitItemService : IKitItemService 
	{
		private IKitItemRepository _iKitItemRepository;
        
		public KitItemService(IKitItemRepository iKitItemRepository)
		{
			this._iKitItemRepository = iKitItemRepository;
		}
        
        public Dictionary<string, string> GetKitItemBasicSearchColumns()
        {
            
            return this._iKitItemRepository.GetKitItemBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetKitItemAdvanceSearchColumns()
        {
            
            return this._iKitItemRepository.GetKitItemAdvanceSearchColumns();
           
        }


		public KitItem GetKitItem(System.Int32 KitItemId)
		{
			return _iKitItemRepository.GetKitItem(KitItemId);
		}

		public KitItem UpdateKitItem(KitItem entity)
		{
			return _iKitItemRepository.UpdateKitItem(entity);
		}

		public bool DeleteKitItem(System.Int32 KitItemId)
		{
			return _iKitItemRepository.DeleteKitItem(KitItemId);
		}

		public List<KitItem> GetAllKitItem()
		{
			return _iKitItemRepository.GetAllKitItem();
		}

		public KitItem InsertKitItem(KitItem entity)
		{
			 return _iKitItemRepository.InsertKitItem(entity);
		}


	}
	
	
}
