using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ISectionRepositoryBase
	{
        
        Dictionary<string, string> GetSectionBasicSearchColumns();
        List<SearchColumn> GetSectionSearchColumns();
        List<SearchColumn> GetSectionAdvanceSearchColumns();
        

		Section GetSection(System.Int32 SectionId);
		Section UpdateSection(Section entity);
		bool DeleteSection(System.Int32 SectionId);
		Section DeleteSection(Section entity);
		List<Section> GetAllSection();
		Section InsertSection(Section entity);	}
	
	
}
