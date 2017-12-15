using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IDocumentCustomerLevelService
	{
        Dictionary<string, string> GetDocumentCustomerLevelBasicSearchColumns();
        
        List<SearchColumn> GetDocumentCustomerLevelAdvanceSearchColumns();

		DocumentCustomerLevel GetDocumentCustomerLevel(System.Int32 DocumentId);
		DocumentCustomerLevel UpdateDocumentCustomerLevel(DocumentCustomerLevel entity);
		bool DeleteDocumentCustomerLevel(System.Int32 DocumentId);
		List<DocumentCustomerLevel> GetAllDocumentCustomerLevel();
		DocumentCustomerLevel InsertDocumentCustomerLevel(DocumentCustomerLevel entity);

	}
	
	
}
