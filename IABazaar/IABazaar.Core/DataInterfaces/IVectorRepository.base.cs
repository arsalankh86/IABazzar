using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IVectorRepositoryBase
	{
        
        Dictionary<string, string> GetVectorBasicSearchColumns();
        List<SearchColumn> GetVectorSearchColumns();
        List<SearchColumn> GetVectorAdvanceSearchColumns();
        

		Vector GetVector(System.Int32 VectorId);
		Vector UpdateVector(Vector entity);
		bool DeleteVector(System.Int32 VectorId);
		Vector DeleteVector(Vector entity);
		List<Vector> GetAllVector();
		Vector InsertVector(Vector entity);	}
	
	
}
