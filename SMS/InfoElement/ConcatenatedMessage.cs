/**
 * Copyright (C) Ehsan Haghpanah, 2010.
 * All rights reserved.
 * Ehsan Haghpanah, (github.com/ehsanhaghpanah)
 */

using System;

namespace sirius.GSM.Protocols.SMS.InfoElement
{
	/// <summary>
	/// 
	/// </summary>
	public sealed class ConcatenatedMessage : IInformationElement
	{
		private byte _ReferenceNumber;
		private byte _MaximumNumber;
		private byte _SequenceNumber;

		public ConcatenatedMessage()
		{ 
		}

		public ConcatenatedMessage(string data)
		{
			if (data.Length != 6)
				throw new ArgumentException();

			_ReferenceNumber = byte.Parse(data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
			_MaximumNumber = byte.Parse(data.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
			_SequenceNumber = byte.Parse(data.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
		}

		#region Interface

		/// <summary>
		///
		/// </summary>
		ElementIdentifier IInformationElement.Identifier
		{
			get { return (ElementIdentifier.ConcatenatedShortMessage); }
		}

		/// <summary>
		/// Actual Information Element Data Length
		/// </summary>
		byte IInformationElement.Length
		{
			get { return (0x03); }
		}

		/// <summary>
		/// note:
		/// </summary>
		byte[] IInformationElement.Data
		{
			get
			{
				byte[] data = new byte[3];
				{
					data[0] = _ReferenceNumber;
					data[1] = _MaximumNumber;
					data[2] = _SequenceNumber;
				}
				return (data);
			}
		}

		/// <summary>
		/// note:
		/// </summary>
		string IInformationElement.ToPDU()
		{
			string pdu = string.Empty;
			string len = string.Empty;

			pdu += _ReferenceNumber.ToString("X2");
			pdu += _MaximumNumber.ToString("X2");
			pdu += _SequenceNumber.ToString("X2");

			//
			// Information Element Data Length
			//
			pdu = ((byte)0x03).ToString("X2") + pdu;
			pdu = ((byte)ElementIdentifier.ConcatenatedShortMessage).ToString("X2") + pdu;

			return (pdu);
		}

		#endregion

		#region Propertys

		/// <summary>
		/// Concatenated short message reference number. This octet shall contain a modulo 256 counter 
		/// indicating the reference number for a particular concatenated short message. This reference 
		/// number shall remain constant for every short message which makes up a particular 
		/// concatenated short message.
		/// </summary>
		public byte ReferenceNumber
		{
			get { return (_ReferenceNumber); }
			set
			{
				_ReferenceNumber = value;
			}
		}

		/// <summary>
		/// Maximum number of short messages in the concatenated short message. This octet shall contain 
		/// a value in the range 0 to 255 indicating the total number of short messages within the 
		/// concatenated short message. The value shall start at 1 and remain constant for every short 
		/// message which makes up the concatenated short message. 
		/// </summary>
		public byte MaximumNumber
		{
			get { return (_MaximumNumber); }
			set
			{
				_MaximumNumber = value;
			}
		}

		/// <summary>
		/// Sequence number of the current short message.
		/// This octet shall contain a value in the range 0 to 255 indicating the sequence number of a 
		/// particular short message within the concatenated short message. The value shall start at 1 
		/// and increment by one for every short message sent within the concatenated short message.
		/// </summary>
		public byte SequenceNumber
		{
			get { return (_SequenceNumber); }
			set
			{
				_SequenceNumber = value;
			}
		}

		#endregion
	}
}
