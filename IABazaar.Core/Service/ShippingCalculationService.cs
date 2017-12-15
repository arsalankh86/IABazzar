using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ShippingCalculationService : IShippingCalculationService 
	{
		private IShippingCalculationRepository _iShippingCalculationRepository;
        
		public ShippingCalculationService(IShippingCalculationRepository iShippingCalculationRepository)
		{
			this._iShippingCalculationRepository = iShippingCalculationRepository;
		}
        
        public Dictionary<string, string> GetShippingCalculationBasicSearchColumns()
        {
            
            return this._iShippingCalculationRepository.GetShippingCalculationBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetShippingCalculationAdvanceSearchColumns()
        {
            
            return this._iShippingCalculationRepository.GetShippingCalculationAdvanceSearchColumns();
           
        }


		public ShippingCalculation GetShippingCalculation(System.Int32 ShippingCalculationId)
		{
			return _iShippingCalculationRepository.GetShippingCalculation(ShippingCalculationId);
		}

		public ShippingCalculation UpdateShippingCalculation(ShippingCalculation entity)
		{
			return _iShippingCalculationRepository.UpdateShippingCalculation(entity);
		}

		public bool DeleteShippingCalculation(System.Int32 ShippingCalculationId)
		{
			return _iShippingCalculationRepository.DeleteShippingCalculation(ShippingCalculationId);
		}

		public List<ShippingCalculation> GetAllShippingCalculation()
		{
			return _iShippingCalculationRepository.GetAllShippingCalculation();
		}

		public ShippingCalculation InsertShippingCalculation(ShippingCalculation entity)
		{
			 return _iShippingCalculationRepository.InsertShippingCalculation(entity);
		}


	}
	
	
}
