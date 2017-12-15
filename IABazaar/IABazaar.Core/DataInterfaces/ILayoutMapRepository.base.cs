using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ILayoutMapRepositoryBase
	{
        
        Dictionary<string, string> GetLayoutMapBasicSearchColumns();
        List<SearchColumn> GetLayoutMapSearchColumns();
        List<SearchColumn> GetLayoutMapAdvanceSearchColumns();
        

		LayoutMap GetLayoutMap(System.Int32 LayoutMapId);
		LayoutMap UpdateLayoutMap(LayoutMap entity);
		bool DeleteLayoutMap(System.Int32 LayoutMapId);
		LayoutMap DeleteLayoutMap(LayoutMap entity);
		List<LayoutMap> GetAllLayoutMap();
		LayoutMap InsertLayoutMap(LayoutMap entity);	}
	
	
}
