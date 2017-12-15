using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IStringResourceService
	{
        Dictionary<string, string> GetStringResourceBasicSearchColumns();
        
        List<SearchColumn> GetStringResourceAdvanceSearchColumns();

		StringResource GetStringResource(System.Int32 StringResourceId);
		StringResource UpdateStringResource(StringResource entity);
		bool DeleteStringResource(System.Int32 StringResourceId);
		List<StringResource> GetAllStringResource();
		StringResource InsertStringResource(StringResource entity);

	}
	
	
}
