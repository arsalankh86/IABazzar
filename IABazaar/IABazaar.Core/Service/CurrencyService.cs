using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class CurrencyService : ICurrencyService 
	{
		private ICurrencyRepository _iCurrencyRepository;
        
		public CurrencyService(ICurrencyRepository iCurrencyRepository)
		{
			this._iCurrencyRepository = iCurrencyRepository;
		}
        
        public Dictionary<string, string> GetCurrencyBasicSearchColumns()
        {
            
            return this._iCurrencyRepository.GetCurrencyBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetCurrencyAdvanceSearchColumns()
        {
            
            return this._iCurrencyRepository.GetCurrencyAdvanceSearchColumns();
           
        }


		public Currency GetCurrency(System.Int32 CurrencyId)
		{
			return _iCurrencyRepository.GetCurrency(CurrencyId);
		}

		public Currency UpdateCurrency(Currency entity)
		{
			return _iCurrencyRepository.UpdateCurrency(entity);
		}

		public bool DeleteCurrency(System.Int32 CurrencyId)
		{
			return _iCurrencyRepository.DeleteCurrency(CurrencyId);
		}

		public List<Currency> GetAllCurrency()
		{
			return _iCurrencyRepository.GetAllCurrency();
		}

		public Currency InsertCurrency(Currency entity)
		{
			 return _iCurrencyRepository.InsertCurrency(entity);
		}


	}
	
	
}
