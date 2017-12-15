using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class CreditCardTypeService : ICreditCardTypeService 
	{
		private ICreditCardTypeRepository _iCreditCardTypeRepository;
        
		public CreditCardTypeService(ICreditCardTypeRepository iCreditCardTypeRepository)
		{
			this._iCreditCardTypeRepository = iCreditCardTypeRepository;
		}
        
        public Dictionary<string, string> GetCreditCardTypeBasicSearchColumns()
        {
            
            return this._iCreditCardTypeRepository.GetCreditCardTypeBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetCreditCardTypeAdvanceSearchColumns()
        {
            
            return this._iCreditCardTypeRepository.GetCreditCardTypeAdvanceSearchColumns();
           
        }


		public CreditCardType GetCreditCardType(System.Int32 CardTypeId)
		{
			return _iCreditCardTypeRepository.GetCreditCardType(CardTypeId);
		}

		public CreditCardType UpdateCreditCardType(CreditCardType entity)
		{
			return _iCreditCardTypeRepository.UpdateCreditCardType(entity);
		}

		public bool DeleteCreditCardType(System.Int32 CardTypeId)
		{
			return _iCreditCardTypeRepository.DeleteCreditCardType(CardTypeId);
		}

		public List<CreditCardType> GetAllCreditCardType()
		{
			return _iCreditCardTypeRepository.GetAllCreditCardType();
		}

		public CreditCardType InsertCreditCardType(CreditCardType entity)
		{
			 return _iCreditCardTypeRepository.InsertCreditCardType(entity);
		}


	}
	
	
}
