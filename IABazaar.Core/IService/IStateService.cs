using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IStateService
	{
        Dictionary<string, string> GetStateBasicSearchColumns();
        
        List<SearchColumn> GetStateAdvanceSearchColumns();

		State GetState(System.Int32 StateId);
		State UpdateState(State entity);
		bool DeleteState(System.Int32 StateId);
		List<State> GetAllState();
		State InsertState(State entity);

	}
	
	
}
