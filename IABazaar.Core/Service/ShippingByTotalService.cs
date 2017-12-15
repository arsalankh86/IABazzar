using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ShippingByTotalService : IShippingByTotalService 
	{
		private IShippingByTotalRepository _iShippingByTotalRepository;
        
		public ShippingByTotalService(IShippingByTotalRepository iShippingByTotalRepository)
		{
			this._iShippingByTotalRepository = iShippingByTotalRepository;
		}
        
        public Dictionary<string, string> GetShippingByTotalBasicSearchColumns()
        {
            
            return this._iShippingByTotalRepository.GetShippingByTotalBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetShippingByTotalAdvanceSearchColumns()
        {
            
            return this._iShippingByTotalRepository.GetShippingByTotalAdvanceSearchColumns();
           
        }


		public List<ShippingByTotal> GetAllShippingByTotal()
		{
			return _iShippingByTotalRepository.GetAllShippingByTotal();
		}

		public ShippingByTotal InsertShippingByTotal(ShippingByTotal entity)
		{
			 return _iShippingByTotalRepository.InsertShippingByTotal(entity);
		}


	}
	
	
}
