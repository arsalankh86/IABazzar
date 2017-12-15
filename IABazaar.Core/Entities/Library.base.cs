using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class LibraryBase:EntityBase, IEquatable<LibraryBase>
	{
			
		[PrimaryKey]
		public System.Int32 LibraryId{ get; set; }

		public System.Guid LibraryGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.String Summary{ get; set; }

		public System.String Description{ get; set; }

		public System.String SeName{ get; set; }

		public System.String SeTitle{ get; set; }

		public System.String SeNoScript{ get; set; }

		public System.String SeAltText{ get; set; }

		public System.String SeKeywords{ get; set; }

		public System.String SeDescription{ get; set; }

		public System.String DisplayPrefix{ get; set; }

		public System.String XmlPackage{ get; set; }

		public System.Int32 ParentLibraryId{ get; set; }

		public System.Int32 ColWidth{ get; set; }

		public System.Byte SortByLooks{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.String RelatedCategories{ get; set; }

		public System.String RelatedSections{ get; set; }

		public System.Int32? QuantityDiscountId{ get; set; }

		public System.String RelatedManufacturers{ get; set; }

		public System.String RelatedProducts{ get; set; }

		public System.Byte Published{ get; set; }

		public System.Byte Wholesale{ get; set; }

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
		
		#region IEquatable<LibraryBase> Members

        public virtual bool Equals(LibraryBase other)
        {
			if(this.LibraryId==other.LibraryId  && this.LibraryGuid==other.LibraryGuid  && this.Name==other.Name  && this.Summary==other.Summary  && this.Description==other.Description  && this.SeName==other.SeName  && this.SeTitle==other.SeTitle  && this.SeNoScript==other.SeNoScript  && this.SeAltText==other.SeAltText  && this.SeKeywords==other.SeKeywords  && this.SeDescription==other.SeDescription  && this.DisplayPrefix==other.DisplayPrefix  && this.XmlPackage==other.XmlPackage  && this.ParentLibraryId==other.ParentLibraryId  && this.ColWidth==other.ColWidth  && this.SortByLooks==other.SortByLooks  && this.DisplayOrder==other.DisplayOrder  && this.RelatedCategories==other.RelatedCategories  && this.RelatedSections==other.RelatedSections  && this.QuantityDiscountId==other.QuantityDiscountId  && this.RelatedManufacturers==other.RelatedManufacturers  && this.RelatedProducts==other.RelatedProducts  && this.Published==other.Published  && this.Wholesale==other.Wholesale  && this.ExtensionData==other.ExtensionData  && this.ContentsBgColor==other.ContentsBgColor  && this.PageBgColor==other.PageBgColor  && this.GraphicsColor==other.GraphicsColor  && this.ImageFilenameOverride==other.ImageFilenameOverride  && this.IsImport==other.IsImport  && this.Deleted==other.Deleted  && this.CreatedOn==other.CreatedOn  && this.PageSize==other.PageSize  && this.SkinId==other.SkinId  && this.TemplateName==other.TemplateName )
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
