using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ShippingMethodToCountryMapService : IShippingMethodToCountryMapService 
	{
		private IShippingMethodToCountryMapRepository _iShippingMethodToCountryMapRepository;
        
		public ShippingMethodToCountryMapService(IShippingMethodToCountryMapRepository iShippingMethodToCountryMapRepository)
		{
			this._iShippingMethodToCountryMapRepository = iShippingMethodToCountryMapRepository;
		}
        
        public Dictionary<string, string> GetShippingMethodToCountryMapBasicSearchColumns()
        {
            
            return this._iShippingMethodToCountryMapRepository.GetShippingMethodToCountryMapBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetShippingMethodToCountryMapAdvanceSearchColumns()
        {
            
            return this._iShippingMethodToCountryMapRepository.GetShippingMethodToCountryMapAdvanceSearchColumns();
           
        }


		public ShippingMethodToCountryMap GetShippingMethodToCountryMap(System.Int32 ShippingMethodId)
		{
			return _iShippingMethodToCountryMapRepository.GetShippingMethodToCountryMap(ShippingMethodId);
		}

		public ShippingMethodToCountryMap UpdateShippingMethodToCountryMap(ShippingMethodToCountryMap entity)
		{
			return _iShippingMethodToCountryMapRepository.UpdateShippingMethodToCountryMap(entity);
		}

		public bool DeleteShippingMethodToCountryMap(System.Int32 ShippingMethodId)
		{
			return _iShippingMethodToCountryMapRepository.DeleteShippingMethodToCountryMap(ShippingMethodId);
		}

		public List<ShippingMethodToCountryMap> GetAllShippingMethodToCountryMap()
		{
			return _iShippingMethodToCountryMapRepository.GetAllShippingMethodToCountryMap();
		}

		public ShippingMethodToCountryMap InsertShippingMethodToCountryMap(ShippingMethodToCountryMap entity)
		{
			 return _iShippingMethodToCountryMapRepository.InsertShippingMethodToCountryMap(entity);
		}


	}
	
	
}
