using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ISearchLogService
	{
        Dictionary<string, string> GetSearchLogBasicSearchColumns();
        
        List<SearchColumn> GetSearchLogAdvanceSearchColumns();

		List<SearchLog> GetAllSearchLog();
		SearchLog InsertSearchLog(SearchLog entity);

	}
	
	
}
