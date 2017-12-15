using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IStringResourceRepositoryBase
	{
        
        Dictionary<string, string> GetStringResourceBasicSearchColumns();
        List<SearchColumn> GetStringResourceSearchColumns();
        List<SearchColumn> GetStringResourceAdvanceSearchColumns();
        

		StringResource GetStringResource(System.Int32 StringResourceId);
		StringResource UpdateStringResource(StringResource entity);
		bool DeleteStringResource(System.Int32 StringResourceId);
		StringResource DeleteStringResource(StringResource entity);
		List<StringResource> GetAllStringResource();
		StringResource InsertStringResource(StringResource entity);	}
	
	
}
