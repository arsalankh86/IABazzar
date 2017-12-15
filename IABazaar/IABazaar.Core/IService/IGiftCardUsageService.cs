using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IGiftCardUsageService
	{
        Dictionary<string, string> GetGiftCardUsageBasicSearchColumns();
        
        List<SearchColumn> GetGiftCardUsageAdvanceSearchColumns();

		GiftCardUsage GetGiftCardUsage(System.Int32 GiftCardUsageId);
		GiftCardUsage UpdateGiftCardUsage(GiftCardUsage entity);
		bool DeleteGiftCardUsage(System.Int32 GiftCardUsageId);
		List<GiftCardUsage> GetAllGiftCardUsage();
		GiftCardUsage InsertGiftCardUsage(GiftCardUsage entity);

	}
	
	
}
