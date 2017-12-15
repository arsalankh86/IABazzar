using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class PollSortOrderService : IPollSortOrderService 
	{
		private IPollSortOrderRepository _iPollSortOrderRepository;
        
		public PollSortOrderService(IPollSortOrderRepository iPollSortOrderRepository)
		{
			this._iPollSortOrderRepository = iPollSortOrderRepository;
		}
        
        public Dictionary<string, string> GetPollSortOrderBasicSearchColumns()
        {
            
            return this._iPollSortOrderRepository.GetPollSortOrderBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetPollSortOrderAdvanceSearchColumns()
        {
            
            return this._iPollSortOrderRepository.GetPollSortOrderAdvanceSearchColumns();
           
        }


		public PollSortOrder GetPollSortOrder(System.Int32 PollSortOrderId)
		{
			return _iPollSortOrderRepository.GetPollSortOrder(PollSortOrderId);
		}

		public PollSortOrder UpdatePollSortOrder(PollSortOrder entity)
		{
			return _iPollSortOrderRepository.UpdatePollSortOrder(entity);
		}

		public bool DeletePollSortOrder(System.Int32 PollSortOrderId)
		{
			return _iPollSortOrderRepository.DeletePollSortOrder(PollSortOrderId);
		}

		public List<PollSortOrder> GetAllPollSortOrder()
		{
			return _iPollSortOrderRepository.GetAllPollSortOrder();
		}

		public PollSortOrder InsertPollSortOrder(PollSortOrder entity)
		{
			 return _iPollSortOrderRepository.InsertPollSortOrder(entity);
		}


	}
	
	
}
