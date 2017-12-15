using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IDocumentCustomerLevelRepositoryBase
	{
        
        Dictionary<string, string> GetDocumentCustomerLevelBasicSearchColumns();
        List<SearchColumn> GetDocumentCustomerLevelSearchColumns();
        List<SearchColumn> GetDocumentCustomerLevelAdvanceSearchColumns();
        

		DocumentCustomerLevel GetDocumentCustomerLevel(System.Int32 DocumentId);
		DocumentCustomerLevel UpdateDocumentCustomerLevel(DocumentCustomerLevel entity);
		bool DeleteDocumentCustomerLevel(System.Int32 DocumentId);
		DocumentCustomerLevel DeleteDocumentCustomerLevel(DocumentCustomerLevel entity);
		List<DocumentCustomerLevel> GetAllDocumentCustomerLevel();
		DocumentCustomerLevel InsertDocumentCustomerLevel(DocumentCustomerLevel entity);	}
	
	
}
