using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class StateService : IStateService 
	{
		private IStateRepository _iStateRepository;
        
		public StateService(IStateRepository iStateRepository)
		{
			this._iStateRepository = iStateRepository;
		}
        
        public Dictionary<string, string> GetStateBasicSearchColumns()
        {
            
            return this._iStateRepository.GetStateBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetStateAdvanceSearchColumns()
        {
            
            return this._iStateRepository.GetStateAdvanceSearchColumns();
           
        }


		public State GetState(System.Int32 StateId)
		{
			return _iStateRepository.GetState(StateId);
		}

		public State UpdateState(State entity)
		{
			return _iStateRepository.UpdateState(entity);
		}

		public bool DeleteState(System.Int32 StateId)
		{
			return _iStateRepository.DeleteState(StateId);
		}

		public List<State> GetAllState()
		{
			return _iStateRepository.GetAllState();
		}

		public State InsertState(State entity)
		{
			 return _iStateRepository.InsertState(entity);
		}


	}
	
	
}
