using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IRestrictedIpService
	{
        Dictionary<string, string> GetRestrictedIpBasicSearchColumns();
        
        List<SearchColumn> GetRestrictedIpAdvanceSearchColumns();

		RestrictedIp GetRestrictedIp(System.String IpAddress);
		RestrictedIp UpdateRestrictedIp(RestrictedIp entity);
		bool DeleteRestrictedIp(System.String IpAddress);
		List<RestrictedIp> GetAllRestrictedIp();
		RestrictedIp InsertRestrictedIp(RestrictedIp entity);

	}
	
	
}
