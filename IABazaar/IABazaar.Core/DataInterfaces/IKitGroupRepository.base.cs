using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IKitGroupRepositoryBase
	{
        
        Dictionary<string, string> GetKitGroupBasicSearchColumns();
        List<SearchColumn> GetKitGroupSearchColumns();
        List<SearchColumn> GetKitGroupAdvanceSearchColumns();
        

		KitGroup GetKitGroup(System.Int32 KitGroupId);
		KitGroup UpdateKitGroup(KitGroup entity);
		bool DeleteKitGroup(System.Int32 KitGroupId);
		KitGroup DeleteKitGroup(KitGroup entity);
		List<KitGroup> GetAllKitGroup();
		KitGroup InsertKitGroup(KitGroup entity);	}
	
	
}
