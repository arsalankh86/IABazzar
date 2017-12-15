using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class GalleryService : IGalleryService 
	{
		private IGalleryRepository _iGalleryRepository;
        
		public GalleryService(IGalleryRepository iGalleryRepository)
		{
			this._iGalleryRepository = iGalleryRepository;
		}
        
        public Dictionary<string, string> GetGalleryBasicSearchColumns()
        {
            
            return this._iGalleryRepository.GetGalleryBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetGalleryAdvanceSearchColumns()
        {
            
            return this._iGalleryRepository.GetGalleryAdvanceSearchColumns();
           
        }


		public Gallery GetGallery(System.Int32 GalleryId)
		{
			return _iGalleryRepository.GetGallery(GalleryId);
		}

		public Gallery UpdateGallery(Gallery entity)
		{
			return _iGalleryRepository.UpdateGallery(entity);
		}

		public bool DeleteGallery(System.Int32 GalleryId)
		{
			return _iGalleryRepository.DeleteGallery(GalleryId);
		}

		public List<Gallery> GetAllGallery()
		{
			return _iGalleryRepository.GetAllGallery();
		}

		public Gallery InsertGallery(Gallery entity)
		{
			 return _iGalleryRepository.InsertGallery(entity);
		}


	}
	
	
}
