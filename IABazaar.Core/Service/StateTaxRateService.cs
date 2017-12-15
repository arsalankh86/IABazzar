using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class StateTaxRateService : IStateTaxRateService 
	{
		private IStateTaxRateRepository _iStateTaxRateRepository;
        
		public StateTaxRateService(IStateTaxRateRepository iStateTaxRateRepository)
		{
			this._iStateTaxRateRepository = iStateTaxRateRepository;
		}
        
        public Dictionary<string, string> GetStateTaxRateBasicSearchColumns()
        {
            
            return this._iStateTaxRateRepository.GetStateTaxRateBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetStateTaxRateAdvanceSearchColumns()
        {
            
            return this._iStateTaxRateRepository.GetStateTaxRateAdvanceSearchColumns();
           
        }


		public StateTaxRate GetStateTaxRate(System.Int32 StateTaxId)
		{
			return _iStateTaxRateRepository.GetStateTaxRate(StateTaxId);
		}

		public StateTaxRate UpdateStateTaxRate(StateTaxRate entity)
		{
			return _iStateTaxRateRepository.UpdateStateTaxRate(entity);
		}

		public bool DeleteStateTaxRate(System.Int32 StateTaxId)
		{
			return _iStateTaxRateRepository.DeleteStateTaxRate(StateTaxId);
		}

		public List<StateTaxRate> GetAllStateTaxRate()
		{
			return _iStateTaxRateRepository.GetAllStateTaxRate();
		}

		public StateTaxRate InsertStateTaxRate(StateTaxRate entity)
		{
			 return _iStateTaxRateRepository.InsertStateTaxRate(entity);
		}


	}
	
	
}
