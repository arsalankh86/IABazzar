using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class CustomerProductSizeDetailService : ICustomerProductSizeDetailService 
	{
		private ICustomerProductSizeDetailRepository _iCustomerProductSizeDetailRepository;
        
		public CustomerProductSizeDetailService(ICustomerProductSizeDetailRepository iCustomerProductSizeDetailRepository)
		{
			this._iCustomerProductSizeDetailRepository = iCustomerProductSizeDetailRepository;
		}
        
        public Dictionary<string, string> GetCustomerProductSizeDetailBasicSearchColumns()
        {
            
            return this._iCustomerProductSizeDetailRepository.GetCustomerProductSizeDetailBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetCustomerProductSizeDetailAdvanceSearchColumns()
        {
            
            return this._iCustomerProductSizeDetailRepository.GetCustomerProductSizeDetailAdvanceSearchColumns();
           
        }


		public CustomerProductSizeDetail GetCustomerProductSizeDetail(System.Int32 CustomerProductSize)
		{
			return _iCustomerProductSizeDetailRepository.GetCustomerProductSizeDetail(CustomerProductSize);
		}

		public CustomerProductSizeDetail UpdateCustomerProductSizeDetail(CustomerProductSizeDetail entity)
		{
			return _iCustomerProductSizeDetailRepository.UpdateCustomerProductSizeDetail(entity);
		}

		public bool DeleteCustomerProductSizeDetail(System.Int32 CustomerProductSize)
		{
			return _iCustomerProductSizeDetailRepository.DeleteCustomerProductSizeDetail(CustomerProductSize);
		}

		public List<CustomerProductSizeDetail> GetAllCustomerProductSizeDetail()
		{
			return _iCustomerProductSizeDetailRepository.GetAllCustomerProductSizeDetail();
		}

		public CustomerProductSizeDetail InsertCustomerProductSizeDetail(CustomerProductSizeDetail entity)
		{
			 return _iCustomerProductSizeDetailRepository.InsertCustomerProductSizeDetail(entity);
		}


	}
	
	
}
