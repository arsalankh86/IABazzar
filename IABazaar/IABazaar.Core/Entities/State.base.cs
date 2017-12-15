using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class StateBase:EntityBase, IEquatable<StateBase>
	{
			
		[PrimaryKey]
		public System.Int32 StateId{ get; set; }

		public System.Guid StateGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.Int32? CountryId{ get; set; }

		public System.String Abbreviation{ get; set; }

		public System.Byte Published{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<StateBase> Members

        public virtual bool Equals(StateBase other)
        {
			if(this.StateId==other.StateId  && this.StateGuid==other.StateGuid  && this.Name==other.Name  && this.CountryId==other.CountryId  && this.Abbreviation==other.Abbreviation  && this.Published==other.Published  && this.DisplayOrder==other.DisplayOrder  && this.ExtensionData==other.ExtensionData  && this.CreatedOn==other.CreatedOn )
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
