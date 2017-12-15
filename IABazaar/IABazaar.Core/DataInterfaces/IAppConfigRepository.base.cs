using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IAppConfigRepositoryBase
	{
        
        Dictionary<string, string> GetAppConfigBasicSearchColumns();
        List<SearchColumn> GetAppConfigSearchColumns();
        List<SearchColumn> GetAppConfigAdvanceSearchColumns();
        

		AppConfig GetAppConfig(System.Int32 AppConfigId);
		AppConfig UpdateAppConfig(AppConfig entity);
		bool DeleteAppConfig(System.Int32 AppConfigId);
		AppConfig DeleteAppConfig(AppConfig entity);
		List<AppConfig> GetAllAppConfig();
		AppConfig InsertAppConfig(AppConfig entity);	}
	
	
}
