using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class FeedBase:EntityBase, IEquatable<FeedBase>
	{
			
		[PrimaryKey]
		public System.Int32 FeedId{ get; set; }

		public System.Guid FeedGuid{ get; set; }

		public System.Int32 StoreId{ get; set; }

		public System.String Name{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.String XmlPackage{ get; set; }

		public System.Byte CanAutoFtp{ get; set; }

		public System.String FtpUsername{ get; set; }

		public System.String FtpPassword{ get; set; }

		public System.String FtpServer{ get; set; }

		public System.Int32? FtpPort{ get; set; }

		public System.String FtpFilename{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<FeedBase> Members

        public virtual bool Equals(FeedBase other)
        {
			if(this.FeedId==other.FeedId  && this.FeedGuid==other.FeedGuid  && this.StoreId==other.StoreId  && this.Name==other.Name  && this.DisplayOrder==other.DisplayOrder  && this.XmlPackage==other.XmlPackage  && this.CanAutoFtp==other.CanAutoFtp  && this.FtpUsername==other.FtpUsername  && this.FtpPassword==other.FtpPassword  && this.FtpServer==other.FtpServer  && this.FtpPort==other.FtpPort  && this.FtpFilename==other.FtpFilename  && this.ExtensionData==other.ExtensionData  && this.CreatedOn==other.CreatedOn )
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
