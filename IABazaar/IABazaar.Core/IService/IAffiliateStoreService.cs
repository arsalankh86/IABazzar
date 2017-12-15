using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IAffiliateStoreService
	{
        Dictionary<string, string> GetAffiliateStoreBasicSearchColumns();
        
        List<SearchColumn> GetAffiliateStoreAdvanceSearchColumns();

		AffiliateStore GetAffiliateStore(System.Int32 AffiliateId);
		AffiliateStore UpdateAffiliateStore(AffiliateStore entity);
		bool DeleteAffiliateStore(System.Int32 AffiliateId);
		List<AffiliateStore> GetAllAffiliateStore();
		AffiliateStore InsertAffiliateStore(AffiliateStore entity);

	}
	
	
}
