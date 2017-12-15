using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class FailedTransactionBase:EntityBase, IEquatable<FailedTransactionBase>
	{
			
		[PrimaryKey]
		public System.Int32 DbRecNo{ get; set; }

		public System.Int32 CustomerId{ get; set; }

		public System.Int32 OrderNumber{ get; set; }

		public System.DateTime OrderDate{ get; set; }

		public System.String PaymentGateway{ get; set; }

		public System.String PaymentMethod{ get; set; }

		public System.String TransactionCommand{ get; set; }

		public System.String TransactionResult{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.String MaxMindDetails{ get; set; }

		public System.String IpAddress{ get; set; }

		public System.Decimal? MaxMindFraudScore{ get; set; }

		public System.String RecurringSubscriptionId{ get; set; }

		public System.Byte CustomerEmailed{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<FailedTransactionBase> Members

        public virtual bool Equals(FailedTransactionBase other)
        {
			if(this.DbRecNo==other.DbRecNo  && this.CustomerId==other.CustomerId  && this.OrderNumber==other.OrderNumber  && this.OrderDate==other.OrderDate  && this.PaymentGateway==other.PaymentGateway  && this.PaymentMethod==other.PaymentMethod  && this.TransactionCommand==other.TransactionCommand  && this.TransactionResult==other.TransactionResult  && this.ExtensionData==other.ExtensionData  && this.MaxMindDetails==other.MaxMindDetails  && this.IpAddress==other.IpAddress  && this.MaxMindFraudScore==other.MaxMindFraudScore  && this.RecurringSubscriptionId==other.RecurringSubscriptionId  && this.CustomerEmailed==other.CustomerEmailed )
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
