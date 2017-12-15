using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IDistributorRepositoryBase
	{
        
        Dictionary<string, string> GetDistributorBasicSearchColumns();
        List<SearchColumn> GetDistributorSearchColumns();
        List<SearchColumn> GetDistributorAdvanceSearchColumns();
        

		Distributor GetDistributor(System.Int32 DistributorId);
		Distributor UpdateDistributor(Distributor entity);
		bool DeleteDistributor(System.Int32 DistributorId);
		Distributor DeleteDistributor(Distributor entity);
		List<Distributor> GetAllDistributor();
		Distributor InsertDistributor(Distributor entity);	}
	
	
}
