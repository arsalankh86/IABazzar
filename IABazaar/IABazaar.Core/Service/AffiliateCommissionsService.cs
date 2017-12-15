using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class AffiliateCommissionsService : IAffiliateCommissionsService 
	{
		private IAffiliateCommissionsRepository _iAffiliateCommissionsRepository;
        
		public AffiliateCommissionsService(IAffiliateCommissionsRepository iAffiliateCommissionsRepository)
		{
			this._iAffiliateCommissionsRepository = iAffiliateCommissionsRepository;
		}
        
        public Dictionary<string, string> GetAffiliateCommissionsBasicSearchColumns()
        {
            
            return this._iAffiliateCommissionsRepository.GetAffiliateCommissionsBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetAffiliateCommissionsAdvanceSearchColumns()
        {
            
            return this._iAffiliateCommissionsRepository.GetAffiliateCommissionsAdvanceSearchColumns();
           
        }


		public List<AffiliateCommissions> GetAllAffiliateCommissions()
		{
			return _iAffiliateCommissionsRepository.GetAllAffiliateCommissions();
		}

		public AffiliateCommissions InsertAffiliateCommissions(AffiliateCommissions entity)
		{
			 return _iAffiliateCommissionsRepository.InsertAffiliateCommissions(entity);
		}


	}
	
	
}
