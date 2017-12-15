using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class AffiliateActivityReasonService : IAffiliateActivityReasonService 
	{
		private IAffiliateActivityReasonRepository _iAffiliateActivityReasonRepository;
        
		public AffiliateActivityReasonService(IAffiliateActivityReasonRepository iAffiliateActivityReasonRepository)
		{
			this._iAffiliateActivityReasonRepository = iAffiliateActivityReasonRepository;
		}
        
        public Dictionary<string, string> GetAffiliateActivityReasonBasicSearchColumns()
        {
            
            return this._iAffiliateActivityReasonRepository.GetAffiliateActivityReasonBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetAffiliateActivityReasonAdvanceSearchColumns()
        {
            
            return this._iAffiliateActivityReasonRepository.GetAffiliateActivityReasonAdvanceSearchColumns();
           
        }


		public AffiliateActivityReason GetAffiliateActivityReason(System.Int32 AffiliateActivityReasonId)
		{
			return _iAffiliateActivityReasonRepository.GetAffiliateActivityReason(AffiliateActivityReasonId);
		}

		public AffiliateActivityReason UpdateAffiliateActivityReason(AffiliateActivityReason entity)
		{
			return _iAffiliateActivityReasonRepository.UpdateAffiliateActivityReason(entity);
		}

		public bool DeleteAffiliateActivityReason(System.Int32 AffiliateActivityReasonId)
		{
			return _iAffiliateActivityReasonRepository.DeleteAffiliateActivityReason(AffiliateActivityReasonId);
		}

		public List<AffiliateActivityReason> GetAllAffiliateActivityReason()
		{
			return _iAffiliateActivityReasonRepository.GetAllAffiliateActivityReason();
		}

		public AffiliateActivityReason InsertAffiliateActivityReason(AffiliateActivityReason entity)
		{
			 return _iAffiliateActivityReasonRepository.InsertAffiliateActivityReason(entity);
		}


	}
	
	
}
