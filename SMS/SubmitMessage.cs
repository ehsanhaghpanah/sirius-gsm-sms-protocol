/**
 * Copyright (C) Ehsan Haghpanah, 2010.
 * All rights reserved.
 * Ehsan Haghpanah, (github.com/ehsanhaghpanah)
 */

using System;
using DC = sirius.GSM.Coding;

namespace sirius.GSM.Protocols.SMS
{
	/// <summary>
	/// Sms-Submit
	/// </summary>
	public sealed partial class SubmitMessage : Message
	{
		private Address _CenterAddress;
		private MessageTypeIndication _MessageTypeIndication = MessageTypeIndication.Submit;
		private RejectDuplicates _RejectDuplicates = RejectDuplicates.No;
		private ValidityPeriodFormat _ValidityPeriodFormat = ValidityPeriodFormat.Relative;
		private ReplyPath _ReplyPath = ReplyPath.No;
		private DataHeaderIndication _DataHeaderIndication = DataHeaderIndication.No;
		private StatusReportRequest _StatusReportRequest = StatusReportRequest.No;
		private int _MessageReference;
		private Address _DestinationAddress;
		private readonly ProtocolIdentifier _ProtocolIdentifier;
		private readonly DataCodingScheme _DataCodingScheme;
		private readonly ValidityPeriod _ValidityPeriod;
		private readonly DataHeader _DataHeader;
		private byte[] _Data;
		private readonly GsmDataCoding _Coding = GsmDataCoding.Ascii;

		public SubmitMessage(GsmDataCoding coding)
		{
			_Coding = coding;
			if (coding == GsmDataCoding.Ascii)
			{
				_DataHeader = new DataHeader();
				{
					InfoElement.PortAddress elem = new InfoElement.PortAddress(InfoElement.AddressingScheme.TwoOctet)
					{
						SourcePort = 16001,
						TargetPort = 16001
					};
					_DataHeader.Add(elem);
				}
				_DataHeaderIndication = DataHeaderIndication.Yes;
			}
			else
			{
				_DataHeaderIndication = DataHeaderIndication.No;
			}

			_ProtocolIdentifier = new ProtocolIdentifier();
			_DataCodingScheme = new DataCodingScheme(coding);
			_ValidityPeriod = new ValidityPeriod(ValidityPeriodDuration.OneDay);
		}

		#region Propertys

		/// <summary>
		/// Center Address (Optional)
		/// </summary>
		public Address CenterAddress
		{
			get { return (_CenterAddress); }
			set
			{
				_CenterAddress = value;
			}
		}

		/// <summary>
		/// Parameter describing the message type (Mandatory)
		/// </summary>
		public MessageTypeIndication MessageTypeIndication
		{
			get { return (_MessageTypeIndication); }
			set 
			{ 
				_MessageTypeIndication = value; 
			}
		}

		/// <summary>
		/// Parameter indicating whether or not the SC shall accept an SMS-SUBMIT for an SM still held in 
		/// the SC which has the same TP-MR and the same TP-DA as a previously submitted SM from the 
		/// same OA. (Mandatory)
		/// </summary>
		public RejectDuplicates RejectDuplicates
		{
			get { return (_RejectDuplicates); }
			set 
			{ 
				_RejectDuplicates = value; 
			}
		}

		/// <summary>
		/// Parameter indicating whether or not the TP-VP field is present (Mandatory)
		/// </summary>
		public ValidityPeriodFormat ValidityPeriodFormat
		{
			get { return (_ValidityPeriodFormat); }
			set 
			{ 
				_ValidityPeriodFormat = value; 
			}
		}

		/// <summary>
		/// Parameter indicating the request for Reply Path (Mandatory)
		/// </summary>
		public ReplyPath ReplyPath
		{
			get { return (_ReplyPath); }
			set 
			{ 
				_ReplyPath = value; 
			}
		}

		/// <summary>
		/// Parameter indicating that the TP-UD field contains a Header (Optional)
		/// </summary>
		public DataHeaderIndication DataHeaderIndication
		{
			get { return (_DataHeaderIndication); }
			set 
			{ 
				_DataHeaderIndication = value; 
			}
		}

		/// <summary>
		/// Parameter indicating if the MS is requesting a status report (Optional)
		/// </summary>
		public StatusReportRequest StatusReportRequest
		{
			get { return (_StatusReportRequest); }
			set 
			{ 
				_StatusReportRequest = value; 
			}
		}

