using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IMobileDeviceService
	{
        Dictionary<string, string> GetMobileDeviceBasicSearchColumns();
        
        List<SearchColumn> GetMobileDeviceAdvanceSearchColumns();

		MobileDevice GetMobileDevice(System.Int32 MobileDeviceId);
		MobileDevice UpdateMobileDevice(MobileDevice entity);
		bool DeleteMobileDevice(System.Int32 MobileDeviceId);
		List<MobileDevice> GetAllMobileDevice();
		MobileDevice InsertMobileDevice(MobileDevice entity);

	}
	
	
}
