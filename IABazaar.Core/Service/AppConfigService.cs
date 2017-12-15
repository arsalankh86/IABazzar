using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class AppConfigService : IAppConfigService 
	{
		private IAppConfigRepository _iAppConfigRepository;
        
		public AppConfigService(IAppConfigRepository iAppConfigRepository)
		{
			this._iAppConfigRepository = iAppConfigRepository;
		}
        
        public Dictionary<string, string> GetAppConfigBasicSearchColumns()
        {
            
            return this._iAppConfigRepository.GetAppConfigBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetAppConfigAdvanceSearchColumns()
        {
            
            return this._iAppConfigRepository.GetAppConfigAdvanceSearchColumns();
           
        }


		public AppConfig GetAppConfig(System.Int32 AppConfigId)
		{
			return _iAppConfigRepository.GetAppConfig(AppConfigId);
		}

		public AppConfig UpdateAppConfig(AppConfig entity)
		{
			return _iAppConfigRepository.UpdateAppConfig(entity);
		}

		public bool DeleteAppConfig(System.Int32 AppConfigId)
		{
			return _iAppConfigRepository.DeleteAppConfig(AppConfigId);
		}

		public List<AppConfig> GetAllAppConfig()
		{
			return _iAppConfigRepository.GetAllAppConfig();
		}

		public AppConfig InsertAppConfig(AppConfig entity)
		{
			 return _iAppConfigRepository.InsertAppConfig(entity);
		}


	}
	
	
}
