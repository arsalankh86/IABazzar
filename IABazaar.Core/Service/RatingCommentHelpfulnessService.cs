using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class RatingCommentHelpfulnessService : IRatingCommentHelpfulnessService 
	{
		private IRatingCommentHelpfulnessRepository _iRatingCommentHelpfulnessRepository;
        
		public RatingCommentHelpfulnessService(IRatingCommentHelpfulnessRepository iRatingCommentHelpfulnessRepository)
		{
			this._iRatingCommentHelpfulnessRepository = iRatingCommentHelpfulnessRepository;
		}
        
        public Dictionary<string, string> GetRatingCommentHelpfulnessBasicSearchColumns()
        {
            
            return this._iRatingCommentHelpfulnessRepository.GetRatingCommentHelpfulnessBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetRatingCommentHelpfulnessAdvanceSearchColumns()
        {
            
            return this._iRatingCommentHelpfulnessRepository.GetRatingCommentHelpfulnessAdvanceSearchColumns();
           
        }


		public RatingCommentHelpfulness GetRatingCommentHelpfulness(System.Int32 StoreId)
		{
			return _iRatingCommentHelpfulnessRepository.GetRatingCommentHelpfulness(StoreId);
		}

		public RatingCommentHelpfulness UpdateRatingCommentHelpfulness(RatingCommentHelpfulness entity)
		{
			return _iRatingCommentHelpfulnessRepository.UpdateRatingCommentHelpfulness(entity);
		}

		public bool DeleteRatingCommentHelpfulness(System.Int32 StoreId)
		{
			return _iRatingCommentHelpfulnessRepository.DeleteRatingCommentHelpfulness(StoreId);
		}

		public List<RatingCommentHelpfulness> GetAllRatingCommentHelpfulness()
		{
			return _iRatingCommentHelpfulnessRepository.GetAllRatingCommentHelpfulness();
		}

		public RatingCommentHelpfulness InsertRatingCommentHelpfulness(RatingCommentHelpfulness entity)
		{
			 return _iRatingCommentHelpfulnessRepository.InsertRatingCommentHelpfulness(entity);
		}


	}
	
	
}
