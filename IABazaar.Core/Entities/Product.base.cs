using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class ProductBase:EntityBase, IEquatable<ProductBase>
	{
			
		[PrimaryKey]
		public System.Int32 ProductId{ get; set; }

		public System.Guid ProductGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.String Summary{ get; set; }

		public System.String Description{ get; set; }

		public System.String SeKeywords{ get; set; }

		public System.String SeDescription{ get; set; }

		public System.String SpecTitle{ get; set; }

		public System.String MiscText{ get; set; }

		public System.String SwatchImageMap{ get; set; }

		public System.String IsFeaturedTeaser{ get; set; }

		public System.String FroogleDescription{ get; set; }

		public System.String SeTitle{ get; set; }

		public System.String SeNoScript{ get; set; }

		public System.String SeAltText{ get; set; }

		public System.String SizeOptionPrompt{ get; set; }

		public System.String ColorOptionPrompt{ get; set; }

		public System.String TextOptionPrompt{ get; set; }

		public System.Int32 ProductTypeId{ get; set; }

		public System.Int32 TaxClassId{ get; set; }

		public System.String Sku{ get; set; }

		public System.String ManufacturerPartNumber{ get; set; }

		public System.Int32 SalesPromptId{ get; set; }

		public System.String SpecCall{ get; set; }

		public System.Byte SpecsInline{ get; set; }

		public System.Byte IsFeatured{ get; set; }

		public System.String XmlPackage{ get; set; }

		public System.Int32 ColWidth{ get; set; }

		public System.Byte Published{ get; set; }

		public System.Byte Wholesale{ get; set; }

		public System.Byte RequiresRegistration{ get; set; }

		public System.Int32 Looks{ get; set; }

		public System.String Notes{ get; set; }

		public System.Int32? QuantityDiscountId{ get; set; }

		public System.String RelatedProducts{ get; set; }

		public System.String UpsellProducts{ get; set; }

		public System.Decimal UpsellProductDiscountPercentage{ get; set; }

		public System.String RelatedDocuments{ get; set; }

		public System.Byte TrackInventoryBySizeAndColor{ get; set; }

		public System.Byte TrackInventoryBySize{ get; set; }

		public System.Byte TrackInventoryByColor{ get; set; }

		public System.Byte IsAkit{ get; set; }

		public System.Int32 ShowInProductBrowser{ get; set; }

		public System.Int32 IsApack{ get; set; }

		public System.Int32 PackSize{ get; set; }

		public System.Int32 ShowBuyButton{ get; set; }

		public System.String RequiresProducts{ get; set; }

		public System.Byte HidePriceUntilCart{ get; set; }

		public System.Byte IsCalltoOrder{ get; set; }

		public System.Byte ExcludeFromPriceFeeds{ get; set; }

		public System.Byte RequiresTextOption{ get; set; }

		public System.Int32? TextOptionMaxLength{ get; set; }

		public System.String SeName{ get; set; }

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

		public System.Byte IsSystem{ get; set; }

		public System.Byte Deleted{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		public System.Int32 PageSize{ get; set; }

		public System.String WarehouseLocation{ get; set; }

		public System.DateTime AvailableStartDate{ get; set; }

		public System.DateTime? AvailableStopDate{ get; set; }

		public System.Byte GoogleCheckoutAllowed{ get; set; }

		public System.Int32 SkinId{ get; set; }

		public System.String TemplateName{ get; set; }

		public System.Decimal? StichedPrice{ get; set; }

		public System.Decimal? Costinrupee{ get; set; }

		public System.Decimal? Costindollar{ get; set; }

		public System.Decimal? Profitpriceinrupee{ get; set; }

		public System.Decimal? Profitpriceindollar{ get; set; }

		public System.Decimal? Profit{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<ProductBase> Members

        public virtual bool Equals(ProductBase other)
        {
			if(this.ProductId==other.ProductId  && this.ProductGuid==other.ProductGuid  && this.Name==other.Name  && this.Summary==other.Summary  && this.Description==other.Description  && this.SeKeywords==other.SeKeywords  && this.SeDescription==other.SeDescription  && this.SpecTitle==other.SpecTitle  && this.MiscText==other.MiscText  && this.SwatchImageMap==other.SwatchImageMap  && this.IsFeaturedTeaser==other.IsFeaturedTeaser  && this.FroogleDescription==other.FroogleDescription  && this.SeTitle==other.SeTitle  && this.SeNoScript==other.SeNoScript  && this.SeAltText==other.SeAltText  && this.SizeOptionPrompt==other.SizeOptionPrompt  && this.ColorOptionPrompt==other.ColorOptionPrompt  && this.TextOptionPrompt==other.TextOptionPrompt  && this.ProductTypeId==other.ProductTypeId  && this.TaxClassId==other.TaxClassId  && this.Sku==other.Sku  && this.ManufacturerPartNumber==other.ManufacturerPartNumber  && this.SalesPromptId==other.SalesPromptId  && this.SpecCall==other.SpecCall  && this.SpecsInline==other.SpecsInline  && this.IsFeatured==other.IsFeatured  && this.XmlPackage==other.XmlPackage  && this.ColWidth==other.ColWidth  && this.Published==other.Published  && this.Wholesale==other.Wholesale  && this.RequiresRegistration==other.RequiresRegistration  && this.Looks==other.Looks  && this.Notes==other.Notes  && this.QuantityDiscountId==other.QuantityDiscountId  && this.RelatedProducts==other.RelatedProducts  && this.UpsellProducts==other.UpsellProducts  && this.UpsellProductDiscountPercentage==other.UpsellProductDiscountPercentage  && this.RelatedDocuments==other.RelatedDocuments  && this.TrackInventoryBySizeAndColor==other.TrackInventoryBySizeAndColor  && this.TrackInventoryBySize==other.TrackInventoryBySize  && this.TrackInventoryByColor==other.TrackInventoryByColor  && this.IsAkit==other.IsAkit  && this.ShowInProductBrowser==other.ShowInProductBrowser  && this.IsApack==other.IsApack  && this.PackSize==other.PackSize  && this.ShowBuyButton==other.ShowBuyButton  && this.RequiresProducts==other.RequiresProducts  && this.HidePriceUntilCart==other.HidePriceUntilCart  && this.IsCalltoOrder==other.IsCalltoOrder  && this.ExcludeFromPriceFeeds==other.ExcludeFromPriceFeeds  && this.RequiresTextOption==other.RequiresTextOption  && this.TextOptionMaxLength==other.TextOptionMaxLength  && this.SeName==other.SeName  && this.ExtensionData==other.ExtensionData  && this.ExtensionData2==other.ExtensionData2  && this.ExtensionData3==other.ExtensionData3  && this.ExtensionData4==other.ExtensionData4  && this.ExtensionData5==other.ExtensionData5  && this.ContentsBgColor==other.ContentsBgColor  && this.PageBgColor==other.PageBgColor  && this.GraphicsColor==other.GraphicsColor  && this.ImageFilenameOverride==other.ImageFilenameOverride  && this.IsImport==other.IsImport  && this.IsSystem==other.IsSystem  && this.Deleted==other.Deleted  && this.CreatedOn==other.CreatedOn  && this.PageSize==other.PageSize  && this.WarehouseLocation==other.WarehouseLocation  && this.AvailableStartDate==other.AvailableStartDate  && this.AvailableStopDate==other.AvailableStopDate  && this.GoogleCheckoutAllowed==other.GoogleCheckoutAllowed  && this.SkinId==other.SkinId  && this.TemplateName==other.TemplateName  && this.StichedPrice==other.StichedPrice  && this.Costinrupee==other.Costinrupee  && this.Costindollar==other.Costindollar  && this.Profitpriceinrupee==other.Profitpriceinrupee  && this.Profitpriceindollar==other.Profitpriceindollar  && this.Profit==other.Profit )
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
