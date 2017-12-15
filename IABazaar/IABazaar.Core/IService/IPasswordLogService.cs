using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IPasswordLogService
	{
        Dictionary<string, string> GetPasswordLogBasicSearchColumns();
        
        List<SearchColumn> GetPasswordLogAdvanceSearchColumns();

		List<PasswordLog> GetAllPasswordLog();
		PasswordLog InsertPasswordLog(PasswordLog entity);

	}
	
	
}
