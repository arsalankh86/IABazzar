using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ZipTaxRateService : IZipTaxRateService 
	{
		private IZipTaxRateRepository _iZipTaxRateRepository;
        
		public ZipTaxRateService(IZipTaxRateRepository iZipTaxRateRepository)
		{
			this._iZipTaxRateRepository = iZipTaxRateRepository;
		}
        
        public Dictionary<string, string> GetZipTaxRateBasicSearchColumns()
        {
            
            return this._iZipTaxRateRepository.GetZipTaxRateBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetZipTaxRateAdvanceSearchColumns()
        {
            
            return this._iZipTaxRateRepository.GetZipTaxRateAdvanceSearchColumns();
           
        }


		public ZipTaxRate GetZipTaxRate(System.Int32 ZipTaxId)
		{
			return _iZipTaxRateRepository.GetZipTaxRate(ZipTaxId);
		}

		public ZipTaxRate UpdateZipTaxRate(ZipTaxRate entity)
		{
			return _iZipTaxRateRepository.UpdateZipTaxRate(entity);
		}

		public bool DeleteZipTaxRate(System.Int32 ZipTaxId)
		{
			return _iZipTaxRateRepository.DeleteZipTaxRate(ZipTaxId);
		}

		public List<ZipTaxRate> GetAllZipTaxRate()
		{
			return _iZipTaxRateRepository.GetAllZipTaxRate();
		}

		public ZipTaxRate InsertZipTaxRate(ZipTaxRate entity)
		{
			 return _iZipTaxRateRepository.InsertZipTaxRate(entity);
		}


	}
	
	
}
