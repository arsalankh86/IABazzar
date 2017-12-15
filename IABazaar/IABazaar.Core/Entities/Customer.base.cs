using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class CustomerBase:EntityBase, IEquatable<CustomerBase>
	{
			
		[PrimaryKey]
		public System.Int32 CustomerId{ get; set; }

		public System.Guid CustomerGuid{ get; set; }

		public System.Int32 CustomerLevelId{ get; set; }

		public System.Int32 StoreId{ get; set; }

		public System.DateTime RegisterDate{ get; set; }

		public System.String Email{ get; set; }

		public System.String Password{ get; set; }

		public System.Int32 SaltKey{ get; set; }

		public System.DateTime? DateOfBirth{ get; set; }

		public System.String Gender{ get; set; }

		public System.String FirstName{ get; set; }

		public System.String LastName{ get; set; }

		public System.String Notes{ get; set; }

		public System.Int32 SkinId{ get; set; }

		public System.String Phone{ get; set; }

		public System.String Fax{ get; set; }

		public System.Int32? AffiliateId{ get; set; }

		public System.String Referrer{ get; set; }

		public System.String CouponCode{ get; set; }

		public System.Byte OkToEmail{ get; set; }

		public System.Byte IsAdmin{ get; set; }

		public System.Byte BillingEqualsShipping{ get; set; }

		public System.String LastIpAddress{ get; set; }

		public System.String OrderNotes{ get; set; }

		public System.DateTime? SubscriptionExpiresOn{ get; set; }

		public System.String RtShipRequest{ get; set; }

		public System.String RtShipResponse{ get; set; }

		public System.String OrderOptions{ get; set; }

		public System.String LocaleSetting{ get; set; }

		public System.Decimal MicroPayBalance{ get; set; }

		public System.Int32 RecurringShippingMethodId{ get; set; }

		public System.String RecurringShippingMethod{ get; set; }

		public System.Int32? BillingAddressId{ get; set; }

		public System.Int32? ShippingAddressId{ get; set; }

		public System.Guid GiftRegistryGuid{ get; set; }

		public System.Byte GiftRegistryIsAnonymous{ get; set; }

		public System.Byte GiftRegistryAllowSearchByOthers{ get; set; }

		public System.String GiftRegistryNickName{ get; set; }

		public System.Byte GiftRegistryHideShippingAddresses{ get; set; }

		public System.Byte CodCompanyCheckAllowed{ get; set; }

		public System.Byte CodNet30Allowed{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.String FinalizationData{ get; set; }

		public System.Byte Deleted{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		public System.Byte? Over13Checked{ get; set; }

		public System.String CurrencySetting{ get; set; }

		public System.Int32 VatSetting{ get; set; }

		public System.String VatRegistrationId{ get; set; }

		public System.Byte StoreCcInDb{ get; set; }

		public System.Byte IsRegistered{ get; set; }

		public System.DateTime? LockedUntil{ get; set; }

		public System.Byte AdminCanViewCc{ get; set; }

		public System.DateTime PwdChanged{ get; set; }

		public System.Byte BadLoginCount{ get; set; }

		public System.DateTime? LastBadLogin{ get; set; }

		public System.Byte Active{ get; set; }

		public System.Byte? PwdChangeRequired{ get; set; }

		public System.String RequestedPaymentMethod{ get; set; }

		public System.Decimal? BuySafe{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<CustomerBase> Members

        public virtual bool Equals(CustomerBase other)
        {
			if(this.CustomerId==other.CustomerId  && this.CustomerGuid==other.CustomerGuid  && this.CustomerLevelId==other.CustomerLevelId  && this.StoreId==other.StoreId  && this.RegisterDate==other.RegisterDate  && this.Email==other.Email  && this.Password==other.Password  && this.SaltKey==other.SaltKey  && this.DateOfBirth==other.DateOfBirth  && this.Gender==other.Gender  && this.FirstName==other.FirstName  && this.LastName==other.LastName  && this.Notes==other.Notes  && this.SkinId==other.SkinId  && this.Phone==other.Phone  && this.Fax==other.Fax  && this.AffiliateId==other.AffiliateId  && this.Referrer==other.Referrer  && this.CouponCode==other.CouponCode  && this.OkToEmail==other.OkToEmail  && this.IsAdmin==other.IsAdmin  && this.BillingEqualsShipping==other.BillingEqualsShipping  && this.LastIpAddress==other.LastIpAddress  && this.OrderNotes==other.OrderNotes  && this.SubscriptionExpiresOn==other.SubscriptionExpiresOn  && this.RtShipRequest==other.RtShipRequest  && this.RtShipResponse==other.RtShipResponse  && this.OrderOptions==other.OrderOptions  && this.LocaleSetting==other.LocaleSetting  && this.MicroPayBalance==other.MicroPayBalance  && this.RecurringShippingMethodId==other.RecurringShippingMethodId  && this.RecurringShippingMethod==other.RecurringShippingMethod  && this.BillingAddressId==other.BillingAddressId  && this.ShippingAddressId==other.ShippingAddressId  && this.GiftRegistryGuid==other.GiftRegistryGuid  && this.GiftRegistryIsAnonymous==other.GiftRegistryIsAnonymous  && this.GiftRegistryAllowSearchByOthers==other.GiftRegistryAllowSearchByOthers  && this.GiftRegistryNickName==other.GiftRegistryNickName  && this.GiftRegistryHideShippingAddresses==other.GiftRegistryHideShippingAddresses  && this.CodCompanyCheckAllowed==other.CodCompanyCheckAllowed  && this.CodNet30Allowed==other.CodNet30Allowed  && this.ExtensionData==other.ExtensionData  && this.FinalizationData==other.FinalizationData  && this.Deleted==other.Deleted  && this.CreatedOn==other.CreatedOn  && this.Over13Checked==other.Over13Checked  && this.CurrencySetting==other.CurrencySetting  && this.VatSetting==other.VatSetting  && this.VatRegistrationId==other.VatRegistrationId  && this.StoreCcInDb==other.StoreCcInDb  && this.IsRegistered==other.IsRegistered  && this.LockedUntil==other.LockedUntil  && this.AdminCanViewCc==other.AdminCanViewCc  && this.PwdChanged==other.PwdChanged  && this.BadLoginCount==other.BadLoginCount  && this.LastBadLogin==other.LastBadLogin  && this.Active==other.Active  && this.PwdChangeRequired==other.PwdChangeRequired  && this.RequestedPaymentMethod==other.RequestedPaymentMethod  && this.BuySafe==other.BuySafe )
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
