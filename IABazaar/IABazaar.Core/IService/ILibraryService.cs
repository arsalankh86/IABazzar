using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ILibraryService
	{
        Dictionary<string, string> GetLibraryBasicSearchColumns();
        
        List<SearchColumn> GetLibraryAdvanceSearchColumns();

		Library GetLibrary(System.Int32 LibraryId);
		Library UpdateLibrary(Library entity);
		bool DeleteLibrary(System.Int32 LibraryId);
		List<Library> GetAllLibrary();
		Library InsertLibrary(Library entity);

	}
	
	
}
