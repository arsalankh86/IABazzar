using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IDocumentTypeService
	{
        Dictionary<string, string> GetDocumentTypeBasicSearchColumns();
        
        List<SearchColumn> GetDocumentTypeAdvanceSearchColumns();

		DocumentType GetDocumentType(System.Int32 DocumentTypeId);
		DocumentType UpdateDocumentType(DocumentType entity);
		bool DeleteDocumentType(System.Int32 DocumentTypeId);
		List<DocumentType> GetAllDocumentType();
		DocumentType InsertDocumentType(DocumentType entity);

	}
	
	
}
