using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ICountryRepositoryBase
	{
        
        Dictionary<string, string> GetCountryBasicSearchColumns();
        List<SearchColumn> GetCountrySearchColumns();
        List<SearchColumn> GetCountryAdvanceSearchColumns();
        

		Country GetCountry(System.Int32 CountryId);
		Country UpdateCountry(Country entity);
		bool DeleteCountry(System.Int32 CountryId);
		Country DeleteCountry(Country entity);
		List<Country> GetAllCountry();
		Country InsertCountry(Country entity);	}
	
	
}
