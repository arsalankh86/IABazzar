using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ISectionService
	{
        Dictionary<string, string> GetSectionBasicSearchColumns();
        
        List<SearchColumn> GetSectionAdvanceSearchColumns();

		Section GetSection(System.Int32 SectionId);
		Section UpdateSection(Section entity);
		bool DeleteSection(System.Int32 SectionId);
		List<Section> GetAllSection();
		Section InsertSection(Section entity);

	}
	
	
}
