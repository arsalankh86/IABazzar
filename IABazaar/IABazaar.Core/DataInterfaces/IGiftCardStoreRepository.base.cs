using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IGiftCardStoreRepositoryBase
	{
        
        Dictionary<string, string> GetGiftCardStoreBasicSearchColumns();
        List<SearchColumn> GetGiftCardStoreSearchColumns();
        List<SearchColumn> GetGiftCardStoreAdvanceSearchColumns();
        

		GiftCardStore GetGiftCardStore(System.Int32 GiftCardId);
		GiftCardStore UpdateGiftCardStore(GiftCardStore entity);
		bool DeleteGiftCardStore(System.Int32 GiftCardId);
		GiftCardStore DeleteGiftCardStore(GiftCardStore entity);
		List<GiftCardStore> GetAllGiftCardStore();
		GiftCardStore InsertGiftCardStore(GiftCardStore entity);	}
	
	
}
