using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class EntityStoreBase:EntityBase, IEquatable<EntityStoreBase>
	{
			
		public System.Int32 Id{ get; set; }

		public System.Int32 StoreId{ get; set; }

		public System.Int32 EntityId{ get; set; }

		public System.String EntityType{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<EntityStoreBase> Members

        public virtual bool Equals(EntityStoreBase other)
        {
			if(this.Id==other.Id  && this.StoreId==other.StoreId  && this.EntityId==other.EntityId  && this.EntityType==other.EntityType  && this.CreatedOn==other.CreatedOn )
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
