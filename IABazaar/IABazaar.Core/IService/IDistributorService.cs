using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IDistributorService
	{
        Dictionary<string, string> GetDistributorBasicSearchColumns();
        
        List<SearchColumn> GetDistributorAdvanceSearchColumns();

		Distributor GetDistributor(System.Int32 DistributorId);
		Distributor UpdateDistributor(Distributor entity);
		bool DeleteDistributor(System.Int32 DistributorId);
		List<Distributor> GetAllDistributor();
		Distributor InsertDistributor(Distributor entity);

	}
	
	
}
