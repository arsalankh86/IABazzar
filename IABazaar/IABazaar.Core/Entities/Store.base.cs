using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class StoreBase:EntityBase, IEquatable<StoreBase>
	{
			
		[PrimaryKey]
		public System.Int32 StoreId{ get; set; }

		public System.Guid StoreGuid{ get; set; }

		public System.String ProductionUri{ get; set; }

		public System.String StagingUri{ get; set; }

		public System.String DevelopmentUri{ get; set; }

		public System.String Name{ get; set; }

		public System.String Summary{ get; set; }

		public System.String Description{ get; set; }

		public System.Byte Published{ get; set; }

		public System.Byte Deleted{ get; set; }

		public System.Int32 SkinId{ get; set; }

		public System.Byte IsDefault{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<StoreBase> Members

        public virtual bool Equals(StoreBase other)
        {
			if(this.StoreId==other.StoreId  && this.StoreGuid==other.StoreGuid  && this.ProductionUri==other.ProductionUri  && this.StagingUri==other.StagingUri  && this.DevelopmentUri==other.DevelopmentUri  && this.Name==other.Name  && this.Summary==other.Summary  && this.Description==other.Description  && this.Published==other.Published  && this.Deleted==other.Deleted  && this.SkinId==other.SkinId  && this.IsDefault==other.IsDefault  && this.CreatedOn==other.CreatedOn )
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
