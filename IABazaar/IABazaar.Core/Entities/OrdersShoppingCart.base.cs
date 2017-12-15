using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class OrdersShoppingCartBase:EntityBase, IEquatable<OrdersShoppingCartBase>
	{
			
		public System.Int32 OrderNumber{ get; set; }

		public System.Int32 ShoppingCartRecId{ get; set; }

		public System.Int32 CustomerId{ get; set; }

		public System.Int32 ProductId{ get; set; }

		public System.Int32 VariantId{ get; set; }

		public System.Int32 Quantity{ get; set; }

		public System.String ChosenColor{ get; set; }

		public System.String ChosenColorSkuModifier{ get; set; }

		public System.String ChosenSize{ get; set; }

		public System.String ChosenSizeSkuModifier{ get; set; }

		public System.String OrderedProductName{ get; set; }

		public System.String OrderedProductVariantName{ get; set; }

		public System.String OrderedProductSku{ get; set; }

		public System.String OrderedProductManufacturerPartNumber{ get; set; }

		public System.Decimal? OrderedProductWeight{ get; set; }

		public System.Decimal? OrderedProductPrice{ get; set; }

		public System.Decimal? OrderedProductRegularPrice{ get; set; }

		public System.Decimal? OrderedProductSalePrice{ get; set; }

		public System.Decimal? OrderedProductExtendedPrice{ get; set; }

		public System.String OrderedProductQuantityDiscountName{ get; set; }

		public System.Int32? OrderedProductQuantityDiscountId{ get; set; }

		public System.Decimal? OrderedProductQuantityDiscountPercent{ get; set; }

		public System.Byte IsTaxable{ get; set; }

		public System.Byte IsShipSeparately{ get; set; }

		public System.Byte IsDownload{ get; set; }

		public System.String DownloadLocation{ get; set; }

		public System.Byte FreeShipping{ get; set; }

		public System.Byte IsSecureAttachment{ get; set; }

		public System.String TextOption{ get; set; }

		public System.Int32 CartType{ get; set; }

		public System.Int32? SubscriptionInterval{ get; set; }

		public System.Int32 ShippingAddressId{ get; set; }

		public System.String ShippingDetail{ get; set; }

		public System.Int32? ShippingMethodId{ get; set; }

		public System.String ShippingMethod{ get; set; }

		public System.Int32? DistributorId{ get; set; }

		public System.Int32? GiftRegistryForCustomerId{ get; set; }

		public System.String Notes{ get; set; }

		public System.DateTime? DistributorEmailSentOn{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.String SizeOptionPrompt{ get; set; }

		public System.String ColorOptionPrompt{ get; set; }

		public System.String TextOptionPrompt{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		public System.Int32 SubscriptionIntervalType{ get; set; }

		public System.Byte CustomerEntersPrice{ get; set; }

		public System.String CustomerEntersPricePrompt{ get; set; }

		public System.Byte? IsAkit{ get; set; }

		public System.Byte? IsApack{ get; set; }

		public System.Byte? IsSystem{ get; set; }

		public System.Int32 TaxClassId{ get; set; }

		public System.Decimal TaxRate{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<OrdersShoppingCartBase> Members

        public virtual bool Equals(OrdersShoppingCartBase other)
        {
			if(this.OrderNumber==other.OrderNumber  && this.ShoppingCartRecId==other.ShoppingCartRecId  && this.CustomerId==other.CustomerId  && this.ProductId==other.ProductId  && this.VariantId==other.VariantId  && this.Quantity==other.Quantity  && this.ChosenColor==other.ChosenColor  && this.ChosenColorSkuModifier==other.ChosenColorSkuModifier  && this.ChosenSize==other.ChosenSize  && this.ChosenSizeSkuModifier==other.ChosenSizeSkuModifier  && this.OrderedProductName==other.OrderedProductName  && this.OrderedProductVariantName==other.OrderedProductVariantName  && this.OrderedProductSku==other.OrderedProductSku  && this.OrderedProductManufacturerPartNumber==other.OrderedProductManufacturerPartNumber  && this.OrderedProductWeight==other.OrderedProductWeight  && this.OrderedProductPrice==other.OrderedProductPrice  && this.OrderedProductRegularPrice==other.OrderedProductRegularPrice  && this.OrderedProductSalePrice==other.OrderedProductSalePrice  && this.OrderedProductExtendedPrice==other.OrderedProductExtendedPrice  && this.OrderedProductQuantityDiscountName==other.OrderedProductQuantityDiscountName  && this.OrderedProductQuantityDiscountId==other.OrderedProductQuantityDiscountId  && this.OrderedProductQuantityDiscountPercent==other.OrderedProductQuantityDiscountPercent  && this.IsTaxable==other.IsTaxable  && this.IsShipSeparately==other.IsShipSeparately  && this.IsDownload==other.IsDownload  && this.DownloadLocation==other.DownloadLocation  && this.FreeShipping==other.FreeShipping  && this.IsSecureAttachment==other.IsSecureAttachment  && this.TextOption==other.TextOption  && this.CartType==other.CartType  && this.SubscriptionInterval==other.SubscriptionInterval  && this.ShippingAddressId==other.ShippingAddressId  && this.ShippingDetail==other.ShippingDetail  && this.ShippingMethodId==other.ShippingMethodId  && this.ShippingMethod==other.ShippingMethod  && this.DistributorId==other.DistributorId  && this.GiftRegistryForCustomerId==other.GiftRegistryForCustomerId  && this.Notes==other.Notes  && this.DistributorEmailSentOn==other.DistributorEmailSentOn  && this.ExtensionData==other.ExtensionData  && this.SizeOptionPrompt==other.SizeOptionPrompt  && this.ColorOptionPrompt==other.ColorOptionPrompt  && this.TextOptionPrompt==other.TextOptionPrompt  && this.CreatedOn==other.CreatedOn  && this.SubscriptionIntervalType==other.SubscriptionIntervalType  && this.CustomerEntersPrice==other.CustomerEntersPrice  && this.CustomerEntersPricePrompt==other.CustomerEntersPricePrompt  && this.IsAkit==other.IsAkit  && this.IsApack==other.IsApack  && this.IsSystem==other.IsSystem  && this.TaxClassId==other.TaxClassId  && this.TaxRate==other.TaxRate )
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
