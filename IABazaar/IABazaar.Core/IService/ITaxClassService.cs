using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ITaxClassService
	{
        Dictionary<string, string> GetTaxClassBasicSearchColumns();
        
        List<SearchColumn> GetTaxClassAdvanceSearchColumns();

		TaxClass GetTaxClass(System.Int32 TaxClassId);
		TaxClass UpdateTaxClass(TaxClass entity);
		bool DeleteTaxClass(System.Int32 TaxClassId);
		List<TaxClass> GetAllTaxClass();
		TaxClass InsertTaxClass(TaxClass entity);

	}
	
	
}
