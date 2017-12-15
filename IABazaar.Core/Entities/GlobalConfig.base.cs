using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class GlobalConfigBase:EntityBase, IEquatable<GlobalConfigBase>
	{
			
		[PrimaryKey]
		public System.Int32 GlobalConfigId{ get; set; }

		public System.Guid GlobalConfigGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.String Description{ get; set; }

		public System.String ConfigValue{ get; set; }

		public System.String ValueType{ get; set; }

		public System.String GroupName{ get; set; }

		public System.String EnumValues{ get; set; }

		public System.Byte SuperOnly{ get; set; }

		public System.Boolean Hidden{ get; set; }

		public System.Boolean IsMultiStore{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<GlobalConfigBase> Members

        public virtual bool Equals(GlobalConfigBase other)
        {
			if(this.GlobalConfigId==other.GlobalConfigId  && this.GlobalConfigGuid==other.GlobalConfigGuid  && this.Name==other.Name  && this.Description==other.Description  && this.ConfigValue==other.ConfigValue  && this.ValueType==other.ValueType  && this.GroupName==other.GroupName  && this.EnumValues==other.EnumValues  && this.SuperOnly==other.SuperOnly  && this.Hidden==other.Hidden  && this.IsMultiStore==other.IsMultiStore  && this.CreatedOn==other.CreatedOn )
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
