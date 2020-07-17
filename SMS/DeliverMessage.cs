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
	/// Sms-Deliver
	/// </summary>
	public sealed partial class DeliverMessage : Message
	{
		private readonly Address _CenterAddress;
		private readonly MessageTypeIndication _MessageTypeIndication;
		private readonly MoreMessagesToSend _MoreMessagesToSend;
		private readonly ReplyPath _ReplyPath;
		private readonly DataHeaderIndication _DataHeaderIndication;
		private readonly StatusReportIndication _StatusReportIndication;
		private readonly Address _OriginatingAddress;
		private readonly ProtocolIdentifier _ProtocolIdentifier;
		private readonly DataCodingScheme _DataCodingScheme;
		private readonly ServiceCentreTimeStamp _TimeStamp;
		private DataHeader _DataHeader;
		private byte[] _Data;

		public DeliverMessage(string pdu)
		{
			_CenterAddress = new Address(DataRepresentation.Octet, pdu);
			pdu = pdu.Substring(2 * (_CenterAddress.Length + 1));

			byte h = byte.Parse(pdu.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
			{
				_MessageTypeIndication = (MessageTypeIndication)((0x03) & h);
				_MoreMessagesToSend = (MoreMessagesToSend)((0x04) & h);
				_ReplyPath = (ReplyPath)((0x80) & h);
				_DataHeaderIndication = (DataHeaderIndication)((0x40) & h);
				_StatusReportIndication = (StatusReportIndication)((0x20) & h);
			}

			if (_MessageTypeIndication != MessageTypeIndication.Deliver)
				throw new ArgumentException();

			pdu = pdu.Substring(2);
			_OriginatingAddress = new Address(DataRepresentation.SemiOctet, pdu);
			pdu = pdu.Substring(_OriginatingAddress.Length + 4);

			_ProtocolIdentifier = new ProtocolIdentifier(pdu.Substring(0, 2));
			pdu = pdu.Substring(2);

			_DataCodingScheme = new DataCodingScheme(pdu.Substring(0, 2));
			pdu = pdu.Substring(2);

			_TimeStamp = new ServiceCentreTimeStamp(pdu.Substring(0, 14));
			pdu = pdu.Substring(14);

			//
			// udl (User Data Length) = (Data Length + User Data Header Length + 1)
			byte udl = byte.Parse(pdu.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
			pdu = pdu.Substring(2);

			switch (_DataCodingScheme.MessageCoding)
			{
				case GsmDataCoding.Ascii:
					{
						Process(pdu);
						break;
					}
				case GsmDataCoding.GsmDefault:
					{
						Process(pdu);
						break;
					}
				default:
					{
						throw new NotImplementedException();
					}
			}
		}

		private void Process(string pdu)
		{
			if (_DataHeaderIndication == DataHeaderIndication.Yes)
			{
				_DataHeader = new DataHeader(pdu);
				pdu = pdu.Substring(2 * (_DataHeader.Length + 1));

				if ((pdu.Length % 2) != 0)
					throw new ArgumentException();

				byte[] data = new byte[(pdu.Length / 2)];
				for (int i = 0; i < data.Length; i++)
					data[i] = byte.Parse(pdu.Substring((2 * i), 2), System.Globalization.NumberStyles.HexNumber);

				if (data.Length > 0)
				{
					if (IsConcatenatedMessage)
					{
						_Data = new byte[data.Length];
						for (int i = 0; i < _Data.Length; i++)
							_Data[i] = data[i];
					}
					else
					{
						if (_DataCodingScheme.MessageCoding == GsmDataCoding.Ascii)
						{
							_Data = new byte[data.Length];
							for (int i = 0; i < _Data.Length; i++)
								_Data[i] = data[i];
							return;
						}

						if (_DataCodingScheme.MessageCoding == GsmDataCoding.GsmDefault)
						{
							_Data = DC.BinaryOp.Decode(data, DC.DataCoding.Coding7Bit);
						}
					}
				}
				else
					_Data = new byte[0];
			}
			else
			{
				_DataHeader = new DataHeader();

				if ((pdu.Length % 2) != 0)
					throw new ArgumentException();

				byte[] data = new byte[(pdu.Length / 2)];
				for (int i = 0; i < data.Length; i++)
					data[i] = byte.Parse(pdu.Substring((2 * i), 2), System.Globalization.NumberStyles.HexNumber);

				if (data.Length > 0)
				{
					if (_DataCodingScheme.MessageCoding == GsmDataCoding.Ascii)
					{
						_Data = new byte[data.Length];
						for (int i = 0; i < _Data.Length; i++)
							_Data[i] = data[i];
						return;
					}

					if (_DataCodingScheme.MessageCoding == GsmDataCoding.GsmDefault)
					{
						_Data = DC.BinaryOp.Decode(data, DC.DataCoding.Coding7Bit);
					}
				}
				else
					_Data = new byte[0];
			}
		}

		#region Propertys

		/// <summary>
		/// Center Address (Optional)
		/// </summary>
		public Address CenterAddress
		{
			get { return (_CenterAddress); }
		}

		/// <summary>
		/// Parameter describing the message type (Mandatory)
		/// </summary>
		public MessageTypeIndication MessageTypeIndication
		{
			get { return (_MessageTypeIndication); }
		}

		/// <summary>
		/// Parameter indicating whether or not there are more messages to send (Mandatory)
		/// </summary>
		public MoreMessagesToSend MoreMessagesToSend
		{
			get { return (_MoreMessagesToSend); }
		}

		/// <summary>
		/// Parameter indicating the request for Reply Path (Mandatory)
		/// </summary>
		public ReplyPath ReplyPath
		{
			get { return (_ReplyPath); }
		}

		/// <summary>
		/// Parameter indicating that the TP-UD field contains a Header (Optional)
		/// </summary>
		public DataHeaderIndication DataHeaderIndication
		{
			get { return (_DataHeaderIndication); }
		}

		/// <summary>
		/// Parameter indicating if the MS is requesting a status report (Optional)
		/// </summary>
		public StatusReportIndication StatusReportIndication
		{
			get { return (_StatusReportIndication); }
		}

		/// <summary>
		/// Recipient Address, Destination Address, Address of the destination SME (Mandatory)
		/// </summary>
		public Address OriginatingAddress
		{
			get { return (_OriginatingAddress); }
		}

		/// <summary>
		/// Parameter identifying the above layer protocol, if any. (Mandatory)
		/// </summary>
		public ProtocolIdentifier ProtocolIdentifier
		{
			get { return (_ProtocolIdentifier); }
		}

		/// <summary>
		/// Parameter identifying the coding scheme within the TP-User-Data (Mandatory)
		/// </summary>
		public DataCodingScheme DataCodingScheme
		{
			get { return (_DataCodingScheme); }
		}

		/// <summary>
		/// Parameter identifying time when the SC received the message (Mandatory)
		/// </summary>
		public ServiceCentreTimeStamp ServiceCentreTimeStamp
		{
			get { return (_TimeStamp); }
		}

		/// <summary>
		/// Parameter indicating the length of the TP-User-Data field to follow (Mandatory)
		/// </summary>
		public override int[] Length
		{
			get
			{
				//int[] lengths = new int[1];
				//{
				//     lengths[0] = _Length;
				//}
				//return (lengths);
				throw new NotSupportedException();
			}
		}

		/// <summary>
		/// Dependent on the TP-DCS, (Optional)
		/// If Data Length is greater than 140 byte it should publicly handle concatenated messages.
		/// </summary>
		public override byte[] Data
		{
			get { return (_Data); }
			set { throw new NotSupportedException(); }
		}

		/// <summary>
		///
		/// </summary>
		public bool IsConcatenatedMessage
		{
			get
			{
				if (_DataHeader.Element(InfoElement.ElementIdentifier.ConcatenatedShortMessage) != null)
					return (true);
				
				return (false);
			}
		}

		#endregion

		#region Functions

		/// <summary>
		///
		/// </summary>
		public override string[] ToPDU()
		{
			return (null);
		}

		#endregion
	}
}