using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class LocaleSettingService : ILocaleSettingService 
	{
		private ILocaleSettingRepository _iLocaleSettingRepository;
        
		public LocaleSettingService(ILocaleSettingRepository iLocaleSettingRepository)
		{
			this._iLocaleSettingRepository = iLocaleSettingRepository;
		}
        
        public Dictionary<string, string> GetLocaleSettingBasicSearchColumns()
        {
            
            return this._iLocaleSettingRepository.GetLocaleSettingBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetLocaleSettingAdvanceSearchColumns()
        {
            
            return this._iLocaleSettingRepository.GetLocaleSettingAdvanceSearchColumns();
           
        }


		public LocaleSetting GetLocaleSetting(System.Int32 LocaleSettingId)
		{
			return _iLocaleSettingRepository.GetLocaleSetting(LocaleSettingId);
		}

		public LocaleSetting UpdateLocaleSetting(LocaleSetting entity)
		{
			return _iLocaleSettingRepository.UpdateLocaleSetting(entity);
		}

		public bool DeleteLocaleSetting(System.Int32 LocaleSettingId)
		{
			return _iLocaleSettingRepository.DeleteLocaleSetting(LocaleSettingId);
		}

		public List<LocaleSetting> GetAllLocaleSetting()
		{
			return _iLocaleSettingRepository.GetAllLocaleSetting();
		}

		public LocaleSetting InsertLocaleSetting(LocaleSetting entity)
		{
			 return _iLocaleSettingRepository.InsertLocaleSetting(entity);
		}


	}
	
	
}
