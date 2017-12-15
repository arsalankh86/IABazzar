using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IKitGroupTypeService
	{
        Dictionary<string, string> GetKitGroupTypeBasicSearchColumns();
        
        List<SearchColumn> GetKitGroupTypeAdvanceSearchColumns();

		KitGroupType GetKitGroupType(System.Int32 KitGroupTypeId);
		KitGroupType UpdateKitGroupType(KitGroupType entity);
		bool DeleteKitGroupType(System.Int32 KitGroupTypeId);
		List<KitGroupType> GetAllKitGroupType();
		KitGroupType InsertKitGroupType(KitGroupType entity);

	}
	
	
}
