using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IProfileService
	{
        Dictionary<string, string> GetProfileBasicSearchColumns();
        
        List<SearchColumn> GetProfileAdvanceSearchColumns();

		Profile GetProfile(System.Int32 ProfileId);
		Profile UpdateProfile(Profile entity);
		bool DeleteProfile(System.Int32 ProfileId);
		List<Profile> GetAllProfile();
		Profile InsertProfile(Profile entity);

	}
	
	
}
