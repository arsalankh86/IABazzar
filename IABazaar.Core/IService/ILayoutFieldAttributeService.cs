using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ILayoutFieldAttributeService
	{
        Dictionary<string, string> GetLayoutFieldAttributeBasicSearchColumns();
        
        List<SearchColumn> GetLayoutFieldAttributeAdvanceSearchColumns();

		LayoutFieldAttribute GetLayoutFieldAttribute(System.Int32 LayoutFieldAttributeId);
		LayoutFieldAttribute UpdateLayoutFieldAttribute(LayoutFieldAttribute entity);
		bool DeleteLayoutFieldAttribute(System.Int32 LayoutFieldAttributeId);
		List<LayoutFieldAttribute> GetAllLayoutFieldAttribute();
		LayoutFieldAttribute InsertLayoutFieldAttribute(LayoutFieldAttribute entity);

	}
	
	
}
