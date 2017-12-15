using System;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using IABazaar.Core;
using IABazaar.Core.Entities;


namespace IABazaar.Repository
{
		
	public abstract partial class OrdersRepositoryBase : Repository 
	{
        
        public OrdersRepositoryBase()
        {   
            this.SearchColumns=new Dictionary<string, SearchColumn>();

			this.SearchColumns.Add("OrderNumber",new SearchColumn(){Name="OrderNumber",Title="OrderNumber",SelectClause="OrderNumber",WhereClause="AllRecords.OrderNumber",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderGUID",new SearchColumn(){Name="OrderGUID",Title="OrderGUID",SelectClause="OrderGUID",WhereClause="AllRecords.OrderGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("StoreID",new SearchColumn(){Name="StoreID",Title="StoreID",SelectClause="StoreID",WhereClause="AllRecords.StoreID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ParentOrderNumber",new SearchColumn(){Name="ParentOrderNumber",Title="ParentOrderNumber",SelectClause="ParentOrderNumber",WhereClause="AllRecords.ParentOrderNumber",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("StoreVersion",new SearchColumn(){Name="StoreVersion",Title="StoreVersion",SelectClause="StoreVersion",WhereClause="AllRecords.StoreVersion",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("QuoteCheckout",new SearchColumn(){Name="QuoteCheckout",Title="QuoteCheckout",SelectClause="QuoteCheckout",WhereClause="AllRecords.QuoteCheckout",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsNew",new SearchColumn(){Name="IsNew",Title="IsNew",SelectClause="IsNew",WhereClause="AllRecords.IsNew",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShippedOn",new SearchColumn(){Name="ShippedOn",Title="ShippedOn",SelectClause="ShippedOn",WhereClause="AllRecords.ShippedOn",DataType="System.DateTime?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerID",new SearchColumn(){Name="CustomerID",Title="CustomerID",SelectClause="CustomerID",WhereClause="AllRecords.CustomerID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerGUID",new SearchColumn(){Name="CustomerGUID",Title="CustomerGUID",SelectClause="CustomerGUID",WhereClause="AllRecords.CustomerGUID",DataType="System.Guid",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Referrer",new SearchColumn(){Name="Referrer",Title="Referrer",SelectClause="Referrer",WhereClause="AllRecords.Referrer",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("SkinID",new SearchColumn(){Name="SkinID",Title="SkinID",SelectClause="SkinID",WhereClause="AllRecords.SkinID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LastName",new SearchColumn(){Name="LastName",Title="LastName",SelectClause="LastName",WhereClause="AllRecords.LastName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("FirstName",new SearchColumn(){Name="FirstName",Title="FirstName",SelectClause="FirstName",WhereClause="AllRecords.FirstName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Email",new SearchColumn(){Name="Email",Title="Email",SelectClause="Email",WhereClause="AllRecords.Email",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Notes",new SearchColumn(){Name="Notes",Title="Notes",SelectClause="Notes",WhereClause="AllRecords.Notes",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("BillingEqualsShipping",new SearchColumn(){Name="BillingEqualsShipping",Title="BillingEqualsShipping",SelectClause="BillingEqualsShipping",WhereClause="AllRecords.BillingEqualsShipping",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("BillingLastName",new SearchColumn(){Name="BillingLastName",Title="BillingLastName",SelectClause="BillingLastName",WhereClause="AllRecords.BillingLastName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("BillingFirstName",new SearchColumn(){Name="BillingFirstName",Title="BillingFirstName",SelectClause="BillingFirstName",WhereClause="AllRecords.BillingFirstName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("BillingCompany",new SearchColumn(){Name="BillingCompany",Title="BillingCompany",SelectClause="BillingCompany",WhereClause="AllRecords.BillingCompany",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("BillingAddress1",new SearchColumn(){Name="BillingAddress1",Title="BillingAddress1",SelectClause="BillingAddress1",WhereClause="AllRecords.BillingAddress1",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("BillingAddress2",new SearchColumn(){Name="BillingAddress2",Title="BillingAddress2",SelectClause="BillingAddress2",WhereClause="AllRecords.BillingAddress2",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("BillingSuite",new SearchColumn(){Name="BillingSuite",Title="BillingSuite",SelectClause="BillingSuite",WhereClause="AllRecords.BillingSuite",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("BillingCity",new SearchColumn(){Name="BillingCity",Title="BillingCity",SelectClause="BillingCity",WhereClause="AllRecords.BillingCity",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("BillingState",new SearchColumn(){Name="BillingState",Title="BillingState",SelectClause="BillingState",WhereClause="AllRecords.BillingState",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("BillingZip",new SearchColumn(){Name="BillingZip",Title="BillingZip",SelectClause="BillingZip",WhereClause="AllRecords.BillingZip",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("BillingCountry",new SearchColumn(){Name="BillingCountry",Title="BillingCountry",SelectClause="BillingCountry",WhereClause="AllRecords.BillingCountry",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("BillingPhone",new SearchColumn(){Name="BillingPhone",Title="BillingPhone",SelectClause="BillingPhone",WhereClause="AllRecords.BillingPhone",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShippingLastName",new SearchColumn(){Name="ShippingLastName",Title="ShippingLastName",SelectClause="ShippingLastName",WhereClause="AllRecords.ShippingLastName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShippingFirstName",new SearchColumn(){Name="ShippingFirstName",Title="ShippingFirstName",SelectClause="ShippingFirstName",WhereClause="AllRecords.ShippingFirstName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShippingCompany",new SearchColumn(){Name="ShippingCompany",Title="ShippingCompany",SelectClause="ShippingCompany",WhereClause="AllRecords.ShippingCompany",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShippingResidenceType",new SearchColumn(){Name="ShippingResidenceType",Title="ShippingResidenceType",SelectClause="ShippingResidenceType",WhereClause="AllRecords.ShippingResidenceType",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShippingAddress1",new SearchColumn(){Name="ShippingAddress1",Title="ShippingAddress1",SelectClause="ShippingAddress1",WhereClause="AllRecords.ShippingAddress1",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShippingAddress2",new SearchColumn(){Name="ShippingAddress2",Title="ShippingAddress2",SelectClause="ShippingAddress2",WhereClause="AllRecords.ShippingAddress2",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShippingSuite",new SearchColumn(){Name="ShippingSuite",Title="ShippingSuite",SelectClause="ShippingSuite",WhereClause="AllRecords.ShippingSuite",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShippingCity",new SearchColumn(){Name="ShippingCity",Title="ShippingCity",SelectClause="ShippingCity",WhereClause="AllRecords.ShippingCity",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShippingState",new SearchColumn(){Name="ShippingState",Title="ShippingState",SelectClause="ShippingState",WhereClause="AllRecords.ShippingState",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShippingZip",new SearchColumn(){Name="ShippingZip",Title="ShippingZip",SelectClause="ShippingZip",WhereClause="AllRecords.ShippingZip",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShippingCountry",new SearchColumn(){Name="ShippingCountry",Title="ShippingCountry",SelectClause="ShippingCountry",WhereClause="AllRecords.ShippingCountry",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShippingMethodID",new SearchColumn(){Name="ShippingMethodID",Title="ShippingMethodID",SelectClause="ShippingMethodID",WhereClause="AllRecords.ShippingMethodID",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShippingMethod",new SearchColumn(){Name="ShippingMethod",Title="ShippingMethod",SelectClause="ShippingMethod",WhereClause="AllRecords.ShippingMethod",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShippingPhone",new SearchColumn(){Name="ShippingPhone",Title="ShippingPhone",SelectClause="ShippingPhone",WhereClause="AllRecords.ShippingPhone",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShippingCalculationID",new SearchColumn(){Name="ShippingCalculationID",Title="ShippingCalculationID",SelectClause="ShippingCalculationID",WhereClause="AllRecords.ShippingCalculationID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Phone",new SearchColumn(){Name="Phone",Title="Phone",SelectClause="Phone",WhereClause="AllRecords.Phone",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RegisterDate",new SearchColumn(){Name="RegisterDate",Title="RegisterDate",SelectClause="RegisterDate",WhereClause="AllRecords.RegisterDate",DataType="System.DateTime?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("AffiliateID",new SearchColumn(){Name="AffiliateID",Title="AffiliateID",SelectClause="AffiliateID",WhereClause="AllRecords.AffiliateID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CouponCode",new SearchColumn(){Name="CouponCode",Title="CouponCode",SelectClause="CouponCode",WhereClause="AllRecords.CouponCode",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CouponType",new SearchColumn(){Name="CouponType",Title="CouponType",SelectClause="CouponType",WhereClause="AllRecords.CouponType",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CouponDescription",new SearchColumn(){Name="CouponDescription",Title="CouponDescription",SelectClause="CouponDescription",WhereClause="AllRecords.CouponDescription",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CouponDiscountAmount",new SearchColumn(){Name="CouponDiscountAmount",Title="CouponDiscountAmount",SelectClause="CouponDiscountAmount",WhereClause="AllRecords.CouponDiscountAmount",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CouponDiscountPercent",new SearchColumn(){Name="CouponDiscountPercent",Title="CouponDiscountPercent",SelectClause="CouponDiscountPercent",WhereClause="AllRecords.CouponDiscountPercent",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CouponIncludesFreeShipping",new SearchColumn(){Name="CouponIncludesFreeShipping",Title="CouponIncludesFreeShipping",SelectClause="CouponIncludesFreeShipping",WhereClause="AllRecords.CouponIncludesFreeShipping",DataType="System.Byte?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OkToEmail",new SearchColumn(){Name="OkToEmail",Title="OkToEmail",SelectClause="OkToEmail",WhereClause="AllRecords.OkToEmail",DataType="System.Byte?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Deleted",new SearchColumn(){Name="Deleted",Title="Deleted",SelectClause="Deleted",WhereClause="AllRecords.Deleted",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CardType",new SearchColumn(){Name="CardType",Title="CardType",SelectClause="CardType",WhereClause="AllRecords.CardType",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CardName",new SearchColumn(){Name="CardName",Title="CardName",SelectClause="CardName",WhereClause="AllRecords.CardName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CardNumber",new SearchColumn(){Name="CardNumber",Title="CardNumber",SelectClause="CardNumber",WhereClause="AllRecords.CardNumber",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CardExpirationMonth",new SearchColumn(){Name="CardExpirationMonth",Title="CardExpirationMonth",SelectClause="CardExpirationMonth",WhereClause="AllRecords.CardExpirationMonth",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CardExpirationYear",new SearchColumn(){Name="CardExpirationYear",Title="CardExpirationYear",SelectClause="CardExpirationYear",WhereClause="AllRecords.CardExpirationYear",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CardStartDate",new SearchColumn(){Name="CardStartDate",Title="CardStartDate",SelectClause="CardStartDate",WhereClause="AllRecords.CardStartDate",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CardIssueNumber",new SearchColumn(){Name="CardIssueNumber",Title="CardIssueNumber",SelectClause="CardIssueNumber",WhereClause="AllRecords.CardIssueNumber",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderSubtotal",new SearchColumn(){Name="OrderSubtotal",Title="OrderSubtotal",SelectClause="OrderSubtotal",WhereClause="AllRecords.OrderSubtotal",DataType="System.Decimal",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderTax",new SearchColumn(){Name="OrderTax",Title="OrderTax",SelectClause="OrderTax",WhereClause="AllRecords.OrderTax",DataType="System.Decimal",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderShippingCosts",new SearchColumn(){Name="OrderShippingCosts",Title="OrderShippingCosts",SelectClause="OrderShippingCosts",WhereClause="AllRecords.OrderShippingCosts",DataType="System.Decimal",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderTotal",new SearchColumn(){Name="OrderTotal",Title="OrderTotal",SelectClause="OrderTotal",WhereClause="AllRecords.OrderTotal",DataType="System.Decimal",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PaymentGateway",new SearchColumn(){Name="PaymentGateway",Title="PaymentGateway",SelectClause="PaymentGateway",WhereClause="AllRecords.PaymentGateway",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("AuthorizationCode",new SearchColumn(){Name="AuthorizationCode",Title="AuthorizationCode",SelectClause="AuthorizationCode",WhereClause="AllRecords.AuthorizationCode",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("AuthorizationResult",new SearchColumn(){Name="AuthorizationResult",Title="AuthorizationResult",SelectClause="AuthorizationResult",WhereClause="AllRecords.AuthorizationResult",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("AuthorizationPNREF",new SearchColumn(){Name="AuthorizationPNREF",Title="AuthorizationPNREF",SelectClause="AuthorizationPNREF",WhereClause="AllRecords.AuthorizationPNREF",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TransactionCommand",new SearchColumn(){Name="TransactionCommand",Title="TransactionCommand",SelectClause="TransactionCommand",WhereClause="AllRecords.TransactionCommand",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderDate",new SearchColumn(){Name="OrderDate",Title="OrderDate",SelectClause="OrderDate",WhereClause="AllRecords.OrderDate",DataType="System.DateTime",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LevelID",new SearchColumn(){Name="LevelID",Title="LevelID",SelectClause="LevelID",WhereClause="AllRecords.LevelID",DataType="System.Int32?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LevelName",new SearchColumn(){Name="LevelName",Title="LevelName",SelectClause="LevelName",WhereClause="AllRecords.LevelName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LevelDiscountPercent",new SearchColumn(){Name="LevelDiscountPercent",Title="LevelDiscountPercent",SelectClause="LevelDiscountPercent",WhereClause="AllRecords.LevelDiscountPercent",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LevelDiscountAmount",new SearchColumn(){Name="LevelDiscountAmount",Title="LevelDiscountAmount",SelectClause="LevelDiscountAmount",WhereClause="AllRecords.LevelDiscountAmount",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LevelHasFreeShipping",new SearchColumn(){Name="LevelHasFreeShipping",Title="LevelHasFreeShipping",SelectClause="LevelHasFreeShipping",WhereClause="AllRecords.LevelHasFreeShipping",DataType="System.Byte?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LevelAllowsQuantityDiscounts",new SearchColumn(){Name="LevelAllowsQuantityDiscounts",Title="LevelAllowsQuantityDiscounts",SelectClause="LevelAllowsQuantityDiscounts",WhereClause="AllRecords.LevelAllowsQuantityDiscounts",DataType="System.Byte?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LevelHasNoTax",new SearchColumn(){Name="LevelHasNoTax",Title="LevelHasNoTax",SelectClause="LevelHasNoTax",WhereClause="AllRecords.LevelHasNoTax",DataType="System.Byte?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LevelAllowsCoupons",new SearchColumn(){Name="LevelAllowsCoupons",Title="LevelAllowsCoupons",SelectClause="LevelAllowsCoupons",WhereClause="AllRecords.LevelAllowsCoupons",DataType="System.Byte?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LevelDiscountsApplyToExtendedPrices",new SearchColumn(){Name="LevelDiscountsApplyToExtendedPrices",Title="LevelDiscountsApplyToExtendedPrices",SelectClause="LevelDiscountsApplyToExtendedPrices",WhereClause="AllRecords.LevelDiscountsApplyToExtendedPrices",DataType="System.Byte?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LastIPAddress",new SearchColumn(){Name="LastIPAddress",Title="LastIPAddress",SelectClause="LastIPAddress",WhereClause="AllRecords.LastIPAddress",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PaymentMethod",new SearchColumn(){Name="PaymentMethod",Title="PaymentMethod",SelectClause="PaymentMethod",WhereClause="AllRecords.PaymentMethod",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderNotes",new SearchColumn(){Name="OrderNotes",Title="OrderNotes",SelectClause="OrderNotes",WhereClause="AllRecords.OrderNotes",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("PONumber",new SearchColumn(){Name="PONumber",Title="PONumber",SelectClause="PONumber",WhereClause="AllRecords.PONumber",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DownloadEmailSentOn",new SearchColumn(){Name="DownloadEmailSentOn",Title="DownloadEmailSentOn",SelectClause="DownloadEmailSentOn",WhereClause="AllRecords.DownloadEmailSentOn",DataType="System.DateTime?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ReceiptEmailSentOn",new SearchColumn(){Name="ReceiptEmailSentOn",Title="ReceiptEmailSentOn",SelectClause="ReceiptEmailSentOn",WhereClause="AllRecords.ReceiptEmailSentOn",DataType="System.DateTime?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("DistributorEmailSentOn",new SearchColumn(){Name="DistributorEmailSentOn",Title="DistributorEmailSentOn",SelectClause="DistributorEmailSentOn",WhereClause="AllRecords.DistributorEmailSentOn",DataType="System.DateTime?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShippingTrackingNumber",new SearchColumn(){Name="ShippingTrackingNumber",Title="ShippingTrackingNumber",SelectClause="ShippingTrackingNumber",WhereClause="AllRecords.ShippingTrackingNumber",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShippedVIA",new SearchColumn(){Name="ShippedVIA",Title="ShippedVIA",SelectClause="ShippedVIA",WhereClause="AllRecords.ShippedVIA",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CustomerServiceNotes",new SearchColumn(){Name="CustomerServiceNotes",Title="CustomerServiceNotes",SelectClause="CustomerServiceNotes",WhereClause="AllRecords.CustomerServiceNotes",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RTShipRequest",new SearchColumn(){Name="RTShipRequest",Title="RTShipRequest",SelectClause="RTShipRequest",WhereClause="AllRecords.RTShipRequest",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RTShipResponse",new SearchColumn(){Name="RTShipResponse",Title="RTShipResponse",SelectClause="RTShipResponse",WhereClause="AllRecords.RTShipResponse",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TransactionState",new SearchColumn(){Name="TransactionState",Title="TransactionState",SelectClause="TransactionState",WhereClause="AllRecords.TransactionState",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("AVSResult",new SearchColumn(){Name="AVSResult",Title="AVSResult",SelectClause="AVSResult",WhereClause="AllRecords.AVSResult",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CaptureTXCommand",new SearchColumn(){Name="CaptureTXCommand",Title="CaptureTXCommand",SelectClause="CaptureTXCommand",WhereClause="AllRecords.CaptureTXCommand",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CaptureTXResult",new SearchColumn(){Name="CaptureTXResult",Title="CaptureTXResult",SelectClause="CaptureTXResult",WhereClause="AllRecords.CaptureTXResult",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("VoidTXCommand",new SearchColumn(){Name="VoidTXCommand",Title="VoidTXCommand",SelectClause="VoidTXCommand",WhereClause="AllRecords.VoidTXCommand",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("VoidTXResult",new SearchColumn(){Name="VoidTXResult",Title="VoidTXResult",SelectClause="VoidTXResult",WhereClause="AllRecords.VoidTXResult",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RefundTXCommand",new SearchColumn(){Name="RefundTXCommand",Title="RefundTXCommand",SelectClause="RefundTXCommand",WhereClause="AllRecords.RefundTXCommand",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RefundTXResult",new SearchColumn(){Name="RefundTXResult",Title="RefundTXResult",SelectClause="RefundTXResult",WhereClause="AllRecords.RefundTXResult",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RefundReason",new SearchColumn(){Name="RefundReason",Title="RefundReason",SelectClause="RefundReason",WhereClause="AllRecords.RefundReason",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CardinalLookupResult",new SearchColumn(){Name="CardinalLookupResult",Title="CardinalLookupResult",SelectClause="CardinalLookupResult",WhereClause="AllRecords.CardinalLookupResult",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CardinalAuthenticateResult",new SearchColumn(){Name="CardinalAuthenticateResult",Title="CardinalAuthenticateResult",SelectClause="CardinalAuthenticateResult",WhereClause="AllRecords.CardinalAuthenticateResult",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CardinalGatewayParms",new SearchColumn(){Name="CardinalGatewayParms",Title="CardinalGatewayParms",SelectClause="CardinalGatewayParms",WhereClause="AllRecords.CardinalGatewayParms",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("AffiliateCommissionRecorded",new SearchColumn(){Name="AffiliateCommissionRecorded",Title="AffiliateCommissionRecorded",SelectClause="AffiliateCommissionRecorded",WhereClause="AllRecords.AffiliateCommissionRecorded",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderOptions",new SearchColumn(){Name="OrderOptions",Title="OrderOptions",SelectClause="OrderOptions",WhereClause="AllRecords.OrderOptions",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("OrderWeight",new SearchColumn(){Name="OrderWeight",Title="OrderWeight",SelectClause="OrderWeight",WhereClause="AllRecords.OrderWeight",DataType="System.Decimal",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("eCheckBankABACode",new SearchColumn(){Name="eCheckBankABACode",Title="eCheckBankABACode",SelectClause="eCheckBankABACode",WhereClause="AllRecords.eCheckBankABACode",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("eCheckBankAccountNumber",new SearchColumn(){Name="eCheckBankAccountNumber",Title="eCheckBankAccountNumber",SelectClause="eCheckBankAccountNumber",WhereClause="AllRecords.eCheckBankAccountNumber",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("eCheckBankAccountType",new SearchColumn(){Name="eCheckBankAccountType",Title="eCheckBankAccountType",SelectClause="eCheckBankAccountType",WhereClause="AllRecords.eCheckBankAccountType",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("eCheckBankName",new SearchColumn(){Name="eCheckBankName",Title="eCheckBankName",SelectClause="eCheckBankName",WhereClause="AllRecords.eCheckBankName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("eCheckBankAccountName",new SearchColumn(){Name="eCheckBankAccountName",Title="eCheckBankAccountName",SelectClause="eCheckBankAccountName",WhereClause="AllRecords.eCheckBankAccountName",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CarrierReportedRate",new SearchColumn(){Name="CarrierReportedRate",Title="CarrierReportedRate",SelectClause="CarrierReportedRate",WhereClause="AllRecords.CarrierReportedRate",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CarrierReportedWeight",new SearchColumn(){Name="CarrierReportedWeight",Title="CarrierReportedWeight",SelectClause="CarrierReportedWeight",WhereClause="AllRecords.CarrierReportedWeight",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("LocaleSetting",new SearchColumn(){Name="LocaleSetting",Title="LocaleSetting",SelectClause="LocaleSetting",WhereClause="AllRecords.LocaleSetting",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("FinalizationData",new SearchColumn(){Name="FinalizationData",Title="FinalizationData",SelectClause="FinalizationData",WhereClause="AllRecords.FinalizationData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ExtensionData",new SearchColumn(){Name="ExtensionData",Title="ExtensionData",SelectClause="ExtensionData",WhereClause="AllRecords.ExtensionData",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("AlreadyConfirmed",new SearchColumn(){Name="AlreadyConfirmed",Title="AlreadyConfirmed",SelectClause="AlreadyConfirmed",WhereClause="AllRecords.AlreadyConfirmed",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CartType",new SearchColumn(){Name="CartType",Title="CartType",SelectClause="CartType",WhereClause="AllRecords.CartType",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("THUB_POSTED_TO_ACCOUNTING",new SearchColumn(){Name="THUB_POSTED_TO_ACCOUNTING",Title="THUB_POSTED_TO_ACCOUNTING",SelectClause="THUB_POSTED_TO_ACCOUNTING",WhereClause="AllRecords.THUB_POSTED_TO_ACCOUNTING",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("THUB_POSTED_DATE",new SearchColumn(){Name="THUB_POSTED_DATE",Title="THUB_POSTED_DATE",SelectClause="THUB_POSTED_DATE",WhereClause="AllRecords.THUB_POSTED_DATE",DataType="System.DateTime?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("THUB_ACCOUNTING_REF",new SearchColumn(){Name="THUB_ACCOUNTING_REF",Title="THUB_ACCOUNTING_REF",SelectClause="THUB_ACCOUNTING_REF",WhereClause="AllRecords.THUB_ACCOUNTING_REF",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Last4",new SearchColumn(){Name="Last4",Title="Last4",SelectClause="Last4",WhereClause="AllRecords.Last4",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ReadyToShip",new SearchColumn(){Name="ReadyToShip",Title="ReadyToShip",SelectClause="ReadyToShip",WhereClause="AllRecords.ReadyToShip",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("IsPrinted",new SearchColumn(){Name="IsPrinted",Title="IsPrinted",SelectClause="IsPrinted",WhereClause="AllRecords.IsPrinted",DataType="System.Byte",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("AuthorizedOn",new SearchColumn(){Name="AuthorizedOn",Title="AuthorizedOn",SelectClause="AuthorizedOn",WhereClause="AllRecords.AuthorizedOn",DataType="System.DateTime?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("CapturedOn",new SearchColumn(){Name="CapturedOn",Title="CapturedOn",SelectClause="CapturedOn",WhereClause="AllRecords.CapturedOn",DataType="System.DateTime?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RefundedOn",new SearchColumn(){Name="RefundedOn",Title="RefundedOn",SelectClause="RefundedOn",WhereClause="AllRecords.RefundedOn",DataType="System.DateTime?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("VoidedOn",new SearchColumn(){Name="VoidedOn",Title="VoidedOn",SelectClause="VoidedOn",WhereClause="AllRecords.VoidedOn",DataType="System.DateTime?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("FraudedOn",new SearchColumn(){Name="FraudedOn",Title="FraudedOn",SelectClause="FraudedOn",WhereClause="AllRecords.FraudedOn",DataType="System.DateTime?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("EditedOn",new SearchColumn(){Name="EditedOn",Title="EditedOn",SelectClause="EditedOn",WhereClause="AllRecords.EditedOn",DataType="System.DateTime?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TrackingURL",new SearchColumn(){Name="TrackingURL",Title="TrackingURL",SelectClause="TrackingURL",WhereClause="AllRecords.TrackingURL",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ShippedEMailSentOn",new SearchColumn(){Name="ShippedEMailSentOn",Title="ShippedEMailSentOn",SelectClause="ShippedEMailSentOn",WhereClause="AllRecords.ShippedEMailSentOn",DataType="System.DateTime?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("InventoryWasReduced",new SearchColumn(){Name="InventoryWasReduced",Title="InventoryWasReduced",SelectClause="InventoryWasReduced",WhereClause="AllRecords.InventoryWasReduced",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("MaxMindFraudScore",new SearchColumn(){Name="MaxMindFraudScore",Title="MaxMindFraudScore",SelectClause="MaxMindFraudScore",WhereClause="AllRecords.MaxMindFraudScore",DataType="System.Decimal?",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("MaxMindDetails",new SearchColumn(){Name="MaxMindDetails",Title="MaxMindDetails",SelectClause="MaxMindDetails",WhereClause="AllRecords.MaxMindDetails",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("VATRegistrationID",new SearchColumn(){Name="VATRegistrationID",Title="VATRegistrationID",SelectClause="VATRegistrationID",WhereClause="AllRecords.VATRegistrationID",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("Crypt",new SearchColumn(){Name="Crypt",Title="Crypt",SelectClause="Crypt",WhereClause="AllRecords.Crypt",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("TransactionType",new SearchColumn(){Name="TransactionType",Title="TransactionType",SelectClause="TransactionType",WhereClause="AllRecords.TransactionType",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RecurringSubscriptionID",new SearchColumn(){Name="RecurringSubscriptionID",Title="RecurringSubscriptionID",SelectClause="RecurringSubscriptionID",WhereClause="AllRecords.RecurringSubscriptionID",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RecurringSubscriptionCommand",new SearchColumn(){Name="RecurringSubscriptionCommand",Title="RecurringSubscriptionCommand",SelectClause="RecurringSubscriptionCommand",WhereClause="AllRecords.RecurringSubscriptionCommand",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RecurringSubscriptionResult",new SearchColumn(){Name="RecurringSubscriptionResult",Title="RecurringSubscriptionResult",SelectClause="RecurringSubscriptionResult",WhereClause="AllRecords.RecurringSubscriptionResult",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("RelatedOrderNumber",new SearchColumn(){Name="RelatedOrderNumber",Title="RelatedOrderNumber",SelectClause="RelatedOrderNumber",WhereClause="AllRecords.RelatedOrderNumber",DataType="System.Int32",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("BuySafeCommand",new SearchColumn(){Name="BuySafeCommand",Title="BuySafeCommand",SelectClause="BuySafeCommand",WhereClause="AllRecords.BuySafeCommand",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("BuySafeResult",new SearchColumn(){Name="BuySafeResult",Title="BuySafeResult",SelectClause="BuySafeResult",WhereClause="AllRecords.BuySafeResult",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});
			this.SearchColumns.Add("ReceiptHtml",new SearchColumn(){Name="ReceiptHtml",Title="ReceiptHtml",SelectClause="ReceiptHtml",WhereClause="AllRecords.ReceiptHtml",DataType="System.String",IsForeignColumn=false,IsAdvanceSearchColumn = false,IsBasicSearchColumm = false});        
        }
        
		public virtual List<SearchColumn> GetOrdersSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                searchColumns.Add(keyValuePair.Value);
            }
            return searchColumns;
        }
		
		
		
        public virtual Dictionary<string, string> GetOrdersBasicSearchColumns()
        {
			Dictionary<string, string> columnList = new Dictionary<string, string>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                if (keyValuePair.Value.IsBasicSearchColumm)
                {
                    columnList.Add(keyValuePair.Key, keyValuePair.Value.Title);
                }
            }
            return columnList;
        }

        public virtual List<SearchColumn> GetOrdersAdvanceSearchColumns()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                if (keyValuePair.Value.IsAdvanceSearchColumn)
                {
                    searchColumns.Add(keyValuePair.Value);
                }
            }
            return searchColumns;
        }
        
        
        public virtual string GetOrdersSelectClause()
        {
            List<SearchColumn> searchColumns = new List<SearchColumn>();
            string selectQuery=string.Empty;
            foreach (KeyValuePair<string, SearchColumn> keyValuePair in this.SearchColumns)
            {
                if (!keyValuePair.Value.IgnoreForDefaultSelect)
                {
					if (keyValuePair.Value.IsForeignColumn)
                	{
						if(string.IsNullOrEmpty(selectQuery))
						{
							selectQuery = "("+keyValuePair.Value.SelectClause+") as \""+keyValuePair.Key+"\"";
						}
						else
						{
							selectQuery += ",(" + keyValuePair.Value.SelectClause + ") as \"" + keyValuePair.Key + "\"";
						}
                	}
                	else
                	{
                    	if (string.IsNullOrEmpty(selectQuery))
                    	{
                        	selectQuery =  "Orders."+keyValuePair.Key;
                    	}
                    	else
                    	{
                        	selectQuery += ",Orders."+keyValuePair.Key;
                    	}
                	}
            	}
            }
            return "Select "+selectQuery+" ";
        }
        

		public virtual Orders GetOrders(System.Int32 OrderNumber)
		{

			string sql=GetOrdersSelectClause();
			sql+="from Orders where OrderNumber=@OrderNumber ";
			SqlParameter parameter=new SqlParameter("@OrderNumber",OrderNumber);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count != 1) return null;
			return OrdersFromDataRow(ds.Tables[0].Rows[0]);
		}

        public virtual DataSet GetOrdersData(System.Int32 OrderNumber)
        {
            string sql = "select * from Orders where OrderNumber=@OrderNumber ";
            SqlParameter parameter = new SqlParameter("@OrderNumber", OrderNumber);
            DataSet ds = SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, sql, new SqlParameter[] { parameter });
            if (ds == null || ds.Tables[0].Rows.Count == 0) return null;
            return ds;
        }

		public virtual List<Orders> GetAllOrders()
		{

			string sql=GetOrdersSelectClause();
			sql+="from Orders";
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql,null);
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Orders>(ds, OrdersFromDataRow);
		}

		public virtual List<Orders> GetPagedOrders(string orderByClause, int pageSize, int startIndex,out int count, List<SearchColumn> searchColumns)
		{

			string whereClause = base.GetAdvancedWhereClauseByColumn(searchColumns, GetSearchColumns());
               if (!String.IsNullOrEmpty(orderByClause))
               {
                   KeyValuePair<string, string> parsedOrderByClause = base.ParseOrderByClause(orderByClause);
                   orderByClause = base.GetBasicSearchOrderByClauseByColumn(parsedOrderByClause.Key, parsedOrderByClause.Value, this.SearchColumns);
               }

            count=GetOrdersCount(whereClause, searchColumns);
			if(count>0)
			{
			if (count < startIndex) startIndex = (count / pageSize) * pageSize;			
			
           	int PageLowerBound = startIndex;
            int PageUpperBound = PageLowerBound + pageSize;
            string sql = @"CREATE TABLE #PageIndex
				            (
				                [IndexId] int IDENTITY (1, 1) NOT NULL,
				                [OrderNumber] int				   
				            );";

            //Insert into the temp table
            string tempsql = "INSERT INTO #PageIndex ([OrderNumber])";
            tempsql += " SELECT ";
            if (pageSize > 0) tempsql += "TOP " + PageUpperBound.ToString();
            tempsql += " [OrderNumber] ";
            tempsql += " FROM [Orders] AllRecords";
            if (!string.IsNullOrEmpty(whereClause) && whereClause.Length > 0) tempsql += " WHERE " + whereClause;
            if (orderByClause.Length > 0) 
			{
				tempsql += " ORDER BY " + orderByClause;
				if( !orderByClause.Contains("OrderNumber"))
					tempsql += " , (AllRecords.[OrderNumber])"; 
			}
			else 
			{
				tempsql  += " ORDER BY (AllRecords.[OrderNumber])"; 
			}           
            
            // Return paged results
            string pagedResultsSql =
                GetOrdersSelectClause()+@" FROM [Orders], #PageIndex PageIndex WHERE ";
            pagedResultsSql += " PageIndex.IndexId > " + PageLowerBound.ToString(); 
            pagedResultsSql += @" AND [Orders].[OrderNumber] = PageIndex.[OrderNumber] 
				                  ORDER BY PageIndex.IndexId;";
            pagedResultsSql += " drop table #PageIndex";
            sql = sql + tempsql + pagedResultsSql;
			sql = string.Format(sql, whereClause, pageSize, startIndex, orderByClause);
			DataSet ds=SqlHelper.ExecuteDataset(this.ConnectionString,CommandType.Text,sql, GetSQLParamtersBySearchColumns(searchColumns));
			if (ds == null || ds.Tables.Count != 1 || ds.Tables[0].Rows.Count == 0) return null;
			return CollectionFromDataSet<Orders>(ds, OrdersFromDataRow);
			}else{ return null;}
		}

		private int GetOrdersCount(string whereClause, List<SearchColumn> searchColumns)
		{

			string sql=string.Empty;
			if(string.IsNullOrEmpty(whereClause))
				sql = "SELECT Count(*) FROM Orders as AllRecords ";
			else
				sql = "SELECT Count(*) FROM Orders as AllRecords where  " +whereClause;
			var rowCount = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, GetSQLParamtersBySearchColumns(searchColumns));
			return rowCount == DBNull.Value ? 0 :(int)rowCount;
		}

		[MOLog(AuditOperations.Create,typeof(Orders))]
		public virtual Orders InsertOrders(Orders entity)
		{

			Orders other=new Orders();
			other = entity;
			if(entity.IsTransient())
			{
				string sql=@"Insert into Orders ( [OrderNumber]
				,[OrderGUID]
				,[StoreID]
				,[ParentOrderNumber]
				,[StoreVersion]
				,[QuoteCheckout]
				,[IsNew]
				,[ShippedOn]
				,[CustomerID]
				,[CustomerGUID]
				,[Referrer]
				,[SkinID]
				,[LastName]
				,[FirstName]
				,[Email]
				,[Notes]
				,[BillingEqualsShipping]
				,[BillingLastName]
				,[BillingFirstName]
				,[BillingCompany]
				,[BillingAddress1]
				,[BillingAddress2]
				,[BillingSuite]
				,[BillingCity]
				,[BillingState]
				,[BillingZip]
				,[BillingCountry]
				,[BillingPhone]
				,[ShippingLastName]
				,[ShippingFirstName]
				,[ShippingCompany]
				,[ShippingResidenceType]
				,[ShippingAddress1]
				,[ShippingAddress2]
				,[ShippingSuite]
				,[ShippingCity]
				,[ShippingState]
				,[ShippingZip]
				,[ShippingCountry]
				,[ShippingMethodID]
				,[ShippingMethod]
				,[ShippingPhone]
				,[ShippingCalculationID]
				,[Phone]
				,[RegisterDate]
				,[AffiliateID]
				,[CouponCode]
				,[CouponType]
				,[CouponDescription]
				,[CouponDiscountAmount]
				,[CouponDiscountPercent]
				,[CouponIncludesFreeShipping]
				,[OkToEmail]
				,[Deleted]
				,[CardType]
				,[CardName]
				,[CardNumber]
				,[CardExpirationMonth]
				,[CardExpirationYear]
				,[CardStartDate]
				,[CardIssueNumber]
				,[OrderSubtotal]
				,[OrderTax]
				,[OrderShippingCosts]
				,[OrderTotal]
				,[PaymentGateway]
				,[AuthorizationCode]
				,[AuthorizationResult]
				,[AuthorizationPNREF]
				,[TransactionCommand]
				,[OrderDate]
				,[LevelID]
				,[LevelName]
				,[LevelDiscountPercent]
				,[LevelDiscountAmount]
				,[LevelHasFreeShipping]
				,[LevelAllowsQuantityDiscounts]
				,[LevelHasNoTax]
				,[LevelAllowsCoupons]
				,[LevelDiscountsApplyToExtendedPrices]
				,[LastIPAddress]
				,[PaymentMethod]
				,[OrderNotes]
				,[PONumber]
				,[DownloadEmailSentOn]
				,[ReceiptEmailSentOn]
				,[DistributorEmailSentOn]
				,[ShippingTrackingNumber]
				,[ShippedVIA]
				,[CustomerServiceNotes]
				,[RTShipRequest]
				,[RTShipResponse]
				,[TransactionState]
				,[AVSResult]
				,[CaptureTXCommand]
				,[CaptureTXResult]
				,[VoidTXCommand]
				,[VoidTXResult]
				,[RefundTXCommand]
				,[RefundTXResult]
				,[RefundReason]
				,[CardinalLookupResult]
				,[CardinalAuthenticateResult]
				,[CardinalGatewayParms]
				,[AffiliateCommissionRecorded]
				,[OrderOptions]
				,[OrderWeight]
				,[eCheckBankABACode]
				,[eCheckBankAccountNumber]
				,[eCheckBankAccountType]
				,[eCheckBankName]
				,[eCheckBankAccountName]
				,[CarrierReportedRate]
				,[CarrierReportedWeight]
				,[LocaleSetting]
				,[FinalizationData]
				,[ExtensionData]
				,[AlreadyConfirmed]
				,[CartType]
				,[THUB_POSTED_TO_ACCOUNTING]
				,[THUB_POSTED_DATE]
				,[THUB_ACCOUNTING_REF]
				,[Last4]
				,[ReadyToShip]
				,[IsPrinted]
				,[AuthorizedOn]
				,[CapturedOn]
				,[RefundedOn]
				,[VoidedOn]
				,[FraudedOn]
				,[EditedOn]
				,[TrackingURL]
				,[ShippedEMailSentOn]
				,[InventoryWasReduced]
				,[MaxMindFraudScore]
				,[MaxMindDetails]
				,[VATRegistrationID]
				,[Crypt]
				,[TransactionType]
				,[RecurringSubscriptionID]
				,[RecurringSubscriptionCommand]
				,[RecurringSubscriptionResult]
				,[RelatedOrderNumber]
				,[BuySafeCommand]
				,[BuySafeResult]
				,[ReceiptHtml] )
				Values
				( @OrderNumber
				, @OrderGUID
				, @StoreID
				, @ParentOrderNumber
				, @StoreVersion
				, @QuoteCheckout
				, @IsNew
				, @ShippedOn
				, @CustomerID
				, @CustomerGUID
				, @Referrer
				, @SkinID
				, @LastName
				, @FirstName
				, @Email
				, @Notes
				, @BillingEqualsShipping
				, @BillingLastName
				, @BillingFirstName
				, @BillingCompany
				, @BillingAddress1
				, @BillingAddress2
				, @BillingSuite
				, @BillingCity
				, @BillingState
				, @BillingZip
				, @BillingCountry
				, @BillingPhone
				, @ShippingLastName
				, @ShippingFirstName
				, @ShippingCompany
				, @ShippingResidenceType
				, @ShippingAddress1
				, @ShippingAddress2
				, @ShippingSuite
				, @ShippingCity
				, @ShippingState
				, @ShippingZip
				, @ShippingCountry
				, @ShippingMethodID
				, @ShippingMethod
				, @ShippingPhone
				, @ShippingCalculationID
				, @Phone
				, @RegisterDate
				, @AffiliateID
				, @CouponCode
				, @CouponType
				, @CouponDescription
				, @CouponDiscountAmount
				, @CouponDiscountPercent
				, @CouponIncludesFreeShipping
				, @OkToEmail
				, @Deleted
				, @CardType
				, @CardName
				, @CardNumber
				, @CardExpirationMonth
				, @CardExpirationYear
				, @CardStartDate
				, @CardIssueNumber
				, @OrderSubtotal
				, @OrderTax
				, @OrderShippingCosts
				, @OrderTotal
				, @PaymentGateway
				, @AuthorizationCode
				, @AuthorizationResult
				, @AuthorizationPNREF
				, @TransactionCommand
				, @OrderDate
				, @LevelID
				, @LevelName
				, @LevelDiscountPercent
				, @LevelDiscountAmount
				, @LevelHasFreeShipping
				, @LevelAllowsQuantityDiscounts
				, @LevelHasNoTax
				, @LevelAllowsCoupons
				, @LevelDiscountsApplyToExtendedPrices
				, @LastIPAddress
				, @PaymentMethod
				, @OrderNotes
				, @PONumber
				, @DownloadEmailSentOn
				, @ReceiptEmailSentOn
				, @DistributorEmailSentOn
				, @ShippingTrackingNumber
				, @ShippedVIA
				, @CustomerServiceNotes
				, @RTShipRequest
				, @RTShipResponse
				, @TransactionState
				, @AVSResult
				, @CaptureTXCommand
				, @CaptureTXResult
				, @VoidTXCommand
				, @VoidTXResult
				, @RefundTXCommand
				, @RefundTXResult
				, @RefundReason
				, @CardinalLookupResult
				, @CardinalAuthenticateResult
				, @CardinalGatewayParms
				, @AffiliateCommissionRecorded
				, @OrderOptions
				, @OrderWeight
				, @eCheckBankABACode
				, @eCheckBankAccountNumber
				, @eCheckBankAccountType
				, @eCheckBankName
				, @eCheckBankAccountName
				, @CarrierReportedRate
				, @CarrierReportedWeight
				, @LocaleSetting
				, @FinalizationData
				, @ExtensionData
				, @AlreadyConfirmed
				, @CartType
				, @THUB_POSTED_TO_ACCOUNTING
				, @THUB_POSTED_DATE
				, @THUB_ACCOUNTING_REF
				, @Last4
				, @ReadyToShip
				, @IsPrinted
				, @AuthorizedOn
				, @CapturedOn
				, @RefundedOn
				, @VoidedOn
				, @FraudedOn
				, @EditedOn
				, @TrackingURL
				, @ShippedEMailSentOn
				, @InventoryWasReduced
				, @MaxMindFraudScore
				, @MaxMindDetails
				, @VATRegistrationID
				, @Crypt
				, @TransactionType
				, @RecurringSubscriptionID
				, @RecurringSubscriptionCommand
				, @RecurringSubscriptionResult
				, @RelatedOrderNumber
				, @BuySafeCommand
				, @BuySafeResult
				, @ReceiptHtml );
				Select scope_identity()";
				SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@OrderNumber",entity.OrderNumber)
					, new SqlParameter("@OrderGUID",entity.OrderGuid)
					, new SqlParameter("@StoreID",entity.StoreId)
					, new SqlParameter("@ParentOrderNumber",entity.ParentOrderNumber ?? (object)DBNull.Value)
					, new SqlParameter("@StoreVersion",entity.StoreVersion ?? (object)DBNull.Value)
					, new SqlParameter("@QuoteCheckout",entity.QuoteCheckout)
					, new SqlParameter("@IsNew",entity.IsNew)
					, new SqlParameter("@ShippedOn",entity.ShippedOn ?? (object)DBNull.Value)
					, new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@CustomerGUID",entity.CustomerGuid)
					, new SqlParameter("@Referrer",entity.Referrer ?? (object)DBNull.Value)
					, new SqlParameter("@SkinID",entity.SkinId)
					, new SqlParameter("@LastName",entity.LastName ?? (object)DBNull.Value)
					, new SqlParameter("@FirstName",entity.FirstName ?? (object)DBNull.Value)
					, new SqlParameter("@Email",entity.Email ?? (object)DBNull.Value)
					, new SqlParameter("@Notes",entity.Notes ?? (object)DBNull.Value)
					, new SqlParameter("@BillingEqualsShipping",entity.BillingEqualsShipping)
					, new SqlParameter("@BillingLastName",entity.BillingLastName ?? (object)DBNull.Value)
					, new SqlParameter("@BillingFirstName",entity.BillingFirstName ?? (object)DBNull.Value)
					, new SqlParameter("@BillingCompany",entity.BillingCompany ?? (object)DBNull.Value)
					, new SqlParameter("@BillingAddress1",entity.BillingAddress1 ?? (object)DBNull.Value)
					, new SqlParameter("@BillingAddress2",entity.BillingAddress2 ?? (object)DBNull.Value)
					, new SqlParameter("@BillingSuite",entity.BillingSuite ?? (object)DBNull.Value)
					, new SqlParameter("@BillingCity",entity.BillingCity ?? (object)DBNull.Value)
					, new SqlParameter("@BillingState",entity.BillingState ?? (object)DBNull.Value)
					, new SqlParameter("@BillingZip",entity.BillingZip ?? (object)DBNull.Value)
					, new SqlParameter("@BillingCountry",entity.BillingCountry ?? (object)DBNull.Value)
					, new SqlParameter("@BillingPhone",entity.BillingPhone ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingLastName",entity.ShippingLastName ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingFirstName",entity.ShippingFirstName ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingCompany",entity.ShippingCompany ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingResidenceType",entity.ShippingResidenceType)
					, new SqlParameter("@ShippingAddress1",entity.ShippingAddress1 ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingAddress2",entity.ShippingAddress2 ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingSuite",entity.ShippingSuite ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingCity",entity.ShippingCity ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingState",entity.ShippingState ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingZip",entity.ShippingZip ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingCountry",entity.ShippingCountry ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingMethodID",entity.ShippingMethodId)
					, new SqlParameter("@ShippingMethod",entity.ShippingMethod ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingPhone",entity.ShippingPhone ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingCalculationID",entity.ShippingCalculationId ?? (object)DBNull.Value)
					, new SqlParameter("@Phone",entity.Phone ?? (object)DBNull.Value)
					, new SqlParameter("@RegisterDate",entity.RegisterDate ?? (object)DBNull.Value)
					, new SqlParameter("@AffiliateID",entity.AffiliateId ?? (object)DBNull.Value)
					, new SqlParameter("@CouponCode",entity.CouponCode ?? (object)DBNull.Value)
					, new SqlParameter("@CouponType",entity.CouponType)
					, new SqlParameter("@CouponDescription",entity.CouponDescription ?? (object)DBNull.Value)
					, new SqlParameter("@CouponDiscountAmount",entity.CouponDiscountAmount ?? (object)DBNull.Value)
					, new SqlParameter("@CouponDiscountPercent",entity.CouponDiscountPercent ?? (object)DBNull.Value)
					, new SqlParameter("@CouponIncludesFreeShipping",entity.CouponIncludesFreeShipping ?? (object)DBNull.Value)
					, new SqlParameter("@OkToEmail",entity.OkToEmail ?? (object)DBNull.Value)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CardType",entity.CardType ?? (object)DBNull.Value)
					, new SqlParameter("@CardName",entity.CardName ?? (object)DBNull.Value)
					, new SqlParameter("@CardNumber",entity.CardNumber ?? (object)DBNull.Value)
					, new SqlParameter("@CardExpirationMonth",entity.CardExpirationMonth ?? (object)DBNull.Value)
					, new SqlParameter("@CardExpirationYear",entity.CardExpirationYear ?? (object)DBNull.Value)
					, new SqlParameter("@CardStartDate",entity.CardStartDate ?? (object)DBNull.Value)
					, new SqlParameter("@CardIssueNumber",entity.CardIssueNumber ?? (object)DBNull.Value)
					, new SqlParameter("@OrderSubtotal",entity.OrderSubtotal)
					, new SqlParameter("@OrderTax",entity.OrderTax)
					, new SqlParameter("@OrderShippingCosts",entity.OrderShippingCosts)
					, new SqlParameter("@OrderTotal",entity.OrderTotal)
					, new SqlParameter("@PaymentGateway",entity.PaymentGateway ?? (object)DBNull.Value)
					, new SqlParameter("@AuthorizationCode",entity.AuthorizationCode ?? (object)DBNull.Value)
					, new SqlParameter("@AuthorizationResult",entity.AuthorizationResult ?? (object)DBNull.Value)
					, new SqlParameter("@AuthorizationPNREF",entity.AuthorizationPnref ?? (object)DBNull.Value)
					, new SqlParameter("@TransactionCommand",entity.TransactionCommand ?? (object)DBNull.Value)
					, new SqlParameter("@OrderDate",entity.OrderDate)
					, new SqlParameter("@LevelID",entity.LevelId ?? (object)DBNull.Value)
					, new SqlParameter("@LevelName",entity.LevelName ?? (object)DBNull.Value)
					, new SqlParameter("@LevelDiscountPercent",entity.LevelDiscountPercent ?? (object)DBNull.Value)
					, new SqlParameter("@LevelDiscountAmount",entity.LevelDiscountAmount ?? (object)DBNull.Value)
					, new SqlParameter("@LevelHasFreeShipping",entity.LevelHasFreeShipping ?? (object)DBNull.Value)
					, new SqlParameter("@LevelAllowsQuantityDiscounts",entity.LevelAllowsQuantityDiscounts ?? (object)DBNull.Value)
					, new SqlParameter("@LevelHasNoTax",entity.LevelHasNoTax ?? (object)DBNull.Value)
					, new SqlParameter("@LevelAllowsCoupons",entity.LevelAllowsCoupons ?? (object)DBNull.Value)
					, new SqlParameter("@LevelDiscountsApplyToExtendedPrices",entity.LevelDiscountsApplyToExtendedPrices ?? (object)DBNull.Value)
					, new SqlParameter("@LastIPAddress",entity.LastIpAddress ?? (object)DBNull.Value)
					, new SqlParameter("@PaymentMethod",entity.PaymentMethod ?? (object)DBNull.Value)
					, new SqlParameter("@OrderNotes",entity.OrderNotes ?? (object)DBNull.Value)
					, new SqlParameter("@PONumber",entity.PoNumber ?? (object)DBNull.Value)
					, new SqlParameter("@DownloadEmailSentOn",entity.DownloadEmailSentOn ?? (object)DBNull.Value)
					, new SqlParameter("@ReceiptEmailSentOn",entity.ReceiptEmailSentOn ?? (object)DBNull.Value)
					, new SqlParameter("@DistributorEmailSentOn",entity.DistributorEmailSentOn ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingTrackingNumber",entity.ShippingTrackingNumber ?? (object)DBNull.Value)
					, new SqlParameter("@ShippedVIA",entity.ShippedVia ?? (object)DBNull.Value)
					, new SqlParameter("@CustomerServiceNotes",entity.CustomerServiceNotes ?? (object)DBNull.Value)
					, new SqlParameter("@RTShipRequest",entity.RtShipRequest ?? (object)DBNull.Value)
					, new SqlParameter("@RTShipResponse",entity.RtShipResponse ?? (object)DBNull.Value)
					, new SqlParameter("@TransactionState",entity.TransactionState ?? (object)DBNull.Value)
					, new SqlParameter("@AVSResult",entity.AvsResult ?? (object)DBNull.Value)
					, new SqlParameter("@CaptureTXCommand",entity.CaptureTxCommand ?? (object)DBNull.Value)
					, new SqlParameter("@CaptureTXResult",entity.CaptureTxResult ?? (object)DBNull.Value)
					, new SqlParameter("@VoidTXCommand",entity.VoidTxCommand ?? (object)DBNull.Value)
					, new SqlParameter("@VoidTXResult",entity.VoidTxResult ?? (object)DBNull.Value)
					, new SqlParameter("@RefundTXCommand",entity.RefundTxCommand ?? (object)DBNull.Value)
					, new SqlParameter("@RefundTXResult",entity.RefundTxResult ?? (object)DBNull.Value)
					, new SqlParameter("@RefundReason",entity.RefundReason ?? (object)DBNull.Value)
					, new SqlParameter("@CardinalLookupResult",entity.CardinalLookupResult ?? (object)DBNull.Value)
					, new SqlParameter("@CardinalAuthenticateResult",entity.CardinalAuthenticateResult ?? (object)DBNull.Value)
					, new SqlParameter("@CardinalGatewayParms",entity.CardinalGatewayParms ?? (object)DBNull.Value)
					, new SqlParameter("@AffiliateCommissionRecorded",entity.AffiliateCommissionRecorded)
					, new SqlParameter("@OrderOptions",entity.OrderOptions ?? (object)DBNull.Value)
					, new SqlParameter("@OrderWeight",entity.OrderWeight)
					, new SqlParameter("@eCheckBankABACode",entity.ECheckBankAbaCode ?? (object)DBNull.Value)
					, new SqlParameter("@eCheckBankAccountNumber",entity.ECheckBankAccountNumber ?? (object)DBNull.Value)
					, new SqlParameter("@eCheckBankAccountType",entity.ECheckBankAccountType ?? (object)DBNull.Value)
					, new SqlParameter("@eCheckBankName",entity.ECheckBankName ?? (object)DBNull.Value)
					, new SqlParameter("@eCheckBankAccountName",entity.ECheckBankAccountName ?? (object)DBNull.Value)
					, new SqlParameter("@CarrierReportedRate",entity.CarrierReportedRate ?? (object)DBNull.Value)
					, new SqlParameter("@CarrierReportedWeight",entity.CarrierReportedWeight ?? (object)DBNull.Value)
					, new SqlParameter("@LocaleSetting",entity.LocaleSetting ?? (object)DBNull.Value)
					, new SqlParameter("@FinalizationData",entity.FinalizationData ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@AlreadyConfirmed",entity.AlreadyConfirmed)
					, new SqlParameter("@CartType",entity.CartType)
					, new SqlParameter("@THUB_POSTED_TO_ACCOUNTING",entity.ThubPostedToAccounting ?? (object)DBNull.Value)
					, new SqlParameter("@THUB_POSTED_DATE",entity.ThubPostedDate ?? (object)DBNull.Value)
					, new SqlParameter("@THUB_ACCOUNTING_REF",entity.ThubAccountingRef ?? (object)DBNull.Value)
					, new SqlParameter("@Last4",entity.Last4 ?? (object)DBNull.Value)
					, new SqlParameter("@ReadyToShip",entity.ReadyToShip)
					, new SqlParameter("@IsPrinted",entity.IsPrinted)
					, new SqlParameter("@AuthorizedOn",entity.AuthorizedOn ?? (object)DBNull.Value)
					, new SqlParameter("@CapturedOn",entity.CapturedOn ?? (object)DBNull.Value)
					, new SqlParameter("@RefundedOn",entity.RefundedOn ?? (object)DBNull.Value)
					, new SqlParameter("@VoidedOn",entity.VoidedOn ?? (object)DBNull.Value)
					, new SqlParameter("@FraudedOn",entity.FraudedOn ?? (object)DBNull.Value)
					, new SqlParameter("@EditedOn",entity.EditedOn ?? (object)DBNull.Value)
					, new SqlParameter("@TrackingURL",entity.TrackingUrl ?? (object)DBNull.Value)
					, new SqlParameter("@ShippedEMailSentOn",entity.ShippedEmailSentOn ?? (object)DBNull.Value)
					, new SqlParameter("@InventoryWasReduced",entity.InventoryWasReduced)
					, new SqlParameter("@MaxMindFraudScore",entity.MaxMindFraudScore ?? (object)DBNull.Value)
					, new SqlParameter("@MaxMindDetails",entity.MaxMindDetails ?? (object)DBNull.Value)
					, new SqlParameter("@VATRegistrationID",entity.VatRegistrationId ?? (object)DBNull.Value)
					, new SqlParameter("@Crypt",entity.Crypt )
					, new SqlParameter("@TransactionType",entity.TransactionType)
					, new SqlParameter("@RecurringSubscriptionID",entity.RecurringSubscriptionId)
					, new SqlParameter("@RecurringSubscriptionCommand",entity.RecurringSubscriptionCommand)
					, new SqlParameter("@RecurringSubscriptionResult",entity.RecurringSubscriptionResult)
					, new SqlParameter("@RelatedOrderNumber",entity.RelatedOrderNumber)
					, new SqlParameter("@BuySafeCommand",entity.BuySafeCommand)
					, new SqlParameter("@BuySafeResult",entity.BuySafeResult)
					, new SqlParameter("@ReceiptHtml",entity.ReceiptHtml ?? (object)DBNull.Value)};
				var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,parameterArray);
				if(identity==DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
				return GetOrders(Convert.ToInt32(identity));
			}
			return entity;
		}


        [MOLog(AuditOperations.Create, typeof(Orders))]
        public virtual int iabazaarInsertOrders(Orders entity)
        {
            try
            {
                Orders other = new Orders();
                other = entity;
                string sql = @"Insert into Orders (
				[CustomerID]
				,[BillingAddress1]
				,[BillingAddress2]
				,[BillingSuite]
				,[BillingCity]
				,[BillingState]
				,[BillingZip]
				,[BillingCountry]
				,[BillingPhone]
				,[ShippingAddress1]
				,[ShippingAddress2]
				,[ShippingSuite]
				,[ShippingCity]
				,[ShippingState]
				,[ShippingZip]
				,[ShippingCountry]
				,[ShippingPhone]
				,[OrderSubtotal]
				,[OrderShippingCosts]
				,[OrderTotal]
                ,[Email]
                ,[Phone]
                ,[FirstName]
                ,[LastName]
                ,[OrderStatus]
                )
				Values
				( @CustomerID
				, @BillingAddress1
				, @BillingAddress2
				, @BillingSuite
				, @BillingCity
				, @BillingState
				, @BillingZip
				, @BillingCountry
				, @BillingPhone
				, @ShippingAddress1
				, @ShippingAddress2
				, @ShippingSuite
				, @ShippingCity
				, @ShippingState
				, @ShippingZip
				, @ShippingCountry
				, @ShippingPhone
				, @OrderSubtotal
				, @OrderShippingCosts
				, @OrderTotal
                , @Email
                , @Phone
                , @FirstName
                , @LastName
                , @OrderStatus
				);
				Select scope_identity()";
                SqlParameter[] parameterArray = new SqlParameter[]{
					 new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@BillingAddress1",entity.BillingAddress1 ?? (object)DBNull.Value)
					, new SqlParameter("@BillingAddress2",entity.BillingAddress2 ?? (object)DBNull.Value)
					, new SqlParameter("@BillingSuite",entity.BillingSuite ?? (object)DBNull.Value)
					, new SqlParameter("@BillingCity",entity.BillingCity ?? (object)DBNull.Value)
					, new SqlParameter("@BillingState",entity.BillingState ?? (object)DBNull.Value)
					, new SqlParameter("@BillingZip",entity.BillingZip ?? (object)DBNull.Value)
					, new SqlParameter("@BillingCountry",entity.BillingCountry ?? (object)DBNull.Value)
					, new SqlParameter("@BillingPhone",entity.BillingPhone ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingAddress1",entity.ShippingAddress1 ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingAddress2",entity.ShippingAddress2 ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingSuite",entity.ShippingSuite ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingCity",entity.ShippingCity ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingState",entity.ShippingState ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingZip",entity.ShippingZip ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingCountry",entity.ShippingCountry ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingPhone",entity.ShippingPhone ?? (object)DBNull.Value)
					, new SqlParameter("@OrderSubtotal",entity.OrderSubtotal)
					, new SqlParameter("@OrderShippingCosts",entity.OrderShippingCosts)
					, new SqlParameter("@OrderTotal",entity.OrderTotal)
                    , new SqlParameter("@Email",entity.Email)
                    , new SqlParameter("@Phone",entity.Phone)
                    , new SqlParameter("@FirstName",entity.FirstName)
                    , new SqlParameter("@LastName",entity.LastName)
                    , new SqlParameter("@OrderStatus",entity.OrderStatus)
					};
                var identity = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql, parameterArray);
                if (identity == DBNull.Value) throw new DataException("Identity column was null as a result of the insert operation.");
                return Convert.ToInt32(identity);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

		[MOLog(AuditOperations.Update,typeof(Orders))]
		public virtual Orders UpdateOrders(Orders entity)
		{

			if (entity.IsTransient()) return entity;
			Orders other = GetOrders(entity.OrderNumber);
			if (entity.Equals(other)) return entity;
			string sql=@"Update Orders set  [OrderGUID]=@OrderGUID
							, [StoreID]=@StoreID
							, [ParentOrderNumber]=@ParentOrderNumber
							, [StoreVersion]=@StoreVersion
							, [QuoteCheckout]=@QuoteCheckout
							, [IsNew]=@IsNew
							, [ShippedOn]=@ShippedOn
							, [CustomerID]=@CustomerID
							, [CustomerGUID]=@CustomerGUID
							, [Referrer]=@Referrer
							, [SkinID]=@SkinID
							, [LastName]=@LastName
							, [FirstName]=@FirstName
							, [Email]=@Email
							, [Notes]=@Notes
							, [BillingEqualsShipping]=@BillingEqualsShipping
							, [BillingLastName]=@BillingLastName
							, [BillingFirstName]=@BillingFirstName
							, [BillingCompany]=@BillingCompany
							, [BillingAddress1]=@BillingAddress1
							, [BillingAddress2]=@BillingAddress2
							, [BillingSuite]=@BillingSuite
							, [BillingCity]=@BillingCity
							, [BillingState]=@BillingState
							, [BillingZip]=@BillingZip
							, [BillingCountry]=@BillingCountry
							, [BillingPhone]=@BillingPhone
							, [ShippingLastName]=@ShippingLastName
							, [ShippingFirstName]=@ShippingFirstName
							, [ShippingCompany]=@ShippingCompany
							, [ShippingResidenceType]=@ShippingResidenceType
							, [ShippingAddress1]=@ShippingAddress1
							, [ShippingAddress2]=@ShippingAddress2
							, [ShippingSuite]=@ShippingSuite
							, [ShippingCity]=@ShippingCity
							, [ShippingState]=@ShippingState
							, [ShippingZip]=@ShippingZip
							, [ShippingCountry]=@ShippingCountry
							, [ShippingMethodID]=@ShippingMethodID
							, [ShippingMethod]=@ShippingMethod
							, [ShippingPhone]=@ShippingPhone
							, [ShippingCalculationID]=@ShippingCalculationID
							, [Phone]=@Phone
							, [RegisterDate]=@RegisterDate
							, [AffiliateID]=@AffiliateID
							, [CouponCode]=@CouponCode
							, [CouponType]=@CouponType
							, [CouponDescription]=@CouponDescription
							, [CouponDiscountAmount]=@CouponDiscountAmount
							, [CouponDiscountPercent]=@CouponDiscountPercent
							, [CouponIncludesFreeShipping]=@CouponIncludesFreeShipping
							, [OkToEmail]=@OkToEmail
							, [Deleted]=@Deleted
							, [CardType]=@CardType
							, [CardName]=@CardName
							, [CardNumber]=@CardNumber
							, [CardExpirationMonth]=@CardExpirationMonth
							, [CardExpirationYear]=@CardExpirationYear
							, [CardStartDate]=@CardStartDate
							, [CardIssueNumber]=@CardIssueNumber
							, [OrderSubtotal]=@OrderSubtotal
							, [OrderTax]=@OrderTax
							, [OrderShippingCosts]=@OrderShippingCosts
							, [OrderTotal]=@OrderTotal
							, [PaymentGateway]=@PaymentGateway
							, [AuthorizationCode]=@AuthorizationCode
							, [AuthorizationResult]=@AuthorizationResult
							, [AuthorizationPNREF]=@AuthorizationPNREF
							, [TransactionCommand]=@TransactionCommand
							, [OrderDate]=@OrderDate
							, [LevelID]=@LevelID
							, [LevelName]=@LevelName
							, [LevelDiscountPercent]=@LevelDiscountPercent
							, [LevelDiscountAmount]=@LevelDiscountAmount
							, [LevelHasFreeShipping]=@LevelHasFreeShipping
							, [LevelAllowsQuantityDiscounts]=@LevelAllowsQuantityDiscounts
							, [LevelHasNoTax]=@LevelHasNoTax
							, [LevelAllowsCoupons]=@LevelAllowsCoupons
							, [LevelDiscountsApplyToExtendedPrices]=@LevelDiscountsApplyToExtendedPrices
							, [LastIPAddress]=@LastIPAddress
							, [PaymentMethod]=@PaymentMethod
							, [OrderNotes]=@OrderNotes
							, [PONumber]=@PONumber
							, [DownloadEmailSentOn]=@DownloadEmailSentOn
							, [ReceiptEmailSentOn]=@ReceiptEmailSentOn
							, [DistributorEmailSentOn]=@DistributorEmailSentOn
							, [ShippingTrackingNumber]=@ShippingTrackingNumber
							, [ShippedVIA]=@ShippedVIA
							, [CustomerServiceNotes]=@CustomerServiceNotes
							, [RTShipRequest]=@RTShipRequest
							, [RTShipResponse]=@RTShipResponse
							, [TransactionState]=@TransactionState
							, [AVSResult]=@AVSResult
							, [CaptureTXCommand]=@CaptureTXCommand
							, [CaptureTXResult]=@CaptureTXResult
							, [VoidTXCommand]=@VoidTXCommand
							, [VoidTXResult]=@VoidTXResult
							, [RefundTXCommand]=@RefundTXCommand
							, [RefundTXResult]=@RefundTXResult
							, [RefundReason]=@RefundReason
							, [CardinalLookupResult]=@CardinalLookupResult
							, [CardinalAuthenticateResult]=@CardinalAuthenticateResult
							, [CardinalGatewayParms]=@CardinalGatewayParms
							, [AffiliateCommissionRecorded]=@AffiliateCommissionRecorded
							, [OrderOptions]=@OrderOptions
							, [OrderWeight]=@OrderWeight
							, [eCheckBankABACode]=@eCheckBankABACode
							, [eCheckBankAccountNumber]=@eCheckBankAccountNumber
							, [eCheckBankAccountType]=@eCheckBankAccountType
							, [eCheckBankName]=@eCheckBankName
							, [eCheckBankAccountName]=@eCheckBankAccountName
							, [CarrierReportedRate]=@CarrierReportedRate
							, [CarrierReportedWeight]=@CarrierReportedWeight
							, [LocaleSetting]=@LocaleSetting
							, [FinalizationData]=@FinalizationData
							, [ExtensionData]=@ExtensionData
							, [AlreadyConfirmed]=@AlreadyConfirmed
							, [CartType]=@CartType
							, [THUB_POSTED_TO_ACCOUNTING]=@THUB_POSTED_TO_ACCOUNTING
							, [THUB_POSTED_DATE]=@THUB_POSTED_DATE
							, [THUB_ACCOUNTING_REF]=@THUB_ACCOUNTING_REF
							, [Last4]=@Last4
							, [ReadyToShip]=@ReadyToShip
							, [IsPrinted]=@IsPrinted
							, [AuthorizedOn]=@AuthorizedOn
							, [CapturedOn]=@CapturedOn
							, [RefundedOn]=@RefundedOn
							, [VoidedOn]=@VoidedOn
							, [FraudedOn]=@FraudedOn
							, [EditedOn]=@EditedOn
							, [TrackingURL]=@TrackingURL
							, [ShippedEMailSentOn]=@ShippedEMailSentOn
							, [InventoryWasReduced]=@InventoryWasReduced
							, [MaxMindFraudScore]=@MaxMindFraudScore
							, [MaxMindDetails]=@MaxMindDetails
							, [VATRegistrationID]=@VATRegistrationID
							, [Crypt]=@Crypt
							, [TransactionType]=@TransactionType
							, [RecurringSubscriptionID]=@RecurringSubscriptionID
							, [RecurringSubscriptionCommand]=@RecurringSubscriptionCommand
							, [RecurringSubscriptionResult]=@RecurringSubscriptionResult
							, [RelatedOrderNumber]=@RelatedOrderNumber
							, [BuySafeCommand]=@BuySafeCommand
							, [BuySafeResult]=@BuySafeResult
							, [ReceiptHtml]=@ReceiptHtml 
							 where OrderNumber=@OrderNumber";
			SqlParameter[] parameterArray=new SqlParameter[]{
					new SqlParameter("@OrderNumber",entity.OrderNumber)
					, new SqlParameter("@OrderGUID",entity.OrderGuid)
					, new SqlParameter("@StoreID",entity.StoreId)
					, new SqlParameter("@ParentOrderNumber",entity.ParentOrderNumber ?? (object)DBNull.Value)
					, new SqlParameter("@StoreVersion",entity.StoreVersion ?? (object)DBNull.Value)
					, new SqlParameter("@QuoteCheckout",entity.QuoteCheckout)
					, new SqlParameter("@IsNew",entity.IsNew)
					, new SqlParameter("@ShippedOn",entity.ShippedOn ?? (object)DBNull.Value)
					, new SqlParameter("@CustomerID",entity.CustomerId)
					, new SqlParameter("@CustomerGUID",entity.CustomerGuid)
					, new SqlParameter("@Referrer",entity.Referrer ?? (object)DBNull.Value)
					, new SqlParameter("@SkinID",entity.SkinId)
					, new SqlParameter("@LastName",entity.LastName ?? (object)DBNull.Value)
					, new SqlParameter("@FirstName",entity.FirstName ?? (object)DBNull.Value)
					, new SqlParameter("@Email",entity.Email ?? (object)DBNull.Value)
					, new SqlParameter("@Notes",entity.Notes ?? (object)DBNull.Value)
					, new SqlParameter("@BillingEqualsShipping",entity.BillingEqualsShipping)
					, new SqlParameter("@BillingLastName",entity.BillingLastName ?? (object)DBNull.Value)
					, new SqlParameter("@BillingFirstName",entity.BillingFirstName ?? (object)DBNull.Value)
					, new SqlParameter("@BillingCompany",entity.BillingCompany ?? (object)DBNull.Value)
					, new SqlParameter("@BillingAddress1",entity.BillingAddress1 ?? (object)DBNull.Value)
					, new SqlParameter("@BillingAddress2",entity.BillingAddress2 ?? (object)DBNull.Value)
					, new SqlParameter("@BillingSuite",entity.BillingSuite ?? (object)DBNull.Value)
					, new SqlParameter("@BillingCity",entity.BillingCity ?? (object)DBNull.Value)
					, new SqlParameter("@BillingState",entity.BillingState ?? (object)DBNull.Value)
					, new SqlParameter("@BillingZip",entity.BillingZip ?? (object)DBNull.Value)
					, new SqlParameter("@BillingCountry",entity.BillingCountry ?? (object)DBNull.Value)
					, new SqlParameter("@BillingPhone",entity.BillingPhone ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingLastName",entity.ShippingLastName ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingFirstName",entity.ShippingFirstName ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingCompany",entity.ShippingCompany ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingResidenceType",entity.ShippingResidenceType)
					, new SqlParameter("@ShippingAddress1",entity.ShippingAddress1 ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingAddress2",entity.ShippingAddress2 ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingSuite",entity.ShippingSuite ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingCity",entity.ShippingCity ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingState",entity.ShippingState ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingZip",entity.ShippingZip ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingCountry",entity.ShippingCountry ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingMethodID",entity.ShippingMethodId)
					, new SqlParameter("@ShippingMethod",entity.ShippingMethod ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingPhone",entity.ShippingPhone ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingCalculationID",entity.ShippingCalculationId ?? (object)DBNull.Value)
					, new SqlParameter("@Phone",entity.Phone ?? (object)DBNull.Value)
					, new SqlParameter("@RegisterDate",entity.RegisterDate ?? (object)DBNull.Value)
					, new SqlParameter("@AffiliateID",entity.AffiliateId ?? (object)DBNull.Value)
					, new SqlParameter("@CouponCode",entity.CouponCode ?? (object)DBNull.Value)
					, new SqlParameter("@CouponType",entity.CouponType)
					, new SqlParameter("@CouponDescription",entity.CouponDescription ?? (object)DBNull.Value)
					, new SqlParameter("@CouponDiscountAmount",entity.CouponDiscountAmount ?? (object)DBNull.Value)
					, new SqlParameter("@CouponDiscountPercent",entity.CouponDiscountPercent ?? (object)DBNull.Value)
					, new SqlParameter("@CouponIncludesFreeShipping",entity.CouponIncludesFreeShipping ?? (object)DBNull.Value)
					, new SqlParameter("@OkToEmail",entity.OkToEmail ?? (object)DBNull.Value)
					, new SqlParameter("@Deleted",entity.Deleted)
					, new SqlParameter("@CardType",entity.CardType ?? (object)DBNull.Value)
					, new SqlParameter("@CardName",entity.CardName ?? (object)DBNull.Value)
					, new SqlParameter("@CardNumber",entity.CardNumber ?? (object)DBNull.Value)
					, new SqlParameter("@CardExpirationMonth",entity.CardExpirationMonth ?? (object)DBNull.Value)
					, new SqlParameter("@CardExpirationYear",entity.CardExpirationYear ?? (object)DBNull.Value)
					, new SqlParameter("@CardStartDate",entity.CardStartDate ?? (object)DBNull.Value)
					, new SqlParameter("@CardIssueNumber",entity.CardIssueNumber ?? (object)DBNull.Value)
					, new SqlParameter("@OrderSubtotal",entity.OrderSubtotal)
					, new SqlParameter("@OrderTax",entity.OrderTax)
					, new SqlParameter("@OrderShippingCosts",entity.OrderShippingCosts)
					, new SqlParameter("@OrderTotal",entity.OrderTotal)
					, new SqlParameter("@PaymentGateway",entity.PaymentGateway ?? (object)DBNull.Value)
					, new SqlParameter("@AuthorizationCode",entity.AuthorizationCode ?? (object)DBNull.Value)
					, new SqlParameter("@AuthorizationResult",entity.AuthorizationResult ?? (object)DBNull.Value)
					, new SqlParameter("@AuthorizationPNREF",entity.AuthorizationPnref ?? (object)DBNull.Value)
					, new SqlParameter("@TransactionCommand",entity.TransactionCommand ?? (object)DBNull.Value)
					, new SqlParameter("@OrderDate",entity.OrderDate)
					, new SqlParameter("@LevelID",entity.LevelId ?? (object)DBNull.Value)
					, new SqlParameter("@LevelName",entity.LevelName ?? (object)DBNull.Value)
					, new SqlParameter("@LevelDiscountPercent",entity.LevelDiscountPercent ?? (object)DBNull.Value)
					, new SqlParameter("@LevelDiscountAmount",entity.LevelDiscountAmount ?? (object)DBNull.Value)
					, new SqlParameter("@LevelHasFreeShipping",entity.LevelHasFreeShipping ?? (object)DBNull.Value)
					, new SqlParameter("@LevelAllowsQuantityDiscounts",entity.LevelAllowsQuantityDiscounts ?? (object)DBNull.Value)
					, new SqlParameter("@LevelHasNoTax",entity.LevelHasNoTax ?? (object)DBNull.Value)
					, new SqlParameter("@LevelAllowsCoupons",entity.LevelAllowsCoupons ?? (object)DBNull.Value)
					, new SqlParameter("@LevelDiscountsApplyToExtendedPrices",entity.LevelDiscountsApplyToExtendedPrices ?? (object)DBNull.Value)
					, new SqlParameter("@LastIPAddress",entity.LastIpAddress ?? (object)DBNull.Value)
					, new SqlParameter("@PaymentMethod",entity.PaymentMethod ?? (object)DBNull.Value)
					, new SqlParameter("@OrderNotes",entity.OrderNotes ?? (object)DBNull.Value)
					, new SqlParameter("@PONumber",entity.PoNumber ?? (object)DBNull.Value)
					, new SqlParameter("@DownloadEmailSentOn",entity.DownloadEmailSentOn ?? (object)DBNull.Value)
					, new SqlParameter("@ReceiptEmailSentOn",entity.ReceiptEmailSentOn ?? (object)DBNull.Value)
					, new SqlParameter("@DistributorEmailSentOn",entity.DistributorEmailSentOn ?? (object)DBNull.Value)
					, new SqlParameter("@ShippingTrackingNumber",entity.ShippingTrackingNumber ?? (object)DBNull.Value)
					, new SqlParameter("@ShippedVIA",entity.ShippedVia ?? (object)DBNull.Value)
					, new SqlParameter("@CustomerServiceNotes",entity.CustomerServiceNotes ?? (object)DBNull.Value)
					, new SqlParameter("@RTShipRequest",entity.RtShipRequest ?? (object)DBNull.Value)
					, new SqlParameter("@RTShipResponse",entity.RtShipResponse ?? (object)DBNull.Value)
					, new SqlParameter("@TransactionState",entity.TransactionState ?? (object)DBNull.Value)
					, new SqlParameter("@AVSResult",entity.AvsResult ?? (object)DBNull.Value)
					, new SqlParameter("@CaptureTXCommand",entity.CaptureTxCommand ?? (object)DBNull.Value)
					, new SqlParameter("@CaptureTXResult",entity.CaptureTxResult ?? (object)DBNull.Value)
					, new SqlParameter("@VoidTXCommand",entity.VoidTxCommand ?? (object)DBNull.Value)
					, new SqlParameter("@VoidTXResult",entity.VoidTxResult ?? (object)DBNull.Value)
					, new SqlParameter("@RefundTXCommand",entity.RefundTxCommand ?? (object)DBNull.Value)
					, new SqlParameter("@RefundTXResult",entity.RefundTxResult ?? (object)DBNull.Value)
					, new SqlParameter("@RefundReason",entity.RefundReason ?? (object)DBNull.Value)
					, new SqlParameter("@CardinalLookupResult",entity.CardinalLookupResult ?? (object)DBNull.Value)
					, new SqlParameter("@CardinalAuthenticateResult",entity.CardinalAuthenticateResult ?? (object)DBNull.Value)
					, new SqlParameter("@CardinalGatewayParms",entity.CardinalGatewayParms ?? (object)DBNull.Value)
					, new SqlParameter("@AffiliateCommissionRecorded",entity.AffiliateCommissionRecorded)
					, new SqlParameter("@OrderOptions",entity.OrderOptions ?? (object)DBNull.Value)
					, new SqlParameter("@OrderWeight",entity.OrderWeight)
					, new SqlParameter("@eCheckBankABACode",entity.ECheckBankAbaCode ?? (object)DBNull.Value)
					, new SqlParameter("@eCheckBankAccountNumber",entity.ECheckBankAccountNumber ?? (object)DBNull.Value)
					, new SqlParameter("@eCheckBankAccountType",entity.ECheckBankAccountType ?? (object)DBNull.Value)
					, new SqlParameter("@eCheckBankName",entity.ECheckBankName ?? (object)DBNull.Value)
					, new SqlParameter("@eCheckBankAccountName",entity.ECheckBankAccountName ?? (object)DBNull.Value)
					, new SqlParameter("@CarrierReportedRate",entity.CarrierReportedRate ?? (object)DBNull.Value)
					, new SqlParameter("@CarrierReportedWeight",entity.CarrierReportedWeight ?? (object)DBNull.Value)
					, new SqlParameter("@LocaleSetting",entity.LocaleSetting ?? (object)DBNull.Value)
					, new SqlParameter("@FinalizationData",entity.FinalizationData ?? (object)DBNull.Value)
					, new SqlParameter("@ExtensionData",entity.ExtensionData ?? (object)DBNull.Value)
					, new SqlParameter("@AlreadyConfirmed",entity.AlreadyConfirmed)
					, new SqlParameter("@CartType",entity.CartType)
					, new SqlParameter("@THUB_POSTED_TO_ACCOUNTING",entity.ThubPostedToAccounting ?? (object)DBNull.Value)
					, new SqlParameter("@THUB_POSTED_DATE",entity.ThubPostedDate ?? (object)DBNull.Value)
					, new SqlParameter("@THUB_ACCOUNTING_REF",entity.ThubAccountingRef ?? (object)DBNull.Value)
					, new SqlParameter("@Last4",entity.Last4 ?? (object)DBNull.Value)
					, new SqlParameter("@ReadyToShip",entity.ReadyToShip)
					, new SqlParameter("@IsPrinted",entity.IsPrinted)
					, new SqlParameter("@AuthorizedOn",entity.AuthorizedOn ?? (object)DBNull.Value)
					, new SqlParameter("@CapturedOn",entity.CapturedOn ?? (object)DBNull.Value)
					, new SqlParameter("@RefundedOn",entity.RefundedOn ?? (object)DBNull.Value)
					, new SqlParameter("@VoidedOn",entity.VoidedOn ?? (object)DBNull.Value)
					, new SqlParameter("@FraudedOn",entity.FraudedOn ?? (object)DBNull.Value)
					, new SqlParameter("@EditedOn",entity.EditedOn ?? (object)DBNull.Value)
					, new SqlParameter("@TrackingURL",entity.TrackingUrl ?? (object)DBNull.Value)
					, new SqlParameter("@ShippedEMailSentOn",entity.ShippedEmailSentOn ?? (object)DBNull.Value)
					, new SqlParameter("@InventoryWasReduced",entity.InventoryWasReduced)
					, new SqlParameter("@MaxMindFraudScore",entity.MaxMindFraudScore ?? (object)DBNull.Value)
					, new SqlParameter("@MaxMindDetails",entity.MaxMindDetails ?? (object)DBNull.Value)
					, new SqlParameter("@VATRegistrationID",entity.VatRegistrationId ?? (object)DBNull.Value)
					, new SqlParameter("@Crypt",entity.Crypt)
					, new SqlParameter("@TransactionType",entity.TransactionType)
					, new SqlParameter("@RecurringSubscriptionID",entity.RecurringSubscriptionId)
					, new SqlParameter("@RecurringSubscriptionCommand",entity.RecurringSubscriptionCommand)
					, new SqlParameter("@RecurringSubscriptionResult",entity.RecurringSubscriptionResult)
					, new SqlParameter("@RelatedOrderNumber",entity.RelatedOrderNumber)
					, new SqlParameter("@BuySafeCommand",entity.BuySafeCommand)
					, new SqlParameter("@BuySafeResult",entity.BuySafeResult)
					, new SqlParameter("@ReceiptHtml",entity.ReceiptHtml ?? (object)DBNull.Value)};
			SqlHelper.ExecuteNonQuery(this.ConnectionString,CommandType.Text,sql,parameterArray);
			return GetOrders(entity.OrderNumber);
		}

		public virtual bool DeleteOrders(System.Int32 OrderNumber)
		{

			string sql="delete from Orders where OrderNumber=@OrderNumber";
			SqlParameter parameter=new SqlParameter("@OrderNumber",OrderNumber);
			var identity=SqlHelper.ExecuteScalar(this.ConnectionString,CommandType.Text,sql,new SqlParameter[] { parameter });
			return (Convert.ToInt32(identity))==1? true: false;
		}

		[MOLog(AuditOperations.Delete,typeof(Orders))]
		public virtual Orders DeleteOrders(Orders entity)
		{
			this.DeleteOrders(entity.OrderNumber);
			return entity;
		}


		public virtual Orders OrdersFromDataRow(DataRow dr)
		{
			if(dr==null) return null;
			Orders entity=new Orders();
			entity.OrderNumber = (System.Int32)dr["OrderNumber"];
			entity.OrderGuid = (System.Guid)dr["OrderGUID"];
			entity.StoreId = (System.Int32)dr["StoreID"];
			entity.ParentOrderNumber = dr["ParentOrderNumber"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["ParentOrderNumber"];
			entity.StoreVersion = dr["StoreVersion"].ToString();
			entity.QuoteCheckout = (System.Byte)dr["QuoteCheckout"];
			entity.IsNew = (System.Byte)dr["IsNew"];
			entity.ShippedOn = dr["ShippedOn"]==DBNull.Value?(System.DateTime?)null:(System.DateTime?)dr["ShippedOn"];
			entity.CustomerId = (System.Int32)dr["CustomerID"];
			entity.CustomerGuid = (System.Guid)dr["CustomerGUID"];
			entity.Referrer = dr["Referrer"].ToString();
			entity.SkinId = (System.Int32)dr["SkinID"];
			entity.LastName = dr["LastName"].ToString();
			entity.FirstName = dr["FirstName"].ToString();
			entity.Email = dr["Email"].ToString();
			entity.Notes = dr["Notes"].ToString();
			entity.BillingEqualsShipping = (System.Byte)dr["BillingEqualsShipping"];
			entity.BillingLastName = dr["BillingLastName"].ToString();
			entity.BillingFirstName = dr["BillingFirstName"].ToString();
			entity.BillingCompany = dr["BillingCompany"].ToString();
			entity.BillingAddress1 = dr["BillingAddress1"].ToString();
			entity.BillingAddress2 = dr["BillingAddress2"].ToString();
			entity.BillingSuite = dr["BillingSuite"].ToString();
			entity.BillingCity = dr["BillingCity"].ToString();
			entity.BillingState = dr["BillingState"].ToString();
			entity.BillingZip = dr["BillingZip"].ToString();
			entity.BillingCountry = dr["BillingCountry"].ToString();
			entity.BillingPhone = dr["BillingPhone"].ToString();
			entity.ShippingLastName = dr["ShippingLastName"].ToString();
			entity.ShippingFirstName = dr["ShippingFirstName"].ToString();
			entity.ShippingCompany = dr["ShippingCompany"].ToString();
			entity.ShippingResidenceType = (System.Int32)dr["ShippingResidenceType"];
			entity.ShippingAddress1 = dr["ShippingAddress1"].ToString();
			entity.ShippingAddress2 = dr["ShippingAddress2"].ToString();
			entity.ShippingSuite = dr["ShippingSuite"].ToString();
			entity.ShippingCity = dr["ShippingCity"].ToString();
			entity.ShippingState = dr["ShippingState"].ToString();
			entity.ShippingZip = dr["ShippingZip"].ToString();
			entity.ShippingCountry = dr["ShippingCountry"].ToString();
			entity.ShippingMethodId = (System.Int32)dr["ShippingMethodID"];
			entity.ShippingMethod = dr["ShippingMethod"].ToString();
			entity.ShippingPhone = dr["ShippingPhone"].ToString();
			entity.ShippingCalculationId = dr["ShippingCalculationID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["ShippingCalculationID"];
			entity.Phone = dr["Phone"].ToString();
			entity.RegisterDate = dr["RegisterDate"]==DBNull.Value?(System.DateTime?)null:(System.DateTime?)dr["RegisterDate"];
			entity.AffiliateId = dr["AffiliateID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["AffiliateID"];
			entity.CouponCode = dr["CouponCode"].ToString();
			entity.CouponType = (System.Int32)dr["CouponType"];
			entity.CouponDescription = dr["CouponDescription"].ToString();
			entity.CouponDiscountAmount = dr["CouponDiscountAmount"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["CouponDiscountAmount"];
			entity.CouponDiscountPercent = dr["CouponDiscountPercent"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["CouponDiscountPercent"];
			entity.CouponIncludesFreeShipping = dr["CouponIncludesFreeShipping"]==DBNull.Value?(System.Byte?)null:(System.Byte?)dr["CouponIncludesFreeShipping"];
			entity.OkToEmail = dr["OkToEmail"]==DBNull.Value?(System.Byte?)null:(System.Byte?)dr["OkToEmail"];
			entity.Deleted = (System.Byte)dr["Deleted"];
			entity.CardType = dr["CardType"].ToString();
			entity.CardName = dr["CardName"].ToString();
			entity.CardNumber = dr["CardNumber"].ToString();
			entity.CardExpirationMonth = dr["CardExpirationMonth"].ToString();
			entity.CardExpirationYear = dr["CardExpirationYear"].ToString();
			entity.CardStartDate = dr["CardStartDate"].ToString();
			entity.CardIssueNumber = dr["CardIssueNumber"].ToString();
			entity.OrderSubtotal = (System.Decimal)dr["OrderSubtotal"];
			entity.OrderTax = (System.Decimal)dr["OrderTax"];
			entity.OrderShippingCosts = (System.Decimal)dr["OrderShippingCosts"];
			entity.OrderTotal = (System.Decimal)dr["OrderTotal"];
			entity.PaymentGateway = dr["PaymentGateway"].ToString();
			entity.AuthorizationCode = dr["AuthorizationCode"].ToString();
			entity.AuthorizationResult = dr["AuthorizationResult"].ToString();
			entity.AuthorizationPnref = dr["AuthorizationPNREF"].ToString();
			entity.TransactionCommand = dr["TransactionCommand"].ToString();
			entity.OrderDate = (System.DateTime)dr["OrderDate"];
			entity.LevelId = dr["LevelID"]==DBNull.Value?(System.Int32?)null:(System.Int32?)dr["LevelID"];
			entity.LevelName = dr["LevelName"].ToString();
			entity.LevelDiscountPercent = dr["LevelDiscountPercent"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["LevelDiscountPercent"];
			entity.LevelDiscountAmount = dr["LevelDiscountAmount"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["LevelDiscountAmount"];
			entity.LevelHasFreeShipping = dr["LevelHasFreeShipping"]==DBNull.Value?(System.Byte?)null:(System.Byte?)dr["LevelHasFreeShipping"];
			entity.LevelAllowsQuantityDiscounts = dr["LevelAllowsQuantityDiscounts"]==DBNull.Value?(System.Byte?)null:(System.Byte?)dr["LevelAllowsQuantityDiscounts"];
			entity.LevelHasNoTax = dr["LevelHasNoTax"]==DBNull.Value?(System.Byte?)null:(System.Byte?)dr["LevelHasNoTax"];
			entity.LevelAllowsCoupons = dr["LevelAllowsCoupons"]==DBNull.Value?(System.Byte?)null:(System.Byte?)dr["LevelAllowsCoupons"];
			entity.LevelDiscountsApplyToExtendedPrices = dr["LevelDiscountsApplyToExtendedPrices"]==DBNull.Value?(System.Byte?)null:(System.Byte?)dr["LevelDiscountsApplyToExtendedPrices"];
			entity.LastIpAddress = dr["LastIPAddress"].ToString();
			entity.PaymentMethod = dr["PaymentMethod"].ToString();
			entity.OrderNotes = dr["OrderNotes"].ToString();
			entity.PoNumber = dr["PONumber"].ToString();
			entity.DownloadEmailSentOn = dr["DownloadEmailSentOn"]==DBNull.Value?(System.DateTime?)null:(System.DateTime?)dr["DownloadEmailSentOn"];
			entity.ReceiptEmailSentOn = dr["ReceiptEmailSentOn"]==DBNull.Value?(System.DateTime?)null:(System.DateTime?)dr["ReceiptEmailSentOn"];
			entity.DistributorEmailSentOn = dr["DistributorEmailSentOn"]==DBNull.Value?(System.DateTime?)null:(System.DateTime?)dr["DistributorEmailSentOn"];
			entity.ShippingTrackingNumber = dr["ShippingTrackingNumber"].ToString();
			entity.ShippedVia = dr["ShippedVIA"].ToString();
			entity.CustomerServiceNotes = dr["CustomerServiceNotes"].ToString();
			entity.RtShipRequest = dr["RTShipRequest"].ToString();
			entity.RtShipResponse = dr["RTShipResponse"].ToString();
			entity.TransactionState = dr["TransactionState"].ToString();
			entity.AvsResult = dr["AVSResult"].ToString();
			entity.CaptureTxCommand = dr["CaptureTXCommand"].ToString();
			entity.CaptureTxResult = dr["CaptureTXResult"].ToString();
			entity.VoidTxCommand = dr["VoidTXCommand"].ToString();
			entity.VoidTxResult = dr["VoidTXResult"].ToString();
			entity.RefundTxCommand = dr["RefundTXCommand"].ToString();
			entity.RefundTxResult = dr["RefundTXResult"].ToString();
			entity.RefundReason = dr["RefundReason"].ToString();
			entity.CardinalLookupResult = dr["CardinalLookupResult"].ToString();
			entity.CardinalAuthenticateResult = dr["CardinalAuthenticateResult"].ToString();
			entity.CardinalGatewayParms = dr["CardinalGatewayParms"].ToString();
			entity.AffiliateCommissionRecorded = (System.Byte)dr["AffiliateCommissionRecorded"];
			entity.OrderOptions = dr["OrderOptions"].ToString();
			entity.OrderWeight = (System.Decimal)dr["OrderWeight"];
			entity.ECheckBankAbaCode = dr["eCheckBankABACode"].ToString();
			entity.ECheckBankAccountNumber = dr["eCheckBankAccountNumber"].ToString();
			entity.ECheckBankAccountType = dr["eCheckBankAccountType"].ToString();
			entity.ECheckBankName = dr["eCheckBankName"].ToString();
			entity.ECheckBankAccountName = dr["eCheckBankAccountName"].ToString();
			entity.CarrierReportedRate = dr["CarrierReportedRate"].ToString();
			entity.CarrierReportedWeight = dr["CarrierReportedWeight"].ToString();
			entity.LocaleSetting = dr["LocaleSetting"].ToString();
			entity.FinalizationData = dr["FinalizationData"].ToString();
			entity.ExtensionData = dr["ExtensionData"].ToString();
			entity.AlreadyConfirmed = (System.Byte)dr["AlreadyConfirmed"];
			entity.CartType = (System.Int32)dr["CartType"];
			entity.ThubPostedToAccounting = dr["THUB_POSTED_TO_ACCOUNTING"].ToString();
			entity.ThubPostedDate = dr["THUB_POSTED_DATE"]==DBNull.Value?(System.DateTime?)null:(System.DateTime?)dr["THUB_POSTED_DATE"];
			entity.ThubAccountingRef = dr["THUB_ACCOUNTING_REF"].ToString();
			entity.Last4 = dr["Last4"].ToString();
			entity.ReadyToShip = (System.Byte)dr["ReadyToShip"];
			entity.IsPrinted = (System.Byte)dr["IsPrinted"];
			entity.AuthorizedOn = dr["AuthorizedOn"]==DBNull.Value?(System.DateTime?)null:(System.DateTime?)dr["AuthorizedOn"];
			entity.CapturedOn = dr["CapturedOn"]==DBNull.Value?(System.DateTime?)null:(System.DateTime?)dr["CapturedOn"];
			entity.RefundedOn = dr["RefundedOn"]==DBNull.Value?(System.DateTime?)null:(System.DateTime?)dr["RefundedOn"];
			entity.VoidedOn = dr["VoidedOn"]==DBNull.Value?(System.DateTime?)null:(System.DateTime?)dr["VoidedOn"];
			entity.FraudedOn = dr["FraudedOn"]==DBNull.Value?(System.DateTime?)null:(System.DateTime?)dr["FraudedOn"];
			entity.EditedOn = dr["EditedOn"]==DBNull.Value?(System.DateTime?)null:(System.DateTime?)dr["EditedOn"];
			entity.TrackingUrl = dr["TrackingURL"].ToString();
			entity.ShippedEmailSentOn = dr["ShippedEMailSentOn"]==DBNull.Value?(System.DateTime?)null:(System.DateTime?)dr["ShippedEMailSentOn"];
			entity.InventoryWasReduced = (System.Int32)dr["InventoryWasReduced"];
			entity.MaxMindFraudScore = dr["MaxMindFraudScore"]==DBNull.Value?(System.Decimal?)null:(System.Decimal?)dr["MaxMindFraudScore"];
			entity.MaxMindDetails = dr["MaxMindDetails"].ToString();
			entity.VatRegistrationId = dr["VATRegistrationID"].ToString();
			entity.Crypt = (System.Int32)dr["Crypt"];
			entity.TransactionType = (System.Int32)dr["TransactionType"];
			entity.RecurringSubscriptionId = dr["RecurringSubscriptionID"].ToString();
			entity.RecurringSubscriptionCommand = dr["RecurringSubscriptionCommand"].ToString();
			entity.RecurringSubscriptionResult = dr["RecurringSubscriptionResult"].ToString();
			entity.RelatedOrderNumber = (System.Int32)dr["RelatedOrderNumber"];
			entity.BuySafeCommand = dr["BuySafeCommand"].ToString();
			entity.BuySafeResult = dr["BuySafeResult"].ToString();
			entity.ReceiptHtml = dr["ReceiptHtml"].ToString();
			return entity;
		}

	}
	
	
}
