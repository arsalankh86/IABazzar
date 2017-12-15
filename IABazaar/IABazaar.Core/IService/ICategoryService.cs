using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ICategoryService
	{
        Dictionary<string, string> GetCategoryBasicSearchColumns();
        
        List<SearchColumn> GetCategoryAdvanceSearchColumns();

		Category GetCategory(System.Int32 CategoryId);
		Category UpdateCategory(Category entity);
		bool DeleteCategory(System.Int32 CategoryId);
		List<Category> GetAllCategory();
		Category InsertCategory(Category entity);

	}
	
	
}
