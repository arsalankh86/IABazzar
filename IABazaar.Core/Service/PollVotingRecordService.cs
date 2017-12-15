using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class PollVotingRecordService : IPollVotingRecordService 
	{
		private IPollVotingRecordRepository _iPollVotingRecordRepository;
        
		public PollVotingRecordService(IPollVotingRecordRepository iPollVotingRecordRepository)
		{
			this._iPollVotingRecordRepository = iPollVotingRecordRepository;
		}
        
        public Dictionary<string, string> GetPollVotingRecordBasicSearchColumns()
        {
            
            return this._iPollVotingRecordRepository.GetPollVotingRecordBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetPollVotingRecordAdvanceSearchColumns()
        {
            
            return this._iPollVotingRecordRepository.GetPollVotingRecordAdvanceSearchColumns();
           
        }


		public PollVotingRecord GetPollVotingRecord(System.Int32 PollVotingRecordId)
		{
			return _iPollVotingRecordRepository.GetPollVotingRecord(PollVotingRecordId);
		}

		public PollVotingRecord UpdatePollVotingRecord(PollVotingRecord entity)
		{
			return _iPollVotingRecordRepository.UpdatePollVotingRecord(entity);
		}

		public bool DeletePollVotingRecord(System.Int32 PollVotingRecordId)
		{
			return _iPollVotingRecordRepository.DeletePollVotingRecord(PollVotingRecordId);
		}

		public List<PollVotingRecord> GetAllPollVotingRecord()
		{
			return _iPollVotingRecordRepository.GetAllPollVotingRecord();
		}

		public PollVotingRecord InsertPollVotingRecord(PollVotingRecord entity)
		{
			 return _iPollVotingRecordRepository.InsertPollVotingRecord(entity);
		}


	}
	
	
}
