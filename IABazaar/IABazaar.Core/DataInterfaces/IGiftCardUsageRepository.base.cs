using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IGiftCardUsageRepositoryBase
	{
        
        Dictionary<string, string> GetGiftCardUsageBasicSearchColumns();
        List<SearchColumn> GetGiftCardUsageSearchColumns();
        List<SearchColumn> GetGiftCardUsageAdvanceSearchColumns();
        

		GiftCardUsage GetGiftCardUsage(System.Int32 GiftCardUsageId);
		GiftCardUsage UpdateGiftCardUsage(GiftCardUsage entity);
		bool DeleteGiftCardUsage(System.Int32 GiftCardUsageId);
		GiftCardUsage DeleteGiftCardUsage(GiftCardUsage entity);
		List<GiftCardUsage> GetAllGiftCardUsage();
		GiftCardUsage InsertGiftCardUsage(GiftCardUsage entity);	}
	
	
}
