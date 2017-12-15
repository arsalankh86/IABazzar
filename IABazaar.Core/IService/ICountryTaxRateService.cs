using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ICountryTaxRateService
	{
        Dictionary<string, string> GetCountryTaxRateBasicSearchColumns();
        
        List<SearchColumn> GetCountryTaxRateAdvanceSearchColumns();

		CountryTaxRate GetCountryTaxRate(System.Int32 CountryTaxId);
		CountryTaxRate UpdateCountryTaxRate(CountryTaxRate entity);
		bool DeleteCountryTaxRate(System.Int32 CountryTaxId);
		List<CountryTaxRate> GetAllCountryTaxRate();
		CountryTaxRate InsertCountryTaxRate(CountryTaxRate entity);

	}
	
	
}
