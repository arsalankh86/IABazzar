using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class RestrictedIpService : IRestrictedIpService 
	{
		private IRestrictedIpRepository _iRestrictedIpRepository;
        
		public RestrictedIpService(IRestrictedIpRepository iRestrictedIpRepository)
		{
			this._iRestrictedIpRepository = iRestrictedIpRepository;
		}
        
        public Dictionary<string, string> GetRestrictedIpBasicSearchColumns()
        {
            
            return this._iRestrictedIpRepository.GetRestrictedIpBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetRestrictedIpAdvanceSearchColumns()
        {
            
            return this._iRestrictedIpRepository.GetRestrictedIpAdvanceSearchColumns();
           
        }


		public RestrictedIp GetRestrictedIp(System.String IpAddress)
		{
			return _iRestrictedIpRepository.GetRestrictedIp(IpAddress);
		}

		public RestrictedIp UpdateRestrictedIp(RestrictedIp entity)
		{
			return _iRestrictedIpRepository.UpdateRestrictedIp(entity);
		}

		public bool DeleteRestrictedIp(System.String IpAddress)
		{
			return _iRestrictedIpRepository.DeleteRestrictedIp(IpAddress);
		}

		public List<RestrictedIp> GetAllRestrictedIp()
		{
			return _iRestrictedIpRepository.GetAllRestrictedIp();
		}

		public RestrictedIp InsertRestrictedIp(RestrictedIp entity)
		{
			 return _iRestrictedIpRepository.InsertRestrictedIp(entity);
		}


	}
	
	
}
