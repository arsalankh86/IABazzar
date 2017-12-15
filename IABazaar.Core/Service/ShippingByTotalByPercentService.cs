using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ShippingByTotalByPercentService : IShippingByTotalByPercentService 
	{
		private IShippingByTotalByPercentRepository _iShippingByTotalByPercentRepository;
        
		public ShippingByTotalByPercentService(IShippingByTotalByPercentRepository iShippingByTotalByPercentRepository)
		{
			this._iShippingByTotalByPercentRepository = iShippingByTotalByPercentRepository;
		}
        
        public Dictionary<string, string> GetShippingByTotalByPercentBasicSearchColumns()
        {
            
            return this._iShippingByTotalByPercentRepository.GetShippingByTotalByPercentBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetShippingByTotalByPercentAdvanceSearchColumns()
        {
            
            return this._iShippingByTotalByPercentRepository.GetShippingByTotalByPercentAdvanceSearchColumns();
           
        }


		public List<ShippingByTotalByPercent> GetAllShippingByTotalByPercent()
		{
			return _iShippingByTotalByPercentRepository.GetAllShippingByTotalByPercent();
		}

		public ShippingByTotalByPercent InsertShippingByTotalByPercent(ShippingByTotalByPercent entity)
		{
			 return _iShippingByTotalByPercentRepository.InsertShippingByTotalByPercent(entity);
		}


	}
	
	
}
