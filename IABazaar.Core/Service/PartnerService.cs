using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class PartnerService : IPartnerService 
	{
		private IPartnerRepository _iPartnerRepository;
        
		public PartnerService(IPartnerRepository iPartnerRepository)
		{
			this._iPartnerRepository = iPartnerRepository;
		}
        
        public Dictionary<string, string> GetPartnerBasicSearchColumns()
        {
            
            return this._iPartnerRepository.GetPartnerBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetPartnerAdvanceSearchColumns()
        {
            
            return this._iPartnerRepository.GetPartnerAdvanceSearchColumns();
           
        }


		public Partner GetPartner(System.Int32 PartnerId)
		{
			return _iPartnerRepository.GetPartner(PartnerId);
		}

		public Partner UpdatePartner(Partner entity)
		{
			return _iPartnerRepository.UpdatePartner(entity);
		}

		public bool DeletePartner(System.Int32 PartnerId)
		{
			return _iPartnerRepository.DeletePartner(PartnerId);
		}

		public List<Partner> GetAllPartner()
		{
			return _iPartnerRepository.GetAllPartner();
		}

		public Partner InsertPartner(Partner entity)
		{
			 return _iPartnerRepository.InsertPartner(entity);
		}


	}
	
	
}
