using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IGiftCardRepositoryBase
	{
        
        Dictionary<string, string> GetGiftCardBasicSearchColumns();
        List<SearchColumn> GetGiftCardSearchColumns();
        List<SearchColumn> GetGiftCardAdvanceSearchColumns();
        

		GiftCard GetGiftCard(System.Int32 GiftCardId);
		GiftCard UpdateGiftCard(GiftCard entity);
		bool DeleteGiftCard(System.Int32 GiftCardId);
		GiftCard DeleteGiftCard(GiftCard entity);
		List<GiftCard> GetAllGiftCard();
		GiftCard InsertGiftCard(GiftCard entity);	}
	
	
}
