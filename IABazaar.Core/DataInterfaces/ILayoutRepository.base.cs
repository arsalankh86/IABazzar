using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ILayoutRepositoryBase
	{
        
        Dictionary<string, string> GetLayoutBasicSearchColumns();
        List<SearchColumn> GetLayoutSearchColumns();
        List<SearchColumn> GetLayoutAdvanceSearchColumns();
        

		Layout GetLayout(System.Int32 LayoutId);
		Layout UpdateLayout(Layout entity);
		bool DeleteLayout(System.Int32 LayoutId);
		Layout DeleteLayout(Layout entity);
		List<Layout> GetAllLayout();
		Layout InsertLayout(Layout entity);	}
	
	
}
