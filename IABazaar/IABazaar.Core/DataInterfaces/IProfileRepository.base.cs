using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IProfileRepositoryBase
	{
        
        Dictionary<string, string> GetProfileBasicSearchColumns();
        List<SearchColumn> GetProfileSearchColumns();
        List<SearchColumn> GetProfileAdvanceSearchColumns();
        

		Profile GetProfile(System.Int32 ProfileId);
		Profile UpdateProfile(Profile entity);
		bool DeleteProfile(System.Int32 ProfileId);
		Profile DeleteProfile(Profile entity);
		List<Profile> GetAllProfile();
		Profile InsertProfile(Profile entity);	}
	
	
}
