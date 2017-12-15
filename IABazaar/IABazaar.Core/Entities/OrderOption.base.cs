using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class OrderOptionBase:EntityBase, IEquatable<OrderOptionBase>
	{
			
		[PrimaryKey]
		public System.Int32 OrderOptionId{ get; set; }

		public System.Guid OrderOptionGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.String Description{ get; set; }

		public System.Decimal Cost{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.Byte DefaultIsChecked{ get; set; }

		public System.Int32 TaxClassId{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<OrderOptionBase> Members

        public virtual bool Equals(OrderOptionBase other)
        {
			if(this.OrderOptionId==other.OrderOptionId  && this.OrderOptionGuid==other.OrderOptionGuid  && this.Name==other.Name  && this.Description==other.Description  && this.Cost==other.Cost  && this.DisplayOrder==other.DisplayOrder  && this.DefaultIsChecked==other.DefaultIsChecked  && this.TaxClassId==other.TaxClassId  && this.ExtensionData==other.ExtensionData  && this.CreatedOn==other.CreatedOn )
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
