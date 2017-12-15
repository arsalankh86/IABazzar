using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ICountryService
	{
        Dictionary<string, string> GetCountryBasicSearchColumns();
        
        List<SearchColumn> GetCountryAdvanceSearchColumns();

		Country GetCountry(System.Int32 CountryId);
		Country UpdateCountry(Country entity);
		bool DeleteCountry(System.Int32 CountryId);
		List<Country> GetAllCountry();
		Country InsertCountry(Country entity);

	}
	
	
}
