using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class DocumentCustomerLevelService : IDocumentCustomerLevelService 
	{
		private IDocumentCustomerLevelRepository _iDocumentCustomerLevelRepository;
        
		public DocumentCustomerLevelService(IDocumentCustomerLevelRepository iDocumentCustomerLevelRepository)
		{
			this._iDocumentCustomerLevelRepository = iDocumentCustomerLevelRepository;
		}
        
        public Dictionary<string, string> GetDocumentCustomerLevelBasicSearchColumns()
        {
            
            return this._iDocumentCustomerLevelRepository.GetDocumentCustomerLevelBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetDocumentCustomerLevelAdvanceSearchColumns()
        {
            
            return this._iDocumentCustomerLevelRepository.GetDocumentCustomerLevelAdvanceSearchColumns();
           
        }


		public DocumentCustomerLevel GetDocumentCustomerLevel(System.Int32 DocumentId)
		{
			return _iDocumentCustomerLevelRepository.GetDocumentCustomerLevel(DocumentId);
		}

		public DocumentCustomerLevel UpdateDocumentCustomerLevel(DocumentCustomerLevel entity)
		{
			return _iDocumentCustomerLevelRepository.UpdateDocumentCustomerLevel(entity);
		}

		public bool DeleteDocumentCustomerLevel(System.Int32 DocumentId)
		{
			return _iDocumentCustomerLevelRepository.DeleteDocumentCustomerLevel(DocumentId);
		}

		public List<DocumentCustomerLevel> GetAllDocumentCustomerLevel()
		{
			return _iDocumentCustomerLevelRepository.GetAllDocumentCustomerLevel();
		}

		public DocumentCustomerLevel InsertDocumentCustomerLevel(DocumentCustomerLevel entity)
		{
			 return _iDocumentCustomerLevelRepository.InsertDocumentCustomerLevel(entity);
		}


	}
	
	
}
