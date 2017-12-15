using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.DataInterfaces
{
		
	public interface ICreditCardTypeRepositoryBase
	{
        
        Dictionary<string, string> GetCreditCardTypeBasicSearchColumns();
        List<SearchColumn> GetCreditCardTypeSearchColumns();
        List<SearchColumn> GetCreditCardTypeAdvanceSearchColumns();
        

		CreditCardType GetCreditCardType(System.Int32 CardTypeId);
		CreditCardType UpdateCreditCardType(CreditCardType entity);
		bool DeleteCreditCardType(System.Int32 CardTypeId);
		CreditCardType DeleteCreditCardType(CreditCardType entity);
		List<CreditCardType> GetAllCreditCardType();
		CreditCardType InsertCreditCardType(CreditCardType entity);	}
	
	
}
