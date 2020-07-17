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
	public sealed class PortAddress : IInformationElement
	{
		private readonly AddressingScheme _Scheme;
		private ushort _SourcePort;
		private ushort _TargetPort;

		public PortAddress(AddressingScheme scheme)
		{
			_Scheme = scheme;
		}

		public PortAddress(AddressingScheme scheme, string data)
		{
			_Scheme = scheme;

			if (_Scheme == AddressingScheme.OneOctet)
			{
				if (data.Length != 4)
					throw new ArgumentException();

				_TargetPort = ushort.Parse(data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
				_SourcePort = ushort.Parse(data.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
			}
			else
			{
				if (data.Length != 8)
					throw new ArgumentException();

				_TargetPort = ushort.Parse(data.Substring(0, 4), System.Globalization.NumberStyles.HexNumber);
				_SourcePort = ushort.Parse(data.Substring(4, 4), System.Globalization.NumberStyles.HexNumber);
			}
		}

		#region Interface

		/// <summary>
		///
		/// </summary>
		ElementIdentifier IInformationElement.Identifier
		{
			get
			{
				if (_Scheme == AddressingScheme.OneOctet)
					return (ElementIdentifier.PortAddressing8bitScheme);
				
				return (ElementIdentifier.PortAddressing16bitScheme);
			}
		}

		/// <summary>
		///
		/// </summary>
		byte IInformationElement.Length
		{
			get
			{
				if (_Scheme == AddressingScheme.OneOctet)
					return (0x02);
				
				return (0x04);
			}
		}

		/// <summary>
		/// note:
		/// This way of calculating Data may corrupt the actual data. Refer to ToPDU()
		/// </summary>
		byte[] IInformationElement.Data
		{
			get
			{
				byte[] sbytes = BitConverter.GetBytes(_SourcePort);
				byte[] tbytes = BitConverter.GetBytes(_TargetPort);

				if (_Scheme == AddressingScheme.OneOctet)
				{
					byte[] data = new byte[2];
					{
						data[0] = tbytes[0];
						data[1] = sbytes[0];
					}
					return (data);
				}
				else
				{
					byte[] data = new byte[4];
					{
						data[0] = tbytes[0];
						data[1] = tbytes[1];
						data[2] = sbytes[0];
						data[3] = sbytes[1];
					}
					return (data);
				}
			}
		}

		/// <summary>
		/// note:
		/// </summary>
		string IInformationElement.ToPDU()
		{
			string pdu = string.Empty;
			string len = string.Empty;

			//byte[] data = ((IInformationElement)this).Data;
			//for (int i = 0; i < data.Length; i++)
			//     pdu += data[i].ToString("X2");
			//pdu = ((byte)data.Length).ToString("X2") + pdu;

			if (_Scheme == AddressingScheme.OneOctet)
			{
				pdu += ((byte)_TargetPort).ToString("X2");
				pdu += ((byte)_SourcePort).ToString("X2");
				pdu = ((byte)0x02).ToString("X2") + pdu;
				pdu = ((byte)ElementIdentifier.PortAddressing8bitScheme).ToString("X2") + pdu;
			}
			else
			{
				pdu += (_TargetPort).ToString("X4");
				pdu += (_SourcePort).ToString("X4");
				pdu = ((byte)0x04).ToString("X2") + pdu;
				pdu = ((byte)ElementIdentifier.PortAddressing16bitScheme).ToString("X2") + pdu;
			}

			return (pdu);
		}

		#endregion

		#region Propertys

		/// <summary>
		/// Originator Port, These octets contain a number indicating the sending port, i.e. application,
		/// in the sending device.
		/// </summary>
		public ushort SourcePort
		{
			get { return (_SourcePort); }
			set
			{
				_SourcePort = value;
			}
		}

		/// <summary>
		/// Destination Port, These octets contain a number indicating the receiving port, i.e. application,
		/// in the receiving device.
		/// </summary>
		public ushort TargetPort
		{
			get { return (_TargetPort); }
			set
			{
				_TargetPort = value;
			}
		}

		#endregion
	}
}
