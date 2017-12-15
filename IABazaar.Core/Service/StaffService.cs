using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class StaffService : IStaffService 
	{
		private IStaffRepository _iStaffRepository;
        
		public StaffService(IStaffRepository iStaffRepository)
		{
			this._iStaffRepository = iStaffRepository;
		}
        
        public Dictionary<string, string> GetStaffBasicSearchColumns()
        {
            
            return this._iStaffRepository.GetStaffBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetStaffAdvanceSearchColumns()
        {
            
            return this._iStaffRepository.GetStaffAdvanceSearchColumns();
           
        }


		public Staff GetStaff(System.Int32 StaffId)
		{
			return _iStaffRepository.GetStaff(StaffId);
		}

		public Staff UpdateStaff(Staff entity)
		{
			return _iStaffRepository.UpdateStaff(entity);
		}

		public bool DeleteStaff(System.Int32 StaffId)
		{
			return _iStaffRepository.DeleteStaff(StaffId);
		}

		public List<Staff> GetAllStaff()
		{
			return _iStaffRepository.GetAllStaff();
		}

		public Staff InsertStaff(Staff entity)
		{
			 return _iStaffRepository.InsertStaff(entity);
		}


	}
	
	
}
