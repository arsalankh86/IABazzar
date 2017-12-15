using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class CustomReportService : ICustomReportService 
	{
		private ICustomReportRepository _iCustomReportRepository;
        
		public CustomReportService(ICustomReportRepository iCustomReportRepository)
		{
			this._iCustomReportRepository = iCustomReportRepository;
		}
        
        public Dictionary<string, string> GetCustomReportBasicSearchColumns()
        {
            
            return this._iCustomReportRepository.GetCustomReportBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetCustomReportAdvanceSearchColumns()
        {
            
            return this._iCustomReportRepository.GetCustomReportAdvanceSearchColumns();
           
        }


		public CustomReport GetCustomReport(System.Int32 CustomReportId)
		{
			return _iCustomReportRepository.GetCustomReport(CustomReportId);
		}

		public CustomReport UpdateCustomReport(CustomReport entity)
		{
			return _iCustomReportRepository.UpdateCustomReport(entity);
		}

		public bool DeleteCustomReport(System.Int32 CustomReportId)
		{
			return _iCustomReportRepository.DeleteCustomReport(CustomReportId);
		}

		public List<CustomReport> GetAllCustomReport()
		{
			return _iCustomReportRepository.GetAllCustomReport();
		}

		public CustomReport InsertCustomReport(CustomReport entity)
		{
			 return _iCustomReportRepository.InsertCustomReport(entity);
		}


	}
	
	
}
