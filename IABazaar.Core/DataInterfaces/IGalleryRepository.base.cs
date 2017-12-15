using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IGalleryRepositoryBase
	{
        
        Dictionary<string, string> GetGalleryBasicSearchColumns();
        List<SearchColumn> GetGallerySearchColumns();
        List<SearchColumn> GetGalleryAdvanceSearchColumns();
        

		Gallery GetGallery(System.Int32 GalleryId);
		Gallery UpdateGallery(Gallery entity);
		bool DeleteGallery(System.Int32 GalleryId);
		Gallery DeleteGallery(Gallery entity);
		List<Gallery> GetAllGallery();
		Gallery InsertGallery(Gallery entity);	}
	
	
}
