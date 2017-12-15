using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IDocumentLibraryRepositoryBase
	{
        
        Dictionary<string, string> GetDocumentLibraryBasicSearchColumns();
        List<SearchColumn> GetDocumentLibrarySearchColumns();
        List<SearchColumn> GetDocumentLibraryAdvanceSearchColumns();
        

		DocumentLibrary GetDocumentLibrary(System.Int32 DocumentId);
		DocumentLibrary UpdateDocumentLibrary(DocumentLibrary entity);
		bool DeleteDocumentLibrary(System.Int32 DocumentId);
		DocumentLibrary DeleteDocumentLibrary(DocumentLibrary entity);
		List<DocumentLibrary> GetAllDocumentLibrary();
		DocumentLibrary InsertDocumentLibrary(DocumentLibrary entity);	}
	
	
}
