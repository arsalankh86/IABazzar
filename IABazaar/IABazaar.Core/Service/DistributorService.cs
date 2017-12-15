using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class DistributorService : IDistributorService 
	{
		private IDistributorRepository _iDistributorRepository;
        
		public DistributorService(IDistributorRepository iDistributorRepository)
		{
			this._iDistributorRepository = iDistributorRepository;
		}
        
        public Dictionary<string, string> GetDistributorBasicSearchColumns()
        {
            
            return this._iDistributorRepository.GetDistributorBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetDistributorAdvanceSearchColumns()
        {
            
            return this._iDistributorRepository.GetDistributorAdvanceSearchColumns();
           
        }


		public Distributor GetDistributor(System.Int32 DistributorId)
		{
			return _iDistributorRepository.GetDistributor(DistributorId);
		}

		public Distributor UpdateDistributor(Distributor entity)
		{
			return _iDistributorRepository.UpdateDistributor(entity);
		}

		public bool DeleteDistributor(System.Int32 DistributorId)
		{
			return _iDistributorRepository.DeleteDistributor(DistributorId);
		}

		public List<Distributor> GetAllDistributor()
		{
			return _iDistributorRepository.GetAllDistributor();
		}

		public Distributor InsertDistributor(Distributor entity)
		{
			 return _iDistributorRepository.InsertDistributor(entity);
		}


	}
	
	
}
