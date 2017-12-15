using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IDocumentRepositoryBase
	{
        
        Dictionary<string, string> GetDocumentBasicSearchColumns();
        List<SearchColumn> GetDocumentSearchColumns();
        List<SearchColumn> GetDocumentAdvanceSearchColumns();
        

		Document GetDocument(System.Int32 DocumentId);
		Document UpdateDocument(Document entity);
		bool DeleteDocument(System.Int32 DocumentId);
		Document DeleteDocument(Document entity);
		List<Document> GetAllDocument();
		Document InsertDocument(Document entity);	}
	
	
}
