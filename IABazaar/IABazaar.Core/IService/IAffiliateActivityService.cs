using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IAffiliateActivityService
	{
        Dictionary<string, string> GetAffiliateActivityBasicSearchColumns();
        
        List<SearchColumn> GetAffiliateActivityAdvanceSearchColumns();

		AffiliateActivity GetAffiliateActivity(System.Int32 AffiliateActivityId);
		AffiliateActivity UpdateAffiliateActivity(AffiliateActivity entity);
		bool DeleteAffiliateActivity(System.Int32 AffiliateActivityId);
		List<AffiliateActivity> GetAllAffiliateActivity();
		AffiliateActivity InsertAffiliateActivity(AffiliateActivity entity);

	}
	
	
}
