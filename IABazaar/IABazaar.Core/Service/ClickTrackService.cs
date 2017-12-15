using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ClickTrackService : IClickTrackService 
	{
		private IClickTrackRepository _iClickTrackRepository;
        
		public ClickTrackService(IClickTrackRepository iClickTrackRepository)
		{
			this._iClickTrackRepository = iClickTrackRepository;
		}
        
        public Dictionary<string, string> GetClickTrackBasicSearchColumns()
        {
            
            return this._iClickTrackRepository.GetClickTrackBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetClickTrackAdvanceSearchColumns()
        {
            
            return this._iClickTrackRepository.GetClickTrackAdvanceSearchColumns();
           
        }


		public ClickTrack GetClickTrack(System.Int32 ClickTrackId)
		{
			return _iClickTrackRepository.GetClickTrack(ClickTrackId);
		}

		public ClickTrack UpdateClickTrack(ClickTrack entity)
		{
			return _iClickTrackRepository.UpdateClickTrack(entity);
		}

		public bool DeleteClickTrack(System.Int32 ClickTrackId)
		{
			return _iClickTrackRepository.DeleteClickTrack(ClickTrackId);
		}

		public List<ClickTrack> GetAllClickTrack()
		{
			return _iClickTrackRepository.GetAllClickTrack();
		}

		public ClickTrack InsertClickTrack(ClickTrack entity)
		{
			 return _iClickTrackRepository.InsertClickTrack(entity);
		}


	}
	
	
}
