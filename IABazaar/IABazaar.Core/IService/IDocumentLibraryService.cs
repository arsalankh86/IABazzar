using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IDocumentLibraryService
	{
        Dictionary<string, string> GetDocumentLibraryBasicSearchColumns();
        
        List<SearchColumn> GetDocumentLibraryAdvanceSearchColumns();

		DocumentLibrary GetDocumentLibrary(System.Int32 DocumentId);
		DocumentLibrary UpdateDocumentLibrary(DocumentLibrary entity);
		bool DeleteDocumentLibrary(System.Int32 DocumentId);
		List<DocumentLibrary> GetAllDocumentLibrary();
		DocumentLibrary InsertDocumentLibrary(DocumentLibrary entity);

	}
	
	
}
