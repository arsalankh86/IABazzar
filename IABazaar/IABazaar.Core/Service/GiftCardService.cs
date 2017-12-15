using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class GiftCardService : IGiftCardService 
	{
		private IGiftCardRepository _iGiftCardRepository;
        
		public GiftCardService(IGiftCardRepository iGiftCardRepository)
		{
			this._iGiftCardRepository = iGiftCardRepository;
		}
        
        public Dictionary<string, string> GetGiftCardBasicSearchColumns()
        {
            
            return this._iGiftCardRepository.GetGiftCardBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetGiftCardAdvanceSearchColumns()
        {
            
            return this._iGiftCardRepository.GetGiftCardAdvanceSearchColumns();
           
        }


		public GiftCard GetGiftCard(System.Int32 GiftCardId)
		{
			return _iGiftCardRepository.GetGiftCard(GiftCardId);
		}

		public GiftCard UpdateGiftCard(GiftCard entity)
		{
			return _iGiftCardRepository.UpdateGiftCard(entity);
		}

		public bool DeleteGiftCard(System.Int32 GiftCardId)
		{
			return _iGiftCardRepository.DeleteGiftCard(GiftCardId);
		}

		public List<GiftCard> GetAllGiftCard()
		{
			return _iGiftCardRepository.GetAllGiftCard();
		}

		public GiftCard InsertGiftCard(GiftCard entity)
		{
			 return _iGiftCardRepository.InsertGiftCard(entity);
		}


	}
	
	
}
