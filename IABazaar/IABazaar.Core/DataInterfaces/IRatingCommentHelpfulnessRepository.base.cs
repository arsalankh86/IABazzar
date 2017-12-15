using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IRatingCommentHelpfulnessRepositoryBase
	{
        
        Dictionary<string, string> GetRatingCommentHelpfulnessBasicSearchColumns();
        List<SearchColumn> GetRatingCommentHelpfulnessSearchColumns();
        List<SearchColumn> GetRatingCommentHelpfulnessAdvanceSearchColumns();
        

		RatingCommentHelpfulness GetRatingCommentHelpfulness(System.Int32 StoreId);
		RatingCommentHelpfulness UpdateRatingCommentHelpfulness(RatingCommentHelpfulness entity);
		bool DeleteRatingCommentHelpfulness(System.Int32 StoreId);
		RatingCommentHelpfulness DeleteRatingCommentHelpfulness(RatingCommentHelpfulness entity);
		List<RatingCommentHelpfulness> GetAllRatingCommentHelpfulness();
		RatingCommentHelpfulness InsertRatingCommentHelpfulness(RatingCommentHelpfulness entity);	}
	
	
}
