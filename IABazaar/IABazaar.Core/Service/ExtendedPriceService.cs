using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ExtendedPriceService : IExtendedPriceService 
	{
		private IExtendedPriceRepository _iExtendedPriceRepository;
        
		public ExtendedPriceService(IExtendedPriceRepository iExtendedPriceRepository)
		{
			this._iExtendedPriceRepository = iExtendedPriceRepository;
		}
        
        public Dictionary<string, string> GetExtendedPriceBasicSearchColumns()
        {
            
            return this._iExtendedPriceRepository.GetExtendedPriceBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetExtendedPriceAdvanceSearchColumns()
        {
            
            return this._iExtendedPriceRepository.GetExtendedPriceAdvanceSearchColumns();
           
        }


		public ExtendedPrice GetExtendedPrice(System.Int32 ExtendedPriceId)
		{
			return _iExtendedPriceRepository.GetExtendedPrice(ExtendedPriceId);
		}

		public ExtendedPrice UpdateExtendedPrice(ExtendedPrice entity)
		{
			return _iExtendedPriceRepository.UpdateExtendedPrice(entity);
		}

		public bool DeleteExtendedPrice(System.Int32 ExtendedPriceId)
		{
			return _iExtendedPriceRepository.DeleteExtendedPrice(ExtendedPriceId);
		}

		public List<ExtendedPrice> GetAllExtendedPrice()
		{
			return _iExtendedPriceRepository.GetAllExtendedPrice();
		}

		public ExtendedPrice InsertExtendedPrice(ExtendedPrice entity)
		{
			 return _iExtendedPriceRepository.InsertExtendedPrice(entity);
		}


	}
	
	
}
