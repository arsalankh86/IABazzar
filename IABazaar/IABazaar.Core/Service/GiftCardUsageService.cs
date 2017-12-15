using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class GiftCardUsageService : IGiftCardUsageService 
	{
		private IGiftCardUsageRepository _iGiftCardUsageRepository;
        
		public GiftCardUsageService(IGiftCardUsageRepository iGiftCardUsageRepository)
		{
			this._iGiftCardUsageRepository = iGiftCardUsageRepository;
		}
        
        public Dictionary<string, string> GetGiftCardUsageBasicSearchColumns()
        {
            
            return this._iGiftCardUsageRepository.GetGiftCardUsageBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetGiftCardUsageAdvanceSearchColumns()
        {
            
            return this._iGiftCardUsageRepository.GetGiftCardUsageAdvanceSearchColumns();
           
        }


		public GiftCardUsage GetGiftCardUsage(System.Int32 GiftCardUsageId)
		{
			return _iGiftCardUsageRepository.GetGiftCardUsage(GiftCardUsageId);
		}

		public GiftCardUsage UpdateGiftCardUsage(GiftCardUsage entity)
		{
			return _iGiftCardUsageRepository.UpdateGiftCardUsage(entity);
		}

		public bool DeleteGiftCardUsage(System.Int32 GiftCardUsageId)
		{
			return _iGiftCardUsageRepository.DeleteGiftCardUsage(GiftCardUsageId);
		}

		public List<GiftCardUsage> GetAllGiftCardUsage()
		{
			return _iGiftCardUsageRepository.GetAllGiftCardUsage();
		}

		public GiftCardUsage InsertGiftCardUsage(GiftCardUsage entity)
		{
			 return _iGiftCardUsageRepository.InsertGiftCardUsage(entity);
		}


	}
	
	
}
