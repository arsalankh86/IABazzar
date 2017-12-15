using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class DocumentBase:EntityBase, IEquatable<DocumentBase>
	{
			
		[PrimaryKey]
		public System.Int32 DocumentId{ get; set; }

		public System.Guid DocumentGuid{ get; set; }

		public System.Int32? DocumentTypeId{ get; set; }

		public System.String Name{ get; set; }

		public System.String Summary{ get; set; }

		public System.String Description{ get; set; }

		public System.String MiscText{ get; set; }

		public System.String SeName{ get; set; }

		public System.String SeKeywords{ get; set; }

		public System.String SeDescription{ get; set; }

		public System.String SeTitle{ get; set; }

		public System.String SeNoScript{ get; set; }

		public System.String SeAltText{ get; set; }

		public System.String SpecTitle{ get; set; }

		public System.Byte IsFeatured{ get; set; }

		public System.Byte RequiresRegistration{ get; set; }

		public System.Int32 Looks{ get; set; }

		public System.String Notes{ get; set; }

		public System.String RelatedCategories{ get; set; }

		public System.String RelatedSections{ get; set; }

		public System.String RelatedManufacturers{ get; set; }

		public System.String RelatedProducts{ get; set; }

		public System.Byte Published{ get; set; }

		public System.Byte Wholesale{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.String ContentsBgColor{ get; set; }

		public System.String PageBgColor{ get; set; }

		public System.String GraphicsColor{ get; set; }

		public System.String ImageFilenameOverride{ get; set; }

		public System.String XmlPackage{ get; set; }

		public System.Byte IsImport{ get; set; }

		public System.Byte Deleted{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		public System.Int32 PageSize{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<DocumentBase> Members

        public virtual bool Equals(DocumentBase other)
        {
			if(this.DocumentId==other.DocumentId  && this.DocumentGuid==other.DocumentGuid  && this.DocumentTypeId==other.DocumentTypeId  && this.Name==other.Name  && this.Summary==other.Summary  && this.Description==other.Description  && this.MiscText==other.MiscText  && this.SeName==other.SeName  && this.SeKeywords==other.SeKeywords  && this.SeDescription==other.SeDescription  && this.SeTitle==other.SeTitle  && this.SeNoScript==other.SeNoScript  && this.SeAltText==other.SeAltText  && this.SpecTitle==other.SpecTitle  && this.IsFeatured==other.IsFeatured  && this.RequiresRegistration==other.RequiresRegistration  && this.Looks==other.Looks  && this.Notes==other.Notes  && this.RelatedCategories==other.RelatedCategories  && this.RelatedSections==other.RelatedSections  && this.RelatedManufacturers==other.RelatedManufacturers  && this.RelatedProducts==other.RelatedProducts  && this.Published==other.Published  && this.Wholesale==other.Wholesale  && this.ExtensionData==other.ExtensionData  && this.ContentsBgColor==other.ContentsBgColor  && this.PageBgColor==other.PageBgColor  && this.GraphicsColor==other.GraphicsColor  && this.ImageFilenameOverride==other.ImageFilenameOverride  && this.XmlPackage==other.XmlPackage  && this.IsImport==other.IsImport  && this.Deleted==other.Deleted  && this.CreatedOn==other.CreatedOn  && this.PageSize==other.PageSize )
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
