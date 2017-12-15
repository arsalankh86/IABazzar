using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ILocaleSettingService
	{
        Dictionary<string, string> GetLocaleSettingBasicSearchColumns();
        
        List<SearchColumn> GetLocaleSettingAdvanceSearchColumns();

		LocaleSetting GetLocaleSetting(System.Int32 LocaleSettingId);
		LocaleSetting UpdateLocaleSetting(LocaleSetting entity);
		bool DeleteLocaleSetting(System.Int32 LocaleSettingId);
		List<LocaleSetting> GetAllLocaleSetting();
		LocaleSetting InsertLocaleSetting(LocaleSetting entity);

	}
	
	
}
