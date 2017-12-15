using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IRestrictedIpRepositoryBase
	{
        
        Dictionary<string, string> GetRestrictedIpBasicSearchColumns();
        List<SearchColumn> GetRestrictedIpSearchColumns();
        List<SearchColumn> GetRestrictedIpAdvanceSearchColumns();
        

		RestrictedIp GetRestrictedIp(System.String IpAddress);
		RestrictedIp UpdateRestrictedIp(RestrictedIp entity);
		bool DeleteRestrictedIp(System.String IpAddress);
		RestrictedIp DeleteRestrictedIp(RestrictedIp entity);
		List<RestrictedIp> GetAllRestrictedIp();
		RestrictedIp InsertRestrictedIp(RestrictedIp entity);	}
	
	
}
