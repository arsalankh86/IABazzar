using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class CustomerLevelService : ICustomerLevelService 
	{
		private ICustomerLevelRepository _iCustomerLevelRepository;
        
		public CustomerLevelService(ICustomerLevelRepository iCustomerLevelRepository)
		{
			this._iCustomerLevelRepository = iCustomerLevelRepository;
		}
        
        public Dictionary<string, string> GetCustomerLevelBasicSearchColumns()
        {
            
            return this._iCustomerLevelRepository.GetCustomerLevelBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetCustomerLevelAdvanceSearchColumns()
        {
            
            return this._iCustomerLevelRepository.GetCustomerLevelAdvanceSearchColumns();
           
        }


		public CustomerLevel GetCustomerLevel(System.Int32 CustomerLevelId)
		{
			return _iCustomerLevelRepository.GetCustomerLevel(CustomerLevelId);
		}

		public CustomerLevel UpdateCustomerLevel(CustomerLevel entity)
		{
			return _iCustomerLevelRepository.UpdateCustomerLevel(entity);
		}

		public bool DeleteCustomerLevel(System.Int32 CustomerLevelId)
		{
			return _iCustomerLevelRepository.DeleteCustomerLevel(CustomerLevelId);
		}

		public List<CustomerLevel> GetAllCustomerLevel()
		{
			return _iCustomerLevelRepository.GetAllCustomerLevel();
		}

		public CustomerLevel InsertCustomerLevel(CustomerLevel entity)
		{
			 return _iCustomerLevelRepository.InsertCustomerLevel(entity);
		}


	}
	
	
}
