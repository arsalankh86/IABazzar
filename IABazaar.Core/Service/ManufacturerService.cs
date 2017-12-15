using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class ManufacturerService : IManufacturerService 
	{
		private IManufacturerRepository _iManufacturerRepository;
        
		public ManufacturerService(IManufacturerRepository iManufacturerRepository)
		{
			this._iManufacturerRepository = iManufacturerRepository;
		}
        
        public Dictionary<string, string> GetManufacturerBasicSearchColumns()
        {
            
            return this._iManufacturerRepository.GetManufacturerBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetManufacturerAdvanceSearchColumns()
        {
            
            return this._iManufacturerRepository.GetManufacturerAdvanceSearchColumns();
           
        }


		public Manufacturer GetManufacturer(System.Int32 ManufacturerId)
		{
			return _iManufacturerRepository.GetManufacturer(ManufacturerId);
		}

		public Manufacturer UpdateManufacturer(Manufacturer entity)
		{
			return _iManufacturerRepository.UpdateManufacturer(entity);
		}

		public bool DeleteManufacturer(System.Int32 ManufacturerId)
		{
			return _iManufacturerRepository.DeleteManufacturer(ManufacturerId);
		}

		public List<Manufacturer> GetAllManufacturer()
		{
			return _iManufacturerRepository.GetAllManufacturer();
		}

		public Manufacturer InsertManufacturer(Manufacturer entity)
		{
			 return _iManufacturerRepository.InsertManufacturer(entity);
		}


	}
	
	
}
