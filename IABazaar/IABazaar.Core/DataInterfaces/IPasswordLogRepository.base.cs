using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IPasswordLogRepositoryBase
	{
        
        Dictionary<string, string> GetPasswordLogBasicSearchColumns();
        List<SearchColumn> GetPasswordLogSearchColumns();
        List<SearchColumn> GetPasswordLogAdvanceSearchColumns();
        

		List<PasswordLog> GetAllPasswordLog();
		PasswordLog InsertPasswordLog(PasswordLog entity);	}
	
	
}
