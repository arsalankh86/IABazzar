using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class VectorService : IVectorService 
	{
		private IVectorRepository _iVectorRepository;
        
		public VectorService(IVectorRepository iVectorRepository)
		{
			this._iVectorRepository = iVectorRepository;
		}
        
        public Dictionary<string, string> GetVectorBasicSearchColumns()
        {
            
            return this._iVectorRepository.GetVectorBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetVectorAdvanceSearchColumns()
        {
            
            return this._iVectorRepository.GetVectorAdvanceSearchColumns();
           
        }


		public Vector GetVector(System.Int32 VectorId)
		{
			return _iVectorRepository.GetVector(VectorId);
		}

		public Vector UpdateVector(Vector entity)
		{
			return _iVectorRepository.UpdateVector(entity);
		}

		public bool DeleteVector(System.Int32 VectorId)
		{
			return _iVectorRepository.DeleteVector(VectorId);
		}

		public List<Vector> GetAllVector()
		{
			return _iVectorRepository.GetAllVector();
		}

		public Vector InsertVector(Vector entity)
		{
			 return _iVectorRepository.InsertVector(entity);
		}


	}
	
	
}
