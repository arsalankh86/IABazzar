using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IAffiliateActivityReasonRepositoryBase
	{
        
        Dictionary<string, string> GetAffiliateActivityReasonBasicSearchColumns();
        List<SearchColumn> GetAffiliateActivityReasonSearchColumns();
        List<SearchColumn> GetAffiliateActivityReasonAdvanceSearchColumns();
        

		AffiliateActivityReason GetAffiliateActivityReason(System.Int32 AffiliateActivityReasonId);
		AffiliateActivityReason UpdateAffiliateActivityReason(AffiliateActivityReason entity);
		bool DeleteAffiliateActivityReason(System.Int32 AffiliateActivityReasonId);
		AffiliateActivityReason DeleteAffiliateActivityReason(AffiliateActivityReason entity);
		List<AffiliateActivityReason> GetAllAffiliateActivityReason();
		AffiliateActivityReason InsertAffiliateActivityReason(AffiliateActivityReason entity);	}
	
	
}
