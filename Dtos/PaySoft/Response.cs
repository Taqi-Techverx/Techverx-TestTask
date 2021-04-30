

namespace Techverx.Test.Project.Dtos.PaySoft
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


		private uint batchCodeField;

		private decimal batchValueSubmittedField;

		private decimal totalFeeExcludingVATField;

		private ResponseCDVResults cDVResultsField;

		
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

		public string ResultMessage { get;set; }

		/// <remarks/>
		public uint BatchCode
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
		public decimal BatchValueSubmitted
		{
			get
			{
				return this.batchValueSubmittedField;
			}
			set
			{
				this.batchValueSubmittedField = value;
			}
		}

		/// <remarks/>
		public decimal TotalFeeExcludingVAT
		{
			get
			{
				return this.totalFeeExcludingVATField;
			}
			set
			{
				this.totalFeeExcludingVATField = value;
			}
		}

		/// <remarks/>
		public ResponseCDVResults CDVResults
		{
			get
			{
				return this.cDVResultsField;
			}
			set
			{
				this.cDVResultsField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class ResponseCDVResults
	{

		private ResponseCDVResultsResult resultField;

		/// <remarks/>
		public ResponseCDVResultsResult Result
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
	public partial class ResponseCDVResultsResult
	{

		private uint accountNumberField;

		private uint branchCodeField;

		private string customerCodeField;

		private string referenceField;

		private string resultField;

		/// <remarks/>
		public uint AccountNumber
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
		public string CustomerCode
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
	}



}
