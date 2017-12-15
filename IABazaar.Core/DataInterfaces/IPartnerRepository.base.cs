using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface IPartnerRepositoryBase
	{
        
        Dictionary<string, string> GetPartnerBasicSearchColumns();
        List<SearchColumn> GetPartnerSearchColumns();
        List<SearchColumn> GetPartnerAdvanceSearchColumns();
        

		Partner GetPartner(System.Int32 PartnerId);
		Partner UpdatePartner(Partner entity);
		bool DeletePartner(System.Int32 PartnerId);
		Partner DeletePartner(Partner entity);
		List<Partner> GetAllPartner();
		Partner InsertPartner(Partner entity);	}
	
	
}
