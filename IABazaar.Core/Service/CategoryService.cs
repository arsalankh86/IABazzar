using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class CategoryService : ICategoryService 
	{
		private ICategoryRepository _iCategoryRepository;
        
		public CategoryService(ICategoryRepository iCategoryRepository)
		{
			this._iCategoryRepository = iCategoryRepository;
		}
        
        public Dictionary<string, string> GetCategoryBasicSearchColumns()
        {
            
            return this._iCategoryRepository.GetCategoryBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetCategoryAdvanceSearchColumns()
        {
            
            return this._iCategoryRepository.GetCategoryAdvanceSearchColumns();
           
        }


		public Category GetCategory(System.Int32 CategoryId)
		{
			return _iCategoryRepository.GetCategory(CategoryId);
		}

		public Category UpdateCategory(Category entity)
		{
			return _iCategoryRepository.UpdateCategory(entity);
		}

		public bool DeleteCategory(System.Int32 CategoryId)
		{
			return _iCategoryRepository.DeleteCategory(CategoryId);
		}

		public List<Category> GetAllCategory()
		{
			return _iCategoryRepository.GetAllCategory();
		}

		public Category InsertCategory(Category entity)
		{
			 return _iCategoryRepository.InsertCategory(entity);
		}


	}
	
	
}
