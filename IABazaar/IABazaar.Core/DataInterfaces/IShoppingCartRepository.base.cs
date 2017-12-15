using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IShoppingCartRepositoryBase
	{
        
        Dictionary<string, string> GetShoppingCartBasicSearchColumns();
        List<SearchColumn> GetShoppingCartSearchColumns();
        List<SearchColumn> GetShoppingCartAdvanceSearchColumns();
        

		ShoppingCart GetShoppingCart(System.Int32 ShoppingCartRecId);
		ShoppingCart UpdateShoppingCart(ShoppingCart entity);
		bool DeleteShoppingCart(System.Int32 ShoppingCartRecId);
		ShoppingCart DeleteShoppingCart(ShoppingCart entity);
		List<ShoppingCart> GetAllShoppingCart();
		ShoppingCart InsertShoppingCart(ShoppingCart entity);	}
	
	
}
