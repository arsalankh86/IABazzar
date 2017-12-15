using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IAffiliateCommissionsService
	{
        Dictionary<string, string> GetAffiliateCommissionsBasicSearchColumns();
        
        List<SearchColumn> GetAffiliateCommissionsAdvanceSearchColumns();

		List<AffiliateCommissions> GetAllAffiliateCommissions();
		AffiliateCommissions InsertAffiliateCommissions(AffiliateCommissions entity);

	}
	
	
}
