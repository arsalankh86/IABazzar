using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IMobileDeviceRepositoryBase
	{
        
        Dictionary<string, string> GetMobileDeviceBasicSearchColumns();
        List<SearchColumn> GetMobileDeviceSearchColumns();
        List<SearchColumn> GetMobileDeviceAdvanceSearchColumns();
        

		MobileDevice GetMobileDevice(System.Int32 MobileDeviceId);
		MobileDevice UpdateMobileDevice(MobileDevice entity);
		bool DeleteMobileDevice(System.Int32 MobileDeviceId);
		MobileDevice DeleteMobileDevice(MobileDevice entity);
		List<MobileDevice> GetAllMobileDevice();
		MobileDevice InsertMobileDevice(MobileDevice entity);	}
	
	
}
