using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IQuantityDiscountService
	{
        Dictionary<string, string> GetQuantityDiscountBasicSearchColumns();
        
        List<SearchColumn> GetQuantityDiscountAdvanceSearchColumns();

		QuantityDiscount GetQuantityDiscount(System.Int32 QuantityDiscountId);
		QuantityDiscount UpdateQuantityDiscount(QuantityDiscount entity);
		bool DeleteQuantityDiscount(System.Int32 QuantityDiscountId);
		List<QuantityDiscount> GetAllQuantityDiscount();
		QuantityDiscount InsertQuantityDiscount(QuantityDiscount entity);

	}
	
	
}
