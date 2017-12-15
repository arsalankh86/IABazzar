using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IKitCartService
	{
        Dictionary<string, string> GetKitCartBasicSearchColumns();
        
        List<SearchColumn> GetKitCartAdvanceSearchColumns();

		KitCart GetKitCart(System.Int32 KitCartRecId);
		KitCart UpdateKitCart(KitCart entity);
		bool DeleteKitCart(System.Int32 KitCartRecId);
		List<KitCart> GetAllKitCart();
		KitCart InsertKitCart(KitCart entity);

	}
	
	
}
