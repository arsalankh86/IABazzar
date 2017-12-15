using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class MobileDeviceService : IMobileDeviceService 
	{
		private IMobileDeviceRepository _iMobileDeviceRepository;
        
		public MobileDeviceService(IMobileDeviceRepository iMobileDeviceRepository)
		{
			this._iMobileDeviceRepository = iMobileDeviceRepository;
		}
        
        public Dictionary<string, string> GetMobileDeviceBasicSearchColumns()
        {
            
            return this._iMobileDeviceRepository.GetMobileDeviceBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetMobileDeviceAdvanceSearchColumns()
        {
            
            return this._iMobileDeviceRepository.GetMobileDeviceAdvanceSearchColumns();
           
        }


		public MobileDevice GetMobileDevice(System.Int32 MobileDeviceId)
		{
			return _iMobileDeviceRepository.GetMobileDevice(MobileDeviceId);
		}

		public MobileDevice UpdateMobileDevice(MobileDevice entity)
		{
			return _iMobileDeviceRepository.UpdateMobileDevice(entity);
		}

		public bool DeleteMobileDevice(System.Int32 MobileDeviceId)
		{
			return _iMobileDeviceRepository.DeleteMobileDevice(MobileDeviceId);
		}

		public List<MobileDevice> GetAllMobileDevice()
		{
			return _iMobileDeviceRepository.GetAllMobileDevice();
		}

		public MobileDevice InsertMobileDevice(MobileDevice entity)
		{
			 return _iMobileDeviceRepository.InsertMobileDevice(entity);
		}


	}
	
	
}
