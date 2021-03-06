﻿using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IPageTypeRepositoryBase
	{
        
        Dictionary<string, string> GetPageTypeBasicSearchColumns();
        List<SearchColumn> GetPageTypeSearchColumns();
        List<SearchColumn> GetPageTypeAdvanceSearchColumns();
        

		PageType GetPageType(System.Int32 PageTypeId);
		PageType UpdatePageType(PageType entity);
		bool DeletePageType(System.Int32 PageTypeId);
		PageType DeletePageType(PageType entity);
		List<PageType> GetAllPageType();
		PageType InsertPageType(PageType entity);	}
	
	
}
