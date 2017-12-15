using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ICurrencyService
	{
        Dictionary<string, string> GetCurrencyBasicSearchColumns();
        
        List<SearchColumn> GetCurrencyAdvanceSearchColumns();

		Currency GetCurrency(System.Int32 CurrencyId);
		Currency UpdateCurrency(Currency entity);
		bool DeleteCurrency(System.Int32 CurrencyId);
		List<Currency> GetAllCurrency();
		Currency InsertCurrency(Currency entity);

	}
	
	
}
