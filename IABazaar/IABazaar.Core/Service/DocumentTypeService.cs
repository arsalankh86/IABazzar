using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class DocumentTypeService : IDocumentTypeService 
	{
		private IDocumentTypeRepository _iDocumentTypeRepository;
        
		public DocumentTypeService(IDocumentTypeRepository iDocumentTypeRepository)
		{
			this._iDocumentTypeRepository = iDocumentTypeRepository;
		}
        
        public Dictionary<string, string> GetDocumentTypeBasicSearchColumns()
        {
            
            return this._iDocumentTypeRepository.GetDocumentTypeBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetDocumentTypeAdvanceSearchColumns()
        {
            
            return this._iDocumentTypeRepository.GetDocumentTypeAdvanceSearchColumns();
           
        }


		public DocumentType GetDocumentType(System.Int32 DocumentTypeId)
		{
			return _iDocumentTypeRepository.GetDocumentType(DocumentTypeId);
		}

		public DocumentType UpdateDocumentType(DocumentType entity)
		{
			return _iDocumentTypeRepository.UpdateDocumentType(entity);
		}

		public bool DeleteDocumentType(System.Int32 DocumentTypeId)
		{
			return _iDocumentTypeRepository.DeleteDocumentType(DocumentTypeId);
		}

		public List<DocumentType> GetAllDocumentType()
		{
			return _iDocumentTypeRepository.GetAllDocumentType();
		}

		public DocumentType InsertDocumentType(DocumentType entity)
		{
			 return _iDocumentTypeRepository.InsertDocumentType(entity);
		}


	}
	
	
}
