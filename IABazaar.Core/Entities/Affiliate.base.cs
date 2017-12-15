using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class AffiliateBase:EntityBase, IEquatable<AffiliateBase>
	{
			
		[PrimaryKey]
		public System.Int32 AffiliateId{ get; set; }

		public System.Guid AffiliateGuid{ get; set; }

		public System.String Email{ get; set; }

		public System.String Password{ get; set; }

		public System.Int32 SaltKey{ get; set; }

		public System.DateTime? DateOfBirth{ get; set; }

		public System.String Gender{ get; set; }

		public System.String Notes{ get; set; }

		public System.Byte? IsOnline{ get; set; }

		public System.String FirstName{ get; set; }

		public System.String LastName{ get; set; }

		public System.String Name{ get; set; }

		public System.String Company{ get; set; }

		public System.String Address1{ get; set; }

		public System.String Address2{ get; set; }

		public System.String Suite{ get; set; }

		public System.String City{ get; set; }

		public System.String State{ get; set; }

		public System.String Zip{ get; set; }

		public System.String Country{ get; set; }

		public System.String Phone{ get; set; }

		public System.String WebSiteName{ get; set; }

		public System.String WebSiteDescription{ get; set; }

		public System.String Url{ get; set; }

		public System.Byte TrackingOnly{ get; set; }

		public System.Int32 DefaultSkinId{ get; set; }

		public System.Int32 ParentAffiliateId{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.String SeName{ get; set; }

		public System.String SeTitle{ get; set; }

		public System.String SeNoScript{ get; set; }

		public System.String SeAltText{ get; set; }

		public System.String SeKeywords{ get; set; }

		public System.String SeDescription{ get; set; }

		public System.Byte Published{ get; set; }

		public System.Byte Wholesale{ get; set; }

		public System.Byte Deleted{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		public System.Int32 SkinId{ get; set; }

		public System.String TemplateName{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<AffiliateBase> Members

        public virtual bool Equals(AffiliateBase other)
        {
			if(this.AffiliateId==other.AffiliateId  && this.AffiliateGuid==other.AffiliateGuid  && this.Email==other.Email  && this.Password==other.Password  && this.SaltKey==other.SaltKey  && this.DateOfBirth==other.DateOfBirth  && this.Gender==other.Gender  && this.Notes==other.Notes  && this.IsOnline==other.IsOnline  && this.FirstName==other.FirstName  && this.LastName==other.LastName  && this.Name==other.Name  && this.Company==other.Company  && this.Address1==other.Address1  && this.Address2==other.Address2  && this.Suite==other.Suite  && this.City==other.City  && this.State==other.State  && this.Zip==other.Zip  && this.Country==other.Country  && this.Phone==other.Phone  && this.WebSiteName==other.WebSiteName  && this.WebSiteDescription==other.WebSiteDescription  && this.Url==other.Url  && this.TrackingOnly==other.TrackingOnly  && this.DefaultSkinId==other.DefaultSkinId  && this.ParentAffiliateId==other.ParentAffiliateId  && this.DisplayOrder==other.DisplayOrder  && this.ExtensionData==other.ExtensionData  && this.SeName==other.SeName  && this.SeTitle==other.SeTitle  && this.SeNoScript==other.SeNoScript  && this.SeAltText==other.SeAltText  && this.SeKeywords==other.SeKeywords  && this.SeDescription==other.SeDescription  && this.Published==other.Published  && this.Wholesale==other.Wholesale  && this.Deleted==other.Deleted  && this.CreatedOn==other.CreatedOn  && this.SkinId==other.SkinId  && this.TemplateName==other.TemplateName )
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
