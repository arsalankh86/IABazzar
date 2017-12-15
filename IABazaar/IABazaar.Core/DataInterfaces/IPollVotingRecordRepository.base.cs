using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IPollVotingRecordRepositoryBase
	{
        
        Dictionary<string, string> GetPollVotingRecordBasicSearchColumns();
        List<SearchColumn> GetPollVotingRecordSearchColumns();
        List<SearchColumn> GetPollVotingRecordAdvanceSearchColumns();
        

		PollVotingRecord GetPollVotingRecord(System.Int32 PollVotingRecordId);
		PollVotingRecord UpdatePollVotingRecord(PollVotingRecord entity);
		bool DeletePollVotingRecord(System.Int32 PollVotingRecordId);
		PollVotingRecord DeletePollVotingRecord(PollVotingRecord entity);
		List<PollVotingRecord> GetAllPollVotingRecord();
		PollVotingRecord InsertPollVotingRecord(PollVotingRecord entity);	}
	
	
}
