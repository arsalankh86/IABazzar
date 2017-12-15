using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ICountryTaxRateRepositoryBase
	{
        
        Dictionary<string, string> GetCountryTaxRateBasicSearchColumns();
        List<SearchColumn> GetCountryTaxRateSearchColumns();
        List<SearchColumn> GetCountryTaxRateAdvanceSearchColumns();
        

		CountryTaxRate GetCountryTaxRate(System.Int32 CountryTaxId);
		CountryTaxRate UpdateCountryTaxRate(CountryTaxRate entity);
		bool DeleteCountryTaxRate(System.Int32 CountryTaxId);
		CountryTaxRate DeleteCountryTaxRate(CountryTaxRate entity);
		List<CountryTaxRate> GetAllCountryTaxRate();
		CountryTaxRate InsertCountryTaxRate(CountryTaxRate entity);	}
	
	
}
