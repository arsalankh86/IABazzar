using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IKitGroupService
	{
        Dictionary<string, string> GetKitGroupBasicSearchColumns();
        
        List<SearchColumn> GetKitGroupAdvanceSearchColumns();

		KitGroup GetKitGroup(System.Int32 KitGroupId);
		KitGroup UpdateKitGroup(KitGroup entity);
		bool DeleteKitGroup(System.Int32 KitGroupId);
		List<KitGroup> GetAllKitGroup();
		KitGroup InsertKitGroup(KitGroup entity);

	}
	
	
}
