using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IPollSortOrderRepositoryBase
	{
        
        Dictionary<string, string> GetPollSortOrderBasicSearchColumns();
        List<SearchColumn> GetPollSortOrderSearchColumns();
        List<SearchColumn> GetPollSortOrderAdvanceSearchColumns();
        

		PollSortOrder GetPollSortOrder(System.Int32 PollSortOrderId);
		PollSortOrder UpdatePollSortOrder(PollSortOrder entity);
		bool DeletePollSortOrder(System.Int32 PollSortOrderId);
		PollSortOrder DeletePollSortOrder(PollSortOrder entity);
		List<PollSortOrder> GetAllPollSortOrder();
		PollSortOrder InsertPollSortOrder(PollSortOrder entity);	}
	
	
}
