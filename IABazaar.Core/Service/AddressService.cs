using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class AddressService : IAddressService 
	{
		private IAddressRepository _iAddressRepository;
        
		public AddressService(IAddressRepository iAddressRepository)
		{
			this._iAddressRepository = iAddressRepository;
		}
        
        public Dictionary<string, string> GetAddressBasicSearchColumns()
        {
            
            return this._iAddressRepository.GetAddressBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetAddressAdvanceSearchColumns()
        {
            
            return this._iAddressRepository.GetAddressAdvanceSearchColumns();
           
        }


		public Address GetAddress(System.Int32 AddressId)
		{
			return _iAddressRepository.GetAddress(AddressId);
		}

		public Address UpdateAddress(Address entity)
		{
			return _iAddressRepository.UpdateAddress(entity);
		}

		public bool DeleteAddress(System.Int32 AddressId)
		{
			return _iAddressRepository.DeleteAddress(AddressId);
		}

		public List<Address> GetAllAddress()
		{
			return _iAddressRepository.GetAllAddress();
		}

		public Address InsertAddress(Address entity)
		{
			 return _iAddressRepository.InsertAddress(entity);
		}


	}
	
	
}
