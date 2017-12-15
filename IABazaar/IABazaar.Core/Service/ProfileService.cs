using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ProfileService : IProfileService 
	{
		private IProfileRepository _iProfileRepository;
        
		public ProfileService(IProfileRepository iProfileRepository)
		{
			this._iProfileRepository = iProfileRepository;
		}
        
        public Dictionary<string, string> GetProfileBasicSearchColumns()
        {
            
            return this._iProfileRepository.GetProfileBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetProfileAdvanceSearchColumns()
        {
            
            return this._iProfileRepository.GetProfileAdvanceSearchColumns();
           
        }


		public Profile GetProfile(System.Int32 ProfileId)
		{
			return _iProfileRepository.GetProfile(ProfileId);
		}

		public Profile UpdateProfile(Profile entity)
		{
			return _iProfileRepository.UpdateProfile(entity);
		}

		public bool DeleteProfile(System.Int32 ProfileId)
		{
			return _iProfileRepository.DeleteProfile(ProfileId);
		}

		public List<Profile> GetAllProfile()
		{
			return _iProfileRepository.GetAllProfile();
		}

		public Profile InsertProfile(Profile entity)
		{
			 return _iProfileRepository.InsertProfile(entity);
		}


	}
	
	
}
