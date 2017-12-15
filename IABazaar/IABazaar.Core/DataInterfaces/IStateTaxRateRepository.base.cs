using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IStateTaxRateRepositoryBase
	{
        
        Dictionary<string, string> GetStateTaxRateBasicSearchColumns();
        List<SearchColumn> GetStateTaxRateSearchColumns();
        List<SearchColumn> GetStateTaxRateAdvanceSearchColumns();
        

		StateTaxRate GetStateTaxRate(System.Int32 StateTaxId);
		StateTaxRate UpdateStateTaxRate(StateTaxRate entity);
		bool DeleteStateTaxRate(System.Int32 StateTaxId);
		StateTaxRate DeleteStateTaxRate(StateTaxRate entity);
		List<StateTaxRate> GetAllStateTaxRate();
		StateTaxRate InsertStateTaxRate(StateTaxRate entity);	}
	
	
}
