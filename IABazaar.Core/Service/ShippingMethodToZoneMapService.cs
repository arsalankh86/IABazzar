using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ShippingMethodToZoneMapService : IShippingMethodToZoneMapService 
	{
		private IShippingMethodToZoneMapRepository _iShippingMethodToZoneMapRepository;
        
		public ShippingMethodToZoneMapService(IShippingMethodToZoneMapRepository iShippingMethodToZoneMapRepository)
		{
			this._iShippingMethodToZoneMapRepository = iShippingMethodToZoneMapRepository;
		}
        
        public Dictionary<string, string> GetShippingMethodToZoneMapBasicSearchColumns()
        {
            
            return this._iShippingMethodToZoneMapRepository.GetShippingMethodToZoneMapBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetShippingMethodToZoneMapAdvanceSearchColumns()
        {
            
            return this._iShippingMethodToZoneMapRepository.GetShippingMethodToZoneMapAdvanceSearchColumns();
           
        }


		public ShippingMethodToZoneMap GetShippingMethodToZoneMap(System.Int32 ShippingMethodId)
		{
			return _iShippingMethodToZoneMapRepository.GetShippingMethodToZoneMap(ShippingMethodId);
		}

		public ShippingMethodToZoneMap UpdateShippingMethodToZoneMap(ShippingMethodToZoneMap entity)
		{
			return _iShippingMethodToZoneMapRepository.UpdateShippingMethodToZoneMap(entity);
		}

		public bool DeleteShippingMethodToZoneMap(System.Int32 ShippingMethodId)
		{
			return _iShippingMethodToZoneMapRepository.DeleteShippingMethodToZoneMap(ShippingMethodId);
		}

		public List<ShippingMethodToZoneMap> GetAllShippingMethodToZoneMap()
		{
			return _iShippingMethodToZoneMapRepository.GetAllShippingMethodToZoneMap();
		}

		public ShippingMethodToZoneMap InsertShippingMethodToZoneMap(ShippingMethodToZoneMap entity)
		{
			 return _iShippingMethodToZoneMapRepository.InsertShippingMethodToZoneMap(entity);
		}


	}
	
	
}
