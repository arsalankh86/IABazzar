using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class CountryService : ICountryService 
	{
		private ICountryRepository _iCountryRepository;
        
		public CountryService(ICountryRepository iCountryRepository)
		{
			this._iCountryRepository = iCountryRepository;
		}
        
        public Dictionary<string, string> GetCountryBasicSearchColumns()
        {
            
            return this._iCountryRepository.GetCountryBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetCountryAdvanceSearchColumns()
        {
            
            return this._iCountryRepository.GetCountryAdvanceSearchColumns();
           
        }


		public Country GetCountry(System.Int32 CountryId)
		{
			return _iCountryRepository.GetCountry(CountryId);
		}

		public Country UpdateCountry(Country entity)
		{
			return _iCountryRepository.UpdateCountry(entity);
		}

		public bool DeleteCountry(System.Int32 CountryId)
		{
			return _iCountryRepository.DeleteCountry(CountryId);
		}

		public List<Country> GetAllCountry()
		{
			return _iCountryRepository.GetAllCountry();
		}

		public Country InsertCountry(Country entity)
		{
			 return _iCountryRepository.InsertCountry(entity);
		}


	}
	
	
}
