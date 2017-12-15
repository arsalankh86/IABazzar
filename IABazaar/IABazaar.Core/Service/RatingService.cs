using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class RatingService : IRatingService 
	{
		private IRatingRepository _iRatingRepository;
        
		public RatingService(IRatingRepository iRatingRepository)
		{
			this._iRatingRepository = iRatingRepository;
		}
        
        public Dictionary<string, string> GetRatingBasicSearchColumns()
        {
            
            return this._iRatingRepository.GetRatingBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetRatingAdvanceSearchColumns()
        {
            
            return this._iRatingRepository.GetRatingAdvanceSearchColumns();
           
        }


		public Rating GetRating(System.Int32 RatingId)
		{
			return _iRatingRepository.GetRating(RatingId);
		}

		public Rating UpdateRating(Rating entity)
		{
			return _iRatingRepository.UpdateRating(entity);
		}

		public bool DeleteRating(System.Int32 RatingId)
		{
			return _iRatingRepository.DeleteRating(RatingId);
		}

		public List<Rating> GetAllRating()
		{
			return _iRatingRepository.GetAllRating();
		}

		public Rating InsertRating(Rating entity)
		{
			 return _iRatingRepository.InsertRating(entity);
		}


	}
	
	
}
