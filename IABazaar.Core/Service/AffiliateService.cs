using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class AffiliateService : IAffiliateService 
	{
		private IAffiliateRepository _iAffiliateRepository;
        
		public AffiliateService(IAffiliateRepository iAffiliateRepository)
		{
			this._iAffiliateRepository = iAffiliateRepository;
		}
        
        public Dictionary<string, string> GetAffiliateBasicSearchColumns()
        {
            
            return this._iAffiliateRepository.GetAffiliateBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetAffiliateAdvanceSearchColumns()
        {
            
            return this._iAffiliateRepository.GetAffiliateAdvanceSearchColumns();
           
        }


		public Affiliate GetAffiliate(System.Int32 AffiliateId)
		{
			return _iAffiliateRepository.GetAffiliate(AffiliateId);
		}

		public Affiliate UpdateAffiliate(Affiliate entity)
		{
			return _iAffiliateRepository.UpdateAffiliate(entity);
		}

		public bool DeleteAffiliate(System.Int32 AffiliateId)
		{
			return _iAffiliateRepository.DeleteAffiliate(AffiliateId);
		}

		public List<Affiliate> GetAllAffiliate()
		{
			return _iAffiliateRepository.GetAllAffiliate();
		}

		public Affiliate InsertAffiliate(Affiliate entity)
		{
			 return _iAffiliateRepository.InsertAffiliate(entity);
		}


	}
	
	
}
