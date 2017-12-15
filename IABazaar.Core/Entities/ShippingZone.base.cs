using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class ShippingZoneBase:EntityBase, IEquatable<ShippingZoneBase>
	{
			
		[PrimaryKey]
		public System.Int32 ShippingZoneId{ get; set; }

		public System.Guid ShippingZoneGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.String ZipCodes{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.Byte Deleted{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		public System.Int32? CountryId{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<ShippingZoneBase> Members

        public virtual bool Equals(ShippingZoneBase other)
        {
			if(this.ShippingZoneId==other.ShippingZoneId  && this.ShippingZoneGuid==other.ShippingZoneGuid  && this.Name==other.Name  && this.ZipCodes==other.ZipCodes  && this.DisplayOrder==other.DisplayOrder  && this.ExtensionData==other.ExtensionData  && this.Deleted==other.Deleted  && this.CreatedOn==other.CreatedOn  && this.CountryId==other.CountryId )
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
