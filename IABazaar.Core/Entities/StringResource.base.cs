using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class StringResourceBase:EntityBase, IEquatable<StringResourceBase>
	{
			
		[PrimaryKey]
		public System.Int32 StringResourceId{ get; set; }

		public System.Guid StringResourceGuid{ get; set; }

		public System.Int32 StoreId{ get; set; }

		public System.String Name{ get; set; }

		public System.String LocaleSetting{ get; set; }

		public System.String ConfigValue{ get; set; }

		public System.Byte Modified{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<StringResourceBase> Members

        public virtual bool Equals(StringResourceBase other)
        {
			if(this.StringResourceId==other.StringResourceId  && this.StringResourceGuid==other.StringResourceGuid  && this.StoreId==other.StoreId  && this.Name==other.Name  && this.LocaleSetting==other.LocaleSetting  && this.ConfigValue==other.ConfigValue  && this.Modified==other.Modified  && this.CreatedOn==other.CreatedOn )
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
