using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IShippingCalculationRepositoryBase
	{
        
        Dictionary<string, string> GetShippingCalculationBasicSearchColumns();
        List<SearchColumn> GetShippingCalculationSearchColumns();
        List<SearchColumn> GetShippingCalculationAdvanceSearchColumns();
        

		ShippingCalculation GetShippingCalculation(System.Int32 ShippingCalculationId);
		ShippingCalculation UpdateShippingCalculation(ShippingCalculation entity);
		bool DeleteShippingCalculation(System.Int32 ShippingCalculationId);
		ShippingCalculation DeleteShippingCalculation(ShippingCalculation entity);
		List<ShippingCalculation> GetAllShippingCalculation();
		ShippingCalculation InsertShippingCalculation(ShippingCalculation entity);	}
	
	
}
