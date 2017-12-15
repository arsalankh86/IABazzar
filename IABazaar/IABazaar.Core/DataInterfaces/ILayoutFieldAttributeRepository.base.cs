using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ILayoutFieldAttributeRepositoryBase
	{
        
        Dictionary<string, string> GetLayoutFieldAttributeBasicSearchColumns();
        List<SearchColumn> GetLayoutFieldAttributeSearchColumns();
        List<SearchColumn> GetLayoutFieldAttributeAdvanceSearchColumns();
        

		LayoutFieldAttribute GetLayoutFieldAttribute(System.Int32 LayoutFieldAttributeId);
		LayoutFieldAttribute UpdateLayoutFieldAttribute(LayoutFieldAttribute entity);
		bool DeleteLayoutFieldAttribute(System.Int32 LayoutFieldAttributeId);
		LayoutFieldAttribute DeleteLayoutFieldAttribute(LayoutFieldAttribute entity);
		List<LayoutFieldAttribute> GetAllLayoutFieldAttribute();
		LayoutFieldAttribute InsertLayoutFieldAttribute(LayoutFieldAttribute entity);	}
	
	
}
