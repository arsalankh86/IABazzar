using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ShippingMethodToStateMapService : IShippingMethodToStateMapService 
	{
		private IShippingMethodToStateMapRepository _iShippingMethodToStateMapRepository;
        
		public ShippingMethodToStateMapService(IShippingMethodToStateMapRepository iShippingMethodToStateMapRepository)
		{
			this._iShippingMethodToStateMapRepository = iShippingMethodToStateMapRepository;
		}
        
        public Dictionary<string, string> GetShippingMethodToStateMapBasicSearchColumns()
        {
            
            return this._iShippingMethodToStateMapRepository.GetShippingMethodToStateMapBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetShippingMethodToStateMapAdvanceSearchColumns()
        {
            
            return this._iShippingMethodToStateMapRepository.GetShippingMethodToStateMapAdvanceSearchColumns();
           
        }


		public ShippingMethodToStateMap GetShippingMethodToStateMap(System.Int32 ShippingMethodId)
		{
			return _iShippingMethodToStateMapRepository.GetShippingMethodToStateMap(ShippingMethodId);
		}

		public ShippingMethodToStateMap UpdateShippingMethodToStateMap(ShippingMethodToStateMap entity)
		{
			return _iShippingMethodToStateMapRepository.UpdateShippingMethodToStateMap(entity);
		}

		public bool DeleteShippingMethodToStateMap(System.Int32 ShippingMethodId)
		{
			return _iShippingMethodToStateMapRepository.DeleteShippingMethodToStateMap(ShippingMethodId);
		}

		public List<ShippingMethodToStateMap> GetAllShippingMethodToStateMap()
		{
			return _iShippingMethodToStateMapRepository.GetAllShippingMethodToStateMap();
		}

		public ShippingMethodToStateMap InsertShippingMethodToStateMap(ShippingMethodToStateMap entity)
		{
			 return _iShippingMethodToStateMapRepository.InsertShippingMethodToStateMap(entity);
		}


	}
	
	
}
