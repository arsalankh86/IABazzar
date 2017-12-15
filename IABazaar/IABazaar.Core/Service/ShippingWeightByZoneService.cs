using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ShippingWeightByZoneService : IShippingWeightByZoneService 
	{
		private IShippingWeightByZoneRepository _iShippingWeightByZoneRepository;
        
		public ShippingWeightByZoneService(IShippingWeightByZoneRepository iShippingWeightByZoneRepository)
		{
			this._iShippingWeightByZoneRepository = iShippingWeightByZoneRepository;
		}
        
        public Dictionary<string, string> GetShippingWeightByZoneBasicSearchColumns()
        {
            
            return this._iShippingWeightByZoneRepository.GetShippingWeightByZoneBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetShippingWeightByZoneAdvanceSearchColumns()
        {
            
            return this._iShippingWeightByZoneRepository.GetShippingWeightByZoneAdvanceSearchColumns();
           
        }


		public List<ShippingWeightByZone> GetAllShippingWeightByZone()
		{
			return _iShippingWeightByZoneRepository.GetAllShippingWeightByZone();
		}

		public ShippingWeightByZone InsertShippingWeightByZone(ShippingWeightByZone entity)
		{
			 return _iShippingWeightByZoneRepository.InsertShippingWeightByZone(entity);
		}


	}
	
	
}
