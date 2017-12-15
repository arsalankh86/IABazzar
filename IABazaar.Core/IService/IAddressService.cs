using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IAddressService
	{
        Dictionary<string, string> GetAddressBasicSearchColumns();
        
        List<SearchColumn> GetAddressAdvanceSearchColumns();

		Address GetAddress(System.Int32 AddressId);
		Address UpdateAddress(Address entity);
		bool DeleteAddress(System.Int32 AddressId);
		List<Address> GetAllAddress();
		Address InsertAddress(Address entity);

	}
	
	
}
