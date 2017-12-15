using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class SectionBase:EntityBase, IEquatable<SectionBase>
	{
			
		[PrimaryKey]
		public System.Int32 SectionId{ get; set; }

		public System.Guid SectionGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.String Summary{ get; set; }

		public System.String Description{ get; set; }

		public System.String SeKeywords{ get; set; }

		public System.String SeDescription{ get; set; }

		public System.String DisplayPrefix{ get; set; }

		public System.String SeTitle{ get; set; }

		public System.String SeNoScript{ get; set; }

		public System.String SeAltText{ get; set; }

		public System.String RelatedDocuments{ get; set; }

		public System.Int32 ParentSectionId{ get; set; }

		public System.Int32 ColWidth{ get; set; }

		public System.Byte SortByLooks{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.String XmlPackage{ get; set; }

		public System.Byte AllowCategoryFiltering{ get; set; }

		public System.Byte AllowManufacturerFiltering{ get; set; }

		public System.Byte AllowProductTypeFiltering{ get; set; }

		public System.Byte Published{ get; set; }

		public System.Byte Wholesale{ get; set; }

		public System.Int32 ShowInProductBrowser{ get; set; }

		public System.Int32? QuantityDiscountId{ get; set; }

		public System.String SeName{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.String ContentsBgColor{ get; set; }

		public System.String PageBgColor{ get; set; }

		public System.String GraphicsColor{ get; set; }

		public System.String ImageFilenameOverride{ get; set; }

		public System.Byte IsImport{ get; set; }

		public System.Byte Deleted{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		public System.Int32 PageSize{ get; set; }

		public System.Int32 SkinId{ get; set; }

		public System.String TemplateName{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<SectionBase> Members

        public virtual bool Equals(SectionBase other)
        {
			if(this.SectionId==other.SectionId  && this.SectionGuid==other.SectionGuid  && this.Name==other.Name  && this.Summary==other.Summary  && this.Description==other.Description  && this.SeKeywords==other.SeKeywords  && this.SeDescription==other.SeDescription  && this.DisplayPrefix==other.DisplayPrefix  && this.SeTitle==other.SeTitle  && this.SeNoScript==other.SeNoScript  && this.SeAltText==other.SeAltText  && this.RelatedDocuments==other.RelatedDocuments  && this.ParentSectionId==other.ParentSectionId  && this.ColWidth==other.ColWidth  && this.SortByLooks==other.SortByLooks  && this.DisplayOrder==other.DisplayOrder  && this.XmlPackage==other.XmlPackage  && this.AllowCategoryFiltering==other.AllowCategoryFiltering  && this.AllowManufacturerFiltering==other.AllowManufacturerFiltering  && this.AllowProductTypeFiltering==other.AllowProductTypeFiltering  && this.Published==other.Published  && this.Wholesale==other.Wholesale  && this.ShowInProductBrowser==other.ShowInProductBrowser  && this.QuantityDiscountId==other.QuantityDiscountId  && this.SeName==other.SeName  && this.ExtensionData==other.ExtensionData  && this.ContentsBgColor==other.ContentsBgColor  && this.PageBgColor==other.PageBgColor  && this.GraphicsColor==other.GraphicsColor  && this.ImageFilenameOverride==other.ImageFilenameOverride  && this.IsImport==other.IsImport  && this.Deleted==other.Deleted  && this.CreatedOn==other.CreatedOn  && this.PageSize==other.PageSize  && this.SkinId==other.SkinId  && this.TemplateName==other.TemplateName )
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
