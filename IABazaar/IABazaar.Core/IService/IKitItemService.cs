using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IKitItemService
	{
        Dictionary<string, string> GetKitItemBasicSearchColumns();
        
        List<SearchColumn> GetKitItemAdvanceSearchColumns();

		KitItem GetKitItem(System.Int32 KitItemId);
		KitItem UpdateKitItem(KitItem entity);
		bool DeleteKitItem(System.Int32 KitItemId);
		List<KitItem> GetAllKitItem();
		KitItem InsertKitItem(KitItem entity);

	}
	
	
}
