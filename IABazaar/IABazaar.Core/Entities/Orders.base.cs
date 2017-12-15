using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class OrdersBase:EntityBase, IEquatable<OrdersBase>
	{
			
		public System.Int32 OrderNumber{ get; set; }

		public System.Guid OrderGuid{ get; set; }

		public System.Int32 StoreId{ get; set; }

		public System.Int32? ParentOrderNumber{ get; set; }

		public System.String StoreVersion{ get; set; }

		public System.Byte QuoteCheckout{ get; set; }

		public System.Byte IsNew{ get; set; }

		public System.DateTime? ShippedOn{ get; set; }

		public System.Int32 CustomerId{ get; set; }

		public System.Guid CustomerGuid{ get; set; }

		public System.String Referrer{ get; set; }

		public System.Int32 SkinId{ get; set; }

		public System.String LastName{ get; set; }

		public System.String FirstName{ get; set; }

		public System.String Email{ get; set; }

		public System.String Notes{ get; set; }

		public System.Byte BillingEqualsShipping{ get; set; }

		public System.String BillingLastName{ get; set; }

		public System.String BillingFirstName{ get; set; }

		public System.String BillingCompany{ get; set; }

		public System.String BillingAddress1{ get; set; }

		public System.String BillingAddress2{ get; set; }

		public System.String BillingSuite{ get; set; }

		public System.String BillingCity{ get; set; }

		public System.String BillingState{ get; set; }

		public System.String BillingZip{ get; set; }

		public System.String BillingCountry{ get; set; }

		public System.String BillingPhone{ get; set; }

		public System.String ShippingLastName{ get; set; }

		public System.String ShippingFirstName{ get; set; }

		public System.String ShippingCompany{ get; set; }

		public System.Int32 ShippingResidenceType{ get; set; }

		public System.String ShippingAddress1{ get; set; }

		public System.String ShippingAddress2{ get; set; }

		public System.String ShippingSuite{ get; set; }

		public System.String ShippingCity{ get; set; }

		public System.String ShippingState{ get; set; }

		public System.String ShippingZip{ get; set; }

		public System.String ShippingCountry{ get; set; }

		public System.Int32 ShippingMethodId{ get; set; }

		public System.String ShippingMethod{ get; set; }

		public System.String ShippingPhone{ get; set; }

		public System.Int32? ShippingCalculationId{ get; set; }

		public System.String Phone{ get; set; }

		public System.DateTime? RegisterDate{ get; set; }

		public System.Int32? AffiliateId{ get; set; }

		public System.String CouponCode{ get; set; }

		public System.Int32 CouponType{ get; set; }

		public System.String CouponDescription{ get; set; }

		public System.Decimal? CouponDiscountAmount{ get; set; }

		public System.Decimal? CouponDiscountPercent{ get; set; }

		public System.Byte? CouponIncludesFreeShipping{ get; set; }

		public System.Byte? OkToEmail{ get; set; }

		public System.Byte Deleted{ get; set; }

		public System.String CardType{ get; set; }

		public System.String CardName{ get; set; }

		public System.String CardNumber{ get; set; }

		public System.String CardExpirationMonth{ get; set; }

		public System.String CardExpirationYear{ get; set; }

		public System.String CardStartDate{ get; set; }

		public System.String CardIssueNumber{ get; set; }

		public System.Decimal OrderSubtotal{ get; set; }

		public System.Decimal OrderTax{ get; set; }

		public System.Decimal OrderShippingCosts{ get; set; }

		public System.Decimal OrderTotal{ get; set; }

		public System.String PaymentGateway{ get; set; }

		public System.String AuthorizationCode{ get; set; }

		public System.String AuthorizationResult{ get; set; }

		public System.String AuthorizationPnref{ get; set; }

		public System.String TransactionCommand{ get; set; }

		public System.DateTime OrderDate{ get; set; }

		public System.Int32? LevelId{ get; set; }

		public System.String LevelName{ get; set; }

		public System.Decimal? LevelDiscountPercent{ get; set; }

		public System.Decimal? LevelDiscountAmount{ get; set; }

		public System.Byte? LevelHasFreeShipping{ get; set; }

		public System.Byte? LevelAllowsQuantityDiscounts{ get; set; }

		public System.Byte? LevelHasNoTax{ get; set; }

		public System.Byte? LevelAllowsCoupons{ get; set; }

		public System.Byte? LevelDiscountsApplyToExtendedPrices{ get; set; }

		public System.String LastIpAddress{ get; set; }

		public System.String PaymentMethod{ get; set; }

		public System.String OrderNotes{ get; set; }

		public System.String PoNumber{ get; set; }

		public System.DateTime? DownloadEmailSentOn{ get; set; }

		public System.DateTime? ReceiptEmailSentOn{ get; set; }

		public System.DateTime? DistributorEmailSentOn{ get; set; }

		public System.String ShippingTrackingNumber{ get; set; }

		public System.String ShippedVia{ get; set; }

		public System.String CustomerServiceNotes{ get; set; }

		public System.String RtShipRequest{ get; set; }

		public System.String RtShipResponse{ get; set; }

		public System.String TransactionState{ get; set; }

		public System.String AvsResult{ get; set; }

		public System.String CaptureTxCommand{ get; set; }

		public System.String CaptureTxResult{ get; set; }

		public System.String VoidTxCommand{ get; set; }

		public System.String VoidTxResult{ get; set; }

		public System.String RefundTxCommand{ get; set; }

		public System.String RefundTxResult{ get; set; }

		public System.String RefundReason{ get; set; }

		public System.String CardinalLookupResult{ get; set; }

		public System.String CardinalAuthenticateResult{ get; set; }

		public System.String CardinalGatewayParms{ get; set; }

		public System.Byte AffiliateCommissionRecorded{ get; set; }

		public System.String OrderOptions{ get; set; }

		public System.Decimal OrderWeight{ get; set; }

		public System.String ECheckBankAbaCode{ get; set; }

		public System.String ECheckBankAccountNumber{ get; set; }

		public System.String ECheckBankAccountType{ get; set; }

		public System.String ECheckBankName{ get; set; }

		public System.String ECheckBankAccountName{ get; set; }

		public System.String CarrierReportedRate{ get; set; }

		public System.String CarrierReportedWeight{ get; set; }

		public System.String LocaleSetting{ get; set; }

		public System.String FinalizationData{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.Byte AlreadyConfirmed{ get; set; }

		public System.Int32 CartType{ get; set; }

		public System.String ThubPostedToAccounting{ get; set; }

		public System.DateTime? ThubPostedDate{ get; set; }

		public System.String ThubAccountingRef{ get; set; }

		public System.String Last4{ get; set; }

		public System.Byte ReadyToShip{ get; set; }

		public System.Byte IsPrinted{ get; set; }

		public System.DateTime? AuthorizedOn{ get; set; }

		public System.DateTime? CapturedOn{ get; set; }

		public System.DateTime? RefundedOn{ get; set; }

		public System.DateTime? VoidedOn{ get; set; }

		public System.DateTime? FraudedOn{ get; set; }

		public System.DateTime? EditedOn{ get; set; }

		public System.String TrackingUrl{ get; set; }

		public System.DateTime? ShippedEmailSentOn{ get; set; }

		public System.Int32 InventoryWasReduced{ get; set; }

		public System.Decimal? MaxMindFraudScore{ get; set; }

		public System.String MaxMindDetails{ get; set; }

		public System.String VatRegistrationId{ get; set; }

		public System.Int32 Crypt{ get; set; }

		public System.Int32 TransactionType{ get; set; }

		public System.String RecurringSubscriptionId{ get; set; }

		public System.String RecurringSubscriptionCommand{ get; set; }

		public System.String RecurringSubscriptionResult{ get; set; }

		public System.Int32 RelatedOrderNumber{ get; set; }

		public System.String BuySafeCommand{ get; set; }

		public System.String BuySafeResult{ get; set; }

		public System.String ReceiptHtml{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<OrdersBase> Members

        public virtual bool Equals(OrdersBase other)
        {
			if(this.OrderNumber==other.OrderNumber  && this.OrderGuid==other.OrderGuid  && this.StoreId==other.StoreId  && this.ParentOrderNumber==other.ParentOrderNumber  && this.StoreVersion==other.StoreVersion  && this.QuoteCheckout==other.QuoteCheckout  && this.IsNew==other.IsNew  && this.ShippedOn==other.ShippedOn  && this.CustomerId==other.CustomerId  && this.CustomerGuid==other.CustomerGuid  && this.Referrer==other.Referrer  && this.SkinId==other.SkinId  && this.LastName==other.LastName  && this.FirstName==other.FirstName  && this.Email==other.Email  && this.Notes==other.Notes  && this.BillingEqualsShipping==other.BillingEqualsShipping  && this.BillingLastName==other.BillingLastName  && this.BillingFirstName==other.BillingFirstName  && this.BillingCompany==other.BillingCompany  && this.BillingAddress1==other.BillingAddress1  && this.BillingAddress2==other.BillingAddress2  && this.BillingSuite==other.BillingSuite  && this.BillingCity==other.BillingCity  && this.BillingState==other.BillingState  && this.BillingZip==other.BillingZip  && this.BillingCountry==other.BillingCountry  && this.BillingPhone==other.BillingPhone  && this.ShippingLastName==other.ShippingLastName  && this.ShippingFirstName==other.ShippingFirstName  && this.ShippingCompany==other.ShippingCompany  && this.ShippingResidenceType==other.ShippingResidenceType  && this.ShippingAddress1==other.ShippingAddress1  && this.ShippingAddress2==other.ShippingAddress2  && this.ShippingSuite==other.ShippingSuite  && this.ShippingCity==other.ShippingCity  && this.ShippingState==other.ShippingState  && this.ShippingZip==other.ShippingZip  && this.ShippingCountry==other.ShippingCountry  && this.ShippingMethodId==other.ShippingMethodId  && this.ShippingMethod==other.ShippingMethod  && this.ShippingPhone==other.ShippingPhone  && this.ShippingCalculationId==other.ShippingCalculationId  && this.Phone==other.Phone  && this.RegisterDate==other.RegisterDate  && this.AffiliateId==other.AffiliateId  && this.CouponCode==other.CouponCode  && this.CouponType==other.CouponType  && this.CouponDescription==other.CouponDescription  && this.CouponDiscountAmount==other.CouponDiscountAmount  && this.CouponDiscountPercent==other.CouponDiscountPercent  && this.CouponIncludesFreeShipping==other.CouponIncludesFreeShipping  && this.OkToEmail==other.OkToEmail  && this.Deleted==other.Deleted  && this.CardType==other.CardType  && this.CardName==other.CardName  && this.CardNumber==other.CardNumber  && this.CardExpirationMonth==other.CardExpirationMonth  && this.CardExpirationYear==other.CardExpirationYear  && this.CardStartDate==other.CardStartDate  && this.CardIssueNumber==other.CardIssueNumber  && this.OrderSubtotal==other.OrderSubtotal  && this.OrderTax==other.OrderTax  && this.OrderShippingCosts==other.OrderShippingCosts  && this.OrderTotal==other.OrderTotal  && this.PaymentGateway==other.PaymentGateway  && this.AuthorizationCode==other.AuthorizationCode  && this.AuthorizationResult==other.AuthorizationResult  && this.AuthorizationPnref==other.AuthorizationPnref  && this.TransactionCommand==other.TransactionCommand  && this.OrderDate==other.OrderDate  && this.LevelId==other.LevelId  && this.LevelName==other.LevelName  && this.LevelDiscountPercent==other.LevelDiscountPercent  && this.LevelDiscountAmount==other.LevelDiscountAmount  && this.LevelHasFreeShipping==other.LevelHasFreeShipping  && this.LevelAllowsQuantityDiscounts==other.LevelAllowsQuantityDiscounts  && this.LevelHasNoTax==other.LevelHasNoTax  && this.LevelAllowsCoupons==other.LevelAllowsCoupons  && this.LevelDiscountsApplyToExtendedPrices==other.LevelDiscountsApplyToExtendedPrices  && this.LastIpAddress==other.LastIpAddress  && this.PaymentMethod==other.PaymentMethod  && this.OrderNotes==other.OrderNotes  && this.PoNumber==other.PoNumber  && this.DownloadEmailSentOn==other.DownloadEmailSentOn  && this.ReceiptEmailSentOn==other.ReceiptEmailSentOn  && this.DistributorEmailSentOn==other.DistributorEmailSentOn  && this.ShippingTrackingNumber==other.ShippingTrackingNumber  && this.ShippedVia==other.ShippedVia  && this.CustomerServiceNotes==other.CustomerServiceNotes  && this.RtShipRequest==other.RtShipRequest  && this.RtShipResponse==other.RtShipResponse  && this.TransactionState==other.TransactionState  && this.AvsResult==other.AvsResult  && this.CaptureTxCommand==other.CaptureTxCommand  && this.CaptureTxResult==other.CaptureTxResult  && this.VoidTxCommand==other.VoidTxCommand  && this.VoidTxResult==other.VoidTxResult  && this.RefundTxCommand==other.RefundTxCommand  && this.RefundTxResult==other.RefundTxResult  && this.RefundReason==other.RefundReason  && this.CardinalLookupResult==other.CardinalLookupResult  && this.CardinalAuthenticateResult==other.CardinalAuthenticateResult  && this.CardinalGatewayParms==other.CardinalGatewayParms  && this.AffiliateCommissionRecorded==other.AffiliateCommissionRecorded  && this.OrderOptions==other.OrderOptions  && this.OrderWeight==other.OrderWeight  && this.ECheckBankAbaCode==other.ECheckBankAbaCode  && this.ECheckBankAccountNumber==other.ECheckBankAccountNumber  && this.ECheckBankAccountType==other.ECheckBankAccountType  && this.ECheckBankName==other.ECheckBankName  && this.ECheckBankAccountName==other.ECheckBankAccountName  && this.CarrierReportedRate==other.CarrierReportedRate  && this.CarrierReportedWeight==other.CarrierReportedWeight  && this.LocaleSetting==other.LocaleSetting  && this.FinalizationData==other.FinalizationData  && this.ExtensionData==other.ExtensionData  && this.AlreadyConfirmed==other.AlreadyConfirmed  && this.CartType==other.CartType  && this.ThubPostedToAccounting==other.ThubPostedToAccounting  && this.ThubPostedDate==other.ThubPostedDate  && this.ThubAccountingRef==other.ThubAccountingRef  && this.Last4==other.Last4  && this.ReadyToShip==other.ReadyToShip  && this.IsPrinted==other.IsPrinted  && this.AuthorizedOn==other.AuthorizedOn  && this.CapturedOn==other.CapturedOn  && this.RefundedOn==other.RefundedOn  && this.VoidedOn==other.VoidedOn  && this.FraudedOn==other.FraudedOn  && this.EditedOn==other.EditedOn  && this.TrackingUrl==other.TrackingUrl  && this.ShippedEmailSentOn==other.ShippedEmailSentOn  && this.InventoryWasReduced==other.InventoryWasReduced  && this.MaxMindFraudScore==other.MaxMindFraudScore  && this.MaxMindDetails==other.MaxMindDetails  && this.VatRegistrationId==other.VatRegistrationId  && this.Crypt==other.Crypt  && this.TransactionType==other.TransactionType  && this.RecurringSubscriptionId==other.RecurringSubscriptionId  && this.RecurringSubscriptionCommand==other.RecurringSubscriptionCommand  && this.RecurringSubscriptionResult==other.RecurringSubscriptionResult  && this.RelatedOrderNumber==other.RelatedOrderNumber  && this.BuySafeCommand==other.BuySafeCommand  && this.BuySafeResult==other.BuySafeResult  && this.ReceiptHtml==other.ReceiptHtml )
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
