using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IAffiliateRepositoryBase
	{
        
        Dictionary<string, string> GetAffiliateBasicSearchColumns();
        List<SearchColumn> GetAffiliateSearchColumns();
        List<SearchColumn> GetAffiliateAdvanceSearchColumns();
        

		Affiliate GetAffiliate(System.Int32 AffiliateId);
		Affiliate UpdateAffiliate(Affiliate entity);
		bool DeleteAffiliate(System.Int32 AffiliateId);
		Affiliate DeleteAffiliate(Affiliate entity);
		List<Affiliate> GetAllAffiliate();
		Affiliate InsertAffiliate(Affiliate entity);	}
	
	
}
