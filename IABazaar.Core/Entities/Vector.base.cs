using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class VectorBase:EntityBase, IEquatable<VectorBase>
	{
			
		[PrimaryKey]
		public System.Int32 VectorId{ get; set; }

		public System.Guid VectorGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.String SeName{ get; set; }

		public System.String SeKeywords{ get; set; }

		public System.String SeDescription{ get; set; }

		public System.String SeTitle{ get; set; }

		public System.String SeNoScript{ get; set; }

		public System.String SeAltText{ get; set; }

		public System.String Address1{ get; set; }

		public System.String Address2{ get; set; }

		public System.String Suite{ get; set; }

		public System.String City{ get; set; }

		public System.String State{ get; set; }

		public System.String ZipCode{ get; set; }

		public System.String Country{ get; set; }

		public System.String Phone{ get; set; }

		public System.String Fax{ get; set; }

		public System.String Url{ get; set; }

		public System.String Email{ get; set; }

		public System.String Summary{ get; set; }

		public System.String Description{ get; set; }

		public System.String Notes{ get; set; }

		public System.Int32? QuantityDiscountId{ get; set; }

		public System.Byte SortByLooks{ get; set; }

		public System.String XmlPackage{ get; set; }

		public System.Int32 ColWidth{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.String ContentsBgColor{ get; set; }

		public System.String PageBgColor{ get; set; }

		public System.String GraphicsColor{ get; set; }

		public System.String NotificationXmlPackage{ get; set; }

		public System.String ImageFilenameOverride{ get; set; }

		public System.Int32 ParentVectorId{ get; set; }

		public System.Byte Published{ get; set; }

		public System.Byte Wholesale{ get; set; }

		public System.Byte IsImport{ get; set; }

		public System.Byte Deleted{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		public System.Int32 PageSize{ get; set; }

		public System.Int32 TaxClassId{ get; set; }

		public System.Int32 SkinId{ get; set; }

		public System.String TemplateName{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<VectorBase> Members

        public virtual bool Equals(VectorBase other)
        {
			if(this.VectorId==other.VectorId  && this.VectorGuid==other.VectorGuid  && this.Name==other.Name  && this.SeName==other.SeName  && this.SeKeywords==other.SeKeywords  && this.SeDescription==other.SeDescription  && this.SeTitle==other.SeTitle  && this.SeNoScript==other.SeNoScript  && this.SeAltText==other.SeAltText  && this.Address1==other.Address1  && this.Address2==other.Address2  && this.Suite==other.Suite  && this.City==other.City  && this.State==other.State  && this.ZipCode==other.ZipCode  && this.Country==other.Country  && this.Phone==other.Phone  && this.Fax==other.Fax  && this.Url==other.Url  && this.Email==other.Email  && this.Summary==other.Summary  && this.Description==other.Description  && this.Notes==other.Notes  && this.QuantityDiscountId==other.QuantityDiscountId  && this.SortByLooks==other.SortByLooks  && this.XmlPackage==other.XmlPackage  && this.ColWidth==other.ColWidth  && this.DisplayOrder==other.DisplayOrder  && this.ExtensionData==other.ExtensionData  && this.ContentsBgColor==other.ContentsBgColor  && this.PageBgColor==other.PageBgColor  && this.GraphicsColor==other.GraphicsColor  && this.NotificationXmlPackage==other.NotificationXmlPackage  && this.ImageFilenameOverride==other.ImageFilenameOverride  && this.ParentVectorId==other.ParentVectorId  && this.Published==other.Published  && this.Wholesale==other.Wholesale  && this.IsImport==other.IsImport  && this.Deleted==other.Deleted  && this.CreatedOn==other.CreatedOn  && this.PageSize==other.PageSize  && this.TaxClassId==other.TaxClassId  && this.SkinId==other.SkinId  && this.TemplateName==other.TemplateName )
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
