using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class DocumentLibraryService : IDocumentLibraryService 
	{
		private IDocumentLibraryRepository _iDocumentLibraryRepository;
        
		public DocumentLibraryService(IDocumentLibraryRepository iDocumentLibraryRepository)
		{
			this._iDocumentLibraryRepository = iDocumentLibraryRepository;
		}
        
        public Dictionary<string, string> GetDocumentLibraryBasicSearchColumns()
        {
            
            return this._iDocumentLibraryRepository.GetDocumentLibraryBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetDocumentLibraryAdvanceSearchColumns()
        {
            
            return this._iDocumentLibraryRepository.GetDocumentLibraryAdvanceSearchColumns();
           
        }


		public DocumentLibrary GetDocumentLibrary(System.Int32 DocumentId)
		{
			return _iDocumentLibraryRepository.GetDocumentLibrary(DocumentId);
		}

		public DocumentLibrary UpdateDocumentLibrary(DocumentLibrary entity)
		{
			return _iDocumentLibraryRepository.UpdateDocumentLibrary(entity);
		}

		public bool DeleteDocumentLibrary(System.Int32 DocumentId)
		{
			return _iDocumentLibraryRepository.DeleteDocumentLibrary(DocumentId);
		}

		public List<DocumentLibrary> GetAllDocumentLibrary()
		{
			return _iDocumentLibraryRepository.GetAllDocumentLibrary();
		}

		public DocumentLibrary InsertDocumentLibrary(DocumentLibrary entity)
		{
			 return _iDocumentLibraryRepository.InsertDocumentLibrary(entity);
		}


	}
	
	
}
