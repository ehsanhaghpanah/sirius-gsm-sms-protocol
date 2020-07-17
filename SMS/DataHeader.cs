/**
 * Copyright (C) Ehsan Haghpanah, 2010.
 * All rights reserved.
 * Ehsan Haghpanah, (github.com/ehsanhaghpanah)
 */

using System;
using System.Collections;

namespace sirius.GSM.Protocols.SMS
{
	/// <summary>
	///
	/// </summary>
	public sealed class DataHeader : IEnumerable
	{
		private readonly ArrayList _ElementCollection;

		public DataHeader()
		{
			_ElementCollection = new ArrayList();
		}

		public DataHeader(string data)
		{
			_ElementCollection = new ArrayList();

			//
			// udhl (User Data Header Length)
			byte udhl = byte.Parse(data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
			data = data.Substring(2, (2 * udhl));

			while (data.Length != 0)
			{
				byte iei = byte.Parse(data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
				data = data.Substring(2);

				switch ((InfoElement.ElementIdentifier)iei)
				{
					case InfoElement.ElementIdentifier.ConcatenatedShortMessage:
						{
							byte ieidl = byte.Parse(data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
							data = data.Substring(2);

							if (data.Length < (2 * ieidl))
								throw new ArgumentException();

							InfoElement.ConcatenatedMessage cm = new InfoElement.ConcatenatedMessage(data.Substring(0, 6));
							Add(cm);
							data = data.Substring((2 * ieidl));

							break;
						}
					case InfoElement.ElementIdentifier.PortAddressing16bitScheme:
						{
							byte ieidl = byte.Parse(data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
							data = data.Substring(2);

							if (data.Length < (2 * ieidl))
								throw new ArgumentException();

							InfoElement.PortAddress pa = new InfoElement.PortAddress(InfoElement.AddressingScheme.TwoOctet, data.Substring(0, 8));
							Add(pa);
							data = data.Substring((2 * ieidl));

							break;
						}
					case InfoElement.ElementIdentifier.PortAddressing8bitScheme:
						{
							byte ieidl = byte.Parse(data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
							data = data.Substring(2);

							if (data.Length < (2 * ieidl))
								throw new ArgumentException();

							InfoElement.PortAddress pa = new InfoElement.PortAddress(InfoElement.AddressingScheme.OneOctet, data.Substring(0, 4));
							Add(pa);
							data = data.Substring((2 * ieidl));

							break;
						}
					default:
						{
							throw new NotSupportedException();
						}
				}
			}
		}

		#region Interface

		IEnumerator IEnumerable.GetEnumerator()
		{
			return (_ElementCollection.GetEnumerator());
		}

		#endregion

		#region Propertys

		/// <summary>
		///
		/// </summary>
		public byte Length
		{
			get
			{
				byte len = 0x00;

				foreach (InfoElement.IInformationElement element in _ElementCollection)
					len += (byte)(element.Length + 2);

				return (len);
			}
		}

		#endregion

		#region Functions

		/// <summary>
		///
		/// </summary>
		public void Add(InfoElement.IInformationElement element)
		{
			_ElementCollection.Add(element);
		}

		/// <summary>
		///
		/// </summary>
		public InfoElement.IInformationElement Element(InfoElement.ElementIdentifier ei)
		{
			foreach (InfoElement.IInformationElement ie in _ElementCollection)
				if (ie.Identifier == ei)
					return (ie);

			return (null);
		}

		/// <summary>
		///
		/// </summary>
		public string ToPDU()
		{
			string pdu = null;
			byte len = 0x00;

			foreach (InfoElement.IInformationElement element in _ElementCollection)
			{
				pdu += element.ToPDU();
				len += (byte)(element.Length + 2);
			}

			return (len.ToString("X2") + pdu);
		}

		#endregion
	}
}