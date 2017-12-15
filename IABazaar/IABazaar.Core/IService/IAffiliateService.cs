using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IAffiliateService
	{
        Dictionary<string, string> GetAffiliateBasicSearchColumns();
        
        List<SearchColumn> GetAffiliateAdvanceSearchColumns();

		Affiliate GetAffiliate(System.Int32 AffiliateId);
		Affiliate UpdateAffiliate(Affiliate entity);
		bool DeleteAffiliate(System.Int32 AffiliateId);
		List<Affiliate> GetAllAffiliate();
		Affiliate InsertAffiliate(Affiliate entity);

	}
	
	
}
