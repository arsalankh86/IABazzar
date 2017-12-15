using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class CustomReportBase:EntityBase, IEquatable<CustomReportBase>
	{
			
		[PrimaryKey]
		public System.Int32 CustomReportId{ get; set; }

		public System.Guid CustomReportGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.String Description{ get; set; }

		public System.String SqlCommand{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<CustomReportBase> Members

        public virtual bool Equals(CustomReportBase other)
        {
			if(this.CustomReportId==other.CustomReportId  && this.CustomReportGuid==other.CustomReportGuid  && this.Name==other.Name  && this.Description==other.Description  && this.SqlCommand==other.SqlCommand  && this.CreatedOn==other.CreatedOn )
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
