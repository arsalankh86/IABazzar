using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IClickTrackService
	{
        Dictionary<string, string> GetClickTrackBasicSearchColumns();
        
        List<SearchColumn> GetClickTrackAdvanceSearchColumns();

		ClickTrack GetClickTrack(System.Int32 ClickTrackId);
		ClickTrack UpdateClickTrack(ClickTrack entity);
		bool DeleteClickTrack(System.Int32 ClickTrackId);
		List<ClickTrack> GetAllClickTrack();
		ClickTrack InsertClickTrack(ClickTrack entity);

	}
	
	
}
