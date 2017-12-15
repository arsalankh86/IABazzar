using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ShippingImportExportService : IShippingImportExportService 
	{
		private IShippingImportExportRepository _iShippingImportExportRepository;
        
		public ShippingImportExportService(IShippingImportExportRepository iShippingImportExportRepository)
		{
			this._iShippingImportExportRepository = iShippingImportExportRepository;
		}
        
        public Dictionary<string, string> GetShippingImportExportBasicSearchColumns()
        {
            
            return this._iShippingImportExportRepository.GetShippingImportExportBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetShippingImportExportAdvanceSearchColumns()
        {
            
            return this._iShippingImportExportRepository.GetShippingImportExportAdvanceSearchColumns();
           
        }


		public ShippingImportExport GetShippingImportExport(System.Int32 OrderNumber)
		{
			return _iShippingImportExportRepository.GetShippingImportExport(OrderNumber);
		}

		public ShippingImportExport UpdateShippingImportExport(ShippingImportExport entity)
		{
			return _iShippingImportExportRepository.UpdateShippingImportExport(entity);
		}

		public bool DeleteShippingImportExport(System.Int32 OrderNumber)
		{
			return _iShippingImportExportRepository.DeleteShippingImportExport(OrderNumber);
		}

		public List<ShippingImportExport> GetAllShippingImportExport()
		{
			return _iShippingImportExportRepository.GetAllShippingImportExport();
		}

		public ShippingImportExport InsertShippingImportExport(ShippingImportExport entity)
		{
			 return _iShippingImportExportRepository.InsertShippingImportExport(entity);
		}


	}
	
	
}
