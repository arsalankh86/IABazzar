using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IKitCartRepositoryBase
	{
        
        Dictionary<string, string> GetKitCartBasicSearchColumns();
        List<SearchColumn> GetKitCartSearchColumns();
        List<SearchColumn> GetKitCartAdvanceSearchColumns();
        

		KitCart GetKitCart(System.Int32 KitCartRecId);
		KitCart UpdateKitCart(KitCart entity);
		bool DeleteKitCart(System.Int32 KitCartRecId);
		KitCart DeleteKitCart(KitCart entity);
		List<KitCart> GetAllKitCart();
		KitCart InsertKitCart(KitCart entity);	}
	
	
}
