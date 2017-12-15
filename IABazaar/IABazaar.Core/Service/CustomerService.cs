using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class CustomerService : ICustomerService 
	{
		private ICustomerRepository _iCustomerRepository;
        
		public CustomerService(ICustomerRepository iCustomerRepository)
		{
			this._iCustomerRepository = iCustomerRepository;
		}
        
        public Dictionary<string, string> GetCustomerBasicSearchColumns()
        {
            
            return this._iCustomerRepository.GetCustomerBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetCustomerAdvanceSearchColumns()
        {
            
            return this._iCustomerRepository.GetCustomerAdvanceSearchColumns();
           
        }


		public Customer GetCustomer(System.Int32 CustomerId)
		{
			return _iCustomerRepository.GetCustomer(CustomerId);
		}

		public Customer UpdateCustomer(Customer entity)
		{
			return _iCustomerRepository.UpdateCustomer(entity);
		}

		public bool DeleteCustomer(System.Int32 CustomerId)
		{
			return _iCustomerRepository.DeleteCustomer(CustomerId);
		}

		public List<Customer> GetAllCustomer()
		{
			return _iCustomerRepository.GetAllCustomer();
		}

		public Customer InsertCustomer(Customer entity)
		{
			 return _iCustomerRepository.InsertCustomer(entity);
		}


	}
	
	
}
