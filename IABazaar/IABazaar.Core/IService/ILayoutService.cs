using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ILayoutService
	{
        Dictionary<string, string> GetLayoutBasicSearchColumns();
        
        List<SearchColumn> GetLayoutAdvanceSearchColumns();

		Layout GetLayout(System.Int32 LayoutId);
		Layout UpdateLayout(Layout entity);
		bool DeleteLayout(System.Int32 LayoutId);
		List<Layout> GetAllLayout();
		Layout InsertLayout(Layout entity);

	}
	
	
}
