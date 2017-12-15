using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IShoppingCartService
	{
        Dictionary<string, string> GetShoppingCartBasicSearchColumns();
        
        List<SearchColumn> GetShoppingCartAdvanceSearchColumns();

		ShoppingCart GetShoppingCart(System.Int32 ShoppingCartRecId);
		ShoppingCart UpdateShoppingCart(ShoppingCart entity);
		bool DeleteShoppingCart(System.Int32 ShoppingCartRecId);
		List<ShoppingCart> GetAllShoppingCart();
		ShoppingCart InsertShoppingCart(ShoppingCart entity);

	}
	
	
}
