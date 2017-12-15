using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class GiftCardStoreService : IGiftCardStoreService 
	{
		private IGiftCardStoreRepository _iGiftCardStoreRepository;
        
		public GiftCardStoreService(IGiftCardStoreRepository iGiftCardStoreRepository)
		{
			this._iGiftCardStoreRepository = iGiftCardStoreRepository;
		}
        
        public Dictionary<string, string> GetGiftCardStoreBasicSearchColumns()
        {
            
            return this._iGiftCardStoreRepository.GetGiftCardStoreBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetGiftCardStoreAdvanceSearchColumns()
        {
            
            return this._iGiftCardStoreRepository.GetGiftCardStoreAdvanceSearchColumns();
           
        }


		public GiftCardStore GetGiftCardStore(System.Int32 GiftCardId)
		{
			return _iGiftCardStoreRepository.GetGiftCardStore(GiftCardId);
		}

		public GiftCardStore UpdateGiftCardStore(GiftCardStore entity)
		{
			return _iGiftCardStoreRepository.UpdateGiftCardStore(entity);
		}

		public bool DeleteGiftCardStore(System.Int32 GiftCardId)
		{
			return _iGiftCardStoreRepository.DeleteGiftCardStore(GiftCardId);
		}

		public List<GiftCardStore> GetAllGiftCardStore()
		{
			return _iGiftCardStoreRepository.GetAllGiftCardStore();
		}

		public GiftCardStore InsertGiftCardStore(GiftCardStore entity)
		{
			 return _iGiftCardStoreRepository.InsertGiftCardStore(entity);
		}


	}
	
	
}
