using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IGalleryService
	{
        Dictionary<string, string> GetGalleryBasicSearchColumns();
        
        List<SearchColumn> GetGalleryAdvanceSearchColumns();

		Gallery GetGallery(System.Int32 GalleryId);
		Gallery UpdateGallery(Gallery entity);
		bool DeleteGallery(System.Int32 GalleryId);
		List<Gallery> GetAllGallery();
		Gallery InsertGallery(Gallery entity);

	}
	
	
}
