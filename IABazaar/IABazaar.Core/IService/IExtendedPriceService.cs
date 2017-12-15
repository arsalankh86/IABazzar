using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IExtendedPriceService
	{
        Dictionary<string, string> GetExtendedPriceBasicSearchColumns();
        
        List<SearchColumn> GetExtendedPriceAdvanceSearchColumns();

		ExtendedPrice GetExtendedPrice(System.Int32 ExtendedPriceId);
		ExtendedPrice UpdateExtendedPrice(ExtendedPrice entity);
		bool DeleteExtendedPrice(System.Int32 ExtendedPriceId);
		List<ExtendedPrice> GetAllExtendedPrice();
		ExtendedPrice InsertExtendedPrice(ExtendedPrice entity);

	}
	
	
}
