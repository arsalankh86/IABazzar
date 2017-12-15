using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ISearchLogRepositoryBase
	{
        
        Dictionary<string, string> GetSearchLogBasicSearchColumns();
        List<SearchColumn> GetSearchLogSearchColumns();
        List<SearchColumn> GetSearchLogAdvanceSearchColumns();
        

		List<SearchLog> GetAllSearchLog();
		SearchLog InsertSearchLog(SearchLog entity);	}
	
	
}
