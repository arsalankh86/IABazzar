using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class AppConfigBase:EntityBase, IEquatable<AppConfigBase>
	{
			
		[PrimaryKey]
		public System.Int32 AppConfigId{ get; set; }

		public System.Guid AppConfigGuid{ get; set; }

		public System.Int32 StoreId{ get; set; }

		public System.String Name{ get; set; }

		public System.String Description{ get; set; }

		public System.String ConfigValue{ get; set; }

		public System.String ValueType{ get; set; }

		public System.String AllowableValues{ get; set; }

		public System.String GroupName{ get; set; }

		public System.Byte SuperOnly{ get; set; }

		public System.Boolean Hidden{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<AppConfigBase> Members

        public virtual bool Equals(AppConfigBase other)
        {
			if(this.AppConfigId==other.AppConfigId  && this.AppConfigGuid==other.AppConfigGuid  && this.StoreId==other.StoreId  && this.Name==other.Name  && this.Description==other.Description  && this.ConfigValue==other.ConfigValue  && this.ValueType==other.ValueType  && this.AllowableValues==other.AllowableValues  && this.GroupName==other.GroupName  && this.SuperOnly==other.SuperOnly  && this.Hidden==other.Hidden  && this.CreatedOn==other.CreatedOn )
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
