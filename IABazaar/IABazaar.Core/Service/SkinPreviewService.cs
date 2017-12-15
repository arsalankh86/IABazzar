using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class SkinPreviewService : ISkinPreviewService 
	{
		private ISkinPreviewRepository _iSkinPreviewRepository;
        
		public SkinPreviewService(ISkinPreviewRepository iSkinPreviewRepository)
		{
			this._iSkinPreviewRepository = iSkinPreviewRepository;
		}
        
        public Dictionary<string, string> GetSkinPreviewBasicSearchColumns()
        {
            
            return this._iSkinPreviewRepository.GetSkinPreviewBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetSkinPreviewAdvanceSearchColumns()
        {
            
            return this._iSkinPreviewRepository.GetSkinPreviewAdvanceSearchColumns();
           
        }


		public SkinPreview GetSkinPreview(System.Int32 SkinPreviewId)
		{
			return _iSkinPreviewRepository.GetSkinPreview(SkinPreviewId);
		}

		public SkinPreview UpdateSkinPreview(SkinPreview entity)
		{
			return _iSkinPreviewRepository.UpdateSkinPreview(entity);
		}

		public bool DeleteSkinPreview(System.Int32 SkinPreviewId)
		{
			return _iSkinPreviewRepository.DeleteSkinPreview(SkinPreviewId);
		}

		public List<SkinPreview> GetAllSkinPreview()
		{
			return _iSkinPreviewRepository.GetAllSkinPreview();
		}

		public SkinPreview InsertSkinPreview(SkinPreview entity)
		{
			 return _iSkinPreviewRepository.InsertSkinPreview(entity);
		}


	}
	
	
}