		/// <summary>
		/// Parameter identifying the SMS-SUBMIT (Mandatory)
		/// </summary>
		public int MessageReference
		{
			get { return (_MessageReference); }
			set 
			{ 
				_MessageReference = value; 
			}
		}

		/// <summary>
		/// Recipient Address, Destination Address, Address of the destination SME (Mandatory)
		/// </summary>
		public Address DestinationAddress
		{
			get { return (_DestinationAddress); }
			set 
			{ 
				_DestinationAddress = value; 
			}
		}

		/// <summary>
		/// Parameter identifying the above layer protocol, if any. (Mandatory)
		/// </summary>
		public ProtocolIdentifier ProtocolIdentifier
		{
			get { return (_ProtocolIdentifier); }
			set 
			{
				throw new NotSupportedException();
			}
		}

		/// <summary>
		/// Parameter identifying the coding scheme within the TP-User-Data (Mandatory)
		/// </summary>
		public DataCodingScheme DataCodingScheme
		{
			get { return (_DataCodingScheme); }
			set
			{
				throw new NotSupportedException();
			}
		}

		/// <summary>
		/// Parameter identifying the time from where the message is no longer valid (Optional)
		/// </summary>
		public ValidityPeriod ValidityPeriod
		{
			get { return (_ValidityPeriod); }
			set
			{
				throw new NotSupportedException();
			}
		}

		/// <summary>
		/// Parameter indicating the length of the TP-User-Data field to follow (Mandatory)
		/// </summary>
		public override int[] Length
		{
			get
			{
				string[] pdus = ToPDU();
				int[] lengths = new int[1];
				{
					lengths[0] = (pdus[0].Length - _CenterAddress.ToPDU().Length) / 2;
					//lengths[0] = (this.ToPDU().Length - _CenterAddress.Length * 2 - 2) / 2;
				}
				return (lengths);
			}
		}

		/// <summary>
		/// Dependent on the TP-DCS (Optional)
		/// If Data Length is greater than 140 byte it should publicly handle concatenated messages.
		/// </summary>
		public override byte[] Data
		{
			get { return (_Data); }
			set { _Data = value; }
		}

		#endregion

		#region Functions

		/// <summary>
		///
		/// </summary>
		public override string[] ToPDU()
		{
			string pdu = string.Empty;
			{
				pdu += _CenterAddress.ToPDU();
				byte args = 0x00;
				{
					args += (byte)_MessageTypeIndication;
					args += (byte)_RejectDuplicates;
					args += (byte)_ValidityPeriodFormat;
				     args += (byte)_ReplyPath;
				     args += (byte)_DataHeaderIndication;
				     args += (byte)_StatusReportRequest;
				}
				pdu += args.ToString("X2");
				pdu += _MessageReference.ToString("X2");
				pdu += _DestinationAddress.ToPDU();
				pdu += _ProtocolIdentifier.ToPDU();
				pdu += _DataCodingScheme.ToPDU();
				pdu += _ValidityPeriod.ToPDU();

				if (_Coding == GsmDataCoding.Ascii)
				{
					pdu += ((byte)(_Data.Length + _DataHeader.Length + 1)).ToString("X2");
					pdu += _DataHeader.ToPDU() + DC.BinaryOp.ToHexString(_Data);
				}
				else
				{
					if (_DataHeaderIndication == DataHeaderIndication.Yes)
					{
						byte[] bytes = DC.BinaryOp.Encode(_Data, DC.DataCoding.Coding7Bit);
						pdu += ((byte)(_Data.Length + 1 + _DataHeader.Length + 1)).ToString("X2");
						pdu += _DataHeader.ToPDU() + DC.BinaryOp.ToHexString(bytes);
					}
					else
					{
						pdu += ((byte)(_Data.Length)).ToString("X2");
						byte[] bytes = DC.BinaryOp.Encode(_Data, DC.DataCoding.Coding7Bit);
						pdu += DC.BinaryOp.ToHexString(bytes);
					}
				}

				pdu = pdu.ToUpper();
			}

			//
			// PDUs
			string[] pdus = new string[1];
			{
				pdus[0] = pdu;
			}
			return (pdus);
		}

		#endregion
	}
}
