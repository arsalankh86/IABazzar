using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ILayoutFieldRepositoryBase
	{
        
        Dictionary<string, string> GetLayoutFieldBasicSearchColumns();
        List<SearchColumn> GetLayoutFieldSearchColumns();
        List<SearchColumn> GetLayoutFieldAdvanceSearchColumns();
        

		LayoutField GetLayoutField(System.Int32 LayoutFieldId);
		LayoutField UpdateLayoutField(LayoutField entity);
		bool DeleteLayoutField(System.Int32 LayoutFieldId);
		LayoutField DeleteLayoutField(LayoutField entity);
		List<LayoutField> GetAllLayoutField();
		LayoutField InsertLayoutField(LayoutField entity);	}
	
	
}
