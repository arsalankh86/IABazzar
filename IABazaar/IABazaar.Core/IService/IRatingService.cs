using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IRatingService
	{
        Dictionary<string, string> GetRatingBasicSearchColumns();
        
        List<SearchColumn> GetRatingAdvanceSearchColumns();

		Rating GetRating(System.Int32 RatingId);
		Rating UpdateRating(Rating entity);
		bool DeleteRating(System.Int32 RatingId);
		List<Rating> GetAllRating();
		Rating InsertRating(Rating entity);

	}
	
	
}
