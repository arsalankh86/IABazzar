using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IProductLocaleSettingService
	{
        Dictionary<string, string> GetProductLocaleSettingBasicSearchColumns();
        
        List<SearchColumn> GetProductLocaleSettingAdvanceSearchColumns();

		ProductLocaleSetting GetProductLocaleSetting(System.Int32 ProductId);
		ProductLocaleSetting UpdateProductLocaleSetting(ProductLocaleSetting entity);
		bool DeleteProductLocaleSetting(System.Int32 ProductId);
		List<ProductLocaleSetting> GetAllProductLocaleSetting();
		ProductLocaleSetting InsertProductLocaleSetting(ProductLocaleSetting entity);

	}
	
	
}
