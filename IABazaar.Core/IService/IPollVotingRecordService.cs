using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IPollVotingRecordService
	{
        Dictionary<string, string> GetPollVotingRecordBasicSearchColumns();
        
        List<SearchColumn> GetPollVotingRecordAdvanceSearchColumns();

		PollVotingRecord GetPollVotingRecord(System.Int32 PollVotingRecordId);
		PollVotingRecord UpdatePollVotingRecord(PollVotingRecord entity);
		bool DeletePollVotingRecord(System.Int32 PollVotingRecordId);
		List<PollVotingRecord> GetAllPollVotingRecord();
		PollVotingRecord InsertPollVotingRecord(PollVotingRecord entity);

	}
	
	
}
