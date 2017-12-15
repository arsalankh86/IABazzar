using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ILayoutFieldService
	{
        Dictionary<string, string> GetLayoutFieldBasicSearchColumns();
        
        List<SearchColumn> GetLayoutFieldAdvanceSearchColumns();

		LayoutField GetLayoutField(System.Int32 LayoutFieldId);
		LayoutField UpdateLayoutField(LayoutField entity);
		bool DeleteLayoutField(System.Int32 LayoutFieldId);
		List<LayoutField> GetAllLayoutField();
		LayoutField InsertLayoutField(LayoutField entity);

	}
	
	
}
