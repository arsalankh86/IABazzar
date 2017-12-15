using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IQuantityDiscountTableRepositoryBase
	{
        
        Dictionary<string, string> GetQuantityDiscountTableBasicSearchColumns();
        List<SearchColumn> GetQuantityDiscountTableSearchColumns();
        List<SearchColumn> GetQuantityDiscountTableAdvanceSearchColumns();
        

		QuantityDiscountTable GetQuantityDiscountTable(System.Int32 QuantityDiscountTableId);
		QuantityDiscountTable UpdateQuantityDiscountTable(QuantityDiscountTable entity);
		bool DeleteQuantityDiscountTable(System.Int32 QuantityDiscountTableId);
		QuantityDiscountTable DeleteQuantityDiscountTable(QuantityDiscountTable entity);
		List<QuantityDiscountTable> GetAllQuantityDiscountTable();
		QuantityDiscountTable InsertQuantityDiscountTable(QuantityDiscountTable entity);	}
	
	
}
