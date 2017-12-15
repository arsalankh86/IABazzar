using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class OrderOptionStoreBase:EntityBase, IEquatable<OrderOptionStoreBase>
	{
			
		public System.Int32 Id{ get; set; }

		public System.Int32 OrderOptionId{ get; set; }

		public System.Int32 StoreId{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<OrderOptionStoreBase> Members

        public virtual bool Equals(OrderOptionStoreBase other)
        {
			if(this.Id==other.Id  && this.OrderOptionId==other.OrderOptionId  && this.StoreId==other.StoreId  && this.CreatedOn==other.CreatedOn )
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
