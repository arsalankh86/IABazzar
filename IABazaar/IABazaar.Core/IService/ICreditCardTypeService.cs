using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface ICreditCardTypeService
	{
        Dictionary<string, string> GetCreditCardTypeBasicSearchColumns();
        
        List<SearchColumn> GetCreditCardTypeAdvanceSearchColumns();

		CreditCardType GetCreditCardType(System.Int32 CardTypeId);
		CreditCardType UpdateCreditCardType(CreditCardType entity);
		bool DeleteCreditCardType(System.Int32 CardTypeId);
		List<CreditCardType> GetAllCreditCardType();
		CreditCardType InsertCreditCardType(CreditCardType entity);

	}
	
	
}
