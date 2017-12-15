using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class DocumentService : IDocumentService 
	{
		private IDocumentRepository _iDocumentRepository;
        
		public DocumentService(IDocumentRepository iDocumentRepository)
		{
			this._iDocumentRepository = iDocumentRepository;
		}
        
        public Dictionary<string, string> GetDocumentBasicSearchColumns()
        {
            
            return this._iDocumentRepository.GetDocumentBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetDocumentAdvanceSearchColumns()
        {
            
            return this._iDocumentRepository.GetDocumentAdvanceSearchColumns();
           
        }


		public Document GetDocument(System.Int32 DocumentId)
		{
			return _iDocumentRepository.GetDocument(DocumentId);
		}

		public Document UpdateDocument(Document entity)
		{
			return _iDocumentRepository.UpdateDocument(entity);
		}

		public bool DeleteDocument(System.Int32 DocumentId)
		{
			return _iDocumentRepository.DeleteDocument(DocumentId);
		}

		public List<Document> GetAllDocument()
		{
			return _iDocumentRepository.GetAllDocument();
		}

		public Document InsertDocument(Document entity)
		{
			 return _iDocumentRepository.InsertDocument(entity);
		}


	}
	
	
}
