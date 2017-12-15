using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IDocumentAffiliateService
	{
        Dictionary<string, string> GetDocumentAffiliateBasicSearchColumns();
        
        List<SearchColumn> GetDocumentAffiliateAdvanceSearchColumns();

		DocumentAffiliate GetDocumentAffiliate(System.Int32 DocumentId);
		DocumentAffiliate UpdateDocumentAffiliate(DocumentAffiliate entity);
		bool DeleteDocumentAffiliate(System.Int32 DocumentId);
		List<DocumentAffiliate> GetAllDocumentAffiliate();
		DocumentAffiliate InsertDocumentAffiliate(DocumentAffiliate entity);

	}
	
	
}
