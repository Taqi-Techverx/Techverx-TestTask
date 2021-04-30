using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Techverx.Test.Project.Dtos.CallBack
{

	// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class Response
	{

		private string resultField;

		private ushort batchCodeField;

		private ResponsePaymentResults paymentResultsField;

		/// <remarks/>
		public string Result
		{
			get
			{
				return this.resultField;
			}
			set
			{
				this.resultField = value;
			}
		}

		/// <remarks/>
		public ushort BatchCode
		{
			get
			{
				return this.batchCodeField;
			}
			set
			{
				this.batchCodeField = value;
			}
		}

		/// <remarks/>
		public ResponsePaymentResults PaymentResults
		{
			get
			{
				return this.paymentResultsField;
			}
			set
			{
				this.paymentResultsField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ResponsePaymentResults
	{

		private ResponsePaymentResultsResult resultField;

		/// <remarks/>
		public ResponsePaymentResultsResult Result
		{
			get
			{
				return this.resultField;
			}
			set
			{
				this.resultField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ResponsePaymentResultsResult
	{

		private string accountNumberField;

		private uint branchCodeField;

		private string firstNameField;

		private string surnameField;

		private string referenceField;

		private byte customerCodeField;

		private string resultField;

		private string resultMessageField;

		private object responseCodeField;

		/// <remarks/>
		public string AccountNumber
		{
			get
			{
				return this.accountNumberField;
			}
			set
			{
				this.accountNumberField = value;
			}
		}

		/// <remarks/>
		public uint BranchCode
		{
			get
			{
				return this.branchCodeField;
			}
			set
			{
				this.branchCodeField = value;
			}
		}

		/// <remarks/>
		public string FirstName
		{
			get
			{
				return this.firstNameField;
			}
			set
			{
				this.firstNameField = value;
			}
		}

		/// <remarks/>
		public string Surname
		{
			get
			{
				return this.surnameField;
			}
			set
			{
				this.surnameField = value;
			}
		}

		/// <remarks/>
		public string Reference
		{
			get
			{
				return this.referenceField;
			}
			set
			{
				this.referenceField = value;
			}
		}

		/// <remarks/>
		public byte CustomerCode
		{
			get
			{
				return this.customerCodeField;
			}
			set
			{
				this.customerCodeField = value;
			}
		}

		/// <remarks/>
		public string Result
		{
			get
			{
				return this.resultField;
			}
			set
			{
				this.resultField = value;
			}
		}

		/// <remarks/>
		public string ResultMessage
		{
			get
			{
				return this.resultMessageField;
			}
			set
			{
				this.resultMessageField = value;
			}
		}

		/// <remarks/>
		public object ResponseCode
		{
			get
			{
				return this.responseCodeField;
			}
			set
			{
				this.responseCodeField = value;
			}
		}
	}


}
