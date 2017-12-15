using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class ShoppingCartBase:EntityBase, IEquatable<ShoppingCartBase>
	{
			
		[PrimaryKey]
		public System.Int32 ShoppingCartRecId{ get; set; }

		public System.Guid ShoppingCartRecGuid{ get; set; }

		public System.Int32 StoreId{ get; set; }

		public System.Int32 CustomerId{ get; set; }

		public System.String ProductSku{ get; set; }

		public System.Decimal? ProductPrice{ get; set; }

		public System.Decimal? ProductWeight{ get; set; }

		public System.Int32 ProductId{ get; set; }

		public System.Int32 VariantId{ get; set; }

		public System.Int32 Quantity{ get; set; }

		public System.Int32 RequiresCount{ get; set; }

		public System.String ChosenColor{ get; set; }

		public System.String ChosenColorSkuModifier{ get; set; }

		public System.String ChosenSize{ get; set; }

		public System.String ChosenSizeSkuModifier{ get; set; }

		public System.Byte IsTaxable{ get; set; }

		public System.Byte IsShipSeparately{ get; set; }

		public System.Byte IsDownload{ get; set; }

		public System.String DownloadLocation{ get; set; }

		public System.Byte FreeShipping{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		public System.String ProductDimensions{ get; set; }

		public System.Int32 CartType{ get; set; }

		public System.Byte IsSecureAttachment{ get; set; }

		public System.String TextOption{ get; set; }

		public System.DateTime? NextRecurringShipDate{ get; set; }

		public System.Int32 RecurringIndex{ get; set; }

		public System.Int32? OriginalRecurringOrderNumber{ get; set; }

		public System.Int32? BillingAddressId{ get; set; }

		public System.Int32? ShippingAddressId{ get; set; }

		public System.Int32? ShippingMethodId{ get; set; }

		public System.String ShippingMethod{ get; set; }

		public System.Int32? DistributorId{ get; set; }

		public System.Int32? SubscriptionInterval{ get; set; }

		public System.String Notes{ get; set; }

		public System.Byte IsUpsell{ get; set; }

		public System.Int32 GiftRegistryForCustomerId{ get; set; }

		public System.Int32 RecurringInterval{ get; set; }

		public System.Int32 RecurringIntervalType{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.Int32 SubscriptionIntervalType{ get; set; }

		public System.Byte CustomerEntersPrice{ get; set; }

		public System.Byte? IsAkit{ get; set; }

		public System.Byte IsKit2{ get; set; }

		public System.Byte? IsApack{ get; set; }

		public System.Byte? IsSystem{ get; set; }

		public System.Int32 TaxClassId{ get; set; }

		public System.Decimal TaxRate{ get; set; }

		public System.String RecurringSubscriptionId{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<ShoppingCartBase> Members

        public virtual bool Equals(ShoppingCartBase other)
        {
			if(this.ShoppingCartRecId==other.ShoppingCartRecId  && this.ShoppingCartRecGuid==other.ShoppingCartRecGuid  && this.StoreId==other.StoreId  && this.CustomerId==other.CustomerId  && this.ProductSku==other.ProductSku  && this.ProductPrice==other.ProductPrice  && this.ProductWeight==other.ProductWeight  && this.ProductId==other.ProductId  && this.VariantId==other.VariantId  && this.Quantity==other.Quantity  && this.RequiresCount==other.RequiresCount  && this.ChosenColor==other.ChosenColor  && this.ChosenColorSkuModifier==other.ChosenColorSkuModifier  && this.ChosenSize==other.ChosenSize  && this.ChosenSizeSkuModifier==other.ChosenSizeSkuModifier  && this.IsTaxable==other.IsTaxable  && this.IsShipSeparately==other.IsShipSeparately  && this.IsDownload==other.IsDownload  && this.DownloadLocation==other.DownloadLocation  && this.FreeShipping==other.FreeShipping  && this.CreatedOn==other.CreatedOn  && this.ProductDimensions==other.ProductDimensions  && this.CartType==other.CartType  && this.IsSecureAttachment==other.IsSecureAttachment  && this.TextOption==other.TextOption  && this.NextRecurringShipDate==other.NextRecurringShipDate  && this.RecurringIndex==other.RecurringIndex  && this.OriginalRecurringOrderNumber==other.OriginalRecurringOrderNumber  && this.BillingAddressId==other.BillingAddressId  && this.ShippingAddressId==other.ShippingAddressId  && this.ShippingMethodId==other.ShippingMethodId  && this.ShippingMethod==other.ShippingMethod  && this.DistributorId==other.DistributorId  && this.SubscriptionInterval==other.SubscriptionInterval  && this.Notes==other.Notes  && this.IsUpsell==other.IsUpsell  && this.GiftRegistryForCustomerId==other.GiftRegistryForCustomerId  && this.RecurringInterval==other.RecurringInterval  && this.RecurringIntervalType==other.RecurringIntervalType  && this.ExtensionData==other.ExtensionData  && this.SubscriptionIntervalType==other.SubscriptionIntervalType  && this.CustomerEntersPrice==other.CustomerEntersPrice  && this.IsAkit==other.IsAkit  && this.IsKit2==other.IsKit2  && this.IsApack==other.IsApack  && this.IsSystem==other.IsSystem  && this.TaxClassId==other.TaxClassId  && this.TaxRate==other.TaxRate  && this.RecurringSubscriptionId==other.RecurringSubscriptionId )
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
