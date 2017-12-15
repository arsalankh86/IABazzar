using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IProductLocaleSettingRepositoryBase
	{
        
        Dictionary<string, string> GetProductLocaleSettingBasicSearchColumns();
        List<SearchColumn> GetProductLocaleSettingSearchColumns();
        List<SearchColumn> GetProductLocaleSettingAdvanceSearchColumns();
        

		ProductLocaleSetting GetProductLocaleSetting(System.Int32 ProductId);
		ProductLocaleSetting UpdateProductLocaleSetting(ProductLocaleSetting entity);
		bool DeleteProductLocaleSetting(System.Int32 ProductId);
		ProductLocaleSetting DeleteProductLocaleSetting(ProductLocaleSetting entity);
		List<ProductLocaleSetting> GetAllProductLocaleSetting();
		ProductLocaleSetting InsertProductLocaleSetting(ProductLocaleSetting entity);	}
	
	
}
