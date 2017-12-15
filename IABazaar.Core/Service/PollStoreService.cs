using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class PollStoreService : IPollStoreService 
	{
		private IPollStoreRepository _iPollStoreRepository;
        
		public PollStoreService(IPollStoreRepository iPollStoreRepository)
		{
			this._iPollStoreRepository = iPollStoreRepository;
		}
        
        public Dictionary<string, string> GetPollStoreBasicSearchColumns()
        {
            
            return this._iPollStoreRepository.GetPollStoreBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetPollStoreAdvanceSearchColumns()
        {
            
            return this._iPollStoreRepository.GetPollStoreAdvanceSearchColumns();
           
        }


		public PollStore GetPollStore(System.Int32 PollId)
		{
			return _iPollStoreRepository.GetPollStore(PollId);
		}

		public PollStore UpdatePollStore(PollStore entity)
		{
			return _iPollStoreRepository.UpdatePollStore(entity);
		}

		public bool DeletePollStore(System.Int32 PollId)
		{
			return _iPollStoreRepository.DeletePollStore(PollId);
		}

		public List<PollStore> GetAllPollStore()
		{
			return _iPollStoreRepository.GetAllPollStore();
		}

		public PollStore InsertPollStore(PollStore entity)
		{
			 return _iPollStoreRepository.InsertPollStore(entity);
		}


	}
	
	
}
