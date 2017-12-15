using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IDocumentTypeRepositoryBase
	{
        
        Dictionary<string, string> GetDocumentTypeBasicSearchColumns();
        List<SearchColumn> GetDocumentTypeSearchColumns();
        List<SearchColumn> GetDocumentTypeAdvanceSearchColumns();
        

		DocumentType GetDocumentType(System.Int32 DocumentTypeId);
		DocumentType UpdateDocumentType(DocumentType entity);
		bool DeleteDocumentType(System.Int32 DocumentTypeId);
		DocumentType DeleteDocumentType(DocumentType entity);
		List<DocumentType> GetAllDocumentType();
		DocumentType InsertDocumentType(DocumentType entity);	}
	
	
}
