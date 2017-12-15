using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class CountryTaxRateService : ICountryTaxRateService 
	{
		private ICountryTaxRateRepository _iCountryTaxRateRepository;
        
		public CountryTaxRateService(ICountryTaxRateRepository iCountryTaxRateRepository)
		{
			this._iCountryTaxRateRepository = iCountryTaxRateRepository;
		}
        
        public Dictionary<string, string> GetCountryTaxRateBasicSearchColumns()
        {
            
            return this._iCountryTaxRateRepository.GetCountryTaxRateBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetCountryTaxRateAdvanceSearchColumns()
        {
            
            return this._iCountryTaxRateRepository.GetCountryTaxRateAdvanceSearchColumns();
           
        }


		public CountryTaxRate GetCountryTaxRate(System.Int32 CountryTaxId)
		{
			return _iCountryTaxRateRepository.GetCountryTaxRate(CountryTaxId);
		}

		public CountryTaxRate UpdateCountryTaxRate(CountryTaxRate entity)
		{
			return _iCountryTaxRateRepository.UpdateCountryTaxRate(entity);
		}

		public bool DeleteCountryTaxRate(System.Int32 CountryTaxId)
		{
			return _iCountryTaxRateRepository.DeleteCountryTaxRate(CountryTaxId);
		}

		public List<CountryTaxRate> GetAllCountryTaxRate()
		{
			return _iCountryTaxRateRepository.GetAllCountryTaxRate();
		}

		public CountryTaxRate InsertCountryTaxRate(CountryTaxRate entity)
		{
			 return _iCountryTaxRateRepository.InsertCountryTaxRate(entity);
		}


	}
	
	
}
