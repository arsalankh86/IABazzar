using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class StringResourceService : IStringResourceService 
	{
		private IStringResourceRepository _iStringResourceRepository;
        
		public StringResourceService(IStringResourceRepository iStringResourceRepository)
		{
			this._iStringResourceRepository = iStringResourceRepository;
		}
        
        public Dictionary<string, string> GetStringResourceBasicSearchColumns()
        {
            
            return this._iStringResourceRepository.GetStringResourceBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetStringResourceAdvanceSearchColumns()
        {
            
            return this._iStringResourceRepository.GetStringResourceAdvanceSearchColumns();
           
        }


		public StringResource GetStringResource(System.Int32 StringResourceId)
		{
			return _iStringResourceRepository.GetStringResource(StringResourceId);
		}

		public StringResource UpdateStringResource(StringResource entity)
		{
			return _iStringResourceRepository.UpdateStringResource(entity);
		}

		public bool DeleteStringResource(System.Int32 StringResourceId)
		{
			return _iStringResourceRepository.DeleteStringResource(StringResourceId);
		}

		public List<StringResource> GetAllStringResource()
		{
			return _iStringResourceRepository.GetAllStringResource();
		}

		public StringResource InsertStringResource(StringResource entity)
		{
			 return _iStringResourceRepository.InsertStringResource(entity);
		}


	}
	
	
}
