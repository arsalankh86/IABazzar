using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class TaxClassService : ITaxClassService 
	{
		private ITaxClassRepository _iTaxClassRepository;
        
		public TaxClassService(ITaxClassRepository iTaxClassRepository)
		{
			this._iTaxClassRepository = iTaxClassRepository;
		}
        
        public Dictionary<string, string> GetTaxClassBasicSearchColumns()
        {
            
            return this._iTaxClassRepository.GetTaxClassBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetTaxClassAdvanceSearchColumns()
        {
            
            return this._iTaxClassRepository.GetTaxClassAdvanceSearchColumns();
           
        }


		public TaxClass GetTaxClass(System.Int32 TaxClassId)
		{
			return _iTaxClassRepository.GetTaxClass(TaxClassId);
		}

		public TaxClass UpdateTaxClass(TaxClass entity)
		{
			return _iTaxClassRepository.UpdateTaxClass(entity);
		}

		public bool DeleteTaxClass(System.Int32 TaxClassId)
		{
			return _iTaxClassRepository.DeleteTaxClass(TaxClassId);
		}

		public List<TaxClass> GetAllTaxClass()
		{
			return _iTaxClassRepository.GetAllTaxClass();
		}

		public TaxClass InsertTaxClass(TaxClass entity)
		{
			 return _iTaxClassRepository.InsertTaxClass(entity);
		}


	}
	
	
}
