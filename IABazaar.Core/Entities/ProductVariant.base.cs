using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class ProductVariantBase:EntityBase, IEquatable<ProductVariantBase>
	{
			
		[PrimaryKey]
		public System.Int32 VariantId{ get; set; }

		public System.Guid VariantGuid{ get; set; }

		public System.Int32 IsDefault{ get; set; }

		public System.String Name{ get; set; }

		public System.String Description{ get; set; }

		public System.String SeKeywords{ get; set; }

		public System.String SeDescription{ get; set; }

		public System.String SeAltText{ get; set; }

		public System.String Colors{ get; set; }

		public System.String ColorSkuModifiers{ get; set; }

		public System.String Sizes{ get; set; }

		public System.String SizeSkuModifiers{ get; set; }

		public System.String FroogleDescription{ get; set; }

		public System.Int32 ProductId{ get; set; }

		public System.String SkuSuffix{ get; set; }

		public System.String ManufacturerPartNumber{ get; set; }

		public System.Decimal Price{ get; set; }

		public System.Decimal? SalePrice{ get; set; }

		public System.Decimal? Weight{ get; set; }

		public System.Decimal? Msrp{ get; set; }

		public System.Decimal? Cost{ get; set; }

		public System.Int32? Points{ get; set; }

		public System.String Dimensions{ get; set; }

		public System.Int32 Inventory{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.String Notes{ get; set; }

		public System.Byte IsTaxable{ get; set; }

		public System.Byte IsShipSeparately{ get; set; }

		public System.Byte IsDownload{ get; set; }

		public System.String DownloadLocation{ get; set; }

		public System.Byte FreeShipping{ get; set; }

		public System.Byte Published{ get; set; }

		public System.Byte Wholesale{ get; set; }

		public System.Byte IsSecureAttachment{ get; set; }

		public System.Byte IsRecurring{ get; set; }

		public System.Int32 RecurringInterval{ get; set; }

		public System.Int32 RecurringIntervalType{ get; set; }

		public System.Int32? SubscriptionInterval{ get; set; }

		public System.Int32? RewardPoints{ get; set; }

		public System.String SeName{ get; set; }

		public System.String RestrictedQuantities{ get; set; }

		public System.Int32? MinimumQuantity{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.String ExtensionData2{ get; set; }

		public System.String ExtensionData3{ get; set; }

		public System.String ExtensionData4{ get; set; }

		public System.String ExtensionData5{ get; set; }

		public System.String ContentsBgColor{ get; set; }

		public System.String PageBgColor{ get; set; }

		public System.String GraphicsColor{ get; set; }

		public System.String ImageFilenameOverride{ get; set; }

		public System.Byte IsImport{ get; set; }

		public System.Byte Deleted{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		public System.Int32 SubscriptionIntervalType{ get; set; }

		public System.Byte CustomerEntersPrice{ get; set; }

		public System.String CustomerEntersPricePrompt{ get; set; }

		public System.Byte Condition{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<ProductVariantBase> Members

        public virtual bool Equals(ProductVariantBase other)
        {
			if(this.VariantId==other.VariantId  && this.VariantGuid==other.VariantGuid  && this.IsDefault==other.IsDefault  && this.Name==other.Name  && this.Description==other.Description  && this.SeKeywords==other.SeKeywords  && this.SeDescription==other.SeDescription  && this.SeAltText==other.SeAltText  && this.Colors==other.Colors  && this.ColorSkuModifiers==other.ColorSkuModifiers  && this.Sizes==other.Sizes  && this.SizeSkuModifiers==other.SizeSkuModifiers  && this.FroogleDescription==other.FroogleDescription  && this.ProductId==other.ProductId  && this.SkuSuffix==other.SkuSuffix  && this.ManufacturerPartNumber==other.ManufacturerPartNumber  && this.Price==other.Price  && this.SalePrice==other.SalePrice  && this.Weight==other.Weight  && this.Msrp==other.Msrp  && this.Cost==other.Cost  && this.Points==other.Points  && this.Dimensions==other.Dimensions  && this.Inventory==other.Inventory  && this.DisplayOrder==other.DisplayOrder  && this.Notes==other.Notes  && this.IsTaxable==other.IsTaxable  && this.IsShipSeparately==other.IsShipSeparately  && this.IsDownload==other.IsDownload  && this.DownloadLocation==other.DownloadLocation  && this.FreeShipping==other.FreeShipping  && this.Published==other.Published  && this.Wholesale==other.Wholesale  && this.IsSecureAttachment==other.IsSecureAttachment  && this.IsRecurring==other.IsRecurring  && this.RecurringInterval==other.RecurringInterval  && this.RecurringIntervalType==other.RecurringIntervalType  && this.SubscriptionInterval==other.SubscriptionInterval  && this.RewardPoints==other.RewardPoints  && this.SeName==other.SeName  && this.RestrictedQuantities==other.RestrictedQuantities  && this.MinimumQuantity==other.MinimumQuantity  && this.ExtensionData==other.ExtensionData  && this.ExtensionData2==other.ExtensionData2  && this.ExtensionData3==other.ExtensionData3  && this.ExtensionData4==other.ExtensionData4  && this.ExtensionData5==other.ExtensionData5  && this.ContentsBgColor==other.ContentsBgColor  && this.PageBgColor==other.PageBgColor  && this.GraphicsColor==other.GraphicsColor  && this.ImageFilenameOverride==other.ImageFilenameOverride  && this.IsImport==other.IsImport  && this.Deleted==other.Deleted  && this.CreatedOn==other.CreatedOn  && this.SubscriptionIntervalType==other.SubscriptionIntervalType  && this.CustomerEntersPrice==other.CustomerEntersPrice  && this.CustomerEntersPricePrompt==other.CustomerEntersPricePrompt  && this.Condition==other.Condition )
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
