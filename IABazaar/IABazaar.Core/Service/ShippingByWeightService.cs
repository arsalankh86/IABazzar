using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ShippingByWeightService : IShippingByWeightService 
	{
		private IShippingByWeightRepository _iShippingByWeightRepository;
        
		public ShippingByWeightService(IShippingByWeightRepository iShippingByWeightRepository)
		{
			this._iShippingByWeightRepository = iShippingByWeightRepository;
		}
        
        public Dictionary<string, string> GetShippingByWeightBasicSearchColumns()
        {
            
            return this._iShippingByWeightRepository.GetShippingByWeightBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetShippingByWeightAdvanceSearchColumns()
        {
            
            return this._iShippingByWeightRepository.GetShippingByWeightAdvanceSearchColumns();
           
        }


		public List<ShippingByWeight> GetAllShippingByWeight()
		{
			return _iShippingByWeightRepository.GetAllShippingByWeight();
		}

		public ShippingByWeight InsertShippingByWeight(ShippingByWeight entity)
		{
			 return _iShippingByWeightRepository.InsertShippingByWeight(entity);
		}


	}
	
	
}
