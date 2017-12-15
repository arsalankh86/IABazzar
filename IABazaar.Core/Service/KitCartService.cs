using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class KitCartService : IKitCartService 
	{
		private IKitCartRepository _iKitCartRepository;
        
		public KitCartService(IKitCartRepository iKitCartRepository)
		{
			this._iKitCartRepository = iKitCartRepository;
		}
        
        public Dictionary<string, string> GetKitCartBasicSearchColumns()
        {
            
            return this._iKitCartRepository.GetKitCartBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetKitCartAdvanceSearchColumns()
        {
            
            return this._iKitCartRepository.GetKitCartAdvanceSearchColumns();
           
        }


		public KitCart GetKitCart(System.Int32 KitCartRecId)
		{
			return _iKitCartRepository.GetKitCart(KitCartRecId);
		}

		public KitCart UpdateKitCart(KitCart entity)
		{
			return _iKitCartRepository.UpdateKitCart(entity);
		}

		public bool DeleteKitCart(System.Int32 KitCartRecId)
		{
			return _iKitCartRepository.DeleteKitCart(KitCartRecId);
		}

		public List<KitCart> GetAllKitCart()
		{
			return _iKitCartRepository.GetAllKitCart();
		}

		public KitCart InsertKitCart(KitCart entity)
		{
			 return _iKitCartRepository.InsertKitCart(entity);
		}


	}
	
	
}
