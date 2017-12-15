using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class LibraryService : ILibraryService 
	{
		private ILibraryRepository _iLibraryRepository;
        
		public LibraryService(ILibraryRepository iLibraryRepository)
		{
			this._iLibraryRepository = iLibraryRepository;
		}
        
        public Dictionary<string, string> GetLibraryBasicSearchColumns()
        {
            
            return this._iLibraryRepository.GetLibraryBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetLibraryAdvanceSearchColumns()
        {
            
            return this._iLibraryRepository.GetLibraryAdvanceSearchColumns();
           
        }


		public Library GetLibrary(System.Int32 LibraryId)
		{
			return _iLibraryRepository.GetLibrary(LibraryId);
		}

		public Library UpdateLibrary(Library entity)
		{
			return _iLibraryRepository.UpdateLibrary(entity);
		}

		public bool DeleteLibrary(System.Int32 LibraryId)
		{
			return _iLibraryRepository.DeleteLibrary(LibraryId);
		}

		public List<Library> GetAllLibrary()
		{
			return _iLibraryRepository.GetAllLibrary();
		}

		public Library InsertLibrary(Library entity)
		{
			 return _iLibraryRepository.InsertLibrary(entity);
		}


	}
	
	
}
