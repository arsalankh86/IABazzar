using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IStaffService
	{
        Dictionary<string, string> GetStaffBasicSearchColumns();
        
        List<SearchColumn> GetStaffAdvanceSearchColumns();

		Staff GetStaff(System.Int32 StaffId);
		Staff UpdateStaff(Staff entity);
		bool DeleteStaff(System.Int32 StaffId);
		List<Staff> GetAllStaff();
		Staff InsertStaff(Staff entity);

	}
	
	
}
