using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class AffiliateStoreService : IAffiliateStoreService 
	{
		private IAffiliateStoreRepository _iAffiliateStoreRepository;
        
		public AffiliateStoreService(IAffiliateStoreRepository iAffiliateStoreRepository)
		{
			this._iAffiliateStoreRepository = iAffiliateStoreRepository;
		}
        
        public Dictionary<string, string> GetAffiliateStoreBasicSearchColumns()
        {
            
            return this._iAffiliateStoreRepository.GetAffiliateStoreBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetAffiliateStoreAdvanceSearchColumns()
        {
            
            return this._iAffiliateStoreRepository.GetAffiliateStoreAdvanceSearchColumns();
           
        }


		public AffiliateStore GetAffiliateStore(System.Int32 AffiliateId)
		{
			return _iAffiliateStoreRepository.GetAffiliateStore(AffiliateId);
		}

		public AffiliateStore UpdateAffiliateStore(AffiliateStore entity)
		{
			return _iAffiliateStoreRepository.UpdateAffiliateStore(entity);
		}

		public bool DeleteAffiliateStore(System.Int32 AffiliateId)
		{
			return _iAffiliateStoreRepository.DeleteAffiliateStore(AffiliateId);
		}

		public List<AffiliateStore> GetAllAffiliateStore()
		{
			return _iAffiliateStoreRepository.GetAllAffiliateStore();
		}

		public AffiliateStore InsertAffiliateStore(AffiliateStore entity)
		{
			 return _iAffiliateStoreRepository.InsertAffiliateStore(entity);
		}


	}
	
	
}
