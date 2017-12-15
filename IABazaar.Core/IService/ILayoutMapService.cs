using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ILayoutMapService
	{
        Dictionary<string, string> GetLayoutMapBasicSearchColumns();
        
        List<SearchColumn> GetLayoutMapAdvanceSearchColumns();

		LayoutMap GetLayoutMap(System.Int32 LayoutMapId);
		LayoutMap UpdateLayoutMap(LayoutMap entity);
		bool DeleteLayoutMap(System.Int32 LayoutMapId);
		List<LayoutMap> GetAllLayoutMap();
		LayoutMap InsertLayoutMap(LayoutMap entity);

	}
	
	
}
