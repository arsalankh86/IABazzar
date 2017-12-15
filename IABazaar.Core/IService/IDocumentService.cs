using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IDocumentService
	{
        Dictionary<string, string> GetDocumentBasicSearchColumns();
        
        List<SearchColumn> GetDocumentAdvanceSearchColumns();

		Document GetDocument(System.Int32 DocumentId);
		Document UpdateDocument(Document entity);
		bool DeleteDocument(System.Int32 DocumentId);
		List<Document> GetAllDocument();
		Document InsertDocument(Document entity);

	}
	
	
}
