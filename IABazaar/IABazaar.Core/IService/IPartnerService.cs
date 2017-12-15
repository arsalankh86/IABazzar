using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IPartnerService
	{
        Dictionary<string, string> GetPartnerBasicSearchColumns();
        
        List<SearchColumn> GetPartnerAdvanceSearchColumns();

		Partner GetPartner(System.Int32 PartnerId);
		Partner UpdatePartner(Partner entity);
		bool DeletePartner(System.Int32 PartnerId);
		List<Partner> GetAllPartner();
		Partner InsertPartner(Partner entity);

	}
	
	
}
