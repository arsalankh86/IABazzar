using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IGiftCardStoreService
	{
        Dictionary<string, string> GetGiftCardStoreBasicSearchColumns();
        
        List<SearchColumn> GetGiftCardStoreAdvanceSearchColumns();

		GiftCardStore GetGiftCardStore(System.Int32 GiftCardId);
		GiftCardStore UpdateGiftCardStore(GiftCardStore entity);
		bool DeleteGiftCardStore(System.Int32 GiftCardId);
		List<GiftCardStore> GetAllGiftCardStore();
		GiftCardStore InsertGiftCardStore(GiftCardStore entity);

	}
	
	
}
