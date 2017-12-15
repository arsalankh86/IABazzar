using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ITaxClassRepositoryBase
	{
        
        Dictionary<string, string> GetTaxClassBasicSearchColumns();
        List<SearchColumn> GetTaxClassSearchColumns();
        List<SearchColumn> GetTaxClassAdvanceSearchColumns();
        

		TaxClass GetTaxClass(System.Int32 TaxClassId);
		TaxClass UpdateTaxClass(TaxClass entity);
		bool DeleteTaxClass(System.Int32 TaxClassId);
		TaxClass DeleteTaxClass(TaxClass entity);
		List<TaxClass> GetAllTaxClass();
		TaxClass InsertTaxClass(TaxClass entity);	}
	
	
}
