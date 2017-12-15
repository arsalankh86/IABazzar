using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IPollStoreService
	{
        Dictionary<string, string> GetPollStoreBasicSearchColumns();
        
        List<SearchColumn> GetPollStoreAdvanceSearchColumns();

		PollStore GetPollStore(System.Int32 PollId);
		PollStore UpdatePollStore(PollStore entity);
		bool DeletePollStore(System.Int32 PollId);
		List<PollStore> GetAllPollStore();
		PollStore InsertPollStore(PollStore entity);

	}
	
	
}
