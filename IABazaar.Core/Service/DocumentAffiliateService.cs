using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class DocumentAffiliateService : IDocumentAffiliateService 
	{
		private IDocumentAffiliateRepository _iDocumentAffiliateRepository;
        
		public DocumentAffiliateService(IDocumentAffiliateRepository iDocumentAffiliateRepository)
		{
			this._iDocumentAffiliateRepository = iDocumentAffiliateRepository;
		}
        
        public Dictionary<string, string> GetDocumentAffiliateBasicSearchColumns()
        {
            
            return this._iDocumentAffiliateRepository.GetDocumentAffiliateBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetDocumentAffiliateAdvanceSearchColumns()
        {
            
            return this._iDocumentAffiliateRepository.GetDocumentAffiliateAdvanceSearchColumns();
           
        }


		public DocumentAffiliate GetDocumentAffiliate(System.Int32 DocumentId)
		{
			return _iDocumentAffiliateRepository.GetDocumentAffiliate(DocumentId);
		}

		public DocumentAffiliate UpdateDocumentAffiliate(DocumentAffiliate entity)
		{
			return _iDocumentAffiliateRepository.UpdateDocumentAffiliate(entity);
		}

		public bool DeleteDocumentAffiliate(System.Int32 DocumentId)
		{
			return _iDocumentAffiliateRepository.DeleteDocumentAffiliate(DocumentId);
		}

		public List<DocumentAffiliate> GetAllDocumentAffiliate()
		{
			return _iDocumentAffiliateRepository.GetAllDocumentAffiliate();
		}

		public DocumentAffiliate InsertDocumentAffiliate(DocumentAffiliate entity)
		{
			 return _iDocumentAffiliateRepository.InsertDocumentAffiliate(entity);
		}


	}
	
	
}
