using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class QuantityDiscountService : IQuantityDiscountService 
	{
		private IQuantityDiscountRepository _iQuantityDiscountRepository;
        
		public QuantityDiscountService(IQuantityDiscountRepository iQuantityDiscountRepository)
		{
			this._iQuantityDiscountRepository = iQuantityDiscountRepository;
		}
        
        public Dictionary<string, string> GetQuantityDiscountBasicSearchColumns()
        {
            
            return this._iQuantityDiscountRepository.GetQuantityDiscountBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetQuantityDiscountAdvanceSearchColumns()
        {
            
            return this._iQuantityDiscountRepository.GetQuantityDiscountAdvanceSearchColumns();
           
        }


		public QuantityDiscount GetQuantityDiscount(System.Int32 QuantityDiscountId)
		{
			return _iQuantityDiscountRepository.GetQuantityDiscount(QuantityDiscountId);
		}

		public QuantityDiscount UpdateQuantityDiscount(QuantityDiscount entity)
		{
			return _iQuantityDiscountRepository.UpdateQuantityDiscount(entity);
		}

		public bool DeleteQuantityDiscount(System.Int32 QuantityDiscountId)
		{
			return _iQuantityDiscountRepository.DeleteQuantityDiscount(QuantityDiscountId);
		}

		public List<QuantityDiscount> GetAllQuantityDiscount()
		{
			return _iQuantityDiscountRepository.GetAllQuantityDiscount();
		}

		public QuantityDiscount InsertQuantityDiscount(QuantityDiscount entity)
		{
			 return _iQuantityDiscountRepository.InsertQuantityDiscount(entity);
		}


	}
	
	
}
