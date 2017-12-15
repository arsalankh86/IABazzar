using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class PartnerBase:EntityBase, IEquatable<PartnerBase>
	{
			
		[PrimaryKey]
		public System.Int32 PartnerId{ get; set; }

		public System.Guid PartnerGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.String Summary{ get; set; }

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

		public System.Byte LinkToSite{ get; set; }

		public System.Byte LinkInNewWindow{ get; set; }

		public System.String Specialty{ get; set; }

		public System.String Instructors{ get; set; }

		public System.String Schedule{ get; set; }

		public System.String Testimonials{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.Byte Published{ get; set; }

		public System.Byte Wholesale{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.Byte Deleted{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<PartnerBase> Members

        public virtual bool Equals(PartnerBase other)
        {
			if(this.PartnerId==other.PartnerId  && this.PartnerGuid==other.PartnerGuid  && this.Name==other.Name  && this.Summary==other.Summary  && this.Address1==other.Address1  && this.Address2==other.Address2  && this.Suite==other.Suite  && this.City==other.City  && this.State==other.State  && this.ZipCode==other.ZipCode  && this.Country==other.Country  && this.Phone==other.Phone  && this.Fax==other.Fax  && this.Url==other.Url  && this.Email==other.Email  && this.LinkToSite==other.LinkToSite  && this.LinkInNewWindow==other.LinkInNewWindow  && this.Specialty==other.Specialty  && this.Instructors==other.Instructors  && this.Schedule==other.Schedule  && this.Testimonials==other.Testimonials  && this.DisplayOrder==other.DisplayOrder  && this.Published==other.Published  && this.Wholesale==other.Wholesale  && this.ExtensionData==other.ExtensionData  && this.Deleted==other.Deleted  && this.CreatedOn==other.CreatedOn )
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
