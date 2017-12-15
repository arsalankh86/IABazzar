using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class GenreService : IGenreService 
	{
		private IGenreRepository _iGenreRepository;
        
		public GenreService(IGenreRepository iGenreRepository)
		{
			this._iGenreRepository = iGenreRepository;
		}
        
        public Dictionary<string, string> GetGenreBasicSearchColumns()
        {
            
            return this._iGenreRepository.GetGenreBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetGenreAdvanceSearchColumns()
        {
            
            return this._iGenreRepository.GetGenreAdvanceSearchColumns();
           
        }


		public Genre GetGenre(System.Int32 GenreId)
		{
			return _iGenreRepository.GetGenre(GenreId);
		}

		public Genre UpdateGenre(Genre entity)
		{
			return _iGenreRepository.UpdateGenre(entity);
		}

		public bool DeleteGenre(System.Int32 GenreId)
		{
			return _iGenreRepository.DeleteGenre(GenreId);
		}

		public List<Genre> GetAllGenre()
		{
			return _iGenreRepository.GetAllGenre();
		}

		public Genre InsertGenre(Genre entity)
		{
			 return _iGenreRepository.InsertGenre(entity);
		}


	}
	
	
}
