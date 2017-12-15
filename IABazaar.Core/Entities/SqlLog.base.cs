using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class SqlLogBase:EntityBase, IEquatable<SqlLogBase>
	{
			
		[PrimaryKey]
		public System.Int32 SqlLogId{ get; set; }

		public System.String SqlText{ get; set; }

		public System.Int32 ExecutedBy{ get; set; }

		public System.DateTime ExecutedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<SqlLogBase> Members

        public virtual bool Equals(SqlLogBase other)
        {
			if(this.SqlLogId==other.SqlLogId  && this.SqlText==other.SqlText  && this.ExecutedBy==other.ExecutedBy  && this.ExecutedOn==other.ExecutedOn )
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
