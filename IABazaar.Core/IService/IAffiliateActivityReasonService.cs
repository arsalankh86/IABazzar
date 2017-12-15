using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IAffiliateActivityReasonService
	{
        Dictionary<string, string> GetAffiliateActivityReasonBasicSearchColumns();
        
        List<SearchColumn> GetAffiliateActivityReasonAdvanceSearchColumns();

		AffiliateActivityReason GetAffiliateActivityReason(System.Int32 AffiliateActivityReasonId);
		AffiliateActivityReason UpdateAffiliateActivityReason(AffiliateActivityReason entity);
		bool DeleteAffiliateActivityReason(System.Int32 AffiliateActivityReasonId);
		List<AffiliateActivityReason> GetAllAffiliateActivityReason();
		AffiliateActivityReason InsertAffiliateActivityReason(AffiliateActivityReason entity);

	}
	
	
}
