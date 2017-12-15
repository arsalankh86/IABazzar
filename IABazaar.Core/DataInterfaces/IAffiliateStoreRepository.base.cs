using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IAffiliateStoreRepositoryBase
	{
        
        Dictionary<string, string> GetAffiliateStoreBasicSearchColumns();
        List<SearchColumn> GetAffiliateStoreSearchColumns();
        List<SearchColumn> GetAffiliateStoreAdvanceSearchColumns();
        

		AffiliateStore GetAffiliateStore(System.Int32 AffiliateId);
		AffiliateStore UpdateAffiliateStore(AffiliateStore entity);
		bool DeleteAffiliateStore(System.Int32 AffiliateId);
		AffiliateStore DeleteAffiliateStore(AffiliateStore entity);
		List<AffiliateStore> GetAllAffiliateStore();
		AffiliateStore InsertAffiliateStore(AffiliateStore entity);	}
	
	
}
