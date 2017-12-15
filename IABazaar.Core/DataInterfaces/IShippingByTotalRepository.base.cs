using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IShippingByTotalRepositoryBase
	{
        
        Dictionary<string, string> GetShippingByTotalBasicSearchColumns();
        List<SearchColumn> GetShippingByTotalSearchColumns();
        List<SearchColumn> GetShippingByTotalAdvanceSearchColumns();
        

		List<ShippingByTotal> GetAllShippingByTotal();
		ShippingByTotal InsertShippingByTotal(ShippingByTotal entity);	}
	
	
}
