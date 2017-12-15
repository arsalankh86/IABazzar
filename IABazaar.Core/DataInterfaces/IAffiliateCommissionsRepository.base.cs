using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IAffiliateCommissionsRepositoryBase
	{
        
        Dictionary<string, string> GetAffiliateCommissionsBasicSearchColumns();
        List<SearchColumn> GetAffiliateCommissionsSearchColumns();
        List<SearchColumn> GetAffiliateCommissionsAdvanceSearchColumns();
        

		List<AffiliateCommissions> GetAllAffiliateCommissions();
		AffiliateCommissions InsertAffiliateCommissions(AffiliateCommissions entity);	}
	
	
}
