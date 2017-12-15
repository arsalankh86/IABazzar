using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ShippingZoneService : IShippingZoneService 
	{
		private IShippingZoneRepository _iShippingZoneRepository;
        
		public ShippingZoneService(IShippingZoneRepository iShippingZoneRepository)
		{
			this._iShippingZoneRepository = iShippingZoneRepository;
		}
        
        public Dictionary<string, string> GetShippingZoneBasicSearchColumns()
        {
            
            return this._iShippingZoneRepository.GetShippingZoneBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetShippingZoneAdvanceSearchColumns()
        {
            
            return this._iShippingZoneRepository.GetShippingZoneAdvanceSearchColumns();
           
        }


		public ShippingZone GetShippingZone(System.Int32 ShippingZoneId)
		{
			return _iShippingZoneRepository.GetShippingZone(ShippingZoneId);
		}

		public ShippingZone UpdateShippingZone(ShippingZone entity)
		{
			return _iShippingZoneRepository.UpdateShippingZone(entity);
		}

		public bool DeleteShippingZone(System.Int32 ShippingZoneId)
		{
			return _iShippingZoneRepository.DeleteShippingZone(ShippingZoneId);
		}

		public List<ShippingZone> GetAllShippingZone()
		{
			return _iShippingZoneRepository.GetAllShippingZone();
		}

		public ShippingZone InsertShippingZone(ShippingZone entity)
		{
			 return _iShippingZoneRepository.InsertShippingZone(entity);
		}


	}
	
	
}
