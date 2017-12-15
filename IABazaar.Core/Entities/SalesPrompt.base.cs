using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class SalesPromptBase:EntityBase, IEquatable<SalesPromptBase>
	{
			
		[PrimaryKey]
		public System.Int32 SalesPromptId{ get; set; }

		public System.Guid SalesPromptGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.Byte Deleted{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<SalesPromptBase> Members

        public virtual bool Equals(SalesPromptBase other)
        {
			if(this.SalesPromptId==other.SalesPromptId  && this.SalesPromptGuid==other.SalesPromptGuid  && this.Name==other.Name  && this.ExtensionData==other.ExtensionData  && this.Deleted==other.Deleted  && this.CreatedOn==other.CreatedOn )
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
