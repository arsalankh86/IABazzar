using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IAddressRepositoryBase
	{
        
        Dictionary<string, string> GetAddressBasicSearchColumns();
        List<SearchColumn> GetAddressSearchColumns();
        List<SearchColumn> GetAddressAdvanceSearchColumns();
        

		Address GetAddress(System.Int32 AddressId);
		Address UpdateAddress(Address entity);
		bool DeleteAddress(System.Int32 AddressId);
		Address DeleteAddress(Address entity);
		List<Address> GetAllAddress();
		Address InsertAddress(Address entity);	}
	
	
}
