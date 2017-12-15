using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IGlobalConfigRepositoryBase
	{
        
        Dictionary<string, string> GetGlobalConfigBasicSearchColumns();
        List<SearchColumn> GetGlobalConfigSearchColumns();
        List<SearchColumn> GetGlobalConfigAdvanceSearchColumns();
        

		GlobalConfig GetGlobalConfig(System.Int32 GlobalConfigId);
		GlobalConfig UpdateGlobalConfig(GlobalConfig entity);
		bool DeleteGlobalConfig(System.Int32 GlobalConfigId);
		GlobalConfig DeleteGlobalConfig(GlobalConfig entity);
		List<GlobalConfig> GetAllGlobalConfig();
		GlobalConfig InsertGlobalConfig(GlobalConfig entity);	}
	
	
}
