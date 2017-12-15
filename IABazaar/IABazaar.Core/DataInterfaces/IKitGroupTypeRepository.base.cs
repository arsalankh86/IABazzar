using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IKitGroupTypeRepositoryBase
	{
        
        Dictionary<string, string> GetKitGroupTypeBasicSearchColumns();
        List<SearchColumn> GetKitGroupTypeSearchColumns();
        List<SearchColumn> GetKitGroupTypeAdvanceSearchColumns();
        

		KitGroupType GetKitGroupType(System.Int32 KitGroupTypeId);
		KitGroupType UpdateKitGroupType(KitGroupType entity);
		bool DeleteKitGroupType(System.Int32 KitGroupTypeId);
		KitGroupType DeleteKitGroupType(KitGroupType entity);
		List<KitGroupType> GetAllKitGroupType();
		KitGroupType InsertKitGroupType(KitGroupType entity);	}
	
	
}
