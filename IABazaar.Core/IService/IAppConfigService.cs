using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IAppConfigService
	{
        Dictionary<string, string> GetAppConfigBasicSearchColumns();
        
        List<SearchColumn> GetAppConfigAdvanceSearchColumns();

		AppConfig GetAppConfig(System.Int32 AppConfigId);
		AppConfig UpdateAppConfig(AppConfig entity);
		bool DeleteAppConfig(System.Int32 AppConfigId);
		List<AppConfig> GetAllAppConfig();
		AppConfig InsertAppConfig(AppConfig entity);

	}
	
	
}
