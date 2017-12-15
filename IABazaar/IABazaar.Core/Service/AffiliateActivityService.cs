using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class AffiliateActivityService : IAffiliateActivityService 
	{
		private IAffiliateActivityRepository _iAffiliateActivityRepository;
        
		public AffiliateActivityService(IAffiliateActivityRepository iAffiliateActivityRepository)
		{
			this._iAffiliateActivityRepository = iAffiliateActivityRepository;
		}
        
        public Dictionary<string, string> GetAffiliateActivityBasicSearchColumns()
        {
            
            return this._iAffiliateActivityRepository.GetAffiliateActivityBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetAffiliateActivityAdvanceSearchColumns()
        {
            
            return this._iAffiliateActivityRepository.GetAffiliateActivityAdvanceSearchColumns();
           
        }


		public AffiliateActivity GetAffiliateActivity(System.Int32 AffiliateActivityId)
		{
			return _iAffiliateActivityRepository.GetAffiliateActivity(AffiliateActivityId);
		}

		public AffiliateActivity UpdateAffiliateActivity(AffiliateActivity entity)
		{
			return _iAffiliateActivityRepository.UpdateAffiliateActivity(entity);
		}

		public bool DeleteAffiliateActivity(System.Int32 AffiliateActivityId)
		{
			return _iAffiliateActivityRepository.DeleteAffiliateActivity(AffiliateActivityId);
		}

		public List<AffiliateActivity> GetAllAffiliateActivity()
		{
			return _iAffiliateActivityRepository.GetAllAffiliateActivity();
		}

		public AffiliateActivity InsertAffiliateActivity(AffiliateActivity entity)
		{
			 return _iAffiliateActivityRepository.InsertAffiliateActivity(entity);
		}


	}
	
	
}
