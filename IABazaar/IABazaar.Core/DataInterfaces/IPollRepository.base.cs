using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IPollRepositoryBase
	{
        
        Dictionary<string, string> GetPollBasicSearchColumns();
        List<SearchColumn> GetPollSearchColumns();
        List<SearchColumn> GetPollAdvanceSearchColumns();
        

		Poll GetPoll(System.Int32 PollId);
		Poll UpdatePoll(Poll entity);
		bool DeletePoll(System.Int32 PollId);
		Poll DeletePoll(Poll entity);
		List<Poll> GetAllPoll();
		Poll InsertPoll(Poll entity);	}
	
	
}
