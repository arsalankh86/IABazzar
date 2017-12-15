using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ISkinPreviewRepositoryBase
	{
        
        Dictionary<string, string> GetSkinPreviewBasicSearchColumns();
        List<SearchColumn> GetSkinPreviewSearchColumns();
        List<SearchColumn> GetSkinPreviewAdvanceSearchColumns();
        

		SkinPreview GetSkinPreview(System.Int32 SkinPreviewId);
		SkinPreview UpdateSkinPreview(SkinPreview entity);
		bool DeleteSkinPreview(System.Int32 SkinPreviewId);
		SkinPreview DeleteSkinPreview(SkinPreview entity);
		List<SkinPreview> GetAllSkinPreview();
		SkinPreview InsertSkinPreview(SkinPreview entity);	}
	
	
}
