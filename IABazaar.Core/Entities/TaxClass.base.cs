using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class TaxClassBase:EntityBase, IEquatable<TaxClassBase>
	{
			
		[PrimaryKey]
		public System.Int32 TaxClassId{ get; set; }

		public System.Guid TaxClassGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.String TaxCode{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<TaxClassBase> Members

        public virtual bool Equals(TaxClassBase other)
        {
			if(this.TaxClassId==other.TaxClassId  && this.TaxClassGuid==other.TaxClassGuid  && this.Name==other.Name  && this.TaxCode==other.TaxCode  && this.DisplayOrder==other.DisplayOrder  && this.CreatedOn==other.CreatedOn )
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
