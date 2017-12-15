using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class AddressBase:EntityBase, IEquatable<AddressBase>
	{
			
		[PrimaryKey]
		public System.Int32 AddressId{ get; set; }

		public System.Guid AddressGuid{ get; set; }

		public System.Int32 CustomerId{ get; set; }

		public System.String NickName{ get; set; }

		public System.String FirstName{ get; set; }

		public System.String LastName{ get; set; }

		public System.String Company{ get; set; }

		public System.String Address1{ get; set; }

		public System.String Address2{ get; set; }

		public System.String Suite{ get; set; }

		public System.String City{ get; set; }

		public System.String State{ get; set; }

		public System.String Zip{ get; set; }

		public System.String Country{ get; set; }

		public System.Int32 ResidenceType{ get; set; }

		public System.String Phone{ get; set; }

		public System.String Email{ get; set; }

		public System.String PaymentMethodLastUsed{ get; set; }

		public System.String CardType{ get; set; }

		public System.String CardName{ get; set; }

		public System.String CardNumber{ get; set; }

		public System.String CardExpirationMonth{ get; set; }

		public System.String CardExpirationYear{ get; set; }

		public System.String CardStartDate{ get; set; }

		public System.String CardIssueNumber{ get; set; }

		public System.String ECheckBankAbaCode{ get; set; }

		public System.String ECheckBankAccountNumber{ get; set; }

		public System.String ECheckBankAccountType{ get; set; }

		public System.String ECheckBankName{ get; set; }

		public System.String ECheckBankAccountName{ get; set; }

		public System.String PoNumber{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.Byte Deleted{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		public System.Int32 Crypt{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<AddressBase> Members

        public virtual bool Equals(AddressBase other)
        {
			if(this.AddressId==other.AddressId  && this.AddressGuid==other.AddressGuid  && this.CustomerId==other.CustomerId  && this.NickName==other.NickName  && this.FirstName==other.FirstName  && this.LastName==other.LastName  && this.Company==other.Company  && this.Address1==other.Address1  && this.Address2==other.Address2  && this.Suite==other.Suite  && this.City==other.City  && this.State==other.State  && this.Zip==other.Zip  && this.Country==other.Country  && this.ResidenceType==other.ResidenceType  && this.Phone==other.Phone  && this.Email==other.Email  && this.PaymentMethodLastUsed==other.PaymentMethodLastUsed  && this.CardType==other.CardType  && this.CardName==other.CardName  && this.CardNumber==other.CardNumber  && this.CardExpirationMonth==other.CardExpirationMonth  && this.CardExpirationYear==other.CardExpirationYear  && this.CardStartDate==other.CardStartDate  && this.CardIssueNumber==other.CardIssueNumber  && this.ECheckBankAbaCode==other.ECheckBankAbaCode  && this.ECheckBankAccountNumber==other.ECheckBankAccountNumber  && this.ECheckBankAccountType==other.ECheckBankAccountType  && this.ECheckBankName==other.ECheckBankName  && this.ECheckBankAccountName==other.ECheckBankAccountName  && this.PoNumber==other.PoNumber  && this.ExtensionData==other.ExtensionData  && this.Deleted==other.Deleted  && this.CreatedOn==other.CreatedOn  && this.Crypt==other.Crypt )
			{
				return true;
			}
			else
			{
				return false;
			}
		
		}

        #endregion
		
		
		
	}
	
	
}
