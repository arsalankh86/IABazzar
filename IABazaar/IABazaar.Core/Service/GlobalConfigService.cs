using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class GlobalConfigService : IGlobalConfigService 
	{
		private IGlobalConfigRepository _iGlobalConfigRepository;
        
		public GlobalConfigService(IGlobalConfigRepository iGlobalConfigRepository)
		{
			this._iGlobalConfigRepository = iGlobalConfigRepository;
		}
        
        public Dictionary<string, string> GetGlobalConfigBasicSearchColumns()
        {
            
            return this._iGlobalConfigRepository.GetGlobalConfigBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetGlobalConfigAdvanceSearchColumns()
        {
            
            return this._iGlobalConfigRepository.GetGlobalConfigAdvanceSearchColumns();
           
        }


		public GlobalConfig GetGlobalConfig(System.Int32 GlobalConfigId)
		{
			return _iGlobalConfigRepository.GetGlobalConfig(GlobalConfigId);
		}

		public GlobalConfig UpdateGlobalConfig(GlobalConfig entity)
		{
			return _iGlobalConfigRepository.UpdateGlobalConfig(entity);
		}

		public bool DeleteGlobalConfig(System.Int32 GlobalConfigId)
		{
			return _iGlobalConfigRepository.DeleteGlobalConfig(GlobalConfigId);
		}

		public List<GlobalConfig> GetAllGlobalConfig()
		{
			return _iGlobalConfigRepository.GetAllGlobalConfig();
		}

		public GlobalConfig InsertGlobalConfig(GlobalConfig entity)
		{
			 return _iGlobalConfigRepository.InsertGlobalConfig(entity);
		}


	}
	
	
}
