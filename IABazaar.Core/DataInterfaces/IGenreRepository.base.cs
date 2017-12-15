using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IGenreRepositoryBase
	{
        
        Dictionary<string, string> GetGenreBasicSearchColumns();
        List<SearchColumn> GetGenreSearchColumns();
        List<SearchColumn> GetGenreAdvanceSearchColumns();
        

		Genre GetGenre(System.Int32 GenreId);
		Genre UpdateGenre(Genre entity);
		bool DeleteGenre(System.Int32 GenreId);
		Genre DeleteGenre(Genre entity);
		List<Genre> GetAllGenre();
		Genre InsertGenre(Genre entity);	}
	
	
}
