using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IQuantityDiscountTableService
	{
        Dictionary<string, string> GetQuantityDiscountTableBasicSearchColumns();
        
        List<SearchColumn> GetQuantityDiscountTableAdvanceSearchColumns();

		QuantityDiscountTable GetQuantityDiscountTable(System.Int32 QuantityDiscountTableId);
		QuantityDiscountTable UpdateQuantityDiscountTable(QuantityDiscountTable entity);
		bool DeleteQuantityDiscountTable(System.Int32 QuantityDiscountTableId);
		List<QuantityDiscountTable> GetAllQuantityDiscountTable();
		QuantityDiscountTable InsertQuantityDiscountTable(QuantityDiscountTable entity);

	}
	
	
}
