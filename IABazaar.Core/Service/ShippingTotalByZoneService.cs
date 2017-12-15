using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ShippingTotalByZoneService : IShippingTotalByZoneService 
	{
		private IShippingTotalByZoneRepository _iShippingTotalByZoneRepository;
        
		public ShippingTotalByZoneService(IShippingTotalByZoneRepository iShippingTotalByZoneRepository)
		{
			this._iShippingTotalByZoneRepository = iShippingTotalByZoneRepository;
		}
        
        public Dictionary<string, string> GetShippingTotalByZoneBasicSearchColumns()
        {
            
            return this._iShippingTotalByZoneRepository.GetShippingTotalByZoneBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetShippingTotalByZoneAdvanceSearchColumns()
        {
            
            return this._iShippingTotalByZoneRepository.GetShippingTotalByZoneAdvanceSearchColumns();
           
        }


		public List<ShippingTotalByZone> GetAllShippingTotalByZone()
		{
			return _iShippingTotalByZoneRepository.GetAllShippingTotalByZone();
		}

		public ShippingTotalByZone InsertShippingTotalByZone(ShippingTotalByZone entity)
		{
			 return _iShippingTotalByZoneRepository.InsertShippingTotalByZone(entity);
		}


	}
	
	
}
