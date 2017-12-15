using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IGenreService
	{
        Dictionary<string, string> GetGenreBasicSearchColumns();
        
        List<SearchColumn> GetGenreAdvanceSearchColumns();

		Genre GetGenre(System.Int32 GenreId);
		Genre UpdateGenre(Genre entity);
		bool DeleteGenre(System.Int32 GenreId);
		List<Genre> GetAllGenre();
		Genre InsertGenre(Genre entity);

	}
	
	
}
