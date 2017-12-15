using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ILocaleSettingRepositoryBase
	{
        
        Dictionary<string, string> GetLocaleSettingBasicSearchColumns();
        List<SearchColumn> GetLocaleSettingSearchColumns();
        List<SearchColumn> GetLocaleSettingAdvanceSearchColumns();
        

		LocaleSetting GetLocaleSetting(System.Int32 LocaleSettingId);
		LocaleSetting UpdateLocaleSetting(LocaleSetting entity);
		bool DeleteLocaleSetting(System.Int32 LocaleSettingId);
		LocaleSetting DeleteLocaleSetting(LocaleSetting entity);
		List<LocaleSetting> GetAllLocaleSetting();
		LocaleSetting InsertLocaleSetting(LocaleSetting entity);	}
	
	
}
