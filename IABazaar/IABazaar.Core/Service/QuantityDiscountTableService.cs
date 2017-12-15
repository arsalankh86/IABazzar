using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class QuantityDiscountTableService : IQuantityDiscountTableService 
	{
		private IQuantityDiscountTableRepository _iQuantityDiscountTableRepository;
        
		public QuantityDiscountTableService(IQuantityDiscountTableRepository iQuantityDiscountTableRepository)
		{
			this._iQuantityDiscountTableRepository = iQuantityDiscountTableRepository;
		}
        
        public Dictionary<string, string> GetQuantityDiscountTableBasicSearchColumns()
        {
            
            return this._iQuantityDiscountTableRepository.GetQuantityDiscountTableBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetQuantityDiscountTableAdvanceSearchColumns()
        {
            
            return this._iQuantityDiscountTableRepository.GetQuantityDiscountTableAdvanceSearchColumns();
           
        }


		public QuantityDiscountTable GetQuantityDiscountTable(System.Int32 QuantityDiscountTableId)
		{
			return _iQuantityDiscountTableRepository.GetQuantityDiscountTable(QuantityDiscountTableId);
		}

		public QuantityDiscountTable UpdateQuantityDiscountTable(QuantityDiscountTable entity)
		{
			return _iQuantityDiscountTableRepository.UpdateQuantityDiscountTable(entity);
		}

		public bool DeleteQuantityDiscountTable(System.Int32 QuantityDiscountTableId)
		{
			return _iQuantityDiscountTableRepository.DeleteQuantityDiscountTable(QuantityDiscountTableId);
		}

		public List<QuantityDiscountTable> GetAllQuantityDiscountTable()
		{
			return _iQuantityDiscountTableRepository.GetAllQuantityDiscountTable();
		}

		public QuantityDiscountTable InsertQuantityDiscountTable(QuantityDiscountTable entity)
		{
			 return _iQuantityDiscountTableRepository.InsertQuantityDiscountTable(entity);
		}


	}
	
	
}
