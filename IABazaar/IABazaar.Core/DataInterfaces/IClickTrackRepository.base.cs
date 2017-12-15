using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IClickTrackRepositoryBase
	{
        
        Dictionary<string, string> GetClickTrackBasicSearchColumns();
        List<SearchColumn> GetClickTrackSearchColumns();
        List<SearchColumn> GetClickTrackAdvanceSearchColumns();
        

		ClickTrack GetClickTrack(System.Int32 ClickTrackId);
		ClickTrack UpdateClickTrack(ClickTrack entity);
		bool DeleteClickTrack(System.Int32 ClickTrackId);
		ClickTrack DeleteClickTrack(ClickTrack entity);
		List<ClickTrack> GetAllClickTrack();
		ClickTrack InsertClickTrack(ClickTrack entity);	}
	
	
}
