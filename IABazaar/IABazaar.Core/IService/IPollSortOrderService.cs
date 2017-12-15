using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IPollSortOrderService
	{
        Dictionary<string, string> GetPollSortOrderBasicSearchColumns();
        
        List<SearchColumn> GetPollSortOrderAdvanceSearchColumns();

		PollSortOrder GetPollSortOrder(System.Int32 PollSortOrderId);
		PollSortOrder UpdatePollSortOrder(PollSortOrder entity);
		bool DeletePollSortOrder(System.Int32 PollSortOrderId);
		List<PollSortOrder> GetAllPollSortOrder();
		PollSortOrder InsertPollSortOrder(PollSortOrder entity);

	}
	
	
}
