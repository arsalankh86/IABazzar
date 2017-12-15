using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IKitItemRepositoryBase
	{
        
        Dictionary<string, string> GetKitItemBasicSearchColumns();
        List<SearchColumn> GetKitItemSearchColumns();
        List<SearchColumn> GetKitItemAdvanceSearchColumns();
        

		KitItem GetKitItem(System.Int32 KitItemId);
		KitItem UpdateKitItem(KitItem entity);
		bool DeleteKitItem(System.Int32 KitItemId);
		KitItem DeleteKitItem(KitItem entity);
		List<KitItem> GetAllKitItem();
		KitItem InsertKitItem(KitItem entity);	}
	
	
}
