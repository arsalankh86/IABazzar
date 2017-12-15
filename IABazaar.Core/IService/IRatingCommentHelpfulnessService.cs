using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IRatingCommentHelpfulnessService
	{
        Dictionary<string, string> GetRatingCommentHelpfulnessBasicSearchColumns();
        
        List<SearchColumn> GetRatingCommentHelpfulnessAdvanceSearchColumns();

		RatingCommentHelpfulness GetRatingCommentHelpfulness(System.Int32 StoreId);
		RatingCommentHelpfulness UpdateRatingCommentHelpfulness(RatingCommentHelpfulness entity);
		bool DeleteRatingCommentHelpfulness(System.Int32 StoreId);
		List<RatingCommentHelpfulness> GetAllRatingCommentHelpfulness();
		RatingCommentHelpfulness InsertRatingCommentHelpfulness(RatingCommentHelpfulness entity);

	}
	
	
}
