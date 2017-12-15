using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IStaffRepositoryBase
	{
        
        Dictionary<string, string> GetStaffBasicSearchColumns();
        List<SearchColumn> GetStaffSearchColumns();
        List<SearchColumn> GetStaffAdvanceSearchColumns();
        

		Staff GetStaff(System.Int32 StaffId);
		Staff UpdateStaff(Staff entity);
		bool DeleteStaff(System.Int32 StaffId);
		Staff DeleteStaff(Staff entity);
		List<Staff> GetAllStaff();
		Staff InsertStaff(Staff entity);	}
	
	
}
